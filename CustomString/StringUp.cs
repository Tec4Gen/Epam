using System;
using System.Data;
using System.Linq;

namespace CustomString
{
    public class StringUp
    {
        #region Properties And Fields

        private char[] _arrayString;
        public int Length { get { return _arrayString.Length; } }

        #endregion

        #region Constructors
        public StringUp(string value)
        {
            if (value == null)
                throw new ArgumentException("value " + "object reference not set to an instance of an object.");

            _arrayString = new char[value.Length];
            _arrayString = value.ToCharArray();
        }
        public StringUp(StringUp value)
        {
            if (value == null)
                throw new ArgumentException("value " + "object reference not set to an instance of an object.");

            _arrayString = new char[value.Length];
            Array.Copy(value._arrayString, _arrayString,value.Length);
        }
        public StringUp(char[] value)
        {
            if (value == null)
                throw new ArgumentException("value " + "object reference not set to an instance of an object.");

            _arrayString = new char[value.Length];
            Array.Copy(value, _arrayString, value.Length);
        }

        #endregion

        #region Append
        public void Append(StringUp value)
        {
            //StringUp temp = new StringUp(value);
            if (value == null)
                throw new ArgumentException("value " + "object reference not set to an instance of an object.");

            _arrayString = _arrayString.Concat(value._arrayString).ToArray();
        }

        public void Append(string value)
        {
            //StringUp temp = new StringUp(value);
            if (value == null)
                throw new ArgumentException("value "+"object reference not set to an instance of an object.");

            _arrayString = _arrayString.Concat(value.ToCharArray()).ToArray();
        }
        #endregion

        #region FindChar

        public int FindChar(char value) 
        {
            for (int i = 0; i < _arrayString.Length; i++)
            {
                if (_arrayString[i] == value)
                {
                    return i;
                }
            }
            return -1;
        }

        #endregion

        #region Z-function
        public int[] ZFunction()
        {
            int[] z = new int[_arrayString.Length];
            int l = 0, r = 0;

            for (int i = 1; i < _arrayString.Length; i++)
            {
                z[i] = Math.Max(0, Math.Min(r - i, z[i - l]));
                while (i + z[i] < _arrayString.Length && _arrayString[z[i]] == _arrayString[i + z[i]])
                    z[i]++;

                if (i + z[i] > r)
                {
                    l = i;
                    r = i + z[i];
                }
            }

            return z;
        }

        public static int[] ZFunction(string s)
        {
            int[] z = new int[s.Length];
            int l = 0, r = 0;

            for (int i = 1; i < s.Length; i++)
            {
                z[i] = Math.Max(0, Math.Min(r - i, z[i - l]));
                while (i + z[i] < s.Length && s[z[i]] == s[i + z[i]])
                    z[i]++;

                if (i + z[i] > r)
                {
                    l = i;
                    r = i + z[i];
                }
            }

            return z;
        }


        #endregion

        #region Equals
        public bool Equals(StringUp otherstringup)
        {
            if (Object.ReferenceEquals(this, otherstringup))
            {
                return true;
            }
            if (this.Length != otherstringup.Length)
            {
                return false;
            }

            for (int i = 0; i < otherstringup.Length; i++)
            {
                if (this[i] != otherstringup[i])
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region Overload
        public static bool operator == (StringUp firstvalue, StringUp secondvalue)
        {
            return Equals(firstvalue, secondvalue);
        }

        public static bool operator != (StringUp firstvalue, StringUp secondvalue)
        {
            return !Equals(firstvalue, secondvalue);
        }
        #endregion

        #region Conversions
        public static implicit operator StringUp(char[] value)
        {
            return new StringUp(value);
        }

        public static implicit operator char[](StringUp value)
        {
            char[] temp = { };

            Array.Copy(value._arrayString, temp, temp.Length);
            return temp;
        }
        #endregion

        #region Indexer
        public char this[int index]
        {
            get
            {
                return _arrayString[index];
            }
            set
            {
                _arrayString[index] = value;
            }
        }
        #endregion
    }
}
