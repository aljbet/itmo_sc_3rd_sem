using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Exceptions;

public class UnknownCommandException : Exception
{
    public UnknownCommandException()
    {
    }

    public UnknownCommandException(string message)
        : base(message)
    {
    }

    public UnknownCommandException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}