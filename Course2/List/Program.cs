using System;

namespace List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            list.Add("1");
            list.Add("2");
            list.Add("3");
            list.Add("4");
            list.Add("5");
            list.Add("6");

            List<string> list2 = list.CopyTo();
            list2.Reverse();

            Console.WriteLine("Список:");

            try
            {
                Console.WriteLine(list.ToString());                
                Console.WriteLine("\nНулевой элемент списка: {0}.", list.GetFirstNodeData());
                Console.WriteLine("Нулевой элемент списка со значением {0} заменен на 10.", list.SetData(0, "10"));
                Console.WriteLine("Нулевой элемент списка удален, его старое значение: {0}.", list.RemoveFirst());

                Console.WriteLine("\nСписок:");

                Console.WriteLine(list.ToString());                
            }
            catch(ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
