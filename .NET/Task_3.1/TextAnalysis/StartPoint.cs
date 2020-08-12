using System.Collections.Generic;
using System.IO;
using System.Text;
using TestMyCouting;

namespace TextAnalysis
{
    class StartPoint
    {
        static void Main(string[] args)
        {
            using (StreamReader fileIn = new StreamReader("../../../input.txt", Encoding.GetEncoding(1251)))
            {
                string str = fileIn.ReadToEnd().ToLowerInvariant();

                LogicUI.Go(str);
            }
        }
    }
}
