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
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class MenuComponent : Microsoft.Xna.Framework.DrawableGameComponent
    {

        List<MenuOption> menuOption = new List<MenuOption>();

        public MenuComponent(Game game, SpriteBatch spriteBatch, SpriteFont spriteFont, Texture2D option, string[] menuItems) : base(game)
        {

            for (int i = 0; i < menuItems.Length; i++)
            {
                menuOption.Add(new MenuOption());

                menuOption[i].LoadContent(spriteBatch,
                    spriteFont,
                    option,
                    menuItems[i],
                    Game.Window.ClientBounds.Width,
                    Game.Window.ClientBounds.Height);

                menuOption[i].Measure(i);
            }
        }

        public Rectangle getBounds(int i)
        {
            return menuOption[i].getBounds();
        }

        public int getOptions()
        {
            return menuOption.Count;
        }

        public string getItem(int i)
        {
            return menuOption[i].item;
        }

        public void setItem(int i, String s)
        {
            menuOption[i].item = s;
        }

        public void Hilite(int option, Boolean hilite)
        {
            menuOption[option].Hilite(hilite);
        }

        public void Measure(int i)
        {
            menuOption[i].Measure(i);
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
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {

            base.Draw(gameTime);

            for (int i = 0; i < menuOption.Count; i++)
            {
                menuOption[i].Draw();
            }

        }
    }
}