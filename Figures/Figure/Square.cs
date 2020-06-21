using Figures.Abstracts;
using System.Collections.Generic;

namespace Figures.Figure
{
    public class Square : AbstractQuadrangle
    {
        public Square(List<List<float>> vertexlist) : base(vertexlist)
        {
        }

        public override double Area { get { return SideA * SideA; } }
    }
}
