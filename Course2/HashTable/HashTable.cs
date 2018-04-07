using System;
using System.Collections;
using System.Collections.Generic;

namespace HashTable
{
    class HashTable<T> : ICollection<T>
    {
        private List<T>[] array;
        private int modCount;

        public HashTable(int capacity)
        {
            array = new List<T>[capacity];
        }

        public int Count { get; private set; }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(T item)
        {
            int index = GetIndex(item);

            if (ReferenceEquals(array[index], null))
            {
                array[index] = new List<T>();
            }
            
            array[index].Add(item);
            Count++;
            modCount++;
        }

        public void Clear()
        {
            foreach(List<T> list in array)
            {
                if (!ReferenceEquals(list, null))
                {
                    list.Clear();
                }
            }
            
            if (Count != 0)
            {
                modCount++;
            }

            Count = 0;
        }

        public bool Contains(T item)
        {
            int index = GetIndex(item);

            if (!ReferenceEquals(array[index], null) && array[index].Contains(item))
            {
                return true;
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException("Невозможно скопировать список в массив, индекс < 0.");
            }

            if (ReferenceEquals(array, null))
            {
                throw new ArgumentNullException("Невозможно скопировать список в массив.");
            }

            if (Count > array.Length - arrayIndex)
            {
                throw new ArgumentException("Невозможно скопировать список в массив.");
            }

            int i = arrayIndex;

            foreach (var item in this)
            {
                array[i] = item;
                i++;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            int oldModCount = modCount;

            for (int i = 0; i < array.Length; i++)
            {
                if (!ReferenceEquals(array[i], null))
                {
                    foreach (var item in array[i])
                    {
                        if (oldModCount != modCount)
                        {
                            throw new InvalidOperationException("Невозможно показать элементы списка, список был измененен.");
                        }

                        yield return item;
                    }
                }
            }
        }

        public bool Remove(T item)
        {
            int index = GetIndex(item);

            if (!ReferenceEquals(array[index], null) && array[index].Remove(item))
            {
                Count--;
                modCount++;
                return true;
            }

            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int GetIndex(T item)
        {
            return item == null ? 0 : Math.Abs(item.GetHashCode() % array.Length);
        }
    }
}
