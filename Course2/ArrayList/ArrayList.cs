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
        private T[] items;
        private int length;

        public int Count { get; set; }

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
            
        }

        public T this[int index]
        {
            get
            {
                return default(T);
            }
            set
            {

            }
        }

        public void Add(T data)
        {
            
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
