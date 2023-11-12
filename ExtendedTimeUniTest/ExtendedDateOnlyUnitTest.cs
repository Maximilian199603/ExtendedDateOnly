using ExtendedDate;

namespace ExtendedTimeUnitTest;

//Passed All tests on 19.10.2023 17:12

public class ExtendedDateOnlyUnitTests
{
    private ExtendedDateOnly pos;

    [SetUp]
    public void Setup()
    {
        pos = new ExtendedDateOnly(200);
    }

    [Test]
    public void ExtendedDateAddDaysTest()
    {
        ExtendedDateOnly tester = new ExtendedDateOnly(200);
        //Add
        ExtendedDateOnly comparison = new ExtendedDateOnly(21,1,200);
        tester.AddDays(20);
        Assert.That(tester, Is.EqualTo(comparison));

        //Subtract
        comparison = new ExtendedDateOnly(200);
        tester.AddDays(-20);
        Assert.That(tester, Is.EqualTo(comparison));

        //Crossing Zero from the Positiv Side
        comparison = new ExtendedDateOnly(31,12,-1);
        tester = new ExtendedDateOnly(1);
        tester.AddDays(-1);
        Assert.That(tester, Is.EqualTo(comparison));

        //Crossing Zero from the Negative Side
        comparison = new ExtendedDateOnly(1);
        tester = new ExtendedDateOnly(31, 12, -1);
        tester.AddDays(1);
        Assert.That(tester, Is.EqualTo(comparison));
    }

    [Test]
    public void ExtendedDateAddDaysZeroLegalTest()
    {
        ExtendedDateOnly tester = new ExtendedDateOnly(200,true);
        //Add
        ExtendedDateOnly comparison = new ExtendedDateOnly(21, 1, 200,true);
        tester.AddDays(20);
        Assert.That(tester, Is.EqualTo(comparison));

        //Subtract
        comparison = new ExtendedDateOnly(200, true);
        tester.AddDays(-20);
        Assert.That(tester, Is.EqualTo(comparison));

        //Crossing Zero from the Positiv Side
        comparison = new ExtendedDateOnly(31, 12, 0, true);
        tester = new ExtendedDateOnly(1, true);
        tester.AddDays(-1);
        Assert.That(tester, Is.EqualTo(comparison));

        //Crossing Zero from the Negative Side
        comparison = new ExtendedDateOnly(1, true);
        tester = new ExtendedDateOnly(31, 12, 0, true);
        tester.AddDays(1);
        Assert.That(tester, Is.EqualTo(comparison));
    }

    [Test]
    public void ExtendedDateAddMonthsTest()
    {
        ExtendedDateOnly tester = new ExtendedDateOnly(200);
        //Add
        ExtendedDateOnly comparison = new ExtendedDateOnly(1, 11, 200);
        tester.AddMonths(10);
        Assert.That(tester, Is.EqualTo(comparison));

        //Subtract
        comparison = new ExtendedDateOnly(200);
        tester.AddMonths(-10);
        Assert.That(tester, Is.EqualTo(comparison));

        //Crossing Zero from the Positiv Side
        comparison = new ExtendedDateOnly(1, 12, -1);
        tester = new ExtendedDateOnly(1);
        tester.AddMonths(-1);
        Assert.That(tester, Is.EqualTo(comparison));

        //Crossing Zero from the Negative Side
        comparison = new ExtendedDateOnly(1);
        tester = new ExtendedDateOnly(1, 12, -1);
        tester.AddMonths(1);
        Assert.That(tester, Is.EqualTo(comparison));
    }

    [Test]
    public void ExtendedDateAddMonthsZeroLegalTest()
    {
        ExtendedDateOnly tester = new ExtendedDateOnly(200, true);
        //Add
        ExtendedDateOnly comparison = new ExtendedDateOnly(1, 11, 200, true);
        tester.AddMonths(10);
        Assert.That(tester, Is.EqualTo(comparison));

        //Subtract
        comparison = new ExtendedDateOnly(200, true);
        tester.AddMonths(-10);
        Assert.That(tester, Is.EqualTo(comparison));

        //Crossing Zero from the Positiv Side
        comparison = new ExtendedDateOnly(1, 12, 0, true);
        tester = new ExtendedDateOnly(1, true);
        tester.AddMonths(-1);
        Assert.That(tester, Is.EqualTo(comparison));

        //Crossing Zero from the Negative Side
        comparison = new ExtendedDateOnly(1,true);
        tester = new ExtendedDateOnly(1, 12, 0,true);
        tester.AddMonths(1);
        Assert.That(tester, Is.EqualTo(comparison));
    }

