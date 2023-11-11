using System;
using System.Text;

namespace ExtendedDate;

public class ExtendedTimeSpan : IComparable<ExtendedTimeSpan>, IComparable, IEquatable<ExtendedTimeSpan>, ICloneable, ITime
{
    public int Year { get; private set; }

    public int Month { get; private set; }

    public int Day { get; private set; }

    public int Hour { get; private set; }

    public int Minute { get; private set; }

    public int Second { get; private set; }

    public TimeEra Era => TimeEra.None;

    public MonthNames NameOfMonth => MonthNames.None;

    private static readonly ExtendedTimeSpan _Zero = new ExtendedTimeSpan(0, 0, 0, 0, 0, 0);

    private static readonly ExtendedTimeSpan _MaxValue = new ExtendedTimeSpan(int.MaxValue, 12, 31, 23, 59, 59);

    private static readonly ExtendedTimeSpan _MinValue = new ExtendedTimeSpan(int.MinValue, 0, 0, 0, 0, 0);

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

    public ExtendedTimeSpan(int year, int month, int day, int hour, int minute, int second) : this(year, month, day, hour, minute)
    {
        Second = second;
    }

    public ExtendedTimeSpan(int year, int month, int day, int hour, int minute) : this(year, month, day, hour)
    {
        Minute = minute;
    }

    public ExtendedTimeSpan(int year, int month, int day, int hour) : this(year, month, day)
    {
        Hour = hour;
    }

    public ExtendedTimeSpan(int year, int month, int day) : this(year, month)
    {
        Day = day;
    }

    public ExtendedTimeSpan(int year, int month) : this(year)
    {
        Month = month;
    }

    public ExtendedTimeSpan(int year)
    {
        Year = year;
        Month = 0;
        Day = 0;
        Hour = 0;
        Minute = 0;
        Second = 0;
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
        return HashCode.Combine(Year, Month, Day, Hour, Minute, Second, Era, NameOfMonth);
    }

    public ExtendedTimeSpan Copy()
    {
        return new ExtendedTimeSpan(Year,Month,Day,Hour,Minute,Second); 
    }

    public object Clone()
    {
        return Copy();
    }

    public int CompareTo(object? obj)
    {
        if (obj is not ExtendedTimeSpan)
        {
            throw new ArgumentException("Given Object is not of Type ExtendedDateOnly");
        }

        return CompareTo(obj as ExtendedTimeSpan);
    }

    public override string? ToString()
    {
        return $"Day: {Day} | Month: {Month} | Year: {Year} | Hour: {Hour} | Minute: {Minute} | Second: {Second}";
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

    public static ExtendedTimeSpan operator -(ExtendedTimeSpan left, ExtendedTimeSpan right)
    {
        // cast is not redundant as it calls the more generic method that subtract values from another
        return TimeSpanFactory.Create(left as ITime, right as ITime);
    }

    public static ExtendedTimeSpan operator +(ExtendedTimeSpan left, ExtendedTimeSpan right)
    {
        return TimeSpanFactory.Create(left,right);
    }
}