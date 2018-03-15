using System;
using Vector = Vectors.Vector;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix matrix1 = null;
            Matrix matrix2 = null;
            Matrix matrix3 = null;
            Matrix matrix4 = null;
            Vector v1 = null;
            Vector v2 = null;

            try
            {
                matrix1 = new Matrix(new double[,] { { 1, 2 }, { 2, 5 } });
                matrix2 = new Matrix(matrix1);
                matrix3 = new Matrix(new double[,] { { 1, 2 }, { 0, 4 } });

                v1 = new Vector(new double[] { 1, 2 });
                v2 = new Vector(new double[] { 2, 2 });
                matrix4 = new Matrix(new Vector[] { v1, v2 });

                matrix4.SetRow(0, new Vector(2));

                Console.WriteLine("Матрица: {0}, транспонированная матрица: {1}.\n", matrix3.ToString(), matrix3.Transpose().ToString());
                Console.WriteLine("Результат умножения матрицы {0} на {1} равен {2}.\n", matrix3.ToString(), matrix4.ToString(), Matrix.GetMultiplication(matrix3, matrix4).ToString());
                Console.WriteLine("Определитель матрицы {0} равен {1}.\n", matrix3.ToString(), matrix3.GetDeterminant());
                Console.WriteLine("Сумма матриц {0} и {1} равна {2}.\n", matrix4.ToString(), matrix1.ToString(), matrix1.GetSum(matrix4).ToString());
                Console.WriteLine("Результат умножения матрицы {0} на вектор {1} равен {2}.\n", matrix4.ToString(), v1.ToString(), matrix4.MultiplyByVector(v1).ToString());
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
