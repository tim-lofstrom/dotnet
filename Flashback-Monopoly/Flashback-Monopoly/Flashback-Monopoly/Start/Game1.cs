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

namespace Flashback_Monopoly
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

        KeyboardState currentKeyboardState;
        KeyboardState oldKeyboardState;

        GameScreen activeScreen;
        StartScreen startScreen;
        SingleplayerScreen singleplayerScreen;
        MultiplayerScreen multiplayerScreen;
        OptionScreen optionScreen;

        bool fullScreen;
        List<int[]> resolutions = new List<int[]>();
        int[] currentResolution = new int[3];
        int currentRes;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        public Boolean changeResolution(int[] res, bool full)
        {
            if ((res[0] <= GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width) && (res[1] <= GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height))
            {
                
                graphics.PreferredBackBufferWidth = res[0];
                graphics.PreferredBackBufferHeight = res[1];
   
                graphics.IsFullScreen = full;
                graphics.ApplyChanges();

                currentResolution = res;
                currentRes = currentResolution[2];
                fullScreen = full;
                return true;
            }

            return false;
        }

        public void initializeResolution()
        {
            changeResolution(resolutions[0], false);
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


            for (int i = 0; i < 6; i++)
            {
                double newRes = 1 + (double)i / 5;
                resolutions.Add(new int[] { (int)((double)GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / newRes), (int)((double)GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / newRes), i });
            }

            this.IsMouseVisible = true;
            fullScreen = false;
            if (!changeResolution(resolutions[0], false))
            {
                changeResolution(resolutions[2], false);
            }

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
            spriteFont = Content.Load<SpriteFont>("fonts/menufont");

            startScreen = new StartScreen(this, spriteBatch, spriteFont, Content);
            Components.Add(startScreen);
            startScreen.Hide();

            singleplayerScreen = new SingleplayerScreen(this, spriteBatch, spriteFont, Content);
            Components.Add(singleplayerScreen);
            singleplayerScreen.Hide();

            multiplayerScreen = new MultiplayerScreen(this, spriteBatch, spriteFont, Content);
            Components.Add(multiplayerScreen);
            multiplayerScreen.Hide();

            optionScreen = new OptionScreen(this, spriteBatch, spriteFont, Content, resolutions[currentRes], fullScreen);
            Components.Add(optionScreen);
            optionScreen.Hide();

            activeScreen = startScreen;
            activeScreen.Show();


        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here

            Components.Remove(startScreen);
            startScreen = null;

            Components.Remove(singleplayerScreen);
            singleplayerScreen = null;

            Components.Remove(multiplayerScreen);
            multiplayerScreen = null;

            Components.Remove(optionScreen);
            optionScreen = null;

            spriteBatch = null;
            spriteFont = null;
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            currentMouseState = Mouse.GetState();
            currentKeyboardState = Keyboard.GetState();

            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            if ((activeScreen == singleplayerScreen) || (activeScreen == multiplayerScreen) || (activeScreen == optionScreen))
            {
                if ((currentKeyboardState.IsKeyDown(Keys.Escape)) && (oldKeyboardState.IsKeyUp(Keys.Escape)))
                {
                    activeScreen.Hide();
                    activeScreen = startScreen;
                    activeScreen.Show();

                    UnloadContent();
                    LoadContent();
                }
            }

            if (activeScreen == startScreen)
            {
                for (int i = 0; i < startScreen.getOptions(); i++)
                {
                    Rectangle mouseBounds = new Rectangle(currentMouseState.X, currentMouseState.Y, 0, 0);

                    if (mouseBounds.Intersects(startScreen.getBounds(i)))
                    {
                        startScreen.Hilite(i, true);

                        if ((currentMouseState.LeftButton == ButtonState.Pressed) && (oldMouseState.LeftButton == ButtonState.Released))
                        {

                            switch (startScreen.getItem(i))
                            {
                                case "Singleplayer":
                                    activeScreen.Hide();
                                    activeScreen = singleplayerScreen;
                                    activeScreen.Show();
                                    break;
                                case "Multiplayer":
                                    activeScreen.Hide();
                                    activeScreen = multiplayerScreen;
                                    activeScreen.Show();
                                    break;
                                case "Options":
                                    activeScreen.Hide();
                                    activeScreen = optionScreen;
                                    activeScreen.Show();
                                    break;
                                case "End Game":
                                    this.Exit();
                                    break;
                                default:
                                    break;
                            }

                            oldMouseState = currentMouseState;
                        }
                    }
                    else
                    {
                        startScreen.Hilite(i, false);
                    }
                }
            }

            if (activeScreen == optionScreen)
            {
                for (int i = 0; i < optionScreen.getOptions(); i++)
                {
                    Rectangle mouseBounds = new Rectangle(currentMouseState.X, currentMouseState.Y, 0, 0);

                    if (mouseBounds.Intersects(optionScreen.getBounds(i)))
                    {
                        optionScreen.Hilite(i, true);

                        if ((currentMouseState.LeftButton == ButtonState.Pressed) && (oldMouseState.LeftButton == ButtonState.Released))
                        {
                            string[] arr = optionScreen.getItem(i).Split();
                            switch (arr[0])
                            {
                                case "Resolution":
                                    currentRes--;
                                    if (currentRes < 0)
                                    {
                                        currentRes = resolutions.Count - 1;
                                    }
                                    optionScreen.setItem(0, "Resolution [" + resolutions[currentRes][0] + " x " + resolutions[currentRes][1] + "]");
                                    break;
                                case "Fullscreen":
                                    if (fullScreen == true)
                                    {
                                        fullScreen = false;
                                        optionScreen.setItem(1, "Fullscreen [" + fullScreen + "]");
                                    }
                                    else
                                    {
                                        fullScreen = true;
                                        optionScreen.setItem(1, "Fullscreen [" + fullScreen + "]");
                                    }

                                    break;
                                case "Apply":
                                    changeResolution(resolutions[currentRes], fullScreen);
                                    UnloadContent();
                                    LoadContent();
                                    break;
                                default:
                                    break;
                            }
                            oldMouseState = currentMouseState;
                        }

                        if ((currentMouseState.RightButton == ButtonState.Pressed) && (oldMouseState.RightButton == ButtonState.Released))
                        {
                            string[] arr = optionScreen.getItem(i).Split();
                            switch (arr[0])
                            {
                                case "Resolution":
                                    currentRes++;
                                    if (currentRes >= resolutions.Count)
                                    {
                                        currentRes = 0;
                                    }
                                    optionScreen.setItem(0, "Resolution [" + resolutions[currentRes][0] + " x " + resolutions[currentRes][1] + "]");
                                    break;
                                default:
                                    break;
                            }
                            oldMouseState = currentMouseState;
                        }

                    }
                    else
                    {
                        optionScreen.Hilite(i, false);
                    }
                }
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

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, null, null);

            base.Draw(gameTime);

            spriteBatch.End();
        }
    }
}
