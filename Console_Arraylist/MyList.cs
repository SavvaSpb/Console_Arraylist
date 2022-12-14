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
        //[ContractPublicPropertyName("Count")]
        private int _size;
        //private int _version;
        private const int _defaultCapacity = 4;
        
        private T[] _emptyarray = new T[0];
        //static readonly T[] _emptyArray = new T[0];

        //[NonSerialized]
        //private Object _syncRoot;

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



       // public T this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public int Capacity { get; private set; }




      

        private void EnsureCapacity(int min)
        {
            if (_items.Length >= min)
            {
                int newCapacity = _items.Length == 0 ? _defaultCapacity : _items.Length * 2;
               
                if ((uint)newCapacity > 1000000) newCapacity = 1000000;
                if (newCapacity < min) newCapacity = min;
                Capacity = newCapacity;
            }
        }

      



        //public void Add(T item)
        //{
        //    if (_size == _items.Length) EnsureCapacity(_size + 1);
        //    _items[_size++] = item;
        //    //_version++;
        //}

        public void Add (T value)
        {
            if (this._size == _items.Length)
            {
                EnsureCapacity(this._size + 1);
            }
            
            _items[_size++] = value;
            

        }

       


        public int IndexOf(T value)
        {
            //Contract.Ensures(Contract.Result<int>() >= -1);
            //Contract.Ensures(Contract.Result<int>() < Count);
            return Array.IndexOf(_items, value, 0, _size);
        }

        public int IndexOf( T value, int index)
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


        //public bool Contains( T value)
        //{
        //    return IndexOf(value) != -1;
        //}

        public bool Contains(T item)
        {
            if ((Object)item == null)
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
                    if (c.Equals(_items[i], item)) return true;
                }
                return false;
            }
        }

        

        


        public void CopyTo(T[] array)
        {
            CopyTo(array, 0);
        }

        void CopyTo(Array array, int arrayIndex)
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
            // Note that insertions at the end are legal.
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
            //_version++;
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
            //_version++;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();    
            //return new Enumerator(this);
        }


        public void CopyTo(T[] array, int arrayIndex)
        {
            // Delegate rest of error checking to Array.Copy.
            Array.Copy(_items, 0, array, arrayIndex, _size);
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }
    }
}
