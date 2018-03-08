using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Range
{
    class Range
    {
        public double From { get; set; }
        public double To { get; set; }
        
        public Range(double from, double to)
        {
            From = from;
            To = to;
        }

        public double Length
        {
            get
            {
                return To - From;
            }
        }

        public bool IsInside(double number)
        {
            return number <= To && number >= From;
        }

        public Range GetIntersection(Range range)
        {
            if (Math.Max(From, range.From) < Math.Min(To, range.To))
            {
                return new Range(Math.Max(From, range.From), Math.Min(To, range.To));
            }
            else
            {
                return null;
            }
        }

        public Range[] GetUnion(Range range)
        {
            if (Math.Max(From, range.From) > Math.Min(To, range.To))
            {
                return new Range[] { new Range(From, To), new Range(range.From, range.To) };
            }
            else
            {
                return new Range[] { new Range(Math.Min(From, range.From), Math.Max(To, range.To)) };
            }
        }

        public Range[] GetDifference(Range range)
        {
            if (From == range.From && To == range.To)
            {
                return new Range[0];
            }
            if (range.From > From && range.To < To)
            {
                return new Range[] { new Range(From, range.From), new Range(range.To, To) };
            }
            if (To <= range.From || From >= range.To)
            {
                return new Range[] { new Range(From, To) };
            }
            if (range.To < To)
            {
                return new Range[] { new Range(range.To, To) };
            }
            if (range.From < To && range.From > From)
            {
                return new Range[] { new Range(From, range.From) };
            }

            return new Range[0];
        }
    }
}
