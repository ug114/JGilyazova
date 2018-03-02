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
        
        public Range(double From, double to)
        {
            this.From = From;
            this.To = to;
        }

        public double Length
        {
            get
            {
                return this.To - this.From;
            }
        }

        public bool IsInside(double number)
        {
            return number <= this.To && number >= this.From;
        }

        public Range GetIntersection(Range range)
        {
            if (Math.Max(this.From, range.From) < Math.Min(this.To, range.To))
            {
                return new Range(Math.Max(this.From, range.From), Math.Min(this.To, range.To));
            }
            else
            {
                return null;
            }
        }

        public Range[] GetUnion(Range range)
        {
            if (Math.Max(this.From, range.From) > Math.Min(this.To, range.To))
            {
                return new Range[] { new Range(this.From, this.To), new Range(range.From, range.To) };
            }
            else
            {
                return new Range[] { new Range(Math.Min(this.From, range.From), Math.Max(this.To, range.To)) };
            }
        }

        public Range[] GetDifference(Range range)
        {
            if (this.From == range.From && this.To == range.To)
            {
                return new Range[0];
            }
            if (range.From > this.From && range.To < this.To)
            {
                return new Range[] { new Range(this.From, range.From), new Range(range.To, this.To) };
            }
            if (this.To <= range.From || this.From >= range.To)
            {
                return new Range[] { new Range(this.From, this.To) };
            }
            if (range.To < this.To)
            {
                return new Range[] { new Range(range.To, this.To) };
            }
            if (range.From < this.To && range.From > this.From)
            {
                return new Range[] { new Range(this.From, range.From) };
            }

            return new Range[0];
        }
    }
}
