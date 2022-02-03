using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TopDownRpg.Engine.Objects.Animations;

namespace TopDownRpg.Objects.AnimationBuilders
{
    public class PlayerAnimationBuilder
    {
        public Texture2D spriteSheet;

        private const int AnimationCellWidth = 48;
        private const int AnimationCellHeight = 48;
        private const int AnimationSpeed = 3;

        public Animation Idle { get; private set; } = new Animation(true);
        public Animation Walk { get; private set; } = new Animation(true);
        public Animation Jump { get; private set; } = new Animation(false);
        public Animation Land { get; private set; } = new Animation(false);
        public Animation Hurt { get; private set; } = new Animation(false);
        public Animation Death { get; private set; } = new Animation(false);
        public Animation Attack1 { get; private set; } = new Animation(false);
        public Animation Attack2 { get; private set; } = new Animation(false);
        public Animation Attack3 { get; private set; } = new Animation(false);

        public PlayerAnimationBuilder(Texture2D sprite)
        {
            spriteSheet = sprite;

            Idle.AddFrame(new Rectangle(0, 240, AnimationCellWidth, AnimationCellHeight), AnimationSpeed);
            Idle.AddFrame(new Rectangle(48, 240, AnimationCellWidth, AnimationCellHeight), AnimationSpeed);
            Idle.AddFrame(new Rectangle(96, 240, AnimationCellWidth, AnimationCellHeight), AnimationSpeed);
            Idle.AddFrame(new Rectangle(144, 240, AnimationCellWidth, AnimationCellHeight), AnimationSpeed);
            Idle.AddFrame(new Rectangle(192, 240, AnimationCellWidth, AnimationCellHeight), AnimationSpeed);

            Walk.AddFrame(new Rectangle(0, 384, AnimationCellWidth, AnimationCellHeight), AnimationSpeed - 2);
            Walk.AddFrame(new Rectangle(48, 384, AnimationCellWidth, AnimationCellHeight), AnimationSpeed - 2);
            Walk.AddFrame(new Rectangle(96, 384, AnimationCellWidth, AnimationCellHeight), AnimationSpeed - 2);
            Walk.AddFrame(new Rectangle(144, 384, AnimationCellWidth, AnimationCellHeight), AnimationSpeed - 2);
            Walk.AddFrame(new Rectangle(192, 384, AnimationCellWidth, AnimationCellHeight), AnimationSpeed - 2);
            Walk.AddFrame(new Rectangle(240, 384, AnimationCellWidth, AnimationCellHeight), AnimationSpeed - 2);
            Walk.AddFrame(new Rectangle(288, 384, AnimationCellWidth, AnimationCellHeight), AnimationSpeed - 2);
            Walk.AddFrame(new Rectangle(336, 384, AnimationCellWidth, AnimationCellHeight), AnimationSpeed - 2);

            Jump.AddFrame(new Rectangle(0, 288, AnimationCellWidth, AnimationCellHeight), AnimationSpeed);
            Jump.AddFrame(new Rectangle(48, 288, AnimationCellWidth, AnimationCellHeight), AnimationSpeed);
            Jump.AddFrame(new Rectangle(96, 288, AnimationCellWidth, AnimationCellHeight), AnimationSpeed);
            Jump.AddFrame(new Rectangle(144, 288, AnimationCellWidth, AnimationCellHeight), AnimationSpeed);
            Jump.AddFrame(new Rectangle(192, 288, AnimationCellWidth, AnimationCellHeight), AnimationSpeed);

            Land.AddFrame(new Rectangle(0, 336, AnimationCellWidth, AnimationCellHeight), AnimationSpeed);
            Land.AddFrame(new Rectangle(48, 336, AnimationCellWidth, AnimationCellHeight), AnimationSpeed);
            Land.AddFrame(new Rectangle(96, 336, AnimationCellWidth, AnimationCellHeight), AnimationSpeed);
            Land.AddFrame(new Rectangle(144, 336, AnimationCellWidth, AnimationCellHeight), AnimationSpeed);
            Land.AddFrame(new Rectangle(192, 336, AnimationCellWidth, AnimationCellHeight), AnimationSpeed);

            Hurt.AddFrame(new Rectangle(0, 192, AnimationCellWidth, AnimationCellHeight), AnimationSpeed);
            Hurt.AddFrame(new Rectangle(48, 192, AnimationCellWidth, AnimationCellHeight), AnimationSpeed);
            Hurt.AddFrame(new Rectangle(96, 192, AnimationCellWidth, AnimationCellHeight), AnimationSpeed);
            Hurt.AddFrame(new Rectangle(144, 192, AnimationCellWidth, AnimationCellHeight), AnimationSpeed);

            Death.AddFrame(new Rectangle(0, 144, AnimationCellWidth, AnimationCellHeight), AnimationSpeed);
            Death.AddFrame(new Rectangle(48, 144, AnimationCellWidth, AnimationCellHeight), AnimationSpeed);
            Death.AddFrame(new Rectangle(96, 144, AnimationCellWidth, AnimationCellHeight), AnimationSpeed);
            Death.AddFrame(new Rectangle(144, 144, AnimationCellWidth, AnimationCellHeight), AnimationSpeed);
            Death.AddFrame(new Rectangle(192, 144, AnimationCellWidth, AnimationCellHeight), AnimationSpeed);

            Attack1.AddFrame(new Rectangle(0, 0, AnimationCellWidth, AnimationCellHeight), AnimationSpeed);
            Attack1.AddFrame(new Rectangle(48, 0, AnimationCellWidth, AnimationCellHeight), AnimationSpeed);
            Attack1.AddFrame(new Rectangle(96, 0, AnimationCellWidth, AnimationCellHeight), AnimationSpeed);
            Attack1.AddFrame(new Rectangle(144, 0, AnimationCellWidth, AnimationCellHeight), AnimationSpeed);
            Attack1.AddFrame(new Rectangle(192, 0, AnimationCellWidth, AnimationCellHeight), AnimationSpeed);
            Attack1.AddFrame(new Rectangle(240, 0, AnimationCellWidth, AnimationCellHeight), AnimationSpeed);

            Attack2.AddFrame(new Rectangle(0, 48, AnimationCellWidth, AnimationCellHeight), AnimationSpeed);
            Attack2.AddFrame(new Rectangle(48, 48, AnimationCellWidth, AnimationCellHeight), AnimationSpeed);
            Attack2.AddFrame(new Rectangle(96, 48, AnimationCellWidth, AnimationCellHeight), AnimationSpeed);
            Attack2.AddFrame(new Rectangle(144, 48, AnimationCellWidth, AnimationCellHeight), AnimationSpeed);
            Attack2.AddFrame(new Rectangle(192, 48, AnimationCellWidth, AnimationCellHeight), AnimationSpeed);
            Attack2.AddFrame(new Rectangle(240, 48, AnimationCellWidth, AnimationCellHeight), AnimationSpeed);

            Attack3.AddFrame(new Rectangle(0, 96, AnimationCellWidth, AnimationCellHeight), AnimationSpeed);
            Attack3.AddFrame(new Rectangle(48, 96, AnimationCellWidth, AnimationCellHeight), AnimationSpeed);
            Attack3.AddFrame(new Rectangle(96, 96, AnimationCellWidth, AnimationCellHeight), AnimationSpeed);
            Attack3.AddFrame(new Rectangle(144, 96, AnimationCellWidth, AnimationCellHeight), AnimationSpeed);
            Attack3.AddFrame(new Rectangle(240, 96, AnimationCellWidth, AnimationCellHeight), AnimationSpeed);

        }
    }
}
