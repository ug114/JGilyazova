using System;
using vector = Vector.Vector;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix matrix1 = new Matrix(new double[,] { { 1, 2 }, { 2, 5 } });
            Matrix matrix2 = new Matrix(matrix1);
            Matrix matrix3 = new Matrix(new double[,] { { 1, 2 }, { 3, 4 } });

            vector v1 = new vector(new double[] { 1, 2 });
            vector v2 = new vector(new double[] { 2, 2 });
            Matrix matrix4 = new Matrix(new vector[] { v1, v2 });

            matrix4.SetString(0, new vector(2));
            
            Console.WriteLine("Число столбцов матрицы {0} равно {1}.\n", matrix4.ToString(), matrix4.GetNumberOfColumns());
            Console.WriteLine("Результат умножения матрицы {0} на {1} равен {2}.\n", matrix3.ToString(), matrix4.ToString(), Matrix.GetMultiplication(matrix3, matrix4).ToString());
            Console.WriteLine("Определитель матрицы {0} равен {1}.\n", matrix3.ToString(), matrix3.GetDeterminant());
            Console.WriteLine("Сумма матриц {0} и {1} равна {2}.\n", matrix4.ToString(), matrix1.ToString(), matrix1.GetSum(matrix4).ToString());
            Console.WriteLine("Результат умножения матрицы {0} на вектор {1} равен {2}.\n", matrix4.ToString(), v1.ToString(), matrix4.MultiplyByVector(v1).ToString());
        }
    }
}
