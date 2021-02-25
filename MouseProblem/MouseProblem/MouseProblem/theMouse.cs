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
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class theMouse : Microsoft.Xna.Framework.DrawableGameComponent
    {

        Texture2D mouseTexture;
        Vector2 mousePos;

        public int deaths = 0;
        public int longest = 0;
        int location;
        bool alive;

        Color color;

        SpriteBatch spriteBatch;
        SpriteFont spriteFont;
        ContentManager contentManager;

        public theMouse(Game game, SpriteBatch spriteBatch, SpriteFont spriteFont, ContentManager contentManager, Vector2 pos)
            : base(game)
        {
            // TODO: Construct any child components here

            this.spriteBatch = spriteBatch;
            this.spriteFont = spriteFont;
            this.contentManager = contentManager;

            this.mousePos = pos;

            //mousePos = new Vector2(450, 350);

            color = Color.White;
            alive = true;
            location = 3;

            mouseTexture = contentManager.Load<Texture2D>("img/rat");
        }

        public void changeChamber(Vector2 pos, int loc)
        {
            this.mousePos = pos;
            this.location = loc;
        }

        public bool isAlive()
        {
            return alive;
        }

        public void isAlive(bool a)
        {
            alive = a;
            if (alive == false)
            {
                color = Color.Red;
            }
            else if (alive == true)
            {
                color = Color.White;
            }
        }

        public int getLoc()
        {
            return location;
        }

        public Vector2 getPos()
        {
            return mousePos;
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            //spriteBatch.Draw(mouseTexture, mousePos, Color.White);

            spriteBatch.Draw(mouseTexture, mousePos, color);

        }
    }
}
