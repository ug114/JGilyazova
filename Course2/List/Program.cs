using System;

namespace List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            Console.WriteLine("Список:");

            for (int i = 0; i < list.Count(); i++)
            {
                Console.WriteLine(list.GetData(i));
            }

            List<int> list2 = list.CopyTo();
            list2.Reverse();

            Console.WriteLine("\nНулевой элемент списка: {0}.", list.GetFirstNodeData());
            Console.WriteLine("Нулевой элемент списка со значением {0} заменен на 10.", list.Insert(0, 10));
            Console.WriteLine("Нулевой элемент списка удален, его старое значение: {0}.", list.RemoveAt(0));

            Console.WriteLine("\nСписок после изменений:");

            for (int i = 0; i < list.Count(); i++)
            {
                Console.WriteLine(list.GetData(i));
            }
        }
    }
}
