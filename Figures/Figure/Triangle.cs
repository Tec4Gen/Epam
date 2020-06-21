using System;
using System.Collections.Generic;
using Figures.Abstracts;

namespace Figures.Figure
{
    public class Triangle : AbstractTriangle
    {
        public Triangle(List<List<float>> vertexlist) : base(vertexlist)
        {
        }

        public override double Area
        {
            get
            {
                return Math.Sqrt(HalfMeter * (HalfMeter - SideA) * (HalfMeter - SideB) * (HalfMeter - SideC));
            }
        }
    }
}
