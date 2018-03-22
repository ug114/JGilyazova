namespace List
{
    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }

        public Node(T data, Node<T> next)
        {
            Data = data;
            Next = next;
        }

        public T Data { get; set; }
        public Node<T> Next { get; set; } 
    }
}
