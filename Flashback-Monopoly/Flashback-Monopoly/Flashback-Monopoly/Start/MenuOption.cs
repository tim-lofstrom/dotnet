using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Flashback_Monopoly
{
    class MenuOption
    {
        SpriteBatch spriteBatch;
        SpriteFont spriteFont;

        public Vector2 imgPosition;
        Vector2 txtPosition;

        Texture2D optionTexture;

        Color normal = Color.FromNonPremultiplied(76, 76, 76, 255);
        Color hilite = Color.FromNonPremultiplied(0, 0, 0, 255);
        Color state;

        public string item = "";

        public float textureWidth = 0f;
        public float textureHeight = 0f;

        float txtWidth = 0f;
        float txtHeight = 0f;

        float windowWidth = 0f;
        float windowHeight = 0f;

        public Rectangle getBounds()
        {
            Rectangle rutaBounds = new Rectangle((int)imgPosition.X, (int)imgPosition.Y, (int)textureWidth, (int)textureHeight);
            return rutaBounds;
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

        public void Measure(int i)
        {
            imgPosition = new Vector2(((windowWidth - textureWidth) / 2), (i * (textureHeight + 10)) + 10);

            Vector2 size = spriteFont.MeasureString(item);
            txtWidth = size.X;

            txtPosition = imgPosition;
            txtPosition.X += (optionTexture.Width - txtWidth) / 2;
            txtPosition.Y += (optionTexture.Height - txtHeight) / 2;
        }

        public void LoadContent(SpriteBatch spriteBatch, SpriteFont spriteFont, Texture2D option, String item, int width, int height)
        {
            this.spriteBatch = spriteBatch;
            this.spriteFont = spriteFont;
            this.item = item;
            this.optionTexture = option;
            state = normal;

            Vector2 size = spriteFont.MeasureString(item);
            txtWidth = size.X;
            txtHeight = spriteFont.LineSpacing;

            textureWidth = optionTexture.Width;
            textureHeight = optionTexture.Height;

            windowWidth = width;
            windowHeight = height;
        }

        public void Draw()
        {
            spriteBatch.Draw(optionTexture, imgPosition, Color.White);
            spriteBatch.DrawString(spriteFont, item, txtPosition, state);
        }
    }
}
