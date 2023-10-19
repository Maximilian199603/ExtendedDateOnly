using ExtendedDate;

namespace ExtendedTimeUnitTest;

public class ExtendedDateTimeUnitTests
{
    [SetUp]
    public void SetUp()
    {

    }

    [Test]
    public void ExtendedDateTimeEqualsTest()
    {
        ExtendedDateTime tester = new ExtendedDateTime(200);
        ExtendedDateTime comparison = new ExtendedDateTime(200);
        Assert.That(tester, Is.EqualTo(comparison));
        comparison = new ExtendedDateTime(-200);
        Assert.That(tester, Is.Not.EqualTo(comparison));
    }

    [Test]
    public void ExtendedDateTimeToStringTest()
    {
        ExtendedDateTime tester = new ExtendedDateTime(200);
        string comparison = $"Day: 1 | Month: 1 | Year: 200 | Hour: 0 | Minute: 0 |Second: 0 |Era: AfterZero | Monthname: January";
        Assert.That(tester.ToString(), Is.EqualTo(comparison));
    }

    [Test]
    public void ExtendedDateTimeCompareOperatorTest()
    {
        ExtendedDateTime tester = new ExtendedDateTime(200);
        ExtendedDateTime comparison = new ExtendedDateTime(201);

        //Year Test
        Assert.That(tester < comparison);
        Assert.That(tester <= comparison);
        Assert.That(comparison > tester);
        Assert.That(comparison >= tester);
        comparison = new ExtendedDateTime(200);
        Assert.That(tester <= comparison);
        Assert.That(tester >= comparison);

        //Month Test
        tester = new ExtendedDateTime(1,1,200);
        comparison = new ExtendedDateTime(1,2,200);
        Assert.That(tester < comparison);
        Assert.That(tester <= comparison);
        Assert.That(comparison > tester);
        Assert.That(comparison >= tester);
        comparison = new ExtendedDateTime(1,1,200);
        Assert.That(tester <= comparison);
        Assert.That(tester >= comparison);

        //Day Test
        tester = new ExtendedDateTime(1,1,200);
        comparison = new ExtendedDateTime(2,1,200);
        Assert.That(tester < comparison);
        Assert.That(tester <= comparison);
        Assert.That(comparison > tester);
        Assert.That(comparison >= tester);
        comparison = new ExtendedDateTime(1,1,200);
        Assert.That(tester <= comparison);
        Assert.That(tester >= comparison);

        //Hour Test
        tester = new ExtendedDateTime(1,1,200,1,1,1);
        comparison = new ExtendedDateTime(1,1,200,2,1,1);
        Assert.That(tester < comparison);
        Assert.That(tester <= comparison);
        Assert.That(comparison > tester);
        Assert.That(comparison >= tester);
        comparison = new ExtendedDateTime(1,1,200,1,1,1);
        Assert.That(tester <= comparison);
        Assert.That(tester >= comparison);

        //Minute Test
        tester = new ExtendedDateTime(1,1,200,1,1,1);
        comparison = new ExtendedDateTime(1,1,200,1,2,1);
        Assert.That(tester < comparison);
        Assert.That(tester <= comparison);
        Assert.That(comparison > tester);
        Assert.That(comparison >= tester);
        comparison = new ExtendedDateTime(1,1,200,1,1,1);
        Assert.That(tester <= comparison);
        Assert.That(tester >= comparison);

        //Second Test
        tester = new ExtendedDateTime(1,1,200,1,1,1);
        comparison = new ExtendedDateTime(1,1,200,1,1,2);
        Assert.That(tester < comparison);
        Assert.That(tester <= comparison);
        Assert.That(comparison > tester);
        Assert.That(comparison >= tester);
        comparison = new ExtendedDateTime(1,1,200,1,1,1);
        Assert.That(tester <= comparison);
        Assert.That(tester >= comparison);
    }

    [Test]
    public void ExtendedDateTimeCompareTest()
    {
        ExtendedDateTime tester = new ExtendedDateTime(200);
        ExtendedDateTime comparison = new ExtendedDateTime(200);
        Assert.That(tester.CompareTo(comparison),Is.EqualTo(0));
        comparison = null;
        Assert.That(tester.CompareTo(comparison), Is.EqualTo(1));
        comparison = new ExtendedDateTime(201);
        Assert.That(tester.CompareTo(comparison), Is.EqualTo(-1));
        comparison = new ExtendedDateTime(199);
        Assert.That(tester.CompareTo(comparison), Is.EqualTo(1));
    }

