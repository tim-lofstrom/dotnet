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
    class ControlPanel : Microsoft.Xna.Framework.DrawableGameComponent
    {
        List<Option> option = new List<Option>();

        SpriteBatch spriteBatch;
        SpriteFont spriteFont;

        Texture2D buttonTexture;
        Texture2D panelTexture;

        Vector2 panelPosition;
        Vector2 optionPosition;

        public ControlPanel(Game game, SpriteBatch spriteBatch, SpriteFont spriteFont, ContentManager contentManager, Vector2 gamePlanPosition, Texture2D gamePlanSize) : base(game)
        {
            buttonTexture = contentManager.Load<Texture2D>("img/control_choise");
            panelTexture = contentManager.Load<Texture2D>("img/control_panel");

            this.spriteBatch = spriteBatch;
            this.spriteFont = spriteFont;

            this.panelPosition = gamePlanPosition;
            this.panelPosition.X += (gamePlanSize.Width - panelTexture.Width) / 2;
            this.panelPosition.Y = Game.Window.ClientBounds.Height - panelTexture.Height;

            optionPosition = panelPosition;
            optionPosition.X += 5;
            optionPosition.Y += 5;

            option.Add(new Option(spriteBatch, spriteFont, optionPosition, buttonTexture, "Roll"));

            optionPosition.X += buttonTexture.Width;
            option.Add(new Option(spriteBatch, spriteFont, optionPosition, buttonTexture, "Buy"));
        }

        public Rectangle getBounds(int i)
        {
            return option[i].getBounds();
        }

        public void Hilite(int i, Boolean hilite)
        {
            option[i].Hilite(hilite);
        }

        public int getOptions()
        {
            return option.Count;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Update(gameTime);

            spriteBatch.Draw(panelTexture, panelPosition, Color.White);

            for (int i = 0; i < option.Count; i++)
            {
                option[i].Draw();
            }
        }
    }
}
