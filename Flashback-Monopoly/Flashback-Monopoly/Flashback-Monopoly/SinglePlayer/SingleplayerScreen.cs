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
    class SingleplayerScreen : GameScreen
    {
        MouseState currentMouseState;
        MouseState oldMouseState;
        KeyboardState currentKeyState;
        KeyboardState oldKeyState;

        Texture2D backgroundImage;
        Texture2D playerPane;
        Rectangle imageRectangle;

        Vector2 playerPane_position;

        MenuComponent menuComponent;
        NewGame newGame;

        double nextBlinkTime = 500;

        //variabler för ny spelare
        string nick = "";
        string checker = "img/icon";
        int balance = 30000;
        bool toogleBot = false;

        List<Player> players = new List<Player>();

        int markedPlayer = 0;
        bool writeNick = false;
        bool blink = false;

        public SingleplayerScreen(Game game, SpriteBatch spriteBatch, SpriteFont spriteFont, ContentManager contentManager)
            : base(game, spriteBatch, spriteFont, contentManager)
        {
            string[] menuItems = { "Nick:", "Checker:", "Bot: False", "Add Player", "Start Game"};

            menuComponent = new MenuComponent(game, spriteBatch, spriteFont, contentManager.Load<Texture2D>("img/menu_option"), menuItems);
            Components.Add(menuComponent);

            backgroundImage = contentManager.Load<Texture2D>("img/menu_background");
            imageRectangle = new Rectangle(0, 0, Game.Window.ClientBounds.Width, Game.Window.ClientBounds.Height);

            playerPane = contentManager.Load<Texture2D>("img/player_pane");
            playerPane_position = new Vector2(20, 40);

            
        }

        public void exit()
        {
            Components.Remove(newGame);
            Components.Remove(menuComponent);
            newGame = null;
            
        }


        protected override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {

            currentMouseState = Mouse.GetState();
            currentKeyState = Keyboard.GetState();

            if (writeNick == true)
            {
                if (gameTime.TotalGameTime.TotalMilliseconds >= nextBlinkTime)
                {
                    if (blink == false)
                    {
                        menuComponent.setItem(0, "Nick: " + nick + "|");
                        blink = true;
                    }
                    else
                    {
                        menuComponent.setItem(0, "Nick: " + nick);
                        blink = false;
                    }
                    nextBlinkTime = gameTime.TotalGameTime.TotalMilliseconds + 500;
                }

                foreach (Keys key in currentKeyState.GetPressedKeys())
                {
                    if (oldKeyState.IsKeyUp(key))
                    {
                        if ((key == Keys.Back) && (nick.Length > 0))
                        {
                            nick = nick.Remove(nick.Length - 1, 1);
                            menuComponent.setItem(0, "Nick: " + nick);
                            menuComponent.Measure(0);
                        }
                        else if (key == Keys.Enter)
                        {
                            writeNick = false;
                        }
                        else if((nick.Length < 15) && (key != Keys.Back))
                        {
                            nick += key.ToString();
                            menuComponent.setItem(0, "Nick: " + nick);
                            menuComponent.Measure(0);
                        }
                    }
                }
            }



           /* for (int i = 0; i < players.Count(); i++)
            {
                Vector2 size = spriteFont.MeasureString(players[i].getNick());
            }*/

            for (int i = 0; i < menuComponent.getOptions(); i++)
            {
                Rectangle mouseBounds = new Rectangle(currentMouseState.X, currentMouseState.Y, 0, 0);

                if (mouseBounds.Intersects(menuComponent.getBounds(i)))
                {
                    menuComponent.Hilite(i, true);

                    if ((currentMouseState.LeftButton == ButtonState.Pressed) && (oldMouseState.LeftButton == ButtonState.Released))
                    {
                        writeNick = false;
                        blink = false;
                        menuComponent.setItem(0, "Nick: " + nick);

                        string[] arr = menuComponent.getItem(i).Split();
                        switch (arr[0])
                        {
                            case "Nick:":
                                writeNick = true;
                                break;
                            case "Checker:":
                                break;
                            case "Bot:":
                                toogleBot = !toogleBot;
                                menuComponent.setItem(i, "Bot: " + toogleBot.ToString());
                                break;
                            case "Add":
                                if (nick.Length > 0)
                                {
                                    players.Add(new Player(game, spriteBatch, spriteFont, contentManager, nick, checker, toogleBot, balance,
                                        Game.Window.ClientBounds.Width, Game.Window.ClientBounds.Height, 800));
                                }
                                break;
                            case "Start":
                                newGame = new NewGame(game, spriteBatch, spriteFont, contentManager, players);
                                Components.Add(newGame);
                                break;
                            default:
                                break;
                        }
                        oldMouseState = currentMouseState;
                    }
                }
                else
                {
                    menuComponent.Hilite(i, false);
                }
            }

            oldMouseState = currentMouseState;
            oldKeyState = currentKeyState;

            base.Update(gameTime);

        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(backgroundImage, imageRectangle, Color.White);
            spriteBatch.Draw(playerPane, playerPane_position, Color.White);
            spriteBatch.DrawString(spriteFont, "ESC - BACK", new Vector2(20, 10), Color.Red);

            for (int i = 0; i < players.Count(); i++ )
            {
                Vector2 size = spriteFont.MeasureString(players[i].getNick());

                spriteBatch.DrawString(spriteFont, players[i].getNick(), new Vector2((playerPane_position.X + (playerPane.Width - size.X) / 2) , (playerPane_position.Y + 10 + 20 * i)), Color.Black);
            }

            base.Draw(gameTime);
        }
    }
}