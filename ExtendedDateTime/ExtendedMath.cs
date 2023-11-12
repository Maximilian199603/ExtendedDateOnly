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

    public static int Modulo(int dividend, int divisor)
    {
        return Convert.ToInt32(DoubleModulo(dividend, divisor));
    }

    public static double DoubleModulo(double dividend, double divisor)
    {
        return dividend - divisor * Math.Floor(dividend / divisor);
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
