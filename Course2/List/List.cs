using System;

namespace List
{
    public class List<T>
    {
        private Node<T> head;

        public int Count { get; set; }

        public T GetFirstNodeData()
        {
            if (head == null)
            {
                throw new ArgumentException("Список пустой. Невозможно получить данные о значении первого узла.");
            }

            return head.Data;
        }

        public Node<T> GetNodeAt(int index)
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
                throw new ArgumentException("В списке нет узла с таким индексом.");
            }

            return GetNodeAt(index).Data;
        }

        public T SetData(int index, T newData)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentException("В списке нет узла с таким индексом.");
            }

            Node<T> node = GetNodeAt(index);

            T oldData = node.Data;
            node.Data = newData;

            return oldData;
        }

        public T RemoveAt(int index)
        {
            if (index <= 0 || index >= Count)
            {
                throw new ArgumentException("В списке нет узла с таким индексом.");
            }

            Node<T> previous = GetNodeAt(index - 1);
            Node<T> current = previous.Next;
                        
            T oldData = current.Data;

            if (previous != null)
            {
                previous.Next = current.Next;
            }
            else
            {
                head = head.Next;
            }

            Count--;

            return oldData;
        }

        public bool RemoveNode(T data)
        {
            Node<T> current = head;
            Node<T> previous = null;

            while (current.Data == null || !current.Data.Equals(data))
            {
                previous = current;
                current = current.Next;

                if (current.Next == null && !current.Data.Equals(data))
                {
                    return false;
                }
            }

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

        public T RemoveFirst()
        {
            if (head == null)
            {
                throw new ArgumentException("Список пустой. Невозможно удалить первый узел.");
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
                throw new ArgumentException("Невозможно вставить в список узел с таким индексом.");
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
            }

            Count++;
        }

        public List<T> CopyTo()
        {
            List<T> newList = new List<T>();
            Node<T> node = head;

            while (node != null)
            {
                newList.Add(node.Data);
                node = node.Next;
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
    }
}