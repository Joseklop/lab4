using System;

public class RomanNumber : ICloneable, IComparable
{
    private ushort num;
    public object Clone()
    {
        return new RomanNumber(num);
    }
    public int CompareTo(object? obj)
    {
        if (obj is RomanNumber) return num - ((RomanNumber)obj).num;
        throw new RomanNumberException("ERROR CompareTo-1: Incorrect value");
    }

    //Конструктор получает представление числа n в римской записи
    public RomanNumber(ushort n)
    {
        if (n <= 0) throw new RomanNumberException("ERROR Constructor-1: number is negative or equal to 0");
        if (n >= 4000) throw new RomanNumberException("ERROR Constructor-2: Result is more than 4000");
        num = n;
    }

    //Сложение римских чисел
    public static RomanNumber operator +(RomanNumber? n1, RomanNumber? n2)
    {
        if (n1 == null || n2 == null) throw new RomanNumberException("ERROR Add-1: One or both numbers are null");
        if (n1.num + n2.num >= 4000) throw new RomanNumberException("ERROR Add-2: Result is more than 4000");
        return new RomanNumber((ushort)(n1.num + n2.num));
    }
    //Вычитание римских чисел
    public static RomanNumber operator -(RomanNumber? n1, RomanNumber? n2)
    {
        if (n1 == null || n2 == null) throw new RomanNumberException("ERROR Sub-1: One or both numbers are null");
        if (n1.num <= n2.num) throw new RomanNumberException("ERROR Sub-2: A negative result");
        return new RomanNumber((ushort)(n1.num - n2.num));
    }
    //Умножение римских чисел
    public static RomanNumber operator *(RomanNumber? n1, RomanNumber? n2)
    {
        if (n1 == null || n2 == null) throw new RomanNumberException("ERROR Mul-1: One or both numbers are null");
        if (n1.num * n2.num >= 4000) throw new RomanNumberException("ERROR Mul-2: Result is more than 4000");
        return new RomanNumber((ushort)(n1.num * n2.num));
    }
    //Целочисленное деление римских чисел
    public static RomanNumber operator /(RomanNumber? n1, RomanNumber? n2)
    {
        if (n1 == null || n2 == null) throw new RomanNumberException("ERROR Div-1: One or more numbers are null");
        if (n1.num / n2.num <= 0) throw new RomanNumberException("ERROR Div-2: Result less than or equal to 0");
        return new RomanNumber((ushort)(n1.num / n2.num));
    }
    //Возвращает строковое представление римского числа
    public override string ToString()
    {
        return ToRoman(num);
    }

    //Рекурсивный перевод в римсrие числа
    private static string ToRoman(int numberRoman)
    {
        if (numberRoman < 1) return string.Empty;
        else if (numberRoman >= 1000) return "M" + ToRoman(numberRoman - 1000);
        else if (numberRoman >= 900) return "CM" + ToRoman(numberRoman - 900);
        else if (numberRoman >= 500) return "D" + ToRoman(numberRoman - 500);
        else if (numberRoman >= 400) return "CD" + ToRoman(numberRoman - 400);
        else if (numberRoman >= 100) return "C" + ToRoman(numberRoman - 100);
        else if (numberRoman >= 90) return "XC" + ToRoman(numberRoman - 90);
        else if (numberRoman >= 50) return "L" + ToRoman(numberRoman - 50);
        else if (numberRoman >= 40) return "XL" + ToRoman(numberRoman - 40);
        else if (numberRoman >= 10) return "X" + ToRoman(numberRoman - 10);
        else if (numberRoman >= 9) return "IX" + ToRoman(numberRoman - 9);
        else if (numberRoman >= 5) return "V" + ToRoman(numberRoman - 5);
        else if (numberRoman >= 4) return "IV" + ToRoman(numberRoman - 4);
        else if (numberRoman >= 1) return "I" + ToRoman(numberRoman - 1);
        throw new RomanNumberException();
    }
}

