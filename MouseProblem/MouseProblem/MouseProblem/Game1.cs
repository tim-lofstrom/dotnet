using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace MouseProblem
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont spriteFont;

        MouseState currentMouseState;
        MouseState oldMouseState;

        double oldGameTime;
        int time = 0;
        int count = 0;
        double total = 0;
        double runs = 0;

        bool run = false;

        Texture2D background;
        Texture2D spike;
        Rectangle background_rectangle;

        List<Chamber> chambers = new List<Chamber>();
        theMouse mouse;
        Button button;
        Button speed;

        Random random;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width - 100;
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height - 150;

            graphics.IsFullScreen = false;
            graphics.ApplyChanges();

            this.IsMouseVisible = true;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            random = new Random();

            this.spike = Content.Load<Texture2D>("img/spikes");
            this.background = Content.Load<Texture2D>("img/background");
            this.background_rectangle = new Rectangle(0, 0, this.Window.ClientBounds.Width, this.Window.ClientBounds.Height);

            Vector2 chamberPosition = new Vector2(10, 300);

            chambers.Add(new Chamber(this, spriteBatch, spriteFont, Content, chamberPosition, 0));
            chamberPosition.X += chambers[0].getWidth();
            chambers.Add(new Chamber(this, spriteBatch, spriteFont, Content, chamberPosition, 1));
            chamberPosition.X += chambers[1].getWidth();
            chambers.Add(new Chamber(this, spriteBatch, spriteFont, Content, chamberPosition, 2));
            chamberPosition.X += chambers[2].getWidth();
            chambers.Add(new Chamber(this, spriteBatch, spriteFont, Content, chamberPosition, 3));
            chamberPosition.X += chambers[3].getWidth();
            chambers.Add(new Chamber(this, spriteBatch, spriteFont, Content, chamberPosition, 4));
            chamberPosition.X += chambers[4].getWidth();
            chambers.Add(new Chamber(this, spriteBatch, spriteFont, Content, chamberPosition, 5));
            chamberPosition.X += chambers[5].getWidth();
            chambers.Add(new Chamber(this, spriteBatch, spriteFont, Content, chamberPosition, 6));

            Vector2 mousePosition = chambers[3].getPos();
            mouse = new theMouse(this, spriteBatch, spriteFont, Content, mousePosition);

            button = new Button(this, spriteBatch, spriteFont, Content, "Starta", 20);
            speed = new Button(this, spriteBatch, spriteFont, Content, "Uppdateringsintervall: 1000ms", 70);

            spriteFont = Content.Load<SpriteFont>("fonts/font");

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            currentMouseState = Mouse.GetState();

            Rectangle mouseBounds = new Rectangle(currentMouseState.X, currentMouseState.Y, 0, 0);

            if (mouseBounds.Intersects(button.getBounds()))
            {
                button.Hilite(true);
                if ((currentMouseState.LeftButton == ButtonState.Pressed) && (oldMouseState.LeftButton == ButtonState.Released))
                {
                    run = !run;
                    if (run) button.item = "Stoppa";
                    else button.item = "Starta";
                    oldMouseState = currentMouseState;
                }
            }
            else
            {
                button.Hilite(false);
            }

            if (mouseBounds.Intersects(speed.getBounds()))
            {
                speed.Hilite(true);
                if ((currentMouseState.LeftButton == ButtonState.Pressed) && (oldMouseState.LeftButton == ButtonState.Released))
                {
                    if (speed.m_Speed > 50) speed.m_Speed -= 50;
                    speed.item = "Uppdateringsintervall: " + speed.m_Speed + "ms";
                    oldMouseState = currentMouseState;
                }
                if ((currentMouseState.RightButton == ButtonState.Pressed) && (oldMouseState.RightButton == ButtonState.Released))
                {
                    if (speed.m_Speed < 1000) speed.m_Speed += 50;

                    speed.item = "Uppdateringsintervall: " + speed.m_Speed + "ms";
                    oldMouseState = currentMouseState;
                }
            }
            else
            {
                speed.Hilite(false);
            }

            if ((gameTime.TotalGameTime.TotalMilliseconds - oldGameTime > speed.m_Speed) && (run == true))
            {
                time++;

                if (mouse.isAlive() == true)
                {
                    int dir = random.Next(2);

                    count++;

                    if (dir == 0)
                    {
                        mouse.changeChamber(chambers[mouse.getLoc() - 1].getPos(), (mouse.getLoc() - 1));
                    }
                    else if (dir == 1)
                    {
                        mouse.changeChamber(chambers[mouse.getLoc() + 1].getPos(), (mouse.getLoc() + 1));
                    }
                    if (mouse.getLoc() == 0 || mouse.getLoc() == 6)
                    {
                        mouse.isAlive(false);
                        mouse.deaths++;
                        total += count;
                        if (count > mouse.longest)
                        {
                            mouse.longest = count;
                        }
                        count = 0;
                    }
                }
                else
                {
                    runs++;
                    mouse.isAlive(true);
                    mouse.changeChamber(chambers[3].getPos(), 3);
                }

                oldGameTime = gameTime.TotalGameTime.TotalMilliseconds;
            }


            oldMouseState = currentMouseState;

            base.Update(gameTime);

        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, null, null);

            spriteBatch.Draw(background, background_rectangle, Color.White);

            //spriteBatch.DrawString(spriteFont, time.ToString(), new Vector2(10, 10), Color.Green);

            spriteBatch.DrawString(spriteFont, "Medellivsslangd " + (total/runs).ToString(), new Vector2(10, 50), Color.White);
            spriteBatch.DrawString(spriteFont, "Dodsfall " + mouse.deaths.ToString(), new Vector2(10, 70), Color.White);
            spriteBatch.DrawString(spriteFont, "Langst overlevnad " + mouse.longest.ToString(), new Vector2(10, 90), Color.White);
            spriteBatch.DrawString(spriteFont, "Korningar " + runs.ToString(), new Vector2(10, 120), Color.White);



            for (int i = 0; i < chambers.Count(); i++)
            {
                chambers[i].Draw(gameTime);
                //spriteBatch.DrawString(spriteFont, "X: " + chambers[i].getPos().X + "Y: " + chambers[i].getPos().Y, chambers[i].getPos(), Color.White);
            }

            
            Vector2 temp1 = chambers[0].getPos();
            temp1.Y += 100;
            spriteBatch.Draw(spike, temp1, Color.White);


            Vector2 temp2 = chambers[6].getPos();
            temp2.Y += 100;
            spriteBatch.Draw(spike, temp2, Color.White);

            mouse.Draw(gameTime);

            //spriteBatch.DrawString(spriteFont, "X: " + mouse.getPos().X + "Y: " + mouse.getPos().Y, new Vector2(500, 10) , Color.White);

            button.Draw(gameTime);

            speed.Draw(gameTime);

            
            base.Draw(gameTime);

            spriteBatch.End();
        }
    }
}
