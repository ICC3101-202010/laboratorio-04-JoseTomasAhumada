using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    class Reception : CentralComputer , IRecieve 
    {
        public Reception(int memory, int state)
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
        public void Recieve()
        {
            Console.WriteLine("Piezas recibidas correctamente.");
        }
    }
}
