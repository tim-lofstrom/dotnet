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
    class Player : Microsoft.Xna.Framework.DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        SpriteFont spriteFont;
      //  PlayerPanel playerPanel;

        public Texture2D playerChecker;

        public Vector2 playerPosition;
        public int playerLocation = 0;

        float scale;

        public int balance = 0;

        public string playerNick = "default_player";
        bool bot = false;

        public Player(Game game, SpriteBatch spriteBatch, SpriteFont spriteFont, ContentManager contentManager, string nick, string checker, bool bot, int balance, int gameWidth, int gameHeight, int gamePlanHeight)
            : base(game) 
        {
            this.spriteBatch = spriteBatch;
            this.spriteFont = spriteFont;
            this.playerNick = nick;
            this.balance = balance;
            this.bot = bot;
            this.playerChecker = contentManager.Load<Texture2D>(checker);

           // playerPanel = new PlayerPanel(game, spriteBatch, spriteFont, contentManager);

            this.scale = ((float)(gameHeight - ((float)0.18 * (float)gameHeight)) / (float)(gamePlanHeight + 1));
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            //playerPanel.balance = this.balance;
            //playerPanel.playerPos = this.playerLocation;
        }

        public string getNick()
        {
            return playerNick;
        }

        public override void Draw(GameTime gameTime)
        {
            base.Update(gameTime);

            spriteBatch.Draw(playerChecker, playerPosition, null, Color.White, 0.0f, Vector2.Zero, scale, SpriteEffects.None, 0);

           /* if (playerPanel.isActive())
            {
                playerPanel.Draw();
            }
            */
        }
    }
}
