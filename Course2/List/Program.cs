using System;

namespace List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            list.AddFirst("1");
            list.Add("2");
            list.Add("3");

            List<string> list2 = list.CopyTo();
            list2.Reverse();

            Console.WriteLine("Список:");

            try
            {
                for (int i = 0; i < list.Count; i++)
                {
                    Console.WriteLine(list.GetData(i));
                }
                
                Console.WriteLine("\nНулевой элемент списка: {0}.", list.GetFirstNodeData());
                Console.WriteLine("Нулевой элемент списка со значением {0} заменен на 10.", list.SetData(0, "10"));
                Console.WriteLine("Нулевой элемент списка удален, его старое значение: {0}.", list.RemoveFirst());

                Console.WriteLine("\nСписок после изменений:");

                for (int i = 0; i < list.Count; i++)
                {
                    Console.WriteLine(list.GetData(i));
                }
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
