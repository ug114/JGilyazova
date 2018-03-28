using System;

namespace ArrayList
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList<string> arrayList = new ArrayList<string>();

            try
            {
                arrayList.Add("1");
                arrayList.Add("2");
                arrayList.Add(null);
                arrayList.Add("4");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }           

            foreach (string str in arrayList)
            {
                Console.WriteLine(str);
            }
        }
    }
}
