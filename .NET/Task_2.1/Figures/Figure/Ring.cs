using System;
using Figures.Abstracts;
namespace Figures
{
    class Ring : AbstractCircle
    {
        public double InternalRadius { get; private set; }

        public override double Area
        {
            get
            {
                return Math.PI * (Radius * Radius - InternalRadius * InternalRadius);
            }
        }

        public double InternalCircumference
        {
            get
            {
                return 2 * Math.PI * InternalRadius;
            }
        }

        public double SumCircumference
        {
            get
            {
                return Circumference + InternalCircumference;
            }
        }
        public Ring()
        {

        }
        public Ring(double x, double y,double radius, double internalradius ) : base(x,y, radius)
        {
            InternalRadius = internalradius;
        }
    }
}
