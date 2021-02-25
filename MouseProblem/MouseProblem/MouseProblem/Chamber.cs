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
    public class Chamber : Microsoft.Xna.Framework.DrawableGameComponent
    {

        Texture2D chamberTexture;
        Vector2 chamberPos;

        int chamberNum;

        SpriteBatch spriteBatch;
        SpriteFont spriteFont;
        ContentManager contentManager;


        public Chamber(Game game, SpriteBatch spriteBatch, SpriteFont spriteFont, ContentManager contentManager, Vector2 pos, int num)
            : base(game)
        {
            // TODO: Construct any child components here

            this.spriteBatch = spriteBatch;
            this.spriteFont = spriteFont;
            this.contentManager = contentManager;

            this.chamberPos = pos;
            this.chamberNum = num;

            chamberTexture = contentManager.Load<Texture2D>("img/pelare");


        }

        public int getWidth()
        {
            return chamberTexture.Width;
        }

        public int getHeight()
        {
            return chamberTexture.Height;
        }

        public Vector2 getPos()
        {
            return chamberPos;
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

            spriteBatch.Draw(chamberTexture, chamberPos, Color.White);
            

        }
    }
}
