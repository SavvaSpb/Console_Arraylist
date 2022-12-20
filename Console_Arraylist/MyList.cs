using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Console_Arraylist
{
    public class MyList<T> : IList<T>
    {
        private T[] _items;
        
        private int _size;
        
        private const int _defaultCapacity = 4;
        
        private T[] _emptyarray = new T[0];
        


        public MyList()
        {
            _items = _emptyarray;
        }

        public MyList(int capacity)
        {
            if (capacity < 0) throw new ArgumentException(); //ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.capacity, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
            Contract.EndContractBlock();

            if (capacity == 0)
                _items = _emptyarray;
            else
                _items = new T[capacity];
        }


        public T this[int index]
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


        public void Add(T value)
        {
            if (_size == _items.Length) EnsureCapacity(_size + 1);
            _items[_size++] = value;
        }

        public int IndexOf(T value)
        {
            return Array.IndexOf(_items, value, 0, _size);
        }

        public int IndexOf(T value, int index)
        {
            if (index > _size) throw new ArgumentOutOfRangeException("index");
            return Array.IndexOf(_items, value, index, _size - index);

        }

        public bool Remove(T value)
        {
            int index = IndexOf(value);
            if (index >= 0)
                RemoveAt(index);
            return true;
        }

        public bool Contains(T value)
        {
            if ((Object)value == null)
            {
                for (int i = 0; i < _size; i++)
                    if ((Object)_items[i] == null)
                        return true;
                return false;
            }
            else
            {
                EqualityComparer<T> c = EqualityComparer<T>.Default;
                for (int i = 0; i < _size; i++)
                {
                    if (c.Equals(_items[i], value)) return true;
                }
                return false;
            }
        }


        public int Count
        { get { return _size; } }

        public bool IsReadOnly => throw new NotImplementedException();

        public int Capacity
        {
            get
            {
                Contract.Ensures(Contract.Result<int>() >= 0);
                return _items.Length;
            }
            set
            {
                if (value < _size)
                {
                    throw new ArgumentOutOfRangeException(); //ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.value, ExceptionResource.ArgumentOutOfRange_SmallCapacity);
                }
                Contract.EndContractBlock();

                if (value != _items.Length)
                {
                    if (value > 0)
                    {
                        T[] newItems = new T[value];
                        if (_size > 0)
                        {
                            Array.Copy(_items, 0, newItems, 0, _size);
                        }
                        _items = newItems;
                    }
                    else
                    {
                        _items = _emptyarray;
                      
                    }
                }
            }
        }


        public void CopyTo(T[] array)
        {
            CopyTo(array, 0);
        }

        public void CopyTo(Array array, int arrayIndex)
        {
            if ((array != null) && (array.Rank != 1))
            {
                throw new ArgumentException("ARRAY RANK SHOULD BE ONE");
                //ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_RankMultiDimNotSupported);
            }
            Contract.EndContractBlock();

            try
            {
                // Array.Copy will check for NULL.
                Array.Copy(_items, 0, array, arrayIndex, _size);
            }
            catch (ArrayTypeMismatchException)
            {
                throw new ArgumentException();
                //ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidArrayType);
            }
        }


        


        public void Insert(int index, T item)
        {

            if ((uint)index > (uint)_size)
            {
                throw new NotImplementedException();
                //ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_ListInsert);
            }
            Contract.EndContractBlock();
            if (_size == _items.Length) EnsureCapacity(_size + 1);
            if (index < _size)
            {
                Array.Copy(_items, index, _items, index + 1, _size - index);
            }
            _items[index] = item;
            _size++;
     
        }


        public void RemoveAt(int index)
        {
            if ((uint)index >= (uint)_size)
            {
                throw new NotImplementedException();
                // ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            Contract.EndContractBlock();
            _size--;
            if (index < _size)
            {
                Array.Copy(_items, index + 1, _items, index, _size - index);
            }
            _items[_size] = default(T);
            
        }


        private void EnsureCapacity(int min)
        {
            if (_items.Length < min)
            {
                int newCapacity = _items.Length == 0 ? _defaultCapacity : _items.Length * 2;
        
                if ((uint)newCapacity > 1000000) newCapacity = 1000000;
                if (newCapacity < min) newCapacity = min;
                Capacity = newCapacity;
            }
        }


        public void CopyTo(T[] array, int arrayIndex)
        {
            // Delegate rest of error checking to Array.Copy.
            Array.Copy(_items, 0, array, arrayIndex, _size);
        }


        public void Clear()
        {
            if (_size > 0)
            {
                Array.Clear(_items, 0, _size); // Don't need to doc this but we clear the elements so that the gc can reclaim the references.
                _size = 0;
            }
           
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)_items).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }


        public struct Enumerator : IEnumerator<T>, System.Collections.IEnumerator
        {
            private List<T> list;
            private int index;
            private T current;

            internal Enumerator(List<T> list)
            {
                this.list = list;
                index = 0;
                current = default(T);
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {

                List<T> localList = list;

                if  ((uint)index < (uint)localList.Count)
                {
                    current = localList [index];
                    index++;
                    return true;
                }
                return MoveNextRare();
            }

            private bool MoveNextRare()
            {
                
                index = list.Count + 1;
                current = default(T);
                return false;
            }

            public T Current
            {
                get
                {
                    return current;
                }
            }

            Object System.Collections.IEnumerator.Current
            {
                get
                {
                    if (index == 0 || index == list.Count + 1)
                    {
                        throw new InvalidOperationException(); //ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_EnumOpCantHappen);
                    }
                    return Current;
                }
            }

            void System.Collections.IEnumerator.Reset()
            {
                
                index = 0;
                current = default(T);
            }

        }
    }

}

