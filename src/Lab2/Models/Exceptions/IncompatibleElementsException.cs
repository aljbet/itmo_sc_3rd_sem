using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Exceptions;

public class IncompatibleElementsException : Exception
{
    public IncompatibleElementsException()
    {
    }

    public IncompatibleElementsException(string message)
        : base(message)
    {
    }

    public IncompatibleElementsException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}