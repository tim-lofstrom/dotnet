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
    public class Button : Microsoft.Xna.Framework.DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        SpriteFont spriteFont;
        ContentManager contentManager;

        public Vector2 imgPosition;
        Vector2 txtPosition;

        Texture2D optionTexture;

        public float textureWidth = 0f;
        public float textureHeight = 0f;
        float txtWidth = 0f;
        float txtHeight = 0f;

        public int m_Speed = 1000;

        public string item;
        int Y = 0;
        Color normal = Color.FromNonPremultiplied(76, 76, 76, 255);
        //Color hilite = Color.FromNonPremultiplied(0, 0, 0, 255);
        Color hilite = Color.White;
        Color state;


        public Button(Game game, SpriteBatch spriteBatch, SpriteFont spriteFont, ContentManager contentManager, string i, int y)
            : base(game)
        {
            // TODO: Construct any child components here

            this.spriteBatch = spriteBatch;
            this.spriteFont = contentManager.Load<SpriteFont>("fonts/font");
            this.contentManager = contentManager;

            this.Y = y;

            this.item = i;
            this.state = normal;
            optionTexture = contentManager.Load<Texture2D>("img/button");

            textureWidth = optionTexture.Width;
            textureHeight = optionTexture.Height;

            Measure();
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

        public Rectangle getBounds()
        {
            Rectangle rutaBounds = new Rectangle((int)imgPosition.X, (int)imgPosition.Y, (int)optionTexture.Width, (int)optionTexture.Height);
            return rutaBounds;
        }

        public void Measure()
        {
            //imgPosition = new Vector2(((windowWidth - textureWidth) / 2), (i * (textureHeight + 10)) + 10);

            imgPosition = new Vector2(((Game.Window.ClientBounds.Width - optionTexture.Width) / 2), optionTexture.Height + Y);

            Vector2 size = spriteFont.MeasureString(item);
            txtWidth = size.X;

            txtPosition = imgPosition;
            txtPosition.X += (optionTexture.Width - txtWidth) / 2;
            txtPosition.Y += (optionTexture.Height - spriteFont.LineSpacing) / 2;
        }

        public void Hilite(Boolean hilite)
        {
            if (hilite == true)
            {
                this.state = this.hilite;
            }
            else
            {
                this.state = this.normal;
            }
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            spriteBatch.Draw(optionTexture, imgPosition, Color.White);
            spriteBatch.DrawString(spriteFont, item, txtPosition, state);

        }
    }
}
