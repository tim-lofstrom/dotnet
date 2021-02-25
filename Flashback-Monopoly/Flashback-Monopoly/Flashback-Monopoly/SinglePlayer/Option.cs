using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Flashback_Monopoly
{
    class Option
    {
        SpriteBatch spriteBatch;
        SpriteFont spriteFont;

        Vector2 sqrPosition;
        Vector2 txtPosition;
        Texture2D sqrTexture;

        Color normal = Color.FromNonPremultiplied(76, 76, 76, 255);
        Color hilite = Color.FromNonPremultiplied(0, 0, 0, 255);
        Color state;

        string option;


        public Option(SpriteBatch spriteBatch, SpriteFont spriteFont, Vector2 sqrPosition, Texture2D sqrTexture, string option)
        {
            this.spriteBatch = spriteBatch;
            this.spriteFont = spriteFont;
            this.sqrPosition = sqrPosition;
            this.sqrTexture = sqrTexture;
            this.option = option;

            state = normal;

            txtPosition = sqrPosition;

            txtPosition.X += 5;
            txtPosition.Y += 2;

        }

        public Rectangle getBounds()
        {
            Rectangle rutaBounds = new Rectangle((int)sqrPosition.X, (int)sqrPosition.Y, (int)sqrTexture.Width, (int)sqrTexture.Height);
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

        public void Draw()
        {
            spriteBatch.Draw(sqrTexture, sqrPosition, Color.White);
            spriteBatch.DrawString(spriteFont, option, txtPosition, state);
        }
    }
}
