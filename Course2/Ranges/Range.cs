using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranges
{
    class Range
    {
        private double to;
        private double from;

        public Range(double from, double to)
        {
            this.from = from;
            this.to = to;
        }

        public double To
        {
            get
            {
                return to;
            }
            set
            {
                to = value;
            }
        }

        public double From
        {
            get
            {
                return from;
            }
            set
            {
                from = value;
            }
        }

        public double Length
        {
            get
            {
                return this.to - this.from;
            }
        }

        public bool IsInside(double number)
        {
            return number <= this.to && number >= this.from;
        }

        public static Range GetIntersection(Range range1, Range range2)
        {
            if (Math.Max(range1.From, range2.From) < Math.Min(range1.To, range2.To))
            {
                return new Range(Math.Max(range1.From, range2.From), Math.Min(range1.To, range2.To));
            }
            else
            {
                return null;
            }
        }

        public static Range[] GetUnion(Range range1, Range range2)
        {
            if (Math.Max(range1.From, range2.From) > Math.Min(range1.To, range2.To))
            {
                return new Range[] { new Range(range1.From, range1.To), new Range(range2.From, range2.To) };
            }
            else
            {
                return new Range[] { new Range(Math.Min(range1.From, range2.From), Math.Max(range1.To, range2.To)) };
            }
        }

        public static Range[] GetDifference(Range range1, Range range2)
        {
            if (range1.From == range2.From && range1.To == range2.To)
            {
                return null;
            }
            if (range2.From > range1.From && range2.To < range1.To)
            {
                return new Range[] { new Range(range1.From, range2.From), new Range(range2.To, range1.To) };
            }
            if (range2.To < range1.To)
            {
                return new Range[] { new Range(range2.To, range1.To) };
            }
            if (range2.From < range1.To)
            {
                return new Range[] { new Range(range1.From, range2.From) };
            }

            return null;
        }

        static void Main(string[] args)
        {
            Range range1 = new Range(1, 2);
            Range range2 = new Range(1, 1.5);

            Console.WriteLine("Длина интервала равна {0}.", range1.Length);
            
            Range rangeResult = Range.GetIntersection(range1, range2);
            
            Range[] arrayResult = Range.GetDifference(range1, range2);

            if (arrayResult != null)
            {
                foreach (Range range in arrayResult)
                {
                    Console.WriteLine(range.From + ", " + range.To);
                }
            }
            else
            {
                Console.WriteLine(0);
            }

            double number = 10.0;
            if (range1.IsInside(number))
            {
                Console.WriteLine("Число {0} внутри диапазона от {1} до {2}.", number, range1.From, range1.To);
            }
            else
            {
                Console.WriteLine("Число {0} не принадлежит диапазону от {1} до {2}.", number, range1.From, range1.To);
            }
        }
    }
}
