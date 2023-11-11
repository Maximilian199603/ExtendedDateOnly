using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedDate;
internal class ExtendedMath
{
    private ExtendedMath()
    {
    }

    public static int Modulo(int a, int b)
    {
        return Convert.ToInt32(DoubleModulo(a, b));
    }

    public static double DoubleModulo(double a, double b)
    {
        return a - b * Math.Floor(a / b);
    }

    public static int Negate(int val)
    {
        return val * -1;
    }

    public static int AbsolutSubtraction(int minuend, int subtrahend)
    {
        return Math.Abs(minuend - subtrahend);
    }
}
