using System;
using System.Collections.Generic;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTable<int> hashTable = new HashTable<int>(10);

            hashTable.Add(1);
            hashTable.Add(2);
            
            foreach(int item in hashTable)
            {
                Console.WriteLine(item);
            }
        }
    }
}
