using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TopDownRpg.Engine.State;

namespace TopDownRpg.Engine.Objects
{
    public class BaseGameObject
    {
        protected Texture2D _texture;

        protected Vector2 _position;

        public int zIndex;
        public event EventHandler<BaseGameStateEvent> OnObjectChanged;

        public bool Destroyed { get; private set; }

        public virtual int Width { get { return _texture.Width; } }
        public virtual int Height { get { return _texture.Height; } }

        public virtual Vector2 Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
            }
        }

        public virtual void OnNotify(BaseGameStateEvent gameEvent) { }

        public virtual void Render(SpriteBatch spriteBatch)
        {
            if (!Destroyed)
            {
                spriteBatch.Draw(_texture, _position, Color.White);
            }
        }

        public void Destroy()
        {
            Destroyed = true;
        }
    }
}
