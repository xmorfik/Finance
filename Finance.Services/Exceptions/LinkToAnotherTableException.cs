namespace Finance.Services.Exceptions;

public class LinkToAnotherTableException : Exception
{
    public LinkToAnotherTableException(string? message) : base(message)
    {
    }
}