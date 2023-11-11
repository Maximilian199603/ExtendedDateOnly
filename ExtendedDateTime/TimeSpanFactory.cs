using System;

namespace ExtendedDate;

public class TimeSpanFactory
{
    private TimeSpanFactory()
    {
    }

    public static ExtendedTimeSpan Create(ITime left, ITime right)
    {
        var tuple = Comparator.Compare(left,right);
        ITime larger = (ITime)tuple.larger;
        ITime smaller = (ITime)tuple.smaller;
        if (tuple.equal)
        {
            return ExtendedTimeSpan.Zero;
        }
        int year = ExtendedMath.AbsolutSubtraction(larger.Year, smaller.Year);
        int month = ExtendedMath.AbsolutSubtraction(larger.Month, smaller.Month);
        int day = ExtendedMath.AbsolutSubtraction(larger.Day, smaller.Day);
        int hour = ExtendedMath.AbsolutSubtraction(larger.Hour, smaller.Hour);
        int minute = ExtendedMath.AbsolutSubtraction(larger.Minute, smaller.Minute);
        int second = ExtendedMath.AbsolutSubtraction(larger.Second, smaller.Second);
        return new ExtendedTimeSpan(year, month, day, hour, minute, second);
    }

    public static ExtendedTimeSpan Create(ExtendedTimeSpan left, ExtendedTimeSpan right)
    {
        int year = left.Year + right.Year;
        int month = left.Month + right.Month;
        int day = left.Day + right.Day;
        int hour = left.Hour + right.Hour;
        int minute = left.Minute + right.Minute;
        int second = left.Second + right.Second;
        return new ExtendedTimeSpan(year, month, day, hour, minute, second);
    }
}
