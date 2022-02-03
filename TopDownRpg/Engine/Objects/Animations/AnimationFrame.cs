using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TopDownRpg.Engine.Objects.Animations
{
    public class AnimationFrame
    {
        public Rectangle SourceRectangle { get; private set; }
        public int LifeSpan { get; private set; }

        public AnimationFrame(Rectangle sourceRectangle, int lifeSpan)
        {
            SourceRectangle = sourceRectangle;
            LifeSpan = lifeSpan;
        }
    }
}
