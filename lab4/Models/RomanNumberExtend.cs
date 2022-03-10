using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class RomanNumberExtend : RomanNumber
    {
    public static int CharToInt(char ch)
    {
        switch (ch)
        {
            case ('I'):
                return 1;
            case ('V'):
                return 5;
            case ('X'):
                return 10;
            case ('L'):
                return 50;
            case ('C'):
                return 100;
            case ('D'):
                return 500;
            case ('M'):
                return 1000;
            default:
                return 0;
        }
    }

    public static int RomanToInt(string s)
    {
        int res = 0;
        for (int i = 0; i < (s.Length - 1); ++i)
        {
            if (CharToInt(s[i]) < CharToInt(s[i + 1]))
                res -= CharToInt(s[i]);
            else
                res += CharToInt(s[i]);
        }
        res += CharToInt(s[s.Length - 1]);
        return res;
    }
    public RomanNumberExtend(string number) : base((ushort)RomanToInt(number))
    { 
    }
    }