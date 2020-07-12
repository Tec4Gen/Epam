using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using MyDynamicArray;
namespace MyDynamicArray
{
    public class CycledDynamicArray<T> : DynamicArray<T>, ICloneable, IEnumerator<T>
    {
        public CycledDynamicArray(): base() {}
        public CycledDynamicArray(int value) : base(value) { }
        public CycledDynamicArray(IEnumerable<T> collection) : base(collection) { }

        //public override bool MoveNext()
        //{
        //    while (true)
        //    {
        //        if (_position < _size - 1)
        //        {
        //            _position++;
        //            return true;
        //        }
        //        Reset();
        //    }
        //}
        public override IEnumerator<T> GetEnumerator()
        {
            while (true)
            {
                for (int i = 0; i < _size; i++)
                {
                    yield return _items[i];
                }
            }
        }
    }
}
