using System;
using System.Collections.Generic;
using System.Text;
using TopDownRpg.Engine.Input;

namespace TopDownRpg.States.Dev
{
    public class DevInputCommand : BaseInputCommand
    {
        public class DevQuit : DevInputCommand { }
        public class DevUp : DevInputCommand { }
        public class DevRight : DevInputCommand { }
        public class DevDown : DevInputCommand { }
        public class DevLeft : DevInputCommand { }

    }
}
