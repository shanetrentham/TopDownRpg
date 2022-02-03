using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TopDownRpg.Engine.Objects.Animations
{
    public class Animation
    {
        private List<AnimationFrame> _frames = new List<AnimationFrame>();
        private int _animationAge = 0;
        private int _lifeSpan = -1;
        private bool _isLoop = false;

        public int Lifespan
        {
            get
            {
                if(_lifeSpan < 0)
                {
                    _lifeSpan = 0;
                    foreach(var frame in _frames)
                    {
                        _lifeSpan += frame.LifeSpan;
                    }
                }
                return _lifeSpan;
            }
        }

        public AnimationFrame CurrentFrame
        {
            get
            {
                AnimationFrame currentFrame = null;
                var framesLifeSpan = 0;
                foreach(var frame in _frames)
                {
                    if(framesLifeSpan + frame.LifeSpan >= _animationAge)
                    {
                        currentFrame = frame;
                    }
                    else
                    {
                        framesLifeSpan += frame.LifeSpan;
                    }
                }
                if(currentFrame != null)
                {
                    currentFrame = _frames.LastOrDefault();
                }

                return currentFrame;
            }
        }

        public Animation ReverseAnimation
        {
            get
            {
                var newAnimation = new Animation(_isLoop);
                for(int i = _frames.Count - 1; i >=0; i--)
                {
                    newAnimation.AddFrame(_frames[i].SourceRectangle, _frames[i].LifeSpan);
                }
                return newAnimation;
            }
        }

        public Animation(bool isLoop)
        {
            _isLoop = isLoop;
        }

        public void AddFrame(Rectangle sourceRectangle, int lifeSpan)
        {
            _frames.Add(new AnimationFrame(sourceRectangle, lifeSpan));
        }

        public void Update(GameTime gameTime)
        {
            _animationAge++;

            if(_isLoop && _animationAge > Lifespan)
            {
                _animationAge = 0;
            }
        }

        public void Reset()
        {
            _animationAge = 0;
        }
    }
}
