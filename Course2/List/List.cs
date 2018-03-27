using System;
using System.Text;

namespace List
{
    public class List<T>
    {
        private Node<T> head;

        public int Count { get; private set; }

        public T GetFirstNodeData()
        {
            if (head == null)
            {
                throw new ArgumentOutOfRangeException("Список пустой. Невозможно получить данные о значении первого узла.");
            }

            return head.Data;
        }

        private Node<T> GetNodeAt(int index)
        {
            Node<T> node = head;

            for (int i = 0; i < index; i++)
            {
                node = node.Next;
            }

            return node;
        }

        public T GetData(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException("В списке нет узла с таким индексом. Невозможно получить данные о значении узла.");
            }

            return GetNodeAt(index).Data;
        }

        public T SetData(int index, T newData)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException("В списке нет узла с таким индексом. Невозможно изменить значение узла.");
            }

            Node<T> node = GetNodeAt(index);

            T oldData = node.Data;
            node.Data = newData;

            return oldData;
        }

        public T RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException("В списке нет узла с таким индексом. Невозможно удалить узел.");
            }

            if (index == 0)
            {
                return RemoveFirst();
            }
            else
            {
                Node<T> previous = GetNodeAt(index - 1);
                Node<T> current = previous.Next;

                T oldData = current.Data;

                previous.Next = current.Next;
                Count--;

                return oldData;
            }
        }

        public bool RemoveNode(T data)
        {
            for (Node<T> current = head, previous = null; current != null; previous = current, current = current.Next)
            {
                if (Equals(current.Data, data))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                    }
                    else
                    {
                        head = head.Next;
                    }

                    Count--;

                    return true;
                }
            }

            return false;
        }

        public T RemoveFirst()
        {
            if (head == null)
            {
                throw new ArgumentOutOfRangeException("Список пустой. Невозможно удалить первый узел.");
            }

            T data = GetFirstNodeData();
            head = head.Next;
            Count--;

            return data;
        }

        public void AddFirst(T data)
        {
            Node<T> node = new Node<T>(data, head);
            head = node;
            Count++;
        }

        public void Insert(int index, T data)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException("Невозможно вставить в список узел с таким индексом.");
            }

            if (index == 0)
            {
                AddFirst(data);
            }
            else
            {
                Node<T> previous = GetNodeAt(index - 1);
                Node<T> next = previous.Next;

                Node<T> node = new Node<T>(data, next);
                previous.Next = node;
                Count++;
            }
        }

        public List<T> Copy()
        {
            List<T> newList = new List<T>();

            if (head == null)
            {
                return newList;
            }
                        
            Node<T> newNode = new Node<T>(head.Data);
            newList.head = newNode;
            Node<T> node = head;
            
            for (int i = 0; i < Count - 1; i++)
            {
                node = node.Next;
                newNode.Next = new Node<T>(node.Data);
                newNode = newNode.Next;
            }

            newList.Count = Count;
            
            return newList;
        }

        public List<T> Reverse()
        {
            if (head == null)
            {
                return this;
            }

            Node<T> previous = null;
            Node<T> current = head;
            
            while (current.Next != null)
            {
                Node<T> next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            }

            current.Next = previous;
            head = current;

            return this;
        }

        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);

            if (head == null)
            {
                head = node;
            }
            else
            {
                Node<T> current = GetNodeAt(Count - 1);
                current.Next = node;
            }

            Count++;
        }

        public override string ToString()
        {
            if (Count == 0)
            {
                return "";
            }

            StringBuilder builder = new StringBuilder();
            Node<T> node = head;

            while (node.Next != null)
            {
                builder.Append(node.Data + ", ");
                node = node.Next;
            }

            return builder.Append(node.Data).ToString();
        }
    }
}