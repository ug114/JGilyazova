using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vector = Vector.Vector;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix matrix1 = new Matrix(2, 2);
            Matrix matrix2 = new Matrix(matrix1);
            double[,] array = { { 1, 2 }, { 3, 4 } };
            Matrix matrix3 = new Matrix(array);
            double[] array1 = { 1, 2, 3 };
            vector v1 = new vector(array1);
            double[] array2 = { 2, 4, 6 };
            vector v2 = new vector(array2);
            Matrix matrix4 = new Matrix(new vector[] { v1, v2 });
            matrix4.Multiple(2);
            Console.WriteLine(matrix3.toString());
            Console.WriteLine(matrix4.toString());
            //Console.WriteLine(Multiplicate(matrix3, matrix4).toString());
            Console.WriteLine(matrix3.GetDeterminant());
            //for (int i = 0; i < 2; i++)
            //{
            //    for (int j = 0; j < 3; j++)
            //    {
            //        Console.Write(" {0}", matrix4.array[i].GetComponent(j));
            //    }
            //    Console.WriteLine();
            //}
            //Console.WriteLine(matrix4.MultipleVector(v1).toString());
        }
    }
}