    [Test]
    public void ExtendedDateAddYearsTest()
    {
        ExtendedDateOnly tester = new ExtendedDateOnly(2000);

        //Add
        ExtendedDateOnly comparison = new ExtendedDateOnly(2001);
        tester.AddYears(1);
        Assert.That(tester, Is.EqualTo(comparison));
        //Off by One

        //Subtract
        comparison = new ExtendedDateOnly(2000);
        tester.AddYears(-1);
        Assert.That(tester, Is.EqualTo(comparison));
        //Off by One

        //Crossing Zero from the Positiv Side
        comparison = new ExtendedDateOnly(-1);
        tester = new ExtendedDateOnly(1);
        tester.AddYears(-1);
        Assert.That(tester, Is.EqualTo(comparison));

        //Crossing Zero from the Negative Side
        comparison = new ExtendedDateOnly(1);
        tester = new ExtendedDateOnly(-1);
        tester.AddYears(1);
        Assert.That(tester, Is.EqualTo(comparison));
    }

    [Test]
    public void ExtendedDateAddYearsZeroLegalTest()
    {
        ExtendedDateOnly tester = new ExtendedDateOnly(2000,true);

        //Add
        ExtendedDateOnly comparison = new ExtendedDateOnly(2001,true);
        tester.AddYears(1);
        Assert.That(tester, Is.EqualTo(comparison));
        //Off by One

        //Subtract
        comparison = new ExtendedDateOnly(2000,true);
        tester.AddYears(-1);
        Assert.That(tester, Is.EqualTo(comparison));
        //Off by One

        //Crossing Zero from the Positiv Side
        comparison = new ExtendedDateOnly(0,true);
        tester = new ExtendedDateOnly(1,true);
        tester.AddYears(-1);
        Assert.That(tester, Is.EqualTo(comparison));

        //Crossing Zero from the Negative Side
        comparison = new ExtendedDateOnly(1,true);
        tester = new ExtendedDateOnly(0,true);
        tester.AddYears(1);
        Assert.That(tester, Is.EqualTo(comparison));
    }


    [Test]
    public void ExtendedDateTimeEraTest()
    {
        ExtendedDateOnly eraTest = new ExtendedDateOnly(200);
        Assert.That(eraTest.Era, Is.EqualTo(TimeEra.AfterZero));
        eraTest = new ExtendedDateOnly(0);
        Assert.That(eraTest.Era, Is.EqualTo(TimeEra.AfterZero));
        eraTest = new ExtendedDateOnly(-200);
        Assert.That(eraTest.Era, Is.EqualTo(TimeEra.BeforeZero));
        
        eraTest = new ExtendedDateOnly(200,true);
        Assert.That(eraTest.Era, Is.EqualTo(TimeEra.AfterZero));
        eraTest = new ExtendedDateOnly(0,true);
        Assert.That(eraTest.Era, Is.EqualTo(TimeEra.YearZero));
        eraTest = new ExtendedDateOnly(-200,true);
        Assert.That(eraTest.Era, Is.EqualTo(TimeEra.BeforeZero));
    }

    [Test]
    public void NameOfMonthTest()
    {
        Assert.That(pos.NameOfMonth, Is.EqualTo(Month.January));
        pos.AddMonths(1);
        Assert.That(pos.NameOfMonth, Is.EqualTo(Month.February));
        pos.AddMonths(1);
        Assert.That(pos.NameOfMonth, Is.EqualTo(Month.March));
        pos.AddMonths(1);
        Assert.That(pos.NameOfMonth, Is.EqualTo(Month.April));
        pos.AddMonths(1);
        Assert.That(pos.NameOfMonth, Is.EqualTo(Month.May));
        pos.AddMonths(1);
        Assert.That(pos.NameOfMonth, Is.EqualTo(Month.June));
        pos.AddMonths(1);
        Assert.That(pos.NameOfMonth, Is.EqualTo(Month.July));
        pos.AddMonths(1);
        Assert.That(pos.NameOfMonth, Is.EqualTo(Month.August));
        pos.AddMonths(1);
        Assert.That(pos.NameOfMonth, Is.EqualTo(Month.September));
        pos.AddMonths(1);
        Assert.That(pos.NameOfMonth, Is.EqualTo(Month.October));
        pos.AddMonths(1);
        Assert.That(pos.NameOfMonth, Is.EqualTo(Month.November));
        pos.AddMonths(1);
        Assert.That(pos.NameOfMonth, Is.EqualTo(Month.December));
    }

