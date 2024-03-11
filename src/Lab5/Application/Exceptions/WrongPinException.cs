namespace Application.Exceptions;

public class WrongPinException : Exception
{
    public WrongPinException()
    {
    }

    public WrongPinException(string message)
        : base(message)
    {
    }

    public WrongPinException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}