using System;
using Figures.Abstracts;

namespace Figures
{
    public class Circle : AbstractCircle
    {
        public override double Area
        {
            get
            {
                return Math.PI * (Radius * Radius);
            }
        }

        public Circle(double x, double y, double radius) : base(x, y, radius)
        {
        }
    }
}
