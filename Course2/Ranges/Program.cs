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
            Range range1 = new Range(3, 6);
            Range range2 = new Range(3, 10);

            Console.WriteLine("Длина интервала ({0}, {1}) равна {2}.", range1.From, range1.To, range1.Length);

            Range rangeResult = range1.GetIntersection(range2);

            Range[] arrayResult = range1.GetDifference(range2);

            if (rangeResult != null)
            {
                Console.WriteLine("Пересечение интервалов ({0}, {1}) и ({2}, {3}): ({4}, {5}).", range1.From, range1.To, range2.From, range2.To, rangeResult.From, rangeResult.To);
            }
            else
            {
                Console.WriteLine(0);
            }

            foreach (Range range in arrayResult)
            {
                Console.WriteLine("Разность интервалов ({0}, {1}) и ({2}, {3}): ({4}, {5}).", range1.From, range1.To, range2.From, range2.To, range.From, range.To);
            }

            arrayResult = range1.GetUnion(range2);

            foreach (Range range in arrayResult)
            {
                Console.WriteLine("Объединение интервалов ({0}, {1}) и ({2}, {3}): ({4}, {5}).", range1.From, range1.To, range2.From, range2.To, range.From, range.To);
            }

            double number = 2.0;

            if (range1.IsInside(number))
            {
                Console.WriteLine("Число {0} принадлежит интервалу от {1} до {2}.", number, range1.From, range1.To);
            }
            else
            {
                Console.WriteLine("Число {0} не принадлежит интервалу от {1} до {2}.", number, range1.From, range1.To);
            }
        }
    }
}
