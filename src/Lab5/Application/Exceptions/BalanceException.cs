namespace Application.Exceptions;

public class BalanceException : Exception
{
    public BalanceException()
    {
    }

    public BalanceException(string message)
        : base(message)
    {
    }

    public BalanceException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}