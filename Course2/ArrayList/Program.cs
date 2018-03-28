using System;

namespace ArrayList
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList<string> arrayList = new ArrayList<string>();

            arrayList.Add("1");
            arrayList.Add("2");
            arrayList.Add(null);

            //string[] array = new string[5];
            //Console.WriteLine(arrayList.Remove(null));

            foreach (string str in arrayList)
            {
                Console.WriteLine(str);
            }
        }
    }
}
