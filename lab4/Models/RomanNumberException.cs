using System;

public class RomanNumberException : Exception
{
    public RomanNumberException() : base("ERROR") { }
    public RomanNumberException(string message) : base(message) { }
}