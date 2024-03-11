using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Exceptions;

public class MissingEssentialArgumentException : Exception
{
    public MissingEssentialArgumentException()
    {
    }

    public MissingEssentialArgumentException(string message)
        : base(message)
    {
    }

    public MissingEssentialArgumentException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}