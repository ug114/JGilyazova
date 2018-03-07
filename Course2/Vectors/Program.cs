using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector vector1 = new Vector(0);
            Vector vector2 = new Vector(new double[] { 1, 2, 0 });
            Vector vector3 = new Vector(new double[] { 1, 1 });
            Vector vector4 = new Vector(4, new double[] { 1, 8 });

            Console.WriteLine("Вектор: {0}.", vector2.ToString());
            Console.WriteLine("Хеш-код: {0}.", vector2.GetHashCode());
            Console.WriteLine("Размер: {0}.", vector2.GetSize());
            Console.WriteLine("Сумма векторов {0} и {1} равна {2}.", vector2.ToString(), vector3.ToString(), vector2.GetSum(vector3).ToString());
            Console.WriteLine("Вектор {0}, умноженный на скаляр {1} равен {2}.", vector2.ToString(), 2, vector2.MultiplyByScalar(2).ToString());
            Console.WriteLine("Скалярное произведение векторов {0} и {1} равно {2}.", vector3, vector2, Vector.GetScalarMultiplication(vector3, vector2));
        }
    }
}
