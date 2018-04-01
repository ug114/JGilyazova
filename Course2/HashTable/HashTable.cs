using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HashTable
{
    class HashTable<T> : ICollection<T>
    {
        private List<T>[] array;

        public HashTable(int capacity)
        {
            array = new List<T>[capacity];
        }

        public int Count
        {
            get
            {
                return array.Length;
            }

            private set { }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(T item)
        {
            int index = Math.Abs(item.GetHashCode() % Count);

            if (Equals(array[index], null))
            {
                array[index] = new List<T>();
            }

            array[index].Add(item);
        }

        public void Clear()
        {
            for (int i = 0; i < Count; i++)
            {
                if (!Equals(array[i], null))
                {
                    array[i].Clear();
                }
            }
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (array[i].Contains(item))
                {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException("Невозможно скопировать список в массив, индекс < 0.");
            }

            int k = arrayIndex;

            for (int i = 0; i < this.array.Length; i++)
            {
                if (!Equals(this.array[i], null))
                {
                    for (int j = 0; j < this.array[i].Count; j++)
                    {
                        array[k] = this.array[i][j];
                        k++;
                    }
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                if (!Equals(array[i], null))
                {
                    for (int j = 0; j < array[i].Count; j++)
                    {
                        yield return array[i][j];
                    }
                }
            }
        }

        public bool Remove(T item)
        {
            int index = Math.Abs(item.GetHashCode() % array.Length);

            return array[index].Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
