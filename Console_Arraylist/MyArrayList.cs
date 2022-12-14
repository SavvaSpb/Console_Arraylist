using System;
using System.Collections;
using System.Diagnostics.Contracts;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Reflection;

namespace Console_Arraylist
{
    public class MyArrayList : IList
    {
        private object[] _items;
        private int _size;
        

        private const int _defaultCapacity = 4;
        private object[] emptyarray = new object[0];

        public MyArrayList(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException("capacity");

            if (capacity == 0)
                _items = emptyarray;
            else
                _items = new object[capacity];
        }

        public object? this[int index]
        {
            get
            {
                if (index < 0 || index >= _size) throw new ArgumentOutOfRangeException("index");
                return _items[index];
            }
            set
            {
                if (index < 0 || index >= _size) throw new ArgumentOutOfRangeException("index");
                _items[index] = value;
            }
        }

        public int Add(object? value)
        {
            if(this._size == _items.Length)
            {
                EnsureCapacity(this._size + 1);
            }
            //object[] a = new object[_items.Length + 1];

            _items[_size] = value!;
            _size++;

            //for (int i = 0; i < _items.Length; i++)
            //{
            //    a[i] = _items[i];
            //}
            //a[a.Length - 1] = value;
            //_items = a;

            return _size;
        }


         public int IndexOf(object value)
        {
            return IndexOf(value, 0);
        }


         public int IndexOf (object value, int startIndex)
        {
            for (int i = startIndex; i < _items.Length; i++)
            {
                if (_items[i].Equals(value))
                {
                  return i;
                }
            }
            return -1;
        }

        public void Remove(Object value)
        {
            int index = IndexOf(value);
            if (index >= 0)
                RemoveAt(index);
        }


        public bool Contains(object value)
        {
            return IndexOf(value) != -1;
        }

        public void Clear()
        {
            _items = new object[0];
        }

        public int Count
            { get { return _size; } }

        public bool IsSynchronized => throw new NotImplementedException(); // nt imp

        public object SyncRoot => throw new NotImplementedException(); // nt imp

        public bool IsFixedSize => false;

        public bool IsReadOnly => false;

        public int Capacity { 
            get
            {
                return _items.Length;
            }
            private set
            {
                if (value < _size)
                {
                    throw new ArgumentOutOfRangeException("value");
                }

                if (value != _items.Length)
                {
                    if (value > 0)
                    {
                        Object[] newItems = new Object[value];
                        if (_size > 0)
                        {
                            Array.Copy(_items, 0, newItems, 0, _size);
                        }
                        _items = newItems;
                    }
                    else
                    {
                        _items = new Object[_defaultCapacity];
                    }
                }
            }
        }

        public void CopyTo(Array array, int arrayIndex)
        {
            if ((array != null) && (array.Rank != 1))
                throw new ArgumentException();

            Contract.EndContractBlock();
            Array.Copy(_items, 0, array, arrayIndex, _size);
        }


        public virtual void Insert(int index, Object value)
        {
            if (index < 0 || index > _size) throw new ArgumentOutOfRangeException("index");
            if (_size == _items.Length) EnsureCapacity(_size + 1);
            if (index < _size)
            {
                Array.Copy(_items, index, _items, index + 1, _size - index);
            }
            _items[index] = value;
            _size++;
        }

        public virtual void RemoveAt(int index)
        {
            if (index < 0 || index >= _size)
                throw new ArgumentOutOfRangeException("index");

            _size--;
            
            if (index < _size)
            {
                Array.Copy(_items, index + 1, _items, index, length: _size - index);
            }
            
            _items[_size] = null!;
        }


        private void EnsureCapacity(int min)
        {
            if (_items.Length >= min)
            {
                return;
            }
            int newCapacity = _items.Length == 0 ? _defaultCapacity : _items.Length * 2;
            if ((uint)newCapacity > 10000) newCapacity = 10000;
            if (newCapacity < min) newCapacity = min;
            Capacity = newCapacity;
        }



        IEnumerator IEnumerable.GetEnumerator()
        {
            return new MyArrayListEnumerator(this);
        }
    }

    public class MyArrayListEnumerator : IEnumerator
    {
        private MyArrayList? _items;
        int index = -1;
        private object? currentElement;

        public MyArrayListEnumerator(MyArrayList? arrayList)
        {
            this._items = arrayList;
        }

        public object? Current => currentElement;

        public bool MoveNext()
        {
            if (index == _items.Count - 1)
                return false;

            index++;
            currentElement = _items[index];
            return true;
        }

        public void Reset()
        {
            //index = startIndex - 1;
            //int checkForZero = 1;
            //for (int i = 0; i < array.Rank; i++)
            //{
            //    _indices[i] = array.GetLowerBound(i);
            //    checkForZero *= array.GetLength(i);
            //}
            //_complete = (checkForZero == 0);
            //// To make MoveNext simpler, decrement least significant index.
            //_indices[_indices.Length - 1]--;
            throw new NotImplementedException();
        }
    }
}



