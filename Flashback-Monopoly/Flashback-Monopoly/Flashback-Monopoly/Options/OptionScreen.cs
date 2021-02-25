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
    class OptionScreen : GameScreen
    {
        MenuComponent menuComponent;

        Texture2D image;
        Rectangle imageRectangle;

        public OptionScreen(Game game, SpriteBatch spriteBatch, SpriteFont spriteFont, ContentManager contentManager, int[] res, bool full)
            : base(game, spriteBatch, spriteFont, contentManager)
        {
            string[] menuItems = { "Resolution [" + res[0] + " x " + res[1] + "]", "Fullscreen [" + full + "]", "Apply" };

            menuComponent = new MenuComponent(game, spriteBatch, spriteFont, contentManager.Load<Texture2D>("img/menu_option"), menuItems);

            Components.Add(menuComponent);

            this.image = contentManager.Load<Texture2D>("img/menu_background");
            imageRectangle = new Rectangle(
                0,
                0,
                Game.Window.ClientBounds.Width,
                Game.Window.ClientBounds.Height);
        }

        public Rectangle getBounds(int i)
        {
            return menuComponent.getBounds(i);
        }

        public int getOptions()
        {
            return menuComponent.getOptions();
        }

        public string getItem(int i)
        {
            return menuComponent.getItem(i);
        }

        public void setItem(int i, String s)
        {
            menuComponent.setItem(i, s);
        }

        public void Hilite(int option, Boolean hilite)
        {
            menuComponent.Hilite(option, hilite);
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