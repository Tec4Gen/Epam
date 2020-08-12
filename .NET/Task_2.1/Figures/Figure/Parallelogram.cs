using Figures.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures.Figure
{
    class Parallelogram : AbstractQuadrangle
    {

        //Просто макет
        //Ромб и параллерограм в одном
        public int DiagonalOne { get; }

        public int DiagonalTwo { get; }

        public int Heigth { get; }

        public override double Area => throw new NotImplementedException();

        public Parallelogram()
        {

        }
        public Parallelogram(List<List<float>> vertexlist) : base(vertexlist)
        {

        }

    }
}
