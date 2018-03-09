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

            Console.WriteLine(matrix4.ToString());
            Console.WriteLine("Число столбцов матрицы: {0}.\n", matrix4.GetNumberOfColumns());

            matrix4.Multiple(2);

            Console.WriteLine("Результат умножения матрицы {0} на {1} равен {2}.\n", matrix3.ToString(), matrix4.ToString(), Matrix.Multiplicate(matrix3, matrix4).ToString());
            
            Console.WriteLine("Определитель матрицы {0} равен {1}.\n", matrix3.ToString(), matrix3.GetDeterminant());

            Console.WriteLine("Результат умножения матрицы {0} на вектор {1} равен {2}.\n", matrix4.ToString(), v1.ToString(), matrix4.MultipleVector(v1).ToString());
        }
    }
}
