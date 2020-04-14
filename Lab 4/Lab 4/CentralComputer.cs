using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    public abstract class CentralComputer
    {
        protected int memory;
        protected int state;
        abstract public void TurnOn();
        abstract public void Reboot();
        abstract public void TurnOff();
        public int Memory()
        {
            return memory;
        }
        public int State()
        {
            return state;
        }
    }
}