    [Test]
    public void ExtendedDateTimeHashCodeTest()
    {
        ExtendedDateTime tester = new ExtendedDateTime(200);
        ExtendedDateTime comparison = new ExtendedDateTime(200);
        Assert.That(tester.GetHashCode(), Is.EqualTo(comparison.GetHashCode()));
        comparison = new ExtendedDateTime(201);
        Assert.That(tester.GetHashCode(), Is.Not.EqualTo(comparison.GetHashCode()));
    }

    [Test]
    public void ExtendedDateTimeAddDaysTest()
    {
        ExtendedDateTime tester = new ExtendedDateTime(1,1,200);
        ExtendedDateTime comparison = new ExtendedDateTime(21,1,200);
        //Add
        tester.AddDays(20);
        Assert.That(tester, Is.EqualTo(comparison));
        //Subtract
        comparison = new ExtendedDateTime(1,1,200);
        tester.AddDays(-20);
        Assert.That(tester, Is.EqualTo(comparison));

        //Crossing from Positiv Side
        comparison = new ExtendedDateTime(31, 12, -1);
        tester = new ExtendedDateTime(1);
        tester.AddDays(-1);
        Assert.That(tester, Is.EqualTo(comparison));

        //Crossing Zero from the Negative Side
        comparison = new ExtendedDateTime(1);
        tester = new ExtendedDateTime(31, 12, -1);
        tester.AddDays(1);
        Assert.That(tester, Is.EqualTo(comparison));
    }

    [Test]
    public void ExtendedDateTimeAddDaysZeroLegalTest()
    {
        ExtendedDateTime tester = new ExtendedDateTime(200, true);
        //Add
        ExtendedDateTime comparison = new ExtendedDateTime(21, 1, 200, true);
        tester.AddDays(20);
        Assert.That(tester, Is.EqualTo(comparison));

        //Subtract
        comparison = new ExtendedDateTime(200, true);
        tester.AddDays(-20);
        Assert.That(tester, Is.EqualTo(comparison));

        //Crossing Zero from the Positiv Side
        comparison = new ExtendedDateTime(31, 12, 0, true);
        tester = new ExtendedDateTime(1, true);
        tester.AddDays(-1);
        Assert.That(tester, Is.EqualTo(comparison));

        //Crossing Zero from the Negative Side
        comparison = new ExtendedDateTime(1, true);
        tester = new ExtendedDateTime(31, 12, 0, true);
        tester.AddDays(1);
        Assert.That(tester, Is.EqualTo(comparison));
    }

    [Test]
    public void ExtendedDateTimeAddMonthsTest() 
    {
        ExtendedDateTime tester = new ExtendedDateTime(200);
        //Add
        ExtendedDateTime comparison = new ExtendedDateTime(1, 11, 200);
        tester.AddMonths(10);
        Assert.That(tester, Is.EqualTo(comparison));

        //Subtract
        comparison = new ExtendedDateTime(200);
        tester.AddMonths(-10);
        Assert.That(tester, Is.EqualTo(comparison));

        //Crossing Zero from the Positiv Side
        comparison = new ExtendedDateTime(1, 12, -1);
        tester = new ExtendedDateTime(1);
        tester.AddMonths(-1);
        Assert.That(tester, Is.EqualTo(comparison));

        //Crossing Zero from the Negative Side
        comparison = new ExtendedDateTime(1);
        tester = new ExtendedDateTime(1, 12, -1);
        tester.AddMonths(1);
        Assert.That(tester, Is.EqualTo(comparison));
    }

    [Test]
    public void ExtendedDateTimeAddMonthsYearZeroLegalTest()
    {
        ExtendedDateTime tester = new ExtendedDateTime(200, true);
        //Add
        ExtendedDateTime comparison = new ExtendedDateTime(1, 11, 200, true);
        tester.AddMonths(10);
        Assert.That(tester, Is.EqualTo(comparison));

        //Subtract
        comparison = new ExtendedDateTime(200, true);
        tester.AddMonths(-10);
        Assert.That(tester, Is.EqualTo(comparison));

        //Crossing Zero from the Positiv Side
        comparison = new ExtendedDateTime(1, 12, 0, true);
        tester = new ExtendedDateTime(1, true);
        tester.AddMonths(-1);
        Assert.That(tester, Is.EqualTo(comparison));

        //Crossing Zero from the Negative Side
        comparison = new ExtendedDateTime(1, true);
        tester = new ExtendedDateTime(1, 12, 0, true);
        tester.AddMonths(1);
        Assert.That(tester, Is.EqualTo(comparison));
    }

