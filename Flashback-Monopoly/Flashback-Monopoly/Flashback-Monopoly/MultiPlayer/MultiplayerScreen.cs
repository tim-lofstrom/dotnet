using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Flashback_Monopoly
{
    class MultiplayerScreen : GameScreen
    {
        Texture2D image;
        Rectangle imageRectangle;

        public MultiplayerScreen(Game game, SpriteBatch spriteBatch, SpriteFont spriteFont, ContentManager contentManager) : base(game, spriteBatch, spriteFont, contentManager)
        {
            this.image = contentManager.Load<Texture2D>("img/game_background");
            imageRectangle = new Rectangle(
                0,
                0,
                Game.Window.ClientBounds.Width,
                Game.Window.ClientBounds.Height);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(image, imageRectangle, Color.White);
            base.Draw(gameTime);
        }
    }
}
