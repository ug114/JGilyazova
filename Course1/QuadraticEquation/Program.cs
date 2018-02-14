using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadraticEquation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите коэффициент a:");
            double a = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите коэффициент b:");
            double b = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите коэффициент c:");
            double c = Convert.ToDouble(Console.ReadLine());

            double eps = 1e-10;

            if (Math.Abs(a) < eps)
            {
                if (Math.Abs(b) < eps)
                {
                    Console.WriteLine("Данное выражение не является квадратным уравнением и не имеет решения.");
                }
                else
                {
                    Console.WriteLine("Данное уравнение не является квадратным, его решение: x = {0}.", -c / b);
                }
            }
            else
            {
                double discriminant = Math.Pow(b, 2) - 4 * a * c;

                if (Math.Abs(discriminant) < eps)
                {
                    double x = -b / (2 * a);
                    Console.WriteLine("Решение уравнения: x = {0}.", x);
                }
                else if (discriminant > 0)
                {
                    double x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                    double x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                    Console.WriteLine("Решение уравнения: x1 = {0}, x2 = {1}.", x1, x2);
                }
                else
                {
                    Console.WriteLine("По условию задачи данное квадратное уравнение не имеет решений.");
                }
            }
        }
    }
}
