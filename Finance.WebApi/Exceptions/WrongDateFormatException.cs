namespace Finance.WebApi.Exceptions;

public class WrongDateFormatException : Exception
{
    public WrongDateFormatException(string? message) : base(message)
    {
    }
}
