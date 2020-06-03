using System;
using System.Data;
using System.Linq;

namespace CustomString
{
    public class StringUp
    {
        #region Fields

        private char[] _arrayString;

        #endregion

        #region Constructors
        public StringUp(string value)
        {
            if (value == null)
                throw new NullReferenceException("value " + "object reference not set to an instance of an object.");

            _arrayString = new char[value.Length];
            _arrayString = value.ToCharArray();
        }
        public StringUp(StringUp value)
        {
            if (value == null)
                throw new NullReferenceException("value " + "object reference not set to an instance of an object.");

            _arrayString = new char[value.Length];
            Array.Copy(value._arrayString, _arrayString,value.Length);
        }
        public StringUp(char[] value)
        {
            if (value == null)
                throw new NullReferenceException("value " + "object reference not set to an instance of an object.");

            _arrayString = new char[value.Length];
            Array.Copy(value, _arrayString, value.Length);
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

        #region Append
        public void Append(StringUp value)
        {
            //StringUp temp = new StringUp(value);
            if (value == null)
                throw new NullReferenceException("value " + "object reference not set to an instance of an object.");

            _arrayString = _arrayString.Concat(value._arrayString).ToArray();
        }

        public void Append(string value)
        {
            //StringUp temp = new StringUp(value);
            if (value == null)
                throw new NullReferenceException("value "+"object reference not set to an instance of an object.");

            _arrayString = _arrayString.Concat(value.ToCharArray()).ToArray();
        }
        #endregion

        #region Properties
        public int Length { get { return _arrayString.Length; } }
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
    }
}



/*public static bool Equals(StringUp firstvalue, StringUp secondvalue)
        {
            if (firstvalue.Length != secondvalue.Length)
            {
                return false;
            }
            if (Object.ReferenceEquals(firstvalue, secondvalue))
            {
                return true;
            }

            for (int i = 0; i < firstvalue.Length; i++)
            {
                if (firstvalue[i] != secondvalue[i])
                {
                    return false;
                }
            }
            return true;
        }*/
