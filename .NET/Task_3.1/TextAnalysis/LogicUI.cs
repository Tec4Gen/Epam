using TextAnalysis;
using System.Configuration;

namespace TestMyCouting
{
    public static class LogicUI
    {
        public static void Go(string value)
        {
            Analisis a = new Analisis(value);
            a.ShowStatistics();
        }
    }
}
