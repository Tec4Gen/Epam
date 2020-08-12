using Figures.Abstracts;
using System.Collections.Generic;

namespace Figures.Figure
{
    public class Square : AbstractQuadrangle
    {
        public override double Area { get { return SideA * SideA; } }
        public Square()
        {

        }
        public Square(List<List<float>> vertexlist) : base(vertexlist)
        {
        }

       
    }
}
