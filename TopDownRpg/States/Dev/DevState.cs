using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TopDownRpg.Engine.Input;
using TopDownRpg.Engine.State;
using TopDownRpg.Objects;

namespace TopDownRpg.States.Dev
{
    public class DevState : BaseGameState
    {

        private const string PlayerLeftTexture = "Player/Left/PlayerLeftSheet";
        private const string PlayerRightTexture = "Player/Right/PlayerRightSheet";
        private const string PlayerUpTexture = "Player/Up/PlayerUpSheet";
        private const string PlayerDownTexture = "Player/Down/PlayerDownSheet";
        private PlayerSprite _playerSprite;
        public override void LoadContent()
        {
            _playerSprite = new PlayerSprite(LoadTexture(PlayerLeftTexture), LoadTexture(PlayerRightTexture), LoadTexture(PlayerUpTexture), LoadTexture(PlayerDownTexture));
            var playerXPos = _viewportWidth / 2 - _playerSprite.Width / 2;
            var playerYPos = _viewportHeight / 2 - _playerSprite.Height / 2;
            _playerSprite.Position = new Vector2(playerXPos, playerYPos);
            AddGameObject(_playerSprite);
        }

        public override void HandleInput(GameTime gameTime)
        {
            InputManager.GetCommands(cmd =>
            {
                if (cmd is DevInputCommand.DevQuit)
                {
                    NotifyEvent(new BaseGameStateEvent.GameQuit());
                }

                if(cmd is DevInputCommand.DevUp)
                {
                    _playerSprite.MoveUp();
                }
                if(cmd is DevInputCommand.DevRight)
                {
                    _playerSprite.MoveRight();
                }
                if(cmd is DevInputCommand.DevDown)
                {
                    _playerSprite.MoveDown();
                }
                if(cmd is DevInputCommand.DevLeft)
                {
                    _playerSprite.MoveLeft();
                }
            });
        }

        public override void UpdateGameState(GameTime gameTime)
        {
            _playerSprite.Update(gameTime);
        }

        protected override void SetInputManager()
        {
            InputManager = new InputManager(new DevInputMapper());
        }
    }
}
