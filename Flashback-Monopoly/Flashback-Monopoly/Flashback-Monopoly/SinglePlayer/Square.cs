using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Flashback_Monopoly
{
    class Square
    {
        SpriteBatch spriteBatch;
        SpriteFont spriteFont;

        public Vector2 sqrPosition;
        Vector2 txtPosition;
        public Vector2 origin;
        public Texture2D sqrTexture;
        public float sqrRotation;
        float scale;
        bool streetBought = false;      // Ifall n?gon ?ger gatan (eller ej)
        string streetName = "";         //Gatunamn
        string streetOwner = "";       // Namm p? eventuell gatu?gare "staten" som default
        int streetCharge = 0;                    // Kostnad att k?pa gatan
        int housePrice = 0;              // Kostnad att k?pa ett hus
        int houses = 0;                 // Antal hus
        int[] payRent = new int[5];     //Hyran att betala utifall att man hamnar p? (uppk?pt) gata med eventuella hus, hotell

        //sqrPosition, sqrTexture, sqrRotation, streetBought, streetName, streetOwner, charge, housePrice, payRent[]

        public Square(SpriteBatch spriteBatch,
            SpriteFont spriteFont,
            Vector2 sqrPosition,
            Texture2D sqrTexture,
            float sqrRotation,
            float scale,
            bool streetBought,
            string streetOwner,
            string streetName,
            int streetCharge,
            int housePrice,
            int[] payRent)
        {
            this.spriteBatch = spriteBatch;
            this.spriteFont = spriteFont;
            this.sqrPosition = sqrPosition;
            this.sqrTexture = sqrTexture;
            this.sqrRotation = sqrRotation;
            this.scale = scale;
            this.streetBought = streetBought;
            this.streetName = streetName;
            this.streetOwner = streetOwner;
            this.streetCharge = streetCharge;
            this.housePrice = housePrice;
            this.payRent = payRent;

            txtPosition = sqrPosition;

            if(MathHelper.ToRadians(90) == sqrRotation)
            {
                txtPosition.X -= 25;
                txtPosition.Y += 5;
            }
            else if (MathHelper.ToRadians(-90) == sqrRotation)
            {
                txtPosition.X += 25;
                txtPosition.Y -= 5;
            }
            else
            {
                txtPosition.X += 5;
                txtPosition.Y += 25;
            }

            origin = new Vector2(0, 0);
            //scale = 80.0f / (float)sqrTexture.Width;
        }

        public string Action()
        {
            if(streetBought == false)
            {
                return "buy " + streetCharge;
            }

            if(streetBought == true)
            {
                switch (streetName)
                {
                    case "Allmanning":
                        return "almanning";
                    case "Chance":
                        return "Chance";
                    case "Free Parking":
                        return "default";
                    default:
                        return "pay " + streetOwner + " " + payRent[houses];
                }
            }

           
            return "default";
        }

        public void Draw()
        {
            spriteBatch.Draw(sqrTexture, sqrPosition, null, Color.White, sqrRotation, origin, scale, SpriteEffects.None, 0f);

            if (streetName.Contains('-'))
            {
                string[] spl = streetName.Split('-');

                spriteBatch.DrawString(spriteFont, spl[0] + "-" + "\r\n" + spl[1] + "\r\n" + streetCharge + " Kr", txtPosition, Color.Black, sqrRotation, origin, scale, SpriteEffects.None, 0f);
            }
            else
            {
                spriteBatch.DrawString(spriteFont, streetName + "\r\n" + streetCharge + " Kr", txtPosition, Color.Black, sqrRotation, origin, scale, SpriteEffects.None, 0f);
            }
        }
    }
}
