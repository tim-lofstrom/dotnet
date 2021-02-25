using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Flashback_Monopoly
{
    class NewGame : GameScreen
    {
        MouseState currentMouseState;
        MouseState oldMouseState;

        Dice dice;

        GamePlan gamePlan;

        List<Player> players = new List<Player>();

        ControlPanel controlPanel;
        PlayerPanel playerPanel;
        Texture2D backgroundImage;
        Rectangle imageRectangle;

        int currentPlayer = 0;



        public NewGame(Game game, SpriteBatch spriteBatch, SpriteFont spriteFont, ContentManager contentManager, List<Player> players)
            : base(game, spriteBatch, spriteFont, contentManager)
        {

            gamePlan = new GamePlan(game, spriteBatch, spriteFont, contentManager, Game.Window.ClientBounds.Width, Game.Window.ClientBounds.Height);
            Components.Add(gamePlan);

            controlPanel = new ControlPanel(game, spriteBatch, spriteFont, contentManager, gamePlan.getPosition(), gamePlan.getSize());
            Components.Add(controlPanel);

            playerPanel = new PlayerPanel(game, spriteBatch, spriteFont, contentManager);

            this.players = players;

            for (int i = 0; i < players.Count(); i++ )
            {
                Components.Add(players[i]);
            }

            dice = new Dice();
            backgroundImage = contentManager.Load<Texture2D>("img/game_background");
            imageRectangle = new Rectangle(0, 0, Game.Window.ClientBounds.Width, Game.Window.ClientBounds.Height);

        }

        public void mesaureCheckers()
        {
            Vector2 pos;

            for (int i = 0; i < players.Count(); i++ )
            {
                if (gamePlan.getSquareRotation(players[i].playerLocation) == MathHelper.ToRadians(90))
                {
                    pos = gamePlan.getSquarePosition(players[i].playerLocation);
                    pos.X -= (gamePlan.square_street.Height + gamePlan.square_street.Height - players[i].playerChecker.Width) / 2;
                    pos.Y += (gamePlan.square_street.Width - players[i].playerChecker.Height) / 2;
                    players[i].playerPosition = pos;
                }
                else if (gamePlan.getSquareRotation(players[i].playerLocation) == MathHelper.ToRadians(-90))
                {
                    pos = gamePlan.getSquarePosition(players[i].playerLocation);
                    pos.X -= (gamePlan.square_street.Height - gamePlan.square_street.Height - players[i].playerChecker.Width) / 2;
                    pos.Y += (gamePlan.square_street.Width - players[i].playerChecker.Height) / 2;
                    pos.Y -= gamePlan.square_street.Width;
                    players[i].playerPosition = pos;
                }
                else
                {
                    pos = gamePlan.getSquarePosition(players[i].playerLocation);
                    pos.X += (gamePlan.square_street.Width - players[i].playerChecker.Width) / 2;
                    pos.Y += (gamePlan.square_street.Height - players[i].playerChecker.Height) / 2;
                    players[i].playerPosition = pos;
                }
            }



        }

        public override void Update(GameTime gameTime)
        {

            currentMouseState = Mouse.GetState();

            mesaureCheckers();
            playerPanel.currentPlayer(players[currentPlayer].playerNick, players[currentPlayer].balance, players[currentPlayer].playerLocation);

            for (int i = 0; i < controlPanel.getOptions(); i++)
            {
                Rectangle mouseBounds = new Rectangle(currentMouseState.X, currentMouseState.Y, 0, 0);

                if (mouseBounds.Intersects(controlPanel.getBounds(i)))
                {
                    controlPanel.Hilite(i, true);

                    if ((currentMouseState.LeftButton == ButtonState.Pressed) && (oldMouseState.LeftButton == ButtonState.Released))
                    {
                        players[currentPlayer].playerLocation += dice.Sum(dice.Roll(2));

                        int roll = dice.Sum(dice.Roll(2));


                        if (dice.previousRoll[0][0] == dice.previousRoll[0][1])
                        {
                            //Console.WriteLine("NYTT SLAG");
                            //fungerar
                        }

                        if (players[currentPlayer].playerLocation >= 39)
                        {
                            int temp = players[currentPlayer].playerLocation;
                            temp = temp - 39;
                            players[currentPlayer].playerLocation = temp;
                            players[currentPlayer].balance += 4000;
                        }

                        string[] action = gamePlan.getAction(players[currentPlayer].playerLocation).Split();

                        switch (action[0])
                        {
                            case "buy":
                                MessageBox.Show("test");
                                break;
                            case "pay":
                                players[currentPlayer].balance -= int.Parse(action[2]);

                                break;
                            default:
                                break;
                        }

                        if (currentPlayer >= players.Count() - 1)
                        {
                            currentPlayer = 0;
                        }
                        else
                        {
                            currentPlayer++;
                        }
                        
                    }

                }
                else
                {
                    controlPanel.Hilite(i, false);
                }
            }

            
            oldMouseState = currentMouseState;

            base.Update(gameTime);

        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(backgroundImage, imageRectangle, Color.White);
            spriteBatch.DrawString(spriteFont, "ESC - BACK", new Vector2(20, 10), Color.Red);
            spriteBatch.DrawString(spriteFont, "Player: " + currentPlayer, new Vector2(gamePlan.game_plan.Width - 20, 10), Color.Red);
            playerPanel.Draw();
            base.Draw(gameTime);
        }



    }
}
