using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TopDownRpg.Engine.Objects;
using TopDownRpg.Engine.Objects.Animations;
using TopDownRpg.Objects.AnimationBuilders;

namespace TopDownRpg.Objects
{
    public class PlayerSprite : BaseGameObject
    {
        private const float PlayerHorizontalSpeed = 5.0f;
        private const float PlayerVerticalSpeed = 5.0f;

        private Animation _currentAnimation;
        private Animation _previousAnimation;
        private PlayerAnimationBuilder _playerLeftAnimation;
        private PlayerAnimationBuilder _playerRightAnimation;
        private PlayerAnimationBuilder _playerUpAnimation;
        private PlayerAnimationBuilder _playerDownAnimation;

        private bool _movingLeft = false;
        private bool _movingRight = false;
        private bool _movingUp = false;
        private bool _movingDown = false;

        public override int Width => 48;
        public override int Height => 48;


        public PlayerSprite(Texture2D playerLeft, Texture2D playerRight, Texture2D playerUp, Texture2D playerDown)
        {
            
            _playerLeftAnimation = new PlayerAnimationBuilder(playerLeft);
            _playerRightAnimation = new PlayerAnimationBuilder(playerRight);
            _playerUpAnimation = new PlayerAnimationBuilder(playerUp);
            _playerDownAnimation = new PlayerAnimationBuilder(playerDown);
            _texture = _playerRightAnimation.spriteSheet;

            _currentAnimation = _playerRightAnimation.Idle;
            
        }

        public void Update(GameTime gameTime)
        {
            if(_currentAnimation != null)
            {
                _currentAnimation.Update(gameTime);
            }
        }

        public void MoveUp()
        {
            SetDirection(false, false, true, false);
            _previousAnimation = _currentAnimation;
            _currentAnimation = _playerUpAnimation.Walk;
            _texture = _playerUpAnimation.spriteSheet;
            _previousAnimation.Reset();            
            Position = new Vector2(Position.X, Position.Y - PlayerVerticalSpeed);

        }
        public void MoveRight()
        {
            SetDirection(false, true, false, false);
            _previousAnimation = _currentAnimation;
            _currentAnimation = _playerRightAnimation.Walk;
            _texture = _playerRightAnimation.spriteSheet;
            _previousAnimation.Reset();
            Position = new Vector2(Position.X + PlayerHorizontalSpeed, Position.Y);
        }
        public void MoveDown()
        {
            SetDirection(false, false, false, true);
            _previousAnimation = _currentAnimation;
            _currentAnimation = _playerDownAnimation.Walk;
            _texture = _playerDownAnimation.spriteSheet;
            _previousAnimation.Reset();
            Position = new Vector2(Position.X, Position.Y + PlayerVerticalSpeed);
        }

        public void MoveLeft()
        {
            SetDirection(true, false, false, false);
            _previousAnimation = _currentAnimation;
            _currentAnimation = _playerLeftAnimation.Walk;
            _texture = _playerLeftAnimation.spriteSheet;
            _previousAnimation.Reset();            
            Position = new Vector2(Position.X - PlayerHorizontalSpeed, Position.Y);
        }

        private void SetDirection(bool left, bool right, bool up, bool down)
        {
            _movingLeft = left;
            _movingRight = right;
            _movingUp = up;
            _movingDown = down;
        }

        public override void Render(SpriteBatch spriteBatch)
        {
            var sourceRectangle = new Rectangle(0, 0, 48, 48);
            var destinationRectangle = new Rectangle((int)_position.X, (int)_position.Y, 48, 48);
            
            if(_currentAnimation != null)
            {
                var currentFrame = _currentAnimation.CurrentFrame;
                if(currentFrame != null)
                {
                    sourceRectangle = currentFrame.SourceRectangle;
                }
            }

            spriteBatch.Draw(_texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
