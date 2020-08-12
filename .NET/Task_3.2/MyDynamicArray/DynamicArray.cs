using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MyDynamicArray
{
    public class DynamicArray<T> : IList<T>, ICollection<T>, ICloneable, IEnumerator<T>
    {
        #region Filds and Properties
        protected T[] _items;

        protected int _size;

        protected int _position = -1;

        public int Count
        {
            get
            {
                return _size;
            }
        }

        public int Capacity
        {
            get
            {
                return _items.Length;
            }
            set
            {
                if (value < _size) 
                {
                    T[] temp = new T[value];
                    Array.Copy(_items, 0, temp, 0, value);
                    _items = temp;
                    _size = value;
                }
                   


                if (value == _items.Length)
                {
                    return;
                }

                if (value > 0)
                {
                    T[] temp = new T[value];
                    if (_size > 0)
                        Array.Copy(_items, 0, temp, 0, _size);

                    _items = temp;
                }


            }
        }

        public bool IsReadOnly { get { return false; } }


        #endregion

        #region Indexer
        public T this[int index]
        {
            get
            {
                if (Math.Abs(index) > _size - 1)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else if (index < 0) 
                {
                    return _items[_size - Math.Abs(index)];
                }
                else
                {

                    return _items[index];
                }

            }
            set
            {
                if (index < 0 || index > _size - 1)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {

                    _items[index] = value;
                }
            }
        }
        #endregion

        #region Ctor
        public DynamicArray()
        {
            _items = new T[8];
        }
        public DynamicArray(int value)
        {
            if (value < 0) 
            {
                throw new ArgumentException();
            }
            else
            {
                _items = new T[value];
            }
           
        } 
        public DynamicArray(IEnumerable<T> collectionSource)
        {
            if (collectionSource == null)
                throw new ArgumentNullException("collection", "connot be null referense");

            ICollection<T> collectionSecond = collectionSource as ICollection<T>;

            if (collectionSecond != null) 
            {
                int count = collectionSecond.Count;

                if (count == 0) 
                {
                    _items = new T[8];
                }
                
                if (count > 0)
                { 
                    _items = new T[collectionSecond.Count * 2];

                    collectionSecond.CopyTo(_items, 0);
                    _size = count;
                    return;
                }
            }
        }

        #endregion

        #region Methods
        public void Add(T item)
        {
            if (_size == _items.Length)
            {
                T[] temp = _size == 0 ? new T[8] : new T[_items.Length * 2];
                CopyTo(temp, 0);

                temp[_size++] = item;
                _items = temp;
            }
            else
            {
                _items[_size++] = item;
            }
        }
        public void AddRange(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException();
            if (collection.Count() == 0)
                return;

            if (collection.Count() + _size < Capacity)
            {
                Array.Copy(collection.ToArray(), 0, _items, Count, collection.Count());
                _size += collection.Count();
            }
            else
            {
                T[] temp = new T[(collection.Count() + _size) * 2];
                Array.Copy(_items, 0, temp, 0, _size);
                Array.Copy(collection.ToArray(), 0, temp, Count, collection.Count());

                _items = temp;
                _size += collection.Count();
            }

        }
        public void Clear()
        {
            _items = new T[8];
        }

        public object Clone()
        {
            return new DynamicArray<T>(_items);
        }

        public bool Contains(T item)
        {
            if (item == null)
            {
                for (int i = 0; i < _size; i++)
                {
                    if (_items[i] == null)
                    {
                        return true;
                    }
                }

                return false;
            }

            for (int i = 0; i < _size; i++)
            {
                if (_items[i].Equals(item))
                {
                    return true;
                }
            }

            return false;

        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(_items, 0, array, arrayIndex, _size);
        }



        public int IndexOf(T item)
        {
            return Array.IndexOf(_items, item, 0, _size);
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > _size)
                throw new ArgumentOutOfRangeException();
            if (index == _items.Length)
            {
                Add(item);
            }
            else
            {
                if (_size + 1 < Capacity)
                {
                    _size++;
                    T temp;
                    for (int i = Count - 1; i >= index; i--)
                    {
                        temp = _items[i];
                        _items[i + 1] = temp;
                    }
                    _items[index] = item;
                }
            }
        }

        public bool IsInsert(int index, T item)
        {
            if (index < 0 || index > _size)
                throw new ArgumentOutOfRangeException();
            if (index == _items.Length)
            {
                Add(item);
                return true;
            }
            else
            {

                T temp;
                for (int i = Count - 1; i >= index; i--)
                {
                    temp = _items[i];
                    _items[i + 1] = temp;

                }
                _items[index] = item;
                _size++;
                if (_size == Capacity)
                {
                    T[] tempArray = new T[Capacity * 2];
                    Array.Copy(_items, 0, tempArray, 0, _size);
                    _items = tempArray;
                }

                return true;
            }
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);

            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _size)
                throw new ArgumentOutOfRangeException();

            if (index < _size)
            {
                Array.Copy(_items, index + 1, _items, index, _size - index);
                _size--;
            }
        }

        public T[] ToArray() 
        {
            T[] temp = new T[_size];

            Array.Copy(_items, 0, temp, 0, _size);

            return temp;
        }
        #endregion

        #region Enumerator
        public T Current
        {
            get
            {
                if (_position == -1 || _position >= _size)
                    throw new ArgumentOutOfRangeException();
                return _items[_position];
            }
        }
        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }
        public virtual bool MoveNext()
        {
            if (_position < _size -1)
            {
                _position++;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            _position = -1;
        }

        public void Dispose()
        {
        }

        public virtual IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }

        #endregion
    }
}
