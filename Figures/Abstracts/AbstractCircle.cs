using System;

namespace Figures.Abstracts
{
    public abstract class AbstractCircle : AbstractFigure
    {
        //private int _x;
        public double XPosition { get; private set; }

        //private int _y;
        public double YPosition { get; private set; }

       //private int _radius;
        public double Radius { get; private set; }

        //private int _circumference;
        public double Circumference 
        { 
            get 
            {
                return 2 * Math.PI * Radius; 
            } 
        }

        //private int _area;
        public abstract double Area { get; }

        public AbstractCircle(double x, double y,double radius)
        {
            XPosition = x;
            YPosition = y;
            Radius = radius;
        }
    }
}
