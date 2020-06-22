using Figures.Abstracts;
using Figures.Figure;
using System;
using System.Collections.Generic;

namespace FigureConsolePL
{
    static public class Interface
    {
        static public List<List<float>> FillVertex(int number)
        {
            List<List<float>> vertex = new List<List<float>>();
            Console.WriteLine($"Enter {number} point");
            for (int i = 0; i < number; i++)
            {
                if (int.TryParse(Console.ReadLine(), out int x) &&
                    int.TryParse(Console.ReadLine(), out int y))
                {
                    vertex.Add(new List<float> { x, y });
                }
                else
                {
                    Console.WriteLine("Non-objective values");
                    return null;
                }
            }
            return vertex;
        }

        static public AbstractFigure CreateSpaceShip()
        {

            while (true)
            {
                Console.WriteLine($"SwitchFigure " +
                            Environment.NewLine +
                            "1)BrokenLine" + Environment.NewLine +
                            "2)Line" + Environment.NewLine +
                            "3)Circle" + Environment.NewLine +
                            "4)Ring" + Environment.NewLine +
                            "5)Triangle" + Environment.NewLine +
                            "6)Square" + Environment.NewLine +
                            "7)Parallelogram" + Environment.NewLine +
                            "8)Exit" + Environment.NewLine);

                if (int.TryParse(Console.ReadLine(), out int Number))
                {
                    switch (Number)
                    {
                        case 1:
                            
                            Console.WriteLine("Enter two Point");

                            var list = FillVertex(3);

                            if (list == null)
                            {
                                return new BrokenLine(list);
                            }
                            else
                            {
                                Console.WriteLine("Go back to the menu");
                                continue;
                            }
                            
                        case 2:                
                               //todo

                        default: return null;
                    }
                }
                else
                {
                    Console.WriteLine("Error ");
                    return null;
                }

            }
        }

    }
}

public enum TypeFigure
{
    None,
    BrokenLine,
    Line,
    Circle,
    Ring,
    Triangle,
    Square,
    Parallelogram
}