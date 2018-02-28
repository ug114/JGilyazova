using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Range
{
    class Program
    {
        static void Main(string[] args)
        {
            Range range1 = new Range(1, 2);
            Range range2 = new Range(1.5, 2);

            //Console.WriteLine("Длина интервала равна {0}.", range1.Length);

            //Range rangeResult = range1.GetIntersection(range2);

            Range[] arrayResult = range1.GetDifference(range2);

            //if (rangeResult != null)
            //{
            //    Console.WriteLine(rangeResult.From + ", " + rangeResult.To);
            //}
            //else
            //{
            //    Console.WriteLine(0);
            //}

            foreach (Range range in arrayResult)
            {
                Console.WriteLine(range.From + ", " + range.To);
            }

            //double number = 10.0;
            //if (range1.IsInside(number))
            //{
            //    Console.WriteLine("Число {0} внутри диапазона от {1} до {2}.", number, range1.From, range1.To);
            //}
            //else
            //{
            //    Console.WriteLine("Число {0} не принадлежит диапазону от {1} до {2}.", number, range1.From, range1.To);
            //}
        }
    }
}
