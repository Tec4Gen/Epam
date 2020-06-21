using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Figures.Abstracts
{
    public abstract class AbstractQuadrangle : AbstractFigure
    {
        public PointF PointOne { get; private set; }
        public PointF PointTwo { get; private set; }
        public PointF PointThree { get; private set; }
        public PointF PointFour { get; private set; }

        public double SideA { get; private set; }
        public double SideB { get; private set; }
        public double Perimeter { get { return (SideA + SideB) * 2; } }
        public abstract double Area { get; }

        public AbstractQuadrangle(List<List<float>> vertexlist)
        {
            if (vertexlist == null)
            {
                throw new ArgumentNullException();
            }
            if (vertexlist.Count() < 4 || vertexlist.Count() > 4)
            {
                throw new ArgumentException();
            }
            if (vertexlist.Count() == 4)
            {
                PointOne = new PointF(vertexlist[0][0], vertexlist[0][1]);
                PointTwo = new PointF(vertexlist[1][0], vertexlist[1][1]);
                PointThree = new PointF(vertexlist[2][0], vertexlist[2][1]);
                PointFour = new PointF(vertexlist[3][0], vertexlist[3][1]);

                SideA = Math.Sqrt(Math.Pow((PointOne.X - PointTwo.X), 2) + Math.Pow((PointOne.Y - PointTwo.Y), 2));
                SideB = Math.Sqrt(Math.Pow((PointTwo.X - PointThree.X), 2) + Math.Pow((PointTwo.Y - PointThree.Y), 2));     
            }
        }
    }
}
