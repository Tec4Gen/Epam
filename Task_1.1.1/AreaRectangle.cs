using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1._1._1
{
    class AreaRectangle
    {
        public ulong SideA { get; private set; }
        public ulong SideB { get; private set; }

        public AreaRectangle(ulong sidea, ulong sideb)
        {
            if (sidea == 0 || sideb == 0) 
            {
                throw new Exception();
            }
            SideA = sidea;
            SideB = sideb;
        }

        public ulong Area()
        { 
            return SideA * SideB;
        }
    }
}
