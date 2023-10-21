using System;

namespace ExtendedDate;

/// <summary>
/// Class <c>ExtendedDateOnly</c> Models A DateOnly Object that has extended reach to Int.MinValue and Int.MaxValue. 
/// It allows for Year Modelling with Year Zero and Without it.
/// </summary>
public class ExtendedDateOnly : IComparable<ExtendedDateOnly>, IEquatable<ExtendedDateOnly>
{
    //Constants
    public static readonly ExtendedDateOnly MaxValue = new ExtendedDateOnly(31, 12, int.MaxValue);
    public static readonly ExtendedDateOnly MinValue = new ExtendedDateOnly(1, 1, int.MaxValue);
    private static readonly DateOnly _defaultDate = new DateOnly(5000, 1, 1);

    //Members
    private DateOnly _monthDay = new DateOnly(_defaultDate.Year, 1, 1);
    private bool _isZerolegal = false;

    //Properties
    public int Year { get; private set; }

    public int Month
    {
        get
        {
            return _monthDay.Month;
        }
    }

    public int Day
    {
        get
        {
            return _monthDay.Day;
        }
    }

    public TimeEra Era
    {
        get
        {
            if (Year == 0)
            {
                return TimeEra.YearZero;
            }

            if (Year > 0)
            {
                return TimeEra.AfterZero;
            }

            if (Year < 0)
            {
                return TimeEra.BeforeZero;
            }
            //Branches should catch before reaching
            return TimeEra.NotInitialized;
        }
    }

    public MonthNames NameOfMonth
    {
        get
        {
            switch (_monthDay.Month)
            {
                case 1:
                    return MonthNames.January;
                case 2:
                    return MonthNames.February;
                case 3:
                    return MonthNames.March;
                case 4:
                    return MonthNames.April;
                case 5:
                    return MonthNames.May;
                case 6:
                    return MonthNames.June;
                case 7:
                    return MonthNames.July;
                case 8:
                    return MonthNames.August;
                case 9:
                    return MonthNames.September;
                case 10:
                    return MonthNames.October;
                case 11:
                    return MonthNames.November;
                case 12:
                    return MonthNames.December;
            }
            return MonthNames.None;
        }
    }

    //Constructor
    public ExtendedDateOnly(int year)
    {
        _isZerolegal = false;
        if (!(year >= int.MinValue && year <= int.MaxValue))
        {
            throw new ArgumentOutOfRangeException(nameof(year));
        }

        int tempYear = year;
        if (year == 0)
        {
            tempYear = 1;
        }
        Year = tempYear;
        _monthDay = new DateOnly(_defaultDate.Year, 1, 1);
    }

    public ExtendedDateOnly(int day, int month, int year)
    {
        _isZerolegal = false;
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

        int tempYear = year;
        if (year == 0)
        {
            tempYear = 1;
        }
        Year = tempYear;
        _monthDay = new DateOnly(_defaultDate.Year, month, day);
    }

    public ExtendedDateOnly(int year, bool isZeroLegal)
    {
        _isZerolegal = isZeroLegal;
        if (!(year >= int.MinValue && year <= int.MaxValue))
        {
            throw new ArgumentOutOfRangeException(nameof(year));
        }

        int tempYear = year;
        if (!_isZerolegal && year == 0)
        {
            tempYear = 1;
        }
        Year = tempYear;
        _monthDay = new DateOnly(_defaultDate.Year, 1, 1);
    }

    public ExtendedDateOnly(int day, int month, int year, bool isZeroLegal)
    {
        _isZerolegal = isZeroLegal;
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

        int tempYear = year;
        if (!_isZerolegal && year == 0)
        {
            tempYear = 1;
        }
        Year = tempYear;
        _monthDay = new DateOnly(_defaultDate.Year, month, day);
    }

    //Method

    /// <summary>
    /// Adds the specified Amount of Days to this Instance
    /// </summary>
    /// <param name="days"></param>
    public void AddDays(int days)
    {
        //Skips the Year Zero
        Add(days, TimeUnits.Day);
    }

    /// <summary>
    /// Adds the specified Amount of Months to this Instance
    /// </summary>
    /// <param name="months"></param>
    public void AddMonths(int months)
    {
        //Skips the Year Zero
        Add(months, TimeUnits.Month);
    }

    /// <summary>
    /// Adds the specified Amount of Years to this Instance
    /// </summary>
    /// <param name="years"></param>
    public void AddYears(int years)
    {
        //Skips the Year Zero
        Add(years, TimeUnits.Year);
    }

