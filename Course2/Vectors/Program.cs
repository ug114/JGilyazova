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
            Vector vector0 = null;
            Vector vector1 = null;
            Vector vector2 = null;
            Vector vector3 = null;
            Vector vector4 = null;

            try
            {
                vector0 = new Vector(new double[] { 1, 2, 3 });
                vector2 = new Vector(vector0);
                vector3 = new Vector(new double[] { 1, 1 });
                vector4 = new Vector(4, new double[] { 1, 8 });
                vector1 = new Vector(0);
            }
            catch
            {
                Console.WriteLine("Размерность вектора должна быть > 0.");
            }

            Console.WriteLine("Вектор: {0}.", vector2.ToString());
            Console.WriteLine("Хеш-код: {0}.", vector2.GetHashCode());
            Console.WriteLine("Размер: {0}.", vector2.GetSize());
            Console.WriteLine("Сумма векторов {0} и {1} равна {2}.", vector2.ToString(), vector3.ToString(), Vector.GetSum(vector2, vector3).ToString());
            Console.WriteLine("Вектор {0}, умноженный на скаляр {1} равен {2}.", vector2.ToString(), 2, vector2.MultiplyByScalar(2).ToString());
            Console.WriteLine("Скалярное произведение векторов {0} и {1} равно {2}.", vector3, vector2, Vector.GetScalarMultiplication(vector3, vector2));
        }
    }
}
