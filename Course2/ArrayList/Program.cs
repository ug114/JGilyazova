using System;
using System.Collections.Generic;

namespace ArrayList
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList<string> arrayList = new ArrayList<string>(5);
            
            try
            {
                arrayList.Add("1");
                arrayList.Add("2");
                arrayList.Add(null);
                arrayList.Insert(0, "0");
                arrayList.Add("4");
                arrayList.Add("5");
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
