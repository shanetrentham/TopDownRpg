using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Text;
using TopDownRpg.Engine.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using TopDownRpg.Engine.Input;

namespace TopDownRpg.Engine.State
{
    public abstract class BaseGameState
    {
        protected bool _debug = false;
        protected bool _indestructible = false;

        private ContentManager _contentManager;
        protected int _viewportHeight;
        protected int _viewportWidth;

        private readonly List<BaseGameObject> _gameObjects = new List<BaseGameObject>();

        protected InputManager InputManager { get; set; }

        public void Initialize(ContentManager contentManager, int viewportWidth, int viewportHeight)
        {
            _contentManager = contentManager;
            _viewportWidth = viewportWidth;
            _viewportHeight = viewportHeight;

            SetInputManager();
        }

        public abstract void LoadContent();
        
        public abstract void HandleInput(GameTime gameTime);
        public abstract void UpdateGameState(GameTime gameTime);


        public event EventHandler<BaseGameState> OnStateSwitched;
        public event EventHandler<BaseGameStateEvent> OnEventNotification;
        protected abstract void SetInputManager();

        public void UnLoadContent()
        {
            _contentManager.Unload();
        }
        public void Update(GameTime gameTime)
        {
            UpdateGameState(gameTime);
        }

        /// <summary>
        /// Loads the texture fromt the content directory with a given string containing the file name
        /// </summary>
        /// <param name="textureName">String containing file name of Texture that is to be loaded</param>
        /// <returns>The loaded texture object</returns>
        protected Texture2D LoadTexture(string textureName)
        {
            return _contentManager.Load<Texture2D>(textureName);
        }

        /// <summary>
        /// Notifies all game objects of the event upon notification of the event
        /// </summary>
        /// <param name="gameEvent">Event that has been activated</param>
        protected void NotifyEvent(BaseGameStateEvent gameEvent)
        {
            OnEventNotification?.Invoke(this, gameEvent);

            foreach(var gameObj in _gameObjects)
            {
                if(gameObj != null)
                {
                    gameObj.OnNotify(gameEvent);
                }
            }
        }


        /// <summary>
        /// This method is called to switch from the active gamestate to the new specified Game State
        /// </summary>
        /// <param name="gameState">Game state to switch to from the current game state</param>
        protected void SwitchStates(BaseGameState gameState)
        {
            OnStateSwitched?.Invoke(this, gameState);
        }

        /// <summary>
        /// This method adds a game object to the list of game objects tracked by the active game state
        /// </summary>
        /// <param name="gameObject">Object to be added to the State</param>
        /// <exception cref="NullReferenceException">Thrown when the passed game object to be added is null</exception>"
        protected void AddGameObject(BaseGameObject gameObject)
        {
            if(gameObject != null)
            {
                _gameObjects.Add(gameObject);
            }
            else
            {
                throw new NullReferenceException("Game object to be added is null");
            }
        }
        /// <summary>
        /// Removes a game object from the game state
        /// </summary>
        /// <param name="gameObject">Game object to be removed</param>
        /// <exception cref="NullReferenceException">Thown when the passed game object to be removed is null</exception>
        protected void RemoveGameObject(BaseGameObject gameObject)
        {
            if( gameObject != null)
            {
                _gameObjects.Remove(gameObject);
            }
            else
            {
                throw new NullReferenceException("Game object to be removed is null");
            }
        }

        /// <summary>
        /// Method calls the render method for every game object in the list of game objects that is not null.
        /// The objects are ordered by zIndex prior to render
        /// </summary>
        /// <param name="spriteBatch">Sprite batch object to pass along to the objects render method</param>
        public virtual void Render(SpriteBatch spriteBatch)
        {
            foreach(var gameObj in _gameObjects.Where(a => a != null).OrderBy(a => a.zIndex))
            {
                gameObj.Render(spriteBatch);
            }
        }
    }
}
