using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    class Storage : CentralComputer
    {
        public Storage(int memory, int state)
        {
            this.memory = memory;
            this.state = state;
        }
        public override void TurnOn()
        {
            state = 1;
        }
        public override void Reboot()
        {
            memory = 0;
        }
        public override void TurnOff()
        {
            state = 0;
        }
    }
}