    [Test]
    public void ExtendedDateHashCodeTest()
    {
        ExtendedDateOnly tester = new ExtendedDateOnly(200);
        ExtendedDateOnly comparison = new ExtendedDateOnly(200);
        Assert.That(tester.GetHashCode(), Is.EqualTo(comparison.GetHashCode()));

        comparison = new ExtendedDateOnly(-200);
        Assert.That(tester.GetHashCode(), Is.Not.EqualTo(comparison.GetHashCode()));
    }

    [Test]
    public void ExtendedDateToStringTest()
    {
        ExtendedDateOnly tester = new ExtendedDateOnly(200);
        ExtendedDateOnly comparison = new ExtendedDateOnly(200);
        Assert.That(tester.ToString(), Is.EqualTo(comparison.ToString()));

        string s = "Day: 1 | Month: 1 | Monthname: January | Year: 200 | Era: AfterZero";
        Assert.That(tester.ToString(), Is.EqualTo(s));
    }

    [Test]
    public void ExtendedDateCompareOperatorTest()
    {
        //Tests on Year basis
        ExtendedDateOnly tester = new ExtendedDateOnly(200);
        ExtendedDateOnly comparison = new ExtendedDateOnly(201);
        Assert.That(tester < comparison);
        Assert.That(tester <= comparison);
        Assert.That(comparison > tester);
        Assert.That(comparison >= tester);
        comparison = new ExtendedDateOnly(200);
        Assert.That(tester <= comparison);
        Assert.That(tester >= comparison);

        //Tests on Month basis
        tester = new ExtendedDateOnly(1,1,200);
        comparison = new ExtendedDateOnly(1,2,200);
        Assert.That(tester < comparison);
        Assert.That(tester <= comparison);
        Assert.That(comparison > tester);
        Assert.That(comparison >= tester);
        comparison = new ExtendedDateOnly(1,1,200);
        Assert.That(tester <= comparison);
        Assert.That(tester >= comparison);

        //Tests on Day Basis
        tester = new ExtendedDateOnly(1, 1, 200);
        comparison = new ExtendedDateOnly(2,1,200);
        Assert.That(tester < comparison);
        Assert.That(tester <= comparison);
        Assert.That(comparison > tester);
        Assert.That(comparison >= tester);
        comparison = new ExtendedDateOnly(1, 1, 200);
        Assert.That(tester <= comparison);
        Assert.That(tester >= comparison);
    }

    [Test]
    public void ExtendedDateCompareTest()
    {
        ExtendedDateOnly tester = new ExtendedDateOnly(200);
        ExtendedDateOnly comparison = new ExtendedDateOnly(200);
        Assert.That(tester.CompareTo(comparison) == 0);
        Assert.That(comparison.CompareTo(tester) == 0);
        comparison = new ExtendedDateOnly(201);
        Assert.That(tester.CompareTo(comparison) == -1);
        Assert.That(comparison.CompareTo(tester) == 1);
    }

    [Test]
    public void ExtendedDateEqualsTest()
    {
        ExtendedDateOnly tester = new ExtendedDateOnly(200);
        ExtendedDateOnly comparison = new ExtendedDateOnly(200);
        Assert.That(tester, Is.EqualTo(comparison));
        Assert.That(comparison, Is.EqualTo(tester));
        comparison = new ExtendedDateOnly(1,2,200);
        Assert.That(tester, Is.Not.EqualTo(comparison));
        Assert.That(comparison, Is.Not.EqualTo(tester));
    }

    [Test]
    public void ExtendedDateOnlyMinMaxTest()
    {
        Assert.That(ExtendedDateOnly.MaxValue != ExtendedDateOnly.MaxValue, Is.True);
        Assert.That(ExtendedDateOnly.MinValue != ExtendedDateOnly.MinValue, Is.True);
    }
}