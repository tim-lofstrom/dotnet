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
    public class GamePlan : Microsoft.Xna.Framework.DrawableGameComponent
    {
        List<Square> square = new List<Square>();

        SpriteBatch spriteBatch;
        SpriteFont squareSpriteFont;
        ContentManager contentManager;

        Vector2 planPosition;
        Vector2 sqrPosition;
        Vector2 logoPosition;
        Vector2 origin;

        public Texture2D game_plan;
        public Texture2D game_plan_logo;
        public Texture2D square_blank;
        public Texture2D square_corner;
        public Texture2D square_street;

        float scale;

        public GamePlan(Game game, SpriteBatch spriteBatch, SpriteFont spriteFont, ContentManager contentManager, int gameWidth, int gameHeight) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.squareSpriteFont = contentManager.Load<SpriteFont>("fonts/squarefont");
            this.contentManager = contentManager;

            game_plan = contentManager.Load<Texture2D>("img/game_plan");
            game_plan_logo = contentManager.Load<Texture2D>("img/game_plan_logo");
            square_blank = contentManager.Load<Texture2D>("img/square_blank");
            square_corner = contentManager.Load<Texture2D>("img/square_corner");
            square_street = contentManager.Load<Texture2D>("img/square_street");

            this.scale = ((float)(gameHeight - ((float)0.18 * (float)gameHeight)) / (float)(game_plan.Height + 1));

            planPosition = new Vector2((gameWidth - game_plan.Width) / 2, (gameHeight - game_plan.Height) / 2);
            origin = new Vector2((gameWidth - game_plan.Width * scale) / 2 , (gameHeight - game_plan.Height * scale) / 2);

            logoPosition = origin;

            logoPosition.X += (game_plan.Width * scale - game_plan_logo.Width) / 2;
            logoPosition.Y += (game_plan.Height * scale - game_plan_logo.Height) / 2;

            //sqrPosition, sqrTexture, sqrRotation, streetBought, streetOwner, streetName, charge, housePrice, payRent[]

            //row one
            sqrPosition = origin;
            sqrPosition.X += 5 * scale;
            sqrPosition.Y += 5 * scale;
            square.Add(new Square(spriteBatch, squareSpriteFont, sqrPosition, square_corner, 0, scale, false, "state", "Go", 0, 0, new int[] { 0, 0, 0, 0, 0 }));

            sqrPosition.X += square_corner.Width * scale;
            square.Add(new Square(spriteBatch, squareSpriteFont, sqrPosition, square_street, 0, scale, false, "state", "Vasterlang-gatan", 1200, 1000, new int[] { 40, 200, 600, 1800, 3200, 5000 }));

            sqrPosition.X += square_street.Width * scale;
            square.Add(new Square(spriteBatch, squareSpriteFont, sqrPosition, square_blank, 0, scale, true, "state", "Allmanning", 0, 0, new int[] { 0, 0, 0, 0, 0 }));

            sqrPosition.X += square_street.Width * scale;
            square.Add(new Square(spriteBatch, squareSpriteFont, sqrPosition, square_street, 0, scale, false, "state", "Horgatan", 1200, 1000, new int[] { 80, 400, 1200, 3600, 6400, 9000 }));

            sqrPosition.X += square_street.Width * scale;
            square.Add(new Square(spriteBatch, squareSpriteFont, sqrPosition, square_blank, 0, scale, true, "state", "Income Tax", 4000, 0, new int[] { 4000, 0, 0, 0, 0 }));

            sqrPosition.X += square_street.Width * scale;
            square.Add(new Square(spriteBatch, squareSpriteFont, sqrPosition, square_blank, 0, scale, false, "state", "Ruskigbuss-Station", 4000, 0, new int[] { 500, 1000, 2000, 4000, 0 }));

            sqrPosition.X += square_street.Width * scale;
            square.Add(new Square(spriteBatch, squareSpriteFont, sqrPosition, square_street, 0, scale, false, "state", "Folkunga-gatan", 2000, 1000, new int[] { 120, 600, 1800, 5400, 8000, 11000 }));

            sqrPosition.X += square_street.Width * scale;
            square.Add(new Square(spriteBatch, squareSpriteFont, sqrPosition, square_blank, 0, scale, true, "state", "Chance", 0, 0, new int[] { 0, 0, 0, 0, 0 }));

            sqrPosition.X += square_street.Width * scale;
            square.Add(new Square(spriteBatch, squareSpriteFont, sqrPosition, square_street, 0, scale, false, "state", "Gotagatan", 2000, 1000, new int[] { 120, 600, 1800, 5400, 8000, 11000 }));

            sqrPosition.X += square_street.Width * scale;
            square.Add(new Square(spriteBatch, squareSpriteFont, sqrPosition, square_street, 0, scale, false, "state", "Ringmuskel-vagen", 2400, 1000, new int[] { 160, 800, 2000, 6000, 9000, 12000 }));


            //row two
            sqrPosition.X += square_street.Width * scale;
            square.Add(new Square(spriteBatch, squareSpriteFont, sqrPosition, square_corner, 0, scale, false, "state", "Prison Visitor", 0, 0, new int[] { 0, 0, 0, 0, 0 }));

            sqrPosition.X += square_corner.Width * scale;
            sqrPosition.Y += square_corner.Height * scale;
            square.Add(new Square(spriteBatch, squareSpriteFont, sqrPosition, square_street, MathHelper.ToRadians(90), scale, false, "state", "S:t Eriks-gatan", 2800, 2000, new int[] { 200, 1000, 3000, 9000, 12500, 15000 }));

            sqrPosition.Y += square_street.Width * scale;
            square.Add(new Square(spriteBatch, squareSpriteFont, sqrPosition, square_blank, MathHelper.ToRadians(90), scale, false, "state", "Migrations-verket", 3000, 0, new int[] { }));

            sqrPosition.Y += square_street.Width * scale;
            square.Add(new Square(spriteBatch, squareSpriteFont, sqrPosition, square_street, MathHelper.ToRadians(90), scale, false, "state", "Odengata", 2800, 2000, new int[] { 200, 1000, 3000, 9000, 12500, 15000 }));

            sqrPosition.Y += square_street.Width * scale;
            square.Add(new Square(spriteBatch, squareSpriteFont, sqrPosition, square_street, MathHelper.ToRadians(90), scale, false, "state", "Valhalla-vagen", 3200, 2000, new int[] { 240, 1200, 3600, 10000, 14000, 18000 }));

            sqrPosition.Y += square_street.Width * scale;
            square.Add(new Square(spriteBatch, squareSpriteFont, sqrPosition, square_blank, MathHelper.ToRadians(90), scale, false, "state", "Ostra-Station", 4000, 0, new int[] { 500, 1000, 2000, 4000, 0 }));

            sqrPosition.Y += square_street.Width * scale;
            square.Add(new Square(spriteBatch, squareSpriteFont, sqrPosition, square_street, MathHelper.ToRadians(90), scale, false, "state", "Sturegatan", 3600, 2000, new int[] { 280, 1400, 4000, 11000, 15000, 19000 }));

            sqrPosition.Y += square_street.Width * scale;
            square.Add(new Square(spriteBatch, squareSpriteFont, sqrPosition, square_blank, MathHelper.ToRadians(90), scale, true, "state", "Allmanning", 0, 0, new int[] { 0, 0, 0, 0, 0, 0 }));

            sqrPosition.Y += square_street.Width * scale;
            square.Add(new Square(spriteBatch, squareSpriteFont, sqrPosition, square_street, MathHelper.ToRadians(90), scale, false, "state", "Karlavagen", 3600, 2000, new int[] { 280, 1400, 4000, 11000, 15000, 19000 }));

            sqrPosition.Y += square_street.Width * scale;
            square.Add(new Square(spriteBatch, squareSpriteFont, sqrPosition, square_street, MathHelper.ToRadians(90), scale, false, "state", "Narvavagen", 4000, 2000, new int[] { 320, 1600, 4400, 12000, 16000, 20000 }));


            //row three
            sqrPosition.Y += square_street.Width * scale;
            sqrPosition.X -= square_corner.Width * scale;
            square.Add(new Square(spriteBatch, squareSpriteFont, sqrPosition, square_corner, 0, scale, false, "state", "Free Parking", 0, 0, new int[] { 0, 0, 0, 0, 0 }));

            sqrPosition.X -= square_street.Width * scale;
            square.Add(new Square(spriteBatch, squareSpriteFont, sqrPosition, square_street, 0, scale, false, "state", "Strandvagen", 4400, 3000, new int[] { 360, 1800, 5000, 14000, 17500, 21000 }));

            sqrPosition.X -= square_street.Width * scale;
            square.Add(new Square(spriteBatch, squareSpriteFont, sqrPosition, square_blank, 0, scale, true, "state", "Chance", 0, 0, new int[] {0, 0, 0, 0, 0, 0 }));

            sqrPosition.X -= square_street.Width * scale;
            square.Add(new Square(spriteBatch, squareSpriteFont, sqrPosition, square_street, 0, scale, false, "state", "Kungstrad-gardsgatan", 3600, 3000, new int[] { 360, 1800, 5000, 14000, 17500, 21000 }));

            sqrPosition.X -= square_street.Width * scale;
            square.Add(new Square(spriteBatch, squareSpriteFont, sqrPosition, square_street, 0, scale, false, "state", "Hamngatan", 4800, 3000, new int[] { 400, 2000, 6000, 15000, 18000, 22000 }));

            sqrPosition.X -= square_street.Width * scale;
            square.Add(new Square(spriteBatch, squareSpriteFont, sqrPosition, square_blank, 0, scale, false, "state", "Central-station", 4000, 0, new int[] { 500, 1000, 2000, 4000, 0, 0 }));

            sqrPosition.X -= square_street.Width * scale;
            square.Add(new Square(spriteBatch, squareSpriteFont, sqrPosition, square_street, 0, scale, false, "state", "Vasagatan", 5200, 3000, new int[] { 440, 2200, 6600, 16000, 19500, 23000 }));

            sqrPosition.X -= square_street.Width * scale;
            square.Add(new Square(spriteBatch, squareSpriteFont, sqrPosition, square_street, 0, scale, false, "state", "Kriminal-varden", 3000, 0, new int[] { }));

            sqrPosition.X -= square_street.Width * scale;
            square.Add(new Square(spriteBatch, squareSpriteFont, sqrPosition, square_street, 0, scale, false, "state", "Kungsgatan", 5200, 3000, new int[] { 440, 2200, 6600, 16000, 19500, 23000 }));

            sqrPosition.X -= square_street.Width * scale;
            square.Add(new Square(spriteBatch, squareSpriteFont, sqrPosition, square_street, 0, scale, false, "state", "Stureplan", 5600, 3000, new int[] { 480, 2400, 7200, 17000, 20500, 24000 }));


            //fow four
            sqrPosition.X -= square_corner.Width * scale;
            square.Add(new Square(spriteBatch, squareSpriteFont, sqrPosition, square_corner, 0, scale, false, "state", "Go to prison", 0, 0, new int[] {0, 0, 0, 0, 0, 0 }));

            square.Add(new Square(spriteBatch, squareSpriteFont, sqrPosition, square_street, MathHelper.ToRadians(-90), scale, false, "state", "Gustav-Adolfs Torg", 6000, 4000, new int[] { 520, 2600, 7800, 18000, 22000, 25500 }));

            sqrPosition.Y -= square_street.Width * scale;
            square.Add(new Square(spriteBatch, squareSpriteFont, sqrPosition, square_street, MathHelper.ToRadians(-90), scale, false, "state", "Drottning-gatan", 6000, 4000, new int[] { 520, 2600, 7800, 18000, 22000, 25500 }));

            sqrPosition.Y -= square_street.Width * scale;
            square.Add(new Square(spriteBatch, squareSpriteFont, sqrPosition, square_blank, MathHelper.ToRadians(-90), scale, true, "state", "Allmanning", 0, 0, new int[] {0, 0, 0, 0, 0, 0 }));

            sqrPosition.Y -= square_street.Width * scale;
            square.Add(new Square(spriteBatch, squareSpriteFont, sqrPosition, square_street, MathHelper.ToRadians(-90), scale, false, "state", "Diplomat-staden", 6400, 4000, new int[] { 560, 3000, 9000, 20000, 24000, 28000 }));

            sqrPosition.Y -= square_street.Width * scale;
            square.Add(new Square(spriteBatch, squareSpriteFont, sqrPosition, square_blank, MathHelper.ToRadians(-90), scale, false, "state", "Norra-Station", 4000, 0, new int[] { 500, 1000, 2000, 4000, 0, 0 }));

            sqrPosition.Y -= square_street.Width * scale;
            square.Add(new Square(spriteBatch, squareSpriteFont, sqrPosition, square_blank, MathHelper.ToRadians(-90), scale, true, "state", "Chance", 0, 0, new int[] { 0, 0, 0, 0, 0, 0 }));

            sqrPosition.Y -= square_street.Width * scale;
            square.Add(new Square(spriteBatch, squareSpriteFont, sqrPosition, square_street, MathHelper.ToRadians(-90), scale, false, "state", "Centrum", 7000, 4000, new int[] { 700, 3500, 1000, 22000, 26000, 30000 }));

            sqrPosition.Y -= square_street.Width * scale;
            square.Add(new Square(spriteBatch, squareSpriteFont, sqrPosition, square_street, MathHelper.ToRadians(-90), scale, true, "state", "Luxuary-Tax", 2000, 0, new int[] { 2000, 0, 0, 0, 0, 0 }));

            sqrPosition.Y -= square_street.Width * scale;
            square.Add(new Square(spriteBatch, squareSpriteFont, sqrPosition, square_street, MathHelper.ToRadians(-90), scale, false, "state", "Norrmalms-torg", 8000, 4000, new int[] { 1000, 4000, 12000, 28000, 34000, 40000 }));


        }

        public string getAction(int sqr)
        {
            return square[sqr].Action();
        }

        public Vector2 getPosition()
        {
            return planPosition;
        }

        public Vector2 getSquarePosition(int i)
        {
            return square[i].sqrPosition;
        }

        public float getSquareRotation(int i)
        {
            return square[i].sqrRotation;
        }

        public Texture2D getSize()
        {
            return game_plan;
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

            //spriteBatch.Draw(game_plan, planPosition, Color.White);

            spriteBatch.Draw(game_plan, origin, null, Color.White, 0.0f, Vector2.Zero, scale, SpriteEffects.None, 0);
            spriteBatch.Draw(game_plan_logo, logoPosition, Color.White);

            for(int i = 0; i < square.Count; i++)
            {
                square[i].Draw();
            }
        }
    }
}