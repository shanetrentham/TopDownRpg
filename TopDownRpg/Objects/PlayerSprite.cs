using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TopDownRpg.Engine.Objects;

namespace TopDownRpg.Objects
{
    public class PlayerSprite : BaseGameObject
    {
        private const float PlayerHorizontalSpeed = 10.0f;
        private const float PlayerVerticalSpeed = 8.0f;

        private const int AnimationCellWidth = 48;
        private const int AnimationCellHeight = 48;

        public PlayerSprite(Texture2D texture)
        {
            _texture = texture;
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public void MoveUp()
        {
            Position = new Vector2(Position.X, Position.Y - PlayerVerticalSpeed);
        }
        public void MoveRight()
        {
            Position = new Vector2(Position.X + PlayerHorizontalSpeed, Position.Y);
        }
        public void MoveDown()
        {
            Position = new Vector2(Position.X, Position.Y + PlayerVerticalSpeed);
        }

        public void MoveLeft()
        {
            Position = new Vector2(Position.X - PlayerHorizontalSpeed, Position.Y);
        }

        public override void Render(SpriteBatch spriteBatch)
        {
            var sourceRectangle = new Rectangle(0, 0, AnimationCellWidth, AnimationCellHeight);
            var destinationRectangle = new Rectangle((int)_position.X, (int)_position.Y, AnimationCellWidth, AnimationCellHeight);

            spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
