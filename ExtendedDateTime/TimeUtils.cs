using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedDate;
public class TimeUtils
{
    private TimeUtils()
    {
    }

    private static readonly int _FirstRuleDivisor = 4;

    private static readonly int _SecondRuleDivisor = 100;

    private static readonly int _ThirdRuleDivisor = 400;

    public static int CalculateUpperLimit(int year, int month)
    {
        Month result = Month.FromValue(month);

        if (!IsLeapYear(year))
        {
            return result.AmountOfDays;
        }
        return result.AmountOfDaysInLeapYear;
    }

    public static bool IsLeapYear(int year)
    {
        bool result = false;
        if (FirstLeapYearRule(year))
        {
            result = true;
        }

        if (SecondLeapYearRule(year))
        {
            result = false;
        }

        if (ThirdLeapYearRule(year))
        {
            result = true;
        }
        return result;
    }

    private static bool FirstLeapYearRule(int year)
    {
        return ExtendedMath.Modulo(year, _FirstRuleDivisor) == 0;
    }

    private static bool SecondLeapYearRule(int year)
    {
        return ExtendedMath.Modulo(year, _SecondRuleDivisor) == 0;
    }

    private static bool ThirdLeapYearRule(int year)
    {
        return ExtendedMath.Modulo(year, _ThirdRuleDivisor) == 0;
    }
}
