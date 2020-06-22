using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Figures.Abstracts
{
    public abstract class AbstactLine : AbstractFigure
    {
        public PointF PointOne { get; private set; }
        public PointF PointTwo { get; private set; }
        //public double Length { get; set; }

        private double _length;
        public double Length 
        {
            get 
            {
                return _length; 
            }

            private set 
            {
                //Logic counting
            }
        }
        public AbstactLine()
        {

        }
        public AbstactLine(List<List<float>> vertexlist)
        {
            if (vertexlist == null)
            {
                throw new ArgumentNullException();
            }
            if (vertexlist.Count() < 2)
            {
                throw new ArgumentException();
            }
            //vertexlist.Count() == 2
            else
            {
                PointOne = new PointF(vertexlist[0][0], vertexlist[0][1]);
                PointTwo = new PointF(vertexlist[1][0], vertexlist[1][1]);
            }
        }
    }
}
