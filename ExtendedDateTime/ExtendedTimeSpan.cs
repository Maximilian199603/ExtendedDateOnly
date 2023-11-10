namespace ExtendedDate;

public class ExtendedTimeSpan : IComparable<ExtendedTimeSpan>, IEquatable<ExtendedTimeSpan>
{
    public int Year { get; private set; }

    public int Month { get; private set; }

    public int Day { get; private set; }

    public int Hour { get; private set; }

    public int Minute { get; private set; }

    public int Second { get; private set; }

    private static readonly ExtendedTimeSpan _Zero = new ExtendedTimeSpan(0, 0, 0, 0, 0, 0);

    private static readonly ExtendedTimeSpan _MaxValue = new ExtendedTimeSpan(int.MaxValue, 12, 31, 23, 59, 59);

    private static readonly ExtendedTimeSpan _MinValue = new ExtendedTimeSpan(int.MinValue, 1, 1, 0, 0, 0);

    public static ExtendedTimeSpan Zero => _Zero.Copy();

    public static ExtendedTimeSpan MaxValue => _MaxValue.Copy();

    public static ExtendedTimeSpan MinValue => _MinValue.Copy();

    public ExtendedTimeSpan()
    {
        Year = 0;
        Month = 0;
        Day = 0;
        Hour = 0;
        Minute = 0;
        Second = 0;
    }

    public ExtendedTimeSpan(int year, int month, int day, int hour, int minute, int second)
    {
        if (!(year >= int.MinValue && year <= int.MaxValue))
        {
            throw new ArgumentOutOfRangeException(nameof(year));
        }

        if (!(month >= 1 && month <= 12))
        {
            throw new ArgumentOutOfRangeException(nameof(month));
        }

        if (!(day >= 1 && day <= 31))
        {
            throw new ArgumentOutOfRangeException(nameof(day));
        }

        if (!(hour >= 0 && hour <= 23))
        {
            throw new ArgumentOutOfRangeException(nameof(hour));
        }

        if (!(minute >= 0 && minute <= 59))
        {
            throw new ArgumentOutOfRangeException(nameof(minute));
        }

        if (!(second >= 0 && second <= 59))
        {
            throw new ArgumentOutOfRangeException(nameof(second));
        }

        Year = year;
        Month = month;
        Day = day;
        Hour = hour;
        Minute = minute;
        Second = second;
    }

    public override bool Equals(object? obj)
    {
        if ((obj == null) || !GetType().Equals(obj.GetType()))
        {
            return false;
        }
        else
        {
            return Equals((ExtendedTimeSpan)obj);
        }
    }

    public bool Equals(ExtendedTimeSpan? other)
    {
        if (other is null)
        {
            return false;
        }

        return Year == other.Year && Month == other.Month && Day == other.Day && Hour == other.Hour && Minute == other.Minute && Second == other.Second;
    }

    public int CompareTo(ExtendedTimeSpan? other)
    {
        if (other == null)
        {
            return 1;
        }

        if (Equals(other))
        {
            return 0;
        }

        int yearComparison = CompareYear(other);
        int monthComparison = CompareMonth(other);
        int dayComparison = CompareDay(other);
        int hourComparison = CompareHour(other);
        int minuteComparison = CompareMinute(other);
        int secondComparison = CompareSecond(other);

        if (yearComparison != 0)
        {
            return yearComparison;
        }

        if (monthComparison != 0)
        {
            return monthComparison;
        }

        if (dayComparison != 0)
        {
            return dayComparison;
        }

        if (hourComparison != 0)
        {
            return hourComparison;
        }

        if (minuteComparison != 0)
        {
            return minuteComparison;
        }

        if (secondComparison != 0)
        {
            return secondComparison;
        }

        return 0;
    }

    private int CompareYear(ExtendedTimeSpan other)
    {
        if (Year == other.Year)
        {
            return 0;
        }
        else if (Year < other.Year)
        {
            return -1;
        }
        else 
        { 
            return 1; 
        }
    }

    private int CompareMonth(ExtendedTimeSpan other)
    {
        if (Month == other.Month)
        {
            return 0;
        }
        else if (Month < other.Month)
        {
            return -1;
        }
        else
        {
            return 1;
        }
    }

    private int CompareDay(ExtendedTimeSpan other)
    {
        if (Day == other.Day)
        {
            return 0;
        }
        else if (Day < other.Day)
        {
            return -1;
        }
        else
        {
            return 1;
        }
    }

    private int CompareHour(ExtendedTimeSpan other)
    {
        if (Hour == other.Hour)
        {
            return 0;
        }
        else if (Hour < other.Hour)
        {
            return -1;
        }
        else
        {
            return 1;
        }
    }

    private int CompareMinute(ExtendedTimeSpan other)
    {
        if (Minute == other.Minute)
        {
            return 0;
        }
        else if (Minute < other.Minute)
        {
            return -1;
        }
        else
        {
            return 1;
        }
    }

    private int CompareSecond(ExtendedTimeSpan other)
    {
        if (Second == other.Second)
        {
            return 0;
        }
        else if (Second < other.Second)
        {
            return -1;
        }
        else
        {
            return 1;
        }
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Year, Month, Day, Hour, Minute, Second);
    }

    public ExtendedTimeSpan Copy()
    {
        return new ExtendedTimeSpan(Year,Month,Day,Hour,Minute,Second); 
    }

    public static bool operator <(ExtendedTimeSpan left, ExtendedTimeSpan right)
    {
        return left.CompareTo(right) < 0;
    }

    public static bool operator <=(ExtendedTimeSpan left, ExtendedTimeSpan right)
    {
        return left.CompareTo(right) <= 0;
    }

    public static bool operator >(ExtendedTimeSpan left, ExtendedTimeSpan right)
    {
        return left.CompareTo(right) > 0;
    }

    public static bool operator >=(ExtendedTimeSpan left, ExtendedTimeSpan right)
    {
        return left.CompareTo(right) >= 0;
    }
}