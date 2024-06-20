namespace APBDzad2.Models.Exceptions;

public class OverFillException : Exception
{
    public OverFillException(string message) : base(message) { }
}