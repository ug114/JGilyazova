using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList
{
    public class ArrayList<T> //: IList<T>
    {
        private T[] items = new T[10];
        private int length;

        public int Count
        {
            get
            {
                return length;
            }
        }
        
        public bool IsReadOnly { get; set; }

        public int IndexOf(T data)
        {
            return 0;
        }

        public void Insert(int index, T data)
        {
            
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }
            
            if (index < length - 1)
            {
                Array.Copy(items, index + 1, items, index, length - index - 1);
            }

            --length; 
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }

                return items[index];
            }
            set
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }

                items[index] = value;
            }
        }

        public void Add(T data)
        {
            if (length >= items.Length)
            {
                IncreaseCapacity();
            }

            items[length] = data;
            ++length;
        }

        private void IncreaseCapacity()
        {
            T[] old = items;
            items = new T[old.Length * 2];
            Array.Copy(old, 0, items, 0, old.Length);
        }

        public void Clear()
        {
            
        }

        public bool Contains(T data)
        {
            return true;
        }

        public void CopyTo(T[] array, int number)
        {
            
        }

        public bool Remove(T data)
        {
            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return null;
        }

        //public IEnumerable.GetEnumerator()
        //{
        //    return null;
        //}


    }
}
