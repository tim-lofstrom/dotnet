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
    class StartScreen : GameScreen
    {
        MenuComponent menuComponent;

        Texture2D background;

        Rectangle background_rectangle;

        public StartScreen(Game game, SpriteBatch spriteBatch, SpriteFont spriteFont, ContentManager contentManager) : base(game, spriteBatch, spriteFont, contentManager)
        {
            string[] menuItems = {"Singleplayer", "Multiplayer", "Options", "End Game" };

            menuComponent = new MenuComponent(game, spriteBatch, spriteFont, contentManager.Load<Texture2D>("img/menu_option"), menuItems);

            Components.Add(menuComponent);

            this.background = contentManager.Load<Texture2D>("img/menu_background");
            this.background_rectangle = new Rectangle(0, 0, Game.Window.ClientBounds.Width, Game.Window.ClientBounds.Height);

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
            spriteBatch.Draw(background, background_rectangle, Color.White);
            base.Draw(gameTime);
        }
    }
}
