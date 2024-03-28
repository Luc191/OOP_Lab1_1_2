
using System.Security.Cryptography.X509Certificates;

Console.WriteLine("hi");
//RationalNumber first = new RationalNumber(-2, 0);
//RationalNumber second = new RationalNumber(-5, 3);

//Console.WriteLine(first < second);
public class RationalNumber
{
    public int Numerator { get; private set; }
    public int Denominator { get; private set; }
    public RationalNumber(int numerator, int denominator)
    {
        Numerator = numerator;
        Denominator = denominator;
        if (denominator== 0)
        {
            throw new ArgumentException("Ошибка: знаменатель не может быть 0", nameof(denominator));
        }
        //try { numerator = numerator / denominator; } 
        //catch(DivideByZeroException) { Environment.Exit(0); }
    }
    public override string ToString()
    {
        RationalNumber x = new RationalNumber(Numerator,Denominator);
        x = this.Remainder(this);
        string buff;

        if (x.Numerator == 0)
             buff = "0";
        else if (x.Denominator == 1) //если 7/1 выведем 7
            buff = Numerator.ToString();
        else if (x.Denominator == -1) //если 7/-1 выведем -7
            buff = "-" + Numerator.ToString();
        else if (x.Denominator > 0 && x.Numerator >0) //если 7/3 выведем 7/3
            buff = Numerator.ToString() + "/" + Denominator.ToString();
        else                                          //если -7/3 или 7/-3 выведем -7/3
            buff = "-" + Math.Abs(Numerator).ToString() + "/" + Math.Abs(Denominator).ToString();
        return buff;
    }
    public static RationalNumber operator +(RationalNumber a, RationalNumber b)
    {
        if (a.Numerator == 0) return b;
        if (b.Numerator == 0) return a;
        RationalNumber x = new RationalNumber(1, 1);
        a.Numerator = a.Numerator * b.Denominator;
        b.Numerator = b.Numerator * a.Denominator;
        int temp = a.Denominator;
        a.Denominator = a.Denominator * b.Denominator;
        b.Denominator = b.Denominator * temp;

        x.Numerator = a.Numerator + b.Numerator;
        x.Denominator = a.Denominator;
        return x;
    }
    public static RationalNumber operator -(RationalNumber a, RationalNumber b)
    {
        if (a.Numerator == 0) return -b;
        if (b.Numerator == 0) return a;
        RationalNumber x = new RationalNumber(1, 1);
        a.Numerator = a.Numerator * b.Denominator;
        b.Numerator = b.Numerator * a.Denominator;
        int temp = a.Denominator;
        a.Denominator = a.Denominator * b.Denominator;
        b.Denominator = b.Denominator * temp;

        x.Numerator = a.Numerator - b.Numerator;
        x.Denominator = a.Denominator;
        return x;
    }
    public static RationalNumber operator *(RationalNumber a, RationalNumber b)
    {
        a.Numerator = a.Numerator * b.Numerator;
        a.Denominator = a.Denominator * b.Denominator;
        return a;
    }
    public static RationalNumber operator /(RationalNumber a, RationalNumber b)
    {
        a.Numerator = a.Numerator * b.Denominator;
        a.Denominator = a.Denominator * b.Numerator;
        if (a.Denominator == 0)
        {
            throw new ArgumentException("Ошибка: знаменатель не может быть 0", nameof(a.Denominator));
        }
        return a;
    }

    public static RationalNumber operator -(RationalNumber a)
    {
        a.Denominator = -a.Denominator;
        return a;
    }

    public static bool operator ==(RationalNumber a, RationalNumber b)
    {
        float num1;
        if (a.Numerator == 0 || b.Numerator == 0)
            num1 = 0;
        else
            num1 = (float)a.Numerator / (float)a.Denominator;
        float num2 = (float)b.Numerator / (float)b.Denominator;
        if (num1 == num2)
            return true;
        else
            return false;
    }
    public static bool operator !=(RationalNumber a, RationalNumber b)
    {
        float num1;
        if (a.Numerator == 0 || b.Numerator == 0)
            num1 = 0;
        else
            num1 = (float)a.Numerator / (float)a.Denominator;
        float num2 = (float)b.Numerator / (float)b.Denominator;
        if (num1 != num2)
            return true;
        else
            return false;
    }
    public static bool operator >(RationalNumber a, RationalNumber b)
    {
        float num1;
        if (a.Numerator == 0 || b.Numerator == 0)
            num1 = 0;
        else
            num1 = (float)a.Numerator / (float)a.Denominator;
        float num2 = (float)b.Numerator / (float)b.Denominator;
        if (num1 > num2)
            return true;
        else
            return false;
    }
    public static bool operator <(RationalNumber a, RationalNumber b)
    {
        float num1;
        if (a.Numerator == 0 || b.Numerator == 0)
            num1 = 0;
        else
            num1 = (float)a.Numerator / (float)a.Denominator;
        float num2 = (float)b.Numerator / (float)b.Denominator;
        if (num1 < num2)
            return true;
        else
            return false;
    }
    public static bool operator >=(RationalNumber a, RationalNumber b)
    {
        float num1;
        if (a.Numerator == 0 || b.Numerator == 0)
            num1 = 0;
        else
            num1 = (float)a.Numerator / (float)a.Denominator;
        float num2 = (float)b.Numerator / (float)b.Denominator;
        if (num1 >= num2)
            return true;
        else
            return false;
    }
    public static bool operator <=(RationalNumber a, RationalNumber b)
    {
        float num1;
        if (a.Numerator == 0 || b.Numerator == 0)
            num1 = 0;
        else
            num1 = (float)a.Numerator / (float)a.Denominator;
        float num2 = (float)b.Numerator / (float)b.Denominator;
        if (num1 <= num2)
            return true;
        else
            return false;
    }


    RationalNumber Remainder(RationalNumber a)
    {
        if (a.Numerator == 0)
            return this;
        int num1 = Math.Abs(a.Numerator);
        int num2 = Math.Abs(a.Denominator);
        int tmp;

        while (num1 != num2) //ищем наиб. общ. делитель
        {
            if (num1 > num2)
            {
                tmp = num1;
                num1 = num2;
                num2 = tmp;
            }
            num2 = num2 - num1;
        } //num1 - наибольший общий делитель 

        a.Numerator = a.Numerator / num2;
        a.Denominator = a.Denominator / num2;
        if (a.Denominator <0 && a.Numerator < 0)
        {
            a.Numerator = -a.Numerator;
            a.Denominator = -a.Denominator;
        } 
        return a;
    }
}



