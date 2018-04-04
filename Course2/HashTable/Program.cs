using System;
using System.Collections.Generic;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTable<string> hashTable = new HashTable<string>(10);

            hashTable.Add("1");
            hashTable.Add("2");
            hashTable.Add(null);
            hashTable.Remove("2");

            hashTable.Clear();
            
            foreach (string item in hashTable)
            {
                Console.WriteLine(item);
            }
        }
    }
}
