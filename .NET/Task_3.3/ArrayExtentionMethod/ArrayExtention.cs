using System;
using System.Collections.Generic;
using System.Linq;

namespace ArrayExtentionMethod
{

    public static class ArrayExtention
    {
        #region MySum
        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <exception cref="ArithmeticException"></exception>
        /// <returns></returns>
        public static int MySum(this byte[] array)
        {
            if (array == null)
                throw new ArgumentNullException("array", "argument cannot be null");

            checked
            {
                try
                {
                    int MySum = 0;
                    for (int i = 0; i < array.Length; i++)
                    {
                        MySum += array[i];
                    }
                    return MySum;
                }
                catch (ArithmeticException ex)
                {
                    throw new OverflowException(ex.Message + " Amount caused Int type overflow");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <exception cref="ArithmeticException"></exception>
        /// <returns></returns>
        public static int MySum(this sbyte[] array)
        {
            if (array == null)
                throw new ArgumentNullException("array", "argument cannot be null");

            checked
            {
                try
                {
                    int MySum = 0;
                    for (int i = 0; i < array.Length; i++)
                    {
                        MySum += array[i];
                    }
                    return MySum;
                }
                catch (ArithmeticException ex)
                {
                    throw new OverflowException(ex.Message + " Amount caused Int type overflow");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <exception cref="ArithmeticException"></exception>
        /// <returns></returns>
        public static int MySum(this short[] array)
        {
            if (array == null)
                throw new ArgumentNullException("array", "argument cannot be null");

            checked
            {
                try
                {
                    int MySum = 0;
                    for (int i = 0; i < array.Length; i++)
                    {
                        MySum += array[i];
                    }
                    return MySum;
                }
                catch (ArithmeticException ex)
                {
                    throw new OverflowException(ex.Message + " Amount caused Int type overflow");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <exception cref="ArithmeticException"></exception>
        /// <returns></returns>
        public static int MySum(this ushort[] array)
        {
            if (array == null)
                throw new ArgumentNullException("array", "argument cannot be null");

            checked
            {
                try
                {
                    int MySum = 0;
                    for (int i = 0; i < array.Length; i++)
                    {
                        MySum += array[i];
                    }
                    return MySum;
                }
                catch (ArithmeticException ex)
                {
                    throw new OverflowException(ex.Message + " Amount caused Int type overflow");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <exception cref="OverflowException"></exception>
        /// <returns></returns>
        public static int MySum(this int[] array)
        {
            if (array == null)
                throw new ArgumentNullException("array", "argument cannot be null");
            try
            {
                return array.Sum();
            }
            catch (OverflowException ex)
            {
                throw new OverflowException(ex.Message + " Amount caused Int type overflow");
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <exception cref="OverflowException"></exception>
        /// <returns></returns>
        public static long MySum(this long[] array)
        {
            if (array == null)
                throw new ArgumentNullException("array", "argument cannot be null");
            try
            {
                return array.Sum();
            }
            catch (OverflowException ex)
            {

                throw new OverflowException(ex.Message + " Amount caused Int type overflow");
            }
        }

        public static decimal MySum(this decimal[] array)
        {
            if (array == null)
                throw new ArgumentNullException("array", "argument cannot be null");
            try
            {
                return array.Sum();
            }
            catch (OverflowException ex)
            {

                throw new OverflowException(ex.Message + " Amount caused Int type overflow");
            }
        }
        #endregion

        #region MyAvverage
        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <exception cref="ArithmeticException"></exception>
        /// <returns></returns>
        public static double MyAverage(this byte[] array)
        {
            if (array == null)
                throw new ArgumentNullException("array", "argument cannot be null");
            if (array.Length == 0)
                throw new ArgumentException("Length array cannot be equals zero");
            try
            {
                return array.MySum() / array.Length;
            }
            catch (ArithmeticException ex)
            {
                throw new OverflowException(ex.Message + " Amount caused Int type overflow");
            }
        }

        public static double MyAverage(this sbyte[] array)
        {
            if (array == null)
                throw new ArgumentNullException("array", "argument cannot be null");
            if (array.Length == 0)
                throw new ArgumentException("Length array cannot be equals zero");
            try
            {
                return array.MySum() / array.Length;
            }
            catch (ArithmeticException ex)
            {
                throw new OverflowException(ex.Message + " Amount caused Int type overflow");
            }
        }

        public static double MyAverage(this short[] array)
        {
            if (array == null)
                throw new ArgumentNullException("array", "argument cannot be null");
            if (array.Length == 0)
                throw new ArgumentException("Length array cannot be equals zero");
            try
            {
                return array.MySum() / array.Length;
            }
            catch (ArithmeticException ex)
            {
                throw new OverflowException(ex.Message + " Amount caused Int type overflow");
            }
        }

        public static double MyAverage(this ushort[] array)
        {
            if (array == null)
                throw new ArgumentNullException("array", "argument cannot be null");
            if (array.Length == 0)
                throw new ArgumentException("Length array cannot be equals zero");
            try
            {
                return array.MySum() / array.Length;
            }
            catch (ArithmeticException ex)
            {
                throw new OverflowException(ex.Message + " Amount caused Int type overflow");
            }
        }

        public static double MyAverage(this int[] array)
        {
            if (array == null)
                throw new ArgumentNullException("array", "argument cannot be null");
            if (array.Length == 0)
                throw new ArgumentException("Length array cannot be equals zero");

            return array.Average();
        }

        public static double MyAverage(this long[] array)
        {
            if (array == null)
                throw new ArgumentNullException("array", "argument cannot be null");
            if (array.Length == 0)
                throw new ArgumentException("Length array cannot be equals zero");

            return array.Average();
        }

        public static decimal MyAverage(this decimal[] array)
        {
            if (array == null)
                throw new ArgumentNullException("array", "argument cannot be null");
            if (array.Length == 0)
                throw new ArgumentException("Length array cannot be equals zero");

            return array.Average();
        }

        #endregion

        #region CommonElement

        public static T CommonElement<T>(this T[] array)
        {
            if (array == null)
                throw new ArgumentNullException("array", "argument cannot be null");
            if (array.Length == 0)
                throw new ArgumentException("Length array cannot be equals zero");

            var group = array.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            var element = group.FirstOrDefault(x => x.Value == group.Values.Max()).Key;

            return element;
        }
   
        #endregion

        #region Modification

        public static IEnumerable<T> ArrayModifi<T>(this T[] array, Func<T, T> function)
        {
            if (array == null)
                throw new ArgumentNullException("array", "argument cannot be null");
            if (array.Length == 0)
                throw new ArgumentException("Length array cannot be equals zero");

            T[] temp = new T[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                temp[i] = function.Invoke(array[i]);
            }

            return temp;
        }

        #endregion
    }
}