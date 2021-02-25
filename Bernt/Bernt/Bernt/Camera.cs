using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Bernt
{
    class Camera
    {
        private Vector3 position;
        private Vector3 lookAt;
        private Matrix viewMatrix;
        private Matrix projectionMatrix;
        private float aspectRatio;

        Vector3 thirdPersonReference = new Vector3(0, 200, -200);

        public Camera(Viewport viewport)
        {
            this.aspectRatio = ((float)viewport.Width) / ((float)viewport.Height);
            this.projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45.0f), aspectRatio, 1.0f, 5000.0f);
        }

        public Vector3 Position
        {
            get { return this.position; }
            set { this.position = value; }
        }

        public Vector3 LookAt
        {
            get { return this.lookAt; }
            set { this.lookAt = value; }
        }

        public Matrix ViewMatrix
        {
            get { return viewMatrix; }
        }

        public Matrix ProjectionMatrix
        {
            get { return projectionMatrix; }
        }

        public void Update()
        {
            this.viewMatrix = Matrix.CreateLookAt(this.position, Vector3.Zero, Vector3.Up);
        }


    }
}
