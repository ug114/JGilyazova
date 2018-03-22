namespace List
{
    public class List<T>
    {
        private Node<T> head;

        public int Count()
        {
            int count = 0;

            for (Node<T> node = head; node != null; node = node.Next)
            {
                count++;
            }

            return count;
        }

        public T GetFirstNodeData()
        {
            return head.Data;
        }

        public T GetData(int index)
        {
            Node<T> node = head;

            for (int i = 0; i < index; i++)
            {
                node = node.Next;
            }

            return node.Data;
        }

        public T Insert(int index, T newData)
        {
            Node<T> node = head;

            for (int i = 0; i < index; i++)
            {
                node = node.Next;
            }

            T oldData = node.Data;
            node.Data = newData;

            return oldData;
        }

        public T RemoveAt(int index)
        {
            Node<T> current = head;
            Node<T> previous = null;

            for (int i = 0; i < index; i++)
            {
                previous = current;
                current = current.Next;
            }

            T oldData = current.Data;

            if (previous != null)
            {
                previous.Next = current.Next;
            }
            else
            {
                head = head.Next;
            }

            return oldData;
        }

        public bool RemoveNode(T data)
        {
            Node<T> current = head;
            Node<T> previous = null;

            while (!current.Data.Equals(data))
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

            return true;
        }

        public T RemoveFirst()
        {
            if (head == null)
            {
                return default(T);
            }

            T data = GetFirstNodeData();
            head = head.Next;

            return data;
        }

        public void SetFirst(T data)
        {
            Node<T> node = new Node<T>(data, head);
            head = node;
        }

        public void InsertNode(int index, Node<T> node)
        {
            if (index == 0)
            {
                SetFirst(node.Data);
            }
            else
            {
                Node<T> previous = null;
                Node<T> next = head;
                
                for (int i = 0; i < index; i++)
                {
                    previous = next;
                    next = next.Next;
                }

                previous.Next = node;
                node.Next = next;
            }
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
            Node<T> next = null;

            while (current.Next != null)
            {
                next = current.Next;
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
                Node<T> current = head;

                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = node;
            }
        }
    }
}