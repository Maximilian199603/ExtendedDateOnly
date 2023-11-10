namespace ExtendedDate;

/// <summary>
/// Class <c>ExtendedDateTime</c> Models A DateTime Object that has extended reach to Int.MinValue and Int.MaxValue. 
/// It allows for Year Modelling with Year Zero and Without it.
/// </summary>
public class ExtendedDateTime
{
    //Constants
    private static readonly ExtendedDateTime _MaxValue = new ExtendedDateTime(31, 12, int.MaxValue,23,59,59);
    private static readonly ExtendedDateTime _MinValue = new ExtendedDateTime(1, 1, int.MaxValue,0,0,0);
    private static readonly DateTime _defaultDateTime = new DateTime(5000, 1, 1);

    //Members
    private DateTime _DateTime = new DateTime(_defaultDateTime.Year, 1, 1);
    private readonly bool _IsZerolegal = false;

    //Properties
    public int Year { get; private set; }

    public int Month
    {
        get
        {
            return _DateTime.Month;
        }
    }

    public int Day
    {
        get
        {
            return _DateTime.Day;
        }
    }

    public int Hour
    {
        get
        {
            return _DateTime.Hour;
        }
    }

    public int Minute
    {
        get
        {
            return _DateTime.Minute;
        }
    }

    public int Second
    {
        get
        {
            return _DateTime.Second;
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
            switch (_DateTime.Month)
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

    public static ExtendedDateTime MaxValue => _MaxValue.Copy();

    public static ExtendedDateTime MinValue => _MinValue.Copy();

    //Constructor
    public ExtendedDateTime(int year)
    {
        _IsZerolegal = false;
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
        _DateTime = new DateTime(_defaultDateTime.Year, 1, 1);
    }

    public ExtendedDateTime(int day, int month, int year)
    {
        _IsZerolegal = false;
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
        _DateTime = new DateTime(_defaultDateTime.Year, month, day);
    }

    public ExtendedDateTime(int day, int month, int year, int hour, int minute, int second)
    {
        _IsZerolegal = false;
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

        int tempYear = year;
        if (year == 0)
        {
            tempYear = 1;
        }
        Year = tempYear;
        _DateTime = new DateTime(_defaultDateTime.Year, month, day, hour, minute, second);
    }

    public ExtendedDateTime(int year, bool isZeroLegal)
    {
        _IsZerolegal = isZeroLegal;
        if (!(year >= int.MinValue && year <= int.MaxValue))
        {
            throw new ArgumentOutOfRangeException(nameof(year));
        }

        int tempYear = year;
        if (!_IsZerolegal && year == 0)
        {
            tempYear = 1;
        }
        Year = tempYear;
        _DateTime = new DateTime(_defaultDateTime.Year, 1, 1);
    }

    public ExtendedDateTime(int day, int month, int year, bool isZeroLegal)
    {
        _IsZerolegal = isZeroLegal;
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
        if (!_IsZerolegal && year == 0)
        {
            tempYear = 1;
        }
        Year = tempYear;
        _DateTime = new DateTime(_defaultDateTime.Year, month, day);
    }

    public ExtendedDateTime(int day, int month, int year, int hour, int minute, int second, bool isZeroLegal)
    {
        _IsZerolegal = isZeroLegal;
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

        int tempYear = year;
        if (!_IsZerolegal && year == 0)
        {
            tempYear = 1;
        }
        Year = tempYear;
        _DateTime = new DateTime(_defaultDateTime.Year, month, day, hour, minute, second);
    }

    //Method

    /// <summary>
    /// Adds the specified Amount of Days to this Instance
    /// </summary>
    /// <param name="days"></param>
    public void AddDays(int days)
    {
        Add(days, TimeUnits.Day);
    }

    /// <summary>
    /// Adds the specified Amount of Months to this Instance
    /// </summary>
    /// <param name="months"></param>
    public void AddMonths(int months)
    {
        Add(months, TimeUnits.Month);
    }

    /// <summary>
    /// Adds the specified Amount of Years to this Instance
    /// </summary>
    /// <param name="years"></param>
    public void AddYears(int years)
    {
        Add(years, TimeUnits.Year);
    }

    /// <summary>
    /// Adds the specified Amount of Hours to this Instance
    /// </summary>
    /// <param name="hours"></param>
    public void AddHours(int hours)
    {
        Add(hours, TimeUnits.Hour);
    }

    /// <summary>
    /// Adds the specified Amount of Minutes to this Instance
    /// </summary>
    /// <param name="minutes"></param>
    public void AddMinutes(int minutes)
    {
        Add(minutes, TimeUnits.Minute);
    }

    /// <summary>
    /// Adds the specified Amount of Seconds to this Instance
    /// </summary>
    /// <param name="seconds"></param>
    public void AddSeconds(int seconds)
    {
        Add(seconds, TimeUnits.Second);
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
        TimeUnits[] allowedOperations = { TimeUnits.Day, TimeUnits.Month, TimeUnits.Year, TimeUnits.Hour, TimeUnits.Minute, TimeUnits.Second };
        if (!allowedOperations.Contains(identifier))
        {
            return;
        }
        DateTime tempDate = new DateTime();
        bool matched = false;
        if (identifier is TimeUnits.Day && !matched)
        {
            tempDate = _DateTime.AddDays(val);
            matched = true;
        }

        if (identifier is TimeUnits.Month && !matched)
        {
            tempDate = _DateTime.AddMonths(val);
            matched = true;
        }

        if (identifier is TimeUnits.Year && !matched)
        {
            tempDate = _DateTime.AddYears(val);
            matched = true;
        }

        if (identifier is TimeUnits.Hour && !matched)
        {
            tempDate = _DateTime.AddHours(val);
            matched = true;
        }

        if (identifier is TimeUnits.Minute && !matched)
        {
            tempDate = _DateTime.AddMinutes(val);
            matched = true;
        }

        if (identifier is TimeUnits.Second && !matched)
        {
            tempDate = _DateTime.AddSeconds(val);
            matched = true;
        }

        if (identifier is TimeUnits.Millisecond && !matched)
        {
            tempDate = _DateTime.AddMilliseconds(val);
            matched = true;
        }

        int deviance = 0;
        int year = tempDate.Year;
        int month = tempDate.Month;
        int day = tempDate.Day;
        int hour = tempDate.Hour;
        int minute = tempDate.Minute;
        int second = tempDate.Second;
        deviance = ManageDeviance(year);
        _DateTime = ResetInteralYear(day, month, hour, minute, second);
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
        if (_IsZerolegal)
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
        if (_IsZerolegal)
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
        return year - _defaultDateTime.Year;
    }

    /// <summary>
    /// Resets the Year value of _monthDate but keeps the day and month value given
    /// </summary>
    /// <param name="day"></param>
    /// <param name="month"></param>
    /// <returns>A new DateOnly Struct with _defaultDate.year, month and day as values</returns>
    private DateTime ResetInteralYear(int day, int month, int hour, int minute, int second)
    {
        return new DateTime(_defaultDateTime.Year, month, day, hour, minute, second);
    }

    public override string ToString()
    {
        return $"Day: {Day} | Month: {Month} | Year: {Year} | Hour: {Hour} | Minute: {Minute} |Second: {Second} |Era: {Era} | Monthname: {NameOfMonth}";
    }

    public override bool Equals(object? obj)
    {
        if ((obj == null) || !this.GetType().Equals(obj.GetType()))
        {
            return false;
        }
        else
        {
            return Equals((ExtendedDateTime)obj);
        }
    }

    public bool Equals(ExtendedDateTime? other)
    {
        if (other is null)
        {
            return false;
        }

        return this.Year.Equals(other.Year) && this._DateTime.Equals(other._DateTime);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_DateTime, _IsZerolegal, Year, Month, Day, Era, NameOfMonth);
    }

    public ExtendedDateTime Copy()
    {
        return new ExtendedDateTime(Year,Month,Day,Hour,Minute,Second,_IsZerolegal);
    }

    public int CompareTo(ExtendedDateTime? other)
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

    private int CompareYear(ExtendedDateTime other)
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

    private int CompareMonth(ExtendedDateTime other)
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

    private int CompareDay(ExtendedDateTime other)
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

    private int CompareHour(ExtendedDateTime other)
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

    private int CompareMinute(ExtendedDateTime other)
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

    private int CompareSecond(ExtendedDateTime other)
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

    //Operators
    public static bool operator <(ExtendedDateTime left, ExtendedDateTime right)
    {
        return left.CompareTo(right) < 0;
    }

    public static bool operator <=(ExtendedDateTime left, ExtendedDateTime right)
    {
        return left.CompareTo(right) <= 0;
    }

    public static bool operator >(ExtendedDateTime left, ExtendedDateTime right)
    {
        return left.CompareTo(right) > 0;
    }

    public static bool operator >=(ExtendedDateTime left, ExtendedDateTime right)
    {
        return left.CompareTo(right) >= 0;
    }

    public static ExtendedTimeSpan operator -(ExtendedDateTime left, ExtendedDateTime right)
    {
        return null;
    }

    public static ExtendedDateTime operator +(ExtendedDateTime left, ExtendedDateTime right)
    {
        left.AddSeconds(right.Second);
        left.AddMinutes(right.Minute);
        left.AddHours(right.Hour);
        left.AddDays(right.Day);
        left.AddMonths(right.Month);
        left.AddYears(right.Year);
        return left.Copy();
    }
}
