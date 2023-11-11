using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedDate;
internal class Comparator
{
    private Comparator()
    {
    }

    public static (IComparable larger, IComparable smaller, bool equal) Compare(IComparable left, IComparable right)
    {
        if (!left.GetType().Equals(right.GetType()))
        {
            throw new ArgumentException("The given Comparables are not of the same Type");
        }

        if (left.CompareTo(right) == 0)
        {
            return (left, right, true);
        }

        if (left.CompareTo(right) < 0)
        {
            return (right, left, false);
        }
        else
        {
            return (left, right, false);
        }
    }
}
