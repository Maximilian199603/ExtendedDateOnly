using ExtendedDate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedTimeUnitTest;
internal class TimeUtilsUnitTest
{
    [Test]
    public void TimeUtilsIsLeapYearTest()
    {
        Assert.Multiple(() =>
        {
            //First Rule Test
            Assert.That(TimeUtils.IsLeapYear(2016), Is.True);
            Assert.That(TimeUtils.IsLeapYear(2020), Is.True);
            Assert.That(TimeUtils.IsLeapYear(2024), Is.True);
            Assert.That(TimeUtils.IsLeapYear(2028), Is.True);

            Assert.That(TimeUtils.IsLeapYear(2021), Is.False);
            Assert.That(TimeUtils.IsLeapYear(2022), Is.False);
            Assert.That(TimeUtils.IsLeapYear(2023), Is.False);
            Assert.That(TimeUtils.IsLeapYear(2025), Is.False);

            // Second Rule Test
            Assert.That(TimeUtils.IsLeapYear(1900), Is.False);
            Assert.That(TimeUtils.IsLeapYear(2100), Is.False);
            Assert.That(TimeUtils.IsLeapYear(2200), Is.False);
            Assert.That(TimeUtils.IsLeapYear(2300), Is.False);

            //Third Rule Test
            Assert.That(TimeUtils.IsLeapYear(1200), Is.True);
            Assert.That(TimeUtils.IsLeapYear(1600), Is.True);
            Assert.That(TimeUtils.IsLeapYear(2000), Is.True);
            Assert.That(TimeUtils.IsLeapYear(2400), Is.True);

        });
    }

    [Test]
    public void TimeUtilsUpperLimittest()
    {
        Assert.Multiple(() =>
        {
            //February Leap Year Test
            Assert.That(TimeUtils.CalculateUpperLimit(2016, 2), Is.EqualTo(29));
            Assert.That(TimeUtils.CalculateUpperLimit(2020, 2), Is.EqualTo(29));
            Assert.That(TimeUtils.CalculateUpperLimit(2024, 2), Is.EqualTo(29));
            Assert.That(TimeUtils.CalculateUpperLimit(2028, 2), Is.EqualTo(29));

            //February Non Leap Year Test
            Assert.That(TimeUtils.CalculateUpperLimit(2021, 2), Is.EqualTo(28));
            Assert.That(TimeUtils.CalculateUpperLimit(2022, 2), Is.EqualTo(28));
            Assert.That(TimeUtils.CalculateUpperLimit(2023, 2), Is.EqualTo(28));
            Assert.That(TimeUtils.CalculateUpperLimit(2025, 2), Is.EqualTo(28));

            //31 Day Month Leap Year Test
            Assert.That(TimeUtils.CalculateUpperLimit(2016, 3), Is.EqualTo(31));
            Assert.That(TimeUtils.CalculateUpperLimit(2020, 5), Is.EqualTo(31));
            Assert.That(TimeUtils.CalculateUpperLimit(2024, 7), Is.EqualTo(31));
            Assert.That(TimeUtils.CalculateUpperLimit(2028, 8), Is.EqualTo(31));

            //31 Day Month Non Leap Year Test
            Assert.That(TimeUtils.CalculateUpperLimit(2021, 3), Is.EqualTo(31));
            Assert.That(TimeUtils.CalculateUpperLimit(2022, 5), Is.EqualTo(31));
            Assert.That(TimeUtils.CalculateUpperLimit(2023, 7), Is.EqualTo(31));
            Assert.That(TimeUtils.CalculateUpperLimit(2025, 8), Is.EqualTo(31));

            //30 Day Month Leap Year Test
            Assert.That(TimeUtils.CalculateUpperLimit(2016, 4) , Is.EqualTo(30));
            Assert.That(TimeUtils.CalculateUpperLimit(2020, 6) , Is.EqualTo(30));
            Assert.That(TimeUtils.CalculateUpperLimit(2024, 9) , Is.EqualTo(30));
            Assert.That(TimeUtils.CalculateUpperLimit(2028, 11), Is.EqualTo(30));

            //30 Day Month Leap Year Test
            Assert.That(TimeUtils.CalculateUpperLimit(2021, 4) , Is.EqualTo(30));
            Assert.That(TimeUtils.CalculateUpperLimit(2022, 6) , Is.EqualTo(30));
            Assert.That(TimeUtils.CalculateUpperLimit(2023, 9) , Is.EqualTo(30));
            Assert.That(TimeUtils.CalculateUpperLimit(2025, 11), Is.EqualTo(30));
        });
    }
}