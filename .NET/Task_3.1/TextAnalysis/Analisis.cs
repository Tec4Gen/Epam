using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalysis
{
    public class Analisis
    {
        public List<string> Data { get; private set; }

        public Dictionary<string, int> Dictionary { get; private set; }

        public Analisis(string value)
        {
            if (value == null)
                throw new ArgumentNullException();
            if (value.Length < 10)
                throw new ArgumentException();


            Dictionary = new Dictionary<string, int>();

            var part = new char[] { ' ', ',', '.', '!', '?', ':', ';', '"', '[', ']', '{', '}', '-', '\r', '\n' };
            Data = value.Split(part, StringSplitOptions.RemoveEmptyEntries).ToList();


            for (int i = 0; i < Data.Count(); i++)
            {
                if (Data[i] == "-" || Data[i] == "–") //и множество других разделителей 
                    Data.RemoveAt(i--);
            }

            foreach (var item in Data.Distinct())
            {
                Dictionary.Add(item, Data.Count(x => x.Equals(item)));
            }
        }

        public void ShowStatistics() 
        {
            Console.WriteLine($"Total words: {Dictionary.Count}");
            foreach (var item in Dictionary)
            {

                Console.WriteLine(new String('=', 40) + Environment.NewLine +
                         $"=>|{item.Key} " +
                         $"|Counts: {item.Value} " +
                         $"|Percent: {item.Value * 100 / Data.Count()}%");
            }
        }
    }
}
