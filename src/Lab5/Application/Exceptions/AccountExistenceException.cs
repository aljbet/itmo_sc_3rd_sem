namespace Application.Exceptions;

public class AccountExistenceException : Exception
{
    public AccountExistenceException()
    {
    }

    public AccountExistenceException(string message)
        : base(message)
    {
    }

    public AccountExistenceException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}