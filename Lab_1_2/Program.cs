using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


Console.WriteLine("Hello, World!");

Time time1 = new EuroTime();
Console.WriteLine(time1.ShowTime());
Time time1Dec = new EuroDecorator(time1);
Console.WriteLine(time1Dec.ShowTime());

Time time2 = new USATime();
Console.WriteLine(time2.ShowTime());
Time time2Dec = new USADecorator(time2);
Console.WriteLine(time2Dec.ShowTime());


abstract class Time
{
    public abstract string ShowTime();
}

class EuroTime : Time
{
    protected CultureInfo time_reg = new CultureInfo("es-ES", false);
    public override string ShowTime()
    {
        return DateTime.Now.ToString(time_reg);
    }
}
class USATime : Time
{
    protected CultureInfo time_reg = new CultureInfo("en-US", false);
    public override string ShowTime()
    {
        return DateTime.Now.ToString(time_reg);
    }
}
class Decorator : Time
{
    protected Time time;
    public Decorator(Time time)
    {
        this.time = time;
    }
    public override string ShowTime()
    {
        return time.ShowTime();
    }
}
class EuroDecorator : Decorator
{
    public EuroDecorator(Time time) : base(time) { }
    public override string ShowTime()
    {
        StringBuilder text = new StringBuilder(base.ShowTime());
        text.Append(" - Европейский стиль");
        return text.ToString();
    }
}

class USADecorator : Decorator
{
    public USADecorator(Time time) : base(time) { }
    public override string ShowTime()
    {
        StringBuilder text = new StringBuilder(base.ShowTime());
        text.Append(" - Американский стиль");
        return text.ToString();
    }
}