    [Test]
    public void ExtendedDateTimeAddYearsTest()
    {
        ExtendedDateTime tester = new ExtendedDateTime(2000);

        //Add
        ExtendedDateTime comparison = new ExtendedDateTime(2001);
        tester.AddYears(1);
        Assert.That(tester, Is.EqualTo(comparison));
        //Off by One

        //Subtract
        comparison = new ExtendedDateTime(2000);
        tester.AddYears(-1);
        Assert.That(tester, Is.EqualTo(comparison));
        //Off by One

        //Crossing Zero from the Positiv Side
        comparison = new ExtendedDateTime(-1);
        tester = new ExtendedDateTime(1);
        tester.AddYears(-1);
        Assert.That(tester, Is.EqualTo(comparison));

        //Crossing Zero from the Negative Side
        comparison = new ExtendedDateTime(1);
        tester = new ExtendedDateTime(-1);
        tester.AddYears(1);
        Assert.That(tester, Is.EqualTo(comparison));
    }

    [Test]
    public void ExtendedDateTimeAddYearsYearZeroLegalTest()
    {
        ExtendedDateTime tester = new ExtendedDateTime(2000, true);

        //Add
        ExtendedDateTime comparison = new ExtendedDateTime(2001, true);
        tester.AddYears(1);
        Assert.That(tester, Is.EqualTo(comparison));
        //Off by One

        //Subtract
        comparison = new ExtendedDateTime(2000, true);
        tester.AddYears(-1);
        Assert.That(tester, Is.EqualTo(comparison));
        //Off by One

        //Crossing Zero from the Positiv Side
        comparison = new ExtendedDateTime(0, true);
        tester = new ExtendedDateTime(1, true);
        tester.AddYears(-1);
        Assert.That(tester, Is.EqualTo(comparison));

        //Crossing Zero from the Negative Side
        comparison = new ExtendedDateTime(1, true);
        tester = new ExtendedDateTime(0, true);
        tester.AddYears(1);
        Assert.That(tester, Is.EqualTo(comparison));
    }

    [Test]
    public void ExtendedDateTimeAddHoursTest()
    {
        ExtendedDateTime tester = new ExtendedDateTime(1,1,2000,0,0,0);
        ExtendedDateTime comparison = new ExtendedDateTime(1,1,2000,1, 0, 0);
        //Add
        tester.AddHours(1);
        Assert.That(tester, Is.EqualTo(comparison));

        //Subtract
        comparison = new ExtendedDateTime(1, 1, 2000, 0, 0, 0);
        tester.AddHours(-1);
        Assert.That(tester, Is.EqualTo(comparison));

        //Crossing Zero from the Positiv Side
        tester = new ExtendedDateTime(1,1,1,0,0,0);
        comparison = new ExtendedDateTime(31,12,-1,23,0,0);
        tester.AddHours(-1);
        Assert.That(tester, Is.EqualTo(comparison));

        //Crossing Zero from the Negative Side
        comparison = new ExtendedDateTime(1);
        tester = new ExtendedDateTime(31, 12, -1, 23, 0, 0);
        tester.AddHours(1);
        Assert.That(tester, Is.EqualTo(comparison));
    }

    [Test]
    public void ExtendedDateTimeAddHoursYearzeroLegalTest()
    {
        ExtendedDateTime tester = new ExtendedDateTime(1, 1, 2000, 0, 0, 0, true);
        ExtendedDateTime comparison = new ExtendedDateTime(1, 1, 2000, 1, 0, 0, true);
        //Add
        tester.AddHours(1);
        Assert.That(tester, Is.EqualTo(comparison));

        //Subtract
        comparison = new ExtendedDateTime(1, 1, 2000, 0, 0, 0, true);
        tester.AddHours(-1);
        Assert.That(tester, Is.EqualTo(comparison));

        //Crossing Zero from the Positiv Side
        tester = new ExtendedDateTime(1, 1, 1, 0, 0, 0, true);
        comparison = new ExtendedDateTime(31,12,0,23,0,0, true);
        tester.AddHours(-1);
        Assert.That(tester, Is.EqualTo(comparison));

        //Crossing Zero from the Negative Side
        tester = new ExtendedDateTime(31,12,-1,23,0,0, true);
        comparison = new ExtendedDateTime(1,1,0,0,0,0, true);
        tester.AddHours(1);
        Assert.That(tester, Is.EqualTo(comparison));
    }

