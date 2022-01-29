using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using TopDownRpg.Engine.Input;

namespace TopDownRpg.States.Dev
{
    public class DevInputMapper : BaseInputMapper
    {
        public override IEnumerable<BaseInputCommand> GetKeyboardState(KeyboardState state)
        {
            var commands = new List<DevInputCommand>();

            if (state.IsKeyDown(Keys.Escape))
            {
                commands.Add(new DevInputCommand.DevQuit());
            }
            if (state.IsKeyDown(Keys.W))
            {
                commands.Add(new DevInputCommand.DevUp());
            }
            if (state.IsKeyDown(Keys.D))
            {
                commands.Add(new DevInputCommand.DevRight());
            }
            if (state.IsKeyDown(Keys.S))
            {
                commands.Add(new DevInputCommand.DevDown());
            }
            if (state.IsKeyDown(Keys.A))
            {
                commands.Add(new DevInputCommand.DevLeft());
            }

            return commands;
        }
    }
}
