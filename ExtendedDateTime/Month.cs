using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.SmartEnum;

namespace ExtendedDate;
public class Month : SmartEnum<Month>
{
    public static readonly Month None      = new Month("None"     , 0                  , 0 , 0);
    public static readonly Month January   = new Month("January"  , None.Value + 1     , 31, 31);
    public static readonly Month February  = new Month("February" , January.Value + 1  , 28, 29);
    public static readonly Month March     = new Month("March"    , February.Value + 1 , 31, 31);
    public static readonly Month April     = new Month("April"    , March.Value + 1    , 30, 30);
    public static readonly Month May       = new Month("May"      , April.Value + 1    , 31, 31);
    public static readonly Month June      = new Month("June"     , May.Value + 1      , 30, 30);
    public static readonly Month July      = new Month("July"     , June.Value + 1     , 31, 31);
    public static readonly Month August    = new Month("August"   , July.Value + 1     , 31, 31);
    public static readonly Month September = new Month("September", August.Value + 1   , 30, 30);
    public static readonly Month October   = new Month("October"  , September.Value + 1, 31, 31);
    public static readonly Month November  = new Month("November" , October.Value + 1  , 30, 30);
    public static readonly Month December  = new Month("December" , November.Value + 1 , 31, 31);

    public int AmountOfDays { get; }

    public int AmountOfDaysInLeapYear { get; }

    public Month(string name, int value, int amountOfDays, int amountOfDaysInLeapYear) : base(name, value)
    {
        AmountOfDays = amountOfDays;
        AmountOfDaysInLeapYear = amountOfDaysInLeapYear;
    }
}
