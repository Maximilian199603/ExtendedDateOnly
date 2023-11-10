using ExtendedDate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedTimeUnitTest;
internal class ExtendedTimeSpanUnitTest
{
    [Test]
    public void ExtendedTimeSpanEqualsTest()
    {
        ExtendedTimeSpan tester = new ExtendedTimeSpan();
        ExtendedTimeSpan comparison = ExtendedTimeSpan.Zero;
        Assert.That(comparison, Is.EqualTo(tester));
        comparison = ExtendedTimeSpan.MaxValue;
        Assert.That(comparison, Is.Not.EqualTo(tester));
        comparison = ExtendedTimeSpan.MinValue;
        Assert.That(comparison, Is.Not.EqualTo(tester));
    }

    [Test]
    public void ExtendedTimeSpanCompareToTest()
    {
        ExtendedTimeSpan tester = new ExtendedTimeSpan();
        ExtendedTimeSpan comparison = ExtendedTimeSpan.Zero;
        Assert.That(tester.CompareTo(comparison), Is.EqualTo(0));
        comparison = ExtendedTimeSpan.MaxValue;
        Assert.That(tester.CompareTo(comparison), Is.AtMost(-1));
        comparison = ExtendedTimeSpan.MinValue;
        Assert.That(tester.CompareTo(comparison), Is.AtLeast(1));
    }

    [Test]
    public void ExtendedTimeSpanFromExtendedDateOnlyTest()
    {
        ExtendedDateOnly first = new ExtendedDateOnly(10,11,2023);
        ExtendedDateOnly second = new ExtendedDateOnly(9, 11, 2023);
        ExtendedTimeSpan comparison = new ExtendedTimeSpan(0,0,1);
        Assert.That(comparison, Is.EqualTo(first - second));
    }

    [Test]
    public void ExtendedTimeSpanFromExtendedDateTimeTest()
    {
        ExtendedDateTime first = new ExtendedDateTime(10, 11, 2023, 1, 1, 1);
        ExtendedDateTime second = new ExtendedDateTime(9, 11, 2023, 1, 1, 1);
        ExtendedTimeSpan comparison = new ExtendedTimeSpan(0, 0, 1);
        Assert.That(comparison, Is.EqualTo(first - second));
    }
}
