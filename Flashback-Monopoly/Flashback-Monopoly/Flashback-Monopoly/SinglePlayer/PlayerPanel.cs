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

    public class PlayerPanel
    {
        SpriteBatch spriteBatch;
        SpriteFont spriteFont;

        Texture2D player_panel;
        Texture2D arrow_left;
        Texture2D arrow_right;
        Texture2D street_info;

        Vector2 panel_position;
        Vector2 arrow_left_pos;
        Vector2 arrow_right_pos;
        Vector2 streetArrow_right_pos;
        Vector2 streetArrow_left_pos;
        Vector2 street_info_pos;
        Vector2 nickPos;
        Vector2 balancePos;
        Vector2 posPos;

        public int playerBalance = 0;
        public int playerPos = 0;
        string playerNick = "default_player";

        public PlayerPanel(Game game, SpriteBatch spriteBatch, SpriteFont spriteFont, ContentManager contentManager)
        {
            this.spriteBatch = spriteBatch;
            this.spriteFont = spriteFont;
            player_panel = contentManager.Load<Texture2D>("img/player_pane");
            arrow_left = contentManager.Load<Texture2D>("img/arrow_left");
            arrow_right = contentManager.Load<Texture2D>("img/arrow_right");
            street_info = contentManager.Load<Texture2D>("img/street_info");

            panel_position = new Vector2(0, 200);

            street_info_pos = panel_position;
            street_info_pos.X += 5;
            street_info_pos.Y += player_panel.Height - street_info.Height - 5;

            streetArrow_left_pos = street_info_pos;
            streetArrow_left_pos.Y -= arrow_left.Height;
            streetArrow_left_pos.X += 5;

            streetArrow_right_pos = street_info_pos;
            streetArrow_right_pos.Y -= arrow_right.Height;
            streetArrow_right_pos.X += player_panel.Width - arrow_right.Width - 10;
            

            arrow_left_pos = panel_position;
            arrow_right_pos = panel_position;

            arrow_left_pos.X += 5;
            arrow_left_pos.Y += 5;

            arrow_right_pos.X += player_panel.Width - arrow_right.Width - 5;
            arrow_right_pos.Y += 5;

            nickPos = panel_position;
            nickPos.X += 20;
            nickPos.Y += 100;

            balancePos = nickPos;
            balancePos.Y += 20;

            posPos = balancePos;
            posPos.Y += 20;

        }

       /* public bool isActive()
        {
            return panel_active;
        }

        public void setState(bool b)
        {
            this.panel_active = b;
        }*/

        public void currentPlayer(string nick, int balance, int pos)
        {
            this.playerNick = nick;
            this.playerBalance = balance;
            this.playerPos = pos;
        }

        public void Draw()
        {
            spriteBatch.Draw(player_panel, panel_position, Color.White);
            spriteBatch.Draw(arrow_left, arrow_left_pos, Color.White);
            spriteBatch.Draw(arrow_right, arrow_right_pos, Color.White);
            spriteBatch.Draw(street_info, street_info_pos, Color.White);
            spriteBatch.Draw(arrow_left, streetArrow_left_pos, Color.White);
            spriteBatch.Draw(arrow_right, streetArrow_right_pos, Color.White);

            spriteBatch.DrawString(spriteFont, playerNick, nickPos, Color.Red);
            spriteBatch.DrawString(spriteFont, playerBalance.ToString(), balancePos, Color.Red);
            spriteBatch.DrawString(spriteFont, playerPos.ToString(), posPos, Color.Red);
        }
    }
}
