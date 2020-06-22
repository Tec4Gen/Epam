using Figures.Abstracts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures.Figure
{
    public class BrokenLine : AbstactLine
    {
        public PointF PointThree { get; private set; }

        public BrokenLine()
        {

        }
        public BrokenLine(List<List<float>> vertexlist) : base(vertexlist)
        {
            if (vertexlist == null)
            {
                throw new ArgumentNullException();
            }
            if (vertexlist.Count() > 3)
            {
                throw new ArgumentException();
            }
            //vertexlist.Count() == 2
            else
            {
                PointThree = new PointF(vertexlist[2][0], vertexlist[2][1]);
            }
        }

    }
}
