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
    public abstract class GameScreen : Microsoft.Xna.Framework.DrawableGameComponent
    {
        List<GameComponent> components = new List<GameComponent>();

        protected Game game;
        protected SpriteBatch spriteBatch;
        protected SpriteFont spriteFont;
        protected ContentManager contentManager;

        public GameScreen(Game game, SpriteBatch spriteBatch, SpriteFont spriteFont, ContentManager contentManager)
            : base(game)
        {
            this.game = game;
            this.spriteBatch = spriteBatch;
            this.spriteFont = spriteFont;
            this.contentManager = contentManager;

        }

        public List<GameComponent> Components
        {
            get { return components; }
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            foreach(GameComponent component in components)
            {
                if(component.Enabled == true)
                {
                    component.Update(gameTime);
                }
            }
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            foreach(GameComponent component in components)
            {
                if(component is DrawableGameComponent && ((DrawableGameComponent)component).Visible)
                {
                    ((DrawableGameComponent)component).Draw(gameTime);
                }
            }
        }

        public virtual void Show()
        {
            this.Visible = true;
            this.Enabled = true;
            foreach (GameComponent component in components)
            {
                component.Enabled = true;
                if (component is DrawableGameComponent)
                {
                    ((DrawableGameComponent)component).Visible = true;
                }
            }
        }

        public virtual void Hide()
        {
            this.Visible = false;
            this.Enabled = false;

            foreach (GameComponent component in components)
            {
                component.Enabled = false;
                if (component is DrawableGameComponent)
                {
                    ((DrawableGameComponent)component).Visible = false;
                }
            }
        }
    }
}
