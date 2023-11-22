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

    //Method that takes in an amount of years and returns the accurate amount of days accounting for leap years
    public static long TotalDays(int years)
    {
        long days = 0;
        for (int i = 1; i <= years; i++)
        {
            if (IsLeapYear(i))
            {
                days += 366;
            }
            else
            {
                days += 365;
            }
        }
        return days;
    }

    //method that takes in an amount of months and returns the accurate amount of days accounting for leap years
    public static long TotalDays(int years, int months)
    {
        long days = 0;
        for (int i = 0; i < months; i++)
        {
            if (IsLeapYear(years))
            {
                days += Month.FromValue(i).AmountOfDaysInLeapYear;
            }
            else
            {
                days += Month.FromValue(i).AmountOfDays;
            }
        }
        return days;
    }
}
