namespace Application.Exceptions;

public class WrongSystemPasswordException : Exception
{
    public WrongSystemPasswordException()
    {
    }

    public WrongSystemPasswordException(string message)
        : base(message)
    {
    }

    public WrongSystemPasswordException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}