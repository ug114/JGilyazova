using System;
using System.Collections;
using System.Collections.Generic;

namespace ArrayList
{
    public class ArrayList<T> : IList<T>
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
        
        public bool IsReadOnly { get; }

        public int IndexOf(T data)
        {
            for (int i = 0; i < length; i++)
            {
                if (Equals(items[i], data))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T data)
        {
            if (index > length || index < 0)
            {
                throw new ArgumentOutOfRangeException("Невозможно вставить в список элемент. Индекс выходит за границы списка.");
            }

            if (IsReadOnly)
            {
                throw new NotSupportedException();
            }

            if (length >= items.Length)
            {
                IncreaseCapacity();
            }
            
            if (index == length)
            {                
                items[length] = data;
            }
            else
            {
                Array.Copy(items, index, items, index + 1, length - index);
                items[index] = data;                
            }

            length++;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= length)
            {
                throw new ArgumentOutOfRangeException("Невозможно удалить элемент, индекс выходит за границы списка.");
            }

            if (IsReadOnly)
            {
                throw new NotSupportedException();
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
                if (index < 0 || index >= length)
                {
                    throw new ArgumentOutOfRangeException("Индекс выходит за границы списка.");
                }

                return items[index];
            }
            set
            {
                if (index < 0 || index >= length)
                {
                    throw new ArgumentOutOfRangeException("Индекс выходит за границы списка.");
                }

                items[index] = value;
            }
        }

        public void Add(T data)
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException();
            }

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
            if (IsReadOnly)
            {
                throw new NotSupportedException();
            }

            for (int i = 0; i < length; i++)
            {
                items[i] = default(T);
            }

            length = 0;
        }

        public bool Contains(T data)
        {
            for (int i = 0; i < length; i++)
            {
                if (Equals(items[i], data))
                {
                    return true;
                }
            }

            return false;
        }

        //TODO: throw exceptions
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            Array.Copy(items, 0, array, arrayIndex, length);
        }

        public bool Remove(T data)
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException();
            }

            for (int i = 0; i < length; i++)
            {
                if (Equals(items[i], data))
                {
                    Array.Copy(items, i + 1, items, i, length - i - 1);
                    length--;

                    return true;
                }
            }
                        
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IList<T>)items).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return items.GetEnumerator();
        }
    }
}
