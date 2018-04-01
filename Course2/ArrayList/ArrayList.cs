using System;
using System.Collections;
using System.Collections.Generic;

namespace ArrayList
{
    public class ArrayList<T> : IList<T>
    {
        private T[] items;
        private int modCount;

        public int Count { get; private set; }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public ArrayList(int capacity)
        {
            items = new T[capacity];
        }

        public int IndexOf(T data)
        {
            for (int i = 0; i < Count; i++)
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
            if (index > Count || index < 0)
            {
                throw new ArgumentOutOfRangeException("Невозможно вставить в список элемент. Индекс выходит за границы списка.");
            }

            if (Count >= items.Length)
            {
                IncreaseCapacity();
            }

            if (index == Count)
            {
                items[Count] = data;
            }
            else
            {
                Array.Copy(items, index, items, index + 1, Count - index);
                items[index] = data;
            }

            modCount++;
            Count++;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException("Невозможно удалить элемент, индекс выходит за границы списка.");
            }

            if (index < Count - 1)
            {
                Array.Copy(items, index + 1, items, index, Count - index - 1);
            }

            modCount++;
            --Count;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new ArgumentOutOfRangeException("Индекс выходит за границы списка.");
                }

                return items[index];
            }
            set
            {
                if (index < 0 || index >= Count)
                {
                    throw new ArgumentOutOfRangeException("Индекс выходит за границы списка.");
                }

                items[index] = value;
            }
        }

        public void Add(T data)
        {
            if (Count >= items.Length)
            {
                IncreaseCapacity();
            }

            items[Count] = data;
            modCount++;
            ++Count;
        }

        private void IncreaseCapacity()
        {
            T[] old = items;
            items = new T[old.Length * 2];
            Array.Copy(old, 0, items, 0, old.Length);
        }

        public void Clear()
        {
            for (int i = 0; i < Count; i++)
            {
                items[i] = default(T);
            }

            if (Count != 0)
            {
                modCount++;
            }

            Count = 0;
        }

        public bool Contains(T data)
        {
            return IndexOf(data) > -1;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException("Невозможно скопировать список в массив, индекс < 0.");
            }

            Array.Copy(items, 0, array, arrayIndex, Count);
        }

        public bool Remove(T data)
        {
            for (int i = 0; i < Count; i++)
            {
                if (Equals(items[i], data))
                {
                    Array.Copy(items, i + 1, items, i, Count - i - 1);
                    Count--;
                    modCount++;

                    return true;
                }
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int oldModCount = modCount;

            for (int i = 0; i < Count; i++)
            {
                if (oldModCount != modCount)
                {
                    throw new InvalidOperationException("Невозможно показать элементы списка, список был измененен.");
                }

                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
