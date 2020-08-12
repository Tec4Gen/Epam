using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
namespace MyExtentionString
{
    public static class ExtentionString
    {
        public static Language GetLanguage(this string value) 
        {
            if (value == null)
                throw new ArgumentNullException("Value connot be null");
            if (value.Length == 0)
                return Language.None;

            var part = new char[] { ' ', ',', '.', '!', '?', ':', ';', '"', '[', ']', '{', '}', '-', '\r', '\n' };
            var srtArray = value.Split(part);

            if (srtArray.Length > 1)
            {
                return Language.Mixed;
            }

            else if (srtArray[0].All(wordByte => wordByte > 128))
            {
                return Language.Russian;
            }

            else if (srtArray[0].All(wordByte => wordByte > 57 && wordByte < 128))
            {
                return Language.English;
            }

            else if (srtArray[0].All(wordByte => wordByte > 47 && wordByte < 58))
            {
                return Language.Numeric;
            }
            else 
            {
                return Language.Mixed;
            }
        }
    }
}