    /// <summary>
    /// Method for Adding a value to the specified Identifier.
    /// Accepts positiv and negative values
    /// <example>
    /// 
    /// <code>
    /// Example:
    /// If TimeUnit.Day is Given AddDays is Called on the Underlying DateOnly Struct
    /// If TimeUnit.Month is Given AddMonth is Called on the Underlying DateOnly Struct
    /// If TimeUnit.Year is Given AddYears is Called on the Underlying DateOnly Struct
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="val"></param>
    /// <param name="identifier"></param>
    private void Add(int val, TimeUnits identifier)
    {
        TimeUnits[] allowedOperations = { TimeUnits.Day, TimeUnits.Month, TimeUnits.Year };
        if (!allowedOperations.Contains(identifier))
        {
            return;
        }
        DateOnly tempDate = new DateOnly();
        bool matched = false;
        if (identifier is TimeUnits.Day && !matched)
        {
            tempDate = _monthDay.AddDays(val);
            matched = true;
        }

        if (identifier is TimeUnits.Month && !matched)
        {
            tempDate = _monthDay.AddMonths(val);
            matched = true;
        }

        if (identifier is TimeUnits.Year && !matched)
        {
            tempDate = _monthDay.AddYears(val);
            matched = true;
        }

        int deviance = 0;
        int year = tempDate.Year;
        int month = tempDate.Month;
        int day = tempDate.Day;
        deviance = ManageDeviance(year);
        _monthDay = ResetInteralYear(day, month);
        Year += deviance;
    }

    /// <summary>
    /// Wrapper Method around the deviance calculation.
    /// If Zero is Illegal Zero is Skipped
    /// </summary>
    /// <param name="year"></param>
    /// <returns>The corect deviance value for the situation</returns>
    private int ManageDeviance(int year)
    {
        int deviance = CalculateYearDeviance(year);
        if (_isZerolegal)
        {
            return deviance;
        }
        int result = IncreaseDevianceIfCrossing(deviance);
        return result;
    }

    /// <summary>
    /// If The Operation is Crossing Zero and Zero is an Illegal Year increases the deviance to compensate
    /// </summary>
    /// <param name="deviance"></param>
    /// <param name="year"></param>
    /// <returns>The changed deviance if it is needed by the situation</returns>
    private int IncreaseDevianceIfCrossing(int deviance)
    {
        if (_isZerolegal)
        {
            return deviance;
        }

        if (deviance == 0)
        {
            return deviance;
        }
        int result = deviance;
        if (IsCrossingZero(deviance))
        {
            if (deviance > 0)
            {
                result = deviance + 1;
            }
            else
            {
                result = deviance - 1;
            }
        }
        return result;
    }

    /// <summary>
    /// Determines if the Operation would be crossing the Zero Line
    /// </summary>
    /// <param name="year"></param>
    /// <returns>If the Operation is Crossing Zero</returns>
    private bool IsCrossingZero(int year)
    {
        int dev = Math.Abs(year);
        if (Year < 0 && Year + dev >= 0)
        {
            return true;
        }

        if (Year > 0 && Year - dev <= 0)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Calculates the diffrence between year and _defaultDate.Year
    /// </summary>
    /// <param name="year"></param>
    /// <returns>The difference between year and defaultDate.year</returns>
    private int CalculateYearDeviance(int year)
    {
        return year - _defaultDate.Year;
    }

    /// <summary>
    /// Resets the Year value of _monthDate but keeps the day and month value given
    /// </summary>
    /// <param name="day"></param>
    /// <param name="month"></param>
    /// <returns>A new DateOnly Struct with _defaultDate.year, month and day as values</returns>
    private DateOnly ResetInteralYear(int day, int month)
    {
        return new DateOnly(_defaultDate.Year, month, day);
    }

    public override string ToString()
    {
        return $"Day: {Day} | Month: {Month} | Monthname: {NameOfMonth} | Year: {Year} | Era: {Era}";
    }

    public override bool Equals(object? obj)
    {
        if ((obj == null) || !this.GetType().Equals(obj.GetType()))
        {
            return false;
        }
        else
        {
            return Equals((ExtendedDateOnly)obj);
        }
    }

    public bool Equals(ExtendedDateOnly? other)
    {
        if (other is null)
        {
            return false;
        }

        return this.Year.Equals(other.Year) && this.Month.Equals(other.Month) && this.Day.Equals(other.Day) && this.Era.Equals(other.Era);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_monthDay, _isZerolegal, Year, Month, Day, Era, NameOfMonth);
    }


    //Interface Methods

    public int CompareTo(ExtendedDateOnly? other)
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

        return 0;
    }

    private int CompareYear(ExtendedDateOnly other)
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

    private int CompareMonth(ExtendedDateOnly other)
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

    private int CompareDay(ExtendedDateOnly other)
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

    //Operators
    public static bool operator <(ExtendedDateOnly left, ExtendedDateOnly right)
    {
        return left.CompareTo(right) < 0;
    }

    public static bool operator <=(ExtendedDateOnly left, ExtendedDateOnly right)
    {
        return left.CompareTo(right) <= 0;
    }

    public static bool operator >(ExtendedDateOnly left, ExtendedDateOnly right)
    {
        return left.CompareTo(right) > 0;
    }

    public static bool operator >=(ExtendedDateOnly left, ExtendedDateOnly right)
    {
        return left.CompareTo(right) >= 0;
    }
}