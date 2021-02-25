﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Bernt
{
    class Cube
    {
        public float speed = 0;

        public float burner = 1;

        public Model Model;
        public Matrix[] Transforms;

        //Position of the model in world space
        public Vector3 Position = Vector3.Zero;

        //Velocity of the model, applied each frame to the model's position
        public Vector3 Velocity = Vector3.Zero;
        private const float VelocityScale = 5.0f; //amplifies controller speed input
        public Matrix RotationMatrix = Matrix.CreateRotationX(MathHelper.PiOver2);

        private float rotation;
        public float Rotation
        {
            get { return rotation; }
            set
            {
                while (value >= MathHelper.TwoPi)
                {
                    value -= MathHelper.TwoPi;
                }
                while (value < 0)
                {
                    value += MathHelper.TwoPi;
                }
                if (rotation != value)
                {
                    rotation = value;
                    RotationMatrix =
                        Matrix.CreateRotationX(MathHelper.PiOver2) *
                        Matrix.CreateRotationZ(rotation);
                }
            }
        }

        public void Update(MouseState mouseState, KeyboardState keyboardState)
        {

            if (keyboardState.IsKeyDown(Keys.D))
                Rotation -= 0.05f * burner;
            if (keyboardState.IsKeyDown(Keys.A))
                Rotation += 0.05f * burner;

            Velocity += RotationMatrix.Forward * VelocityScale * speed;
        }
    }
}