    [Test]
    public void ExtendedDateTimeAddMinutesTest()
    {
        ExtendedDateTime tester = new ExtendedDateTime(1, 1, 2000, 0, 0, 0);
        ExtendedDateTime comparison = new ExtendedDateTime(1, 1, 2000, 0, 1, 0);
        //Add
        tester.AddMinutes(1);
        Assert.That(tester, Is.EqualTo(comparison));

        //Subtract
        comparison = new ExtendedDateTime(1, 1, 2000, 0, 0, 0);
        tester.AddMinutes(-1);
        Assert.That(tester, Is.EqualTo(comparison));

        //Crossing Zero from the Positiv Side
        tester = new ExtendedDateTime(1, 1, 1, 0, 0, 0);
        comparison = new ExtendedDateTime(31, 12, -1, 23, 59, 0);
        tester.AddMinutes(-1);
        Assert.That(tester, Is.EqualTo(comparison));

        //Crossing Zero from the Negative Side
        tester = new ExtendedDateTime(31, 12, -1, 23, 59, 0);
        comparison = new ExtendedDateTime(1, 1, 1, 0, 0, 0);
        tester.AddMinutes(1);
        Assert.That(tester, Is.EqualTo(comparison));
    }

    [Test]
    public void ExtendedDateTimeAddMinutesYearZeroLegalTest()
    {
        ExtendedDateTime tester = new ExtendedDateTime(1, 1, 2000, 0, 0, 0, true);
        ExtendedDateTime comparison = new ExtendedDateTime(1, 1, 2000, 0, 1, 0, true);
        //Add
        tester.AddMinutes(1);
        Assert.That(tester, Is.EqualTo(comparison));

        //Subtract
        comparison = new ExtendedDateTime(1, 1, 2000, 0, 0, 0, true);
        tester.AddMinutes(-1);
        Assert.That(tester, Is.EqualTo(comparison));

        //Crossing Zero from the Positiv Side
        tester = new ExtendedDateTime(1, 1, 1, 0, 0, 0, true);
        comparison = new ExtendedDateTime(31, 12, 0, 23, 59, 0, true);
        tester.AddMinutes(-1);
        Assert.That(tester, Is.EqualTo(comparison));

        //Crossing Zero from the Negative Side
        tester = new ExtendedDateTime(31, 12, -1, 23, 59, 0, true);
        comparison = new ExtendedDateTime(1, 1, 0, 0, 0, 0, true);
        tester.AddMinutes(1);
        Assert.That(tester, Is.EqualTo(comparison));
    }

    [Test]
    public void ExtendedDateTimeAddSecondsTest()
    {
        ExtendedDateTime tester = new ExtendedDateTime(1, 1, 2000, 0, 0, 0);
        ExtendedDateTime comparison = new ExtendedDateTime(1, 1, 2000, 0, 0, 1);
        //Add
        tester.AddSeconds(1);
        Assert.That(tester, Is.EqualTo(comparison));
        //Off by One

        //Subtract
        comparison = new ExtendedDateTime(1, 1, 2000, 0, 0, 0);
        tester.AddSeconds(-1);
        Assert.That(tester, Is.EqualTo(comparison));
        //Off by One

        //Crossing Zero from the Positiv Side
        tester = new ExtendedDateTime(1, 1, 1, 0, 0, 0);
        comparison = new ExtendedDateTime(31, 12, -1, 23, 59, 59);
        tester.AddSeconds(-1);
        Assert.That(tester, Is.EqualTo(comparison));

        //Crossing Zero from the Negative Side
        tester = new ExtendedDateTime(31, 12, -1, 23, 59, 59);
        comparison = new ExtendedDateTime(1, 1, 1, 0, 0, 0);
        tester.AddSeconds(1);
        Assert.That(tester, Is.EqualTo(comparison));
    }

    [Test]
    public void ExtendedDateTimeAddSecondsYearZeroLegalTest()
    {
        ExtendedDateTime tester = new ExtendedDateTime(1, 1, 2000, 0, 0, 0, true);
        ExtendedDateTime comparison = new ExtendedDateTime(1, 1, 2000, 0, 0, 1, true);
        //Add
        tester.AddSeconds(1);
        Assert.That(tester, Is.EqualTo(comparison));
        //Off by One

        //Subtract
        comparison = new ExtendedDateTime(1, 1, 2000, 0, 0, 0, true);
        tester.AddSeconds(-1);
        Assert.That(tester, Is.EqualTo(comparison));
        //Off by One

        //Crossing Zero from the Positiv Side
        tester = new ExtendedDateTime(1, 1, 1, 0, 0, 0, true);
        comparison = new ExtendedDateTime(31, 12, 0, 23, 59, 59, true);
        tester.AddSeconds(-1);
        Assert.That(tester, Is.EqualTo(comparison));

        //Crossing Zero from the Negative Side
        tester = new ExtendedDateTime(31, 12, -1, 23, 59, 59, true);
        comparison = new ExtendedDateTime(1, 1, 0, 0, 0, 0, true);
        tester.AddSeconds(1);
        Assert.That(tester, Is.EqualTo(comparison));
    }
}
