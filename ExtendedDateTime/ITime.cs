using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedDate;
public interface ITime : IComparable
{
    public int Year { get; }

    public int Month { get; }

    public int Day { get; }

    public int Hour { get; }

    public int Minute { get; }

    public int Second { get; }

    public TimeEra Era { get; }

    public MonthNames NameOfMonth { get; }
}
