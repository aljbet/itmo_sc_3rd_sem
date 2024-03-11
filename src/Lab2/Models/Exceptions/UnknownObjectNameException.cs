using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Exceptions;

public class UnknownObjectNameException : Exception
{
    public UnknownObjectNameException()
    {
    }

    public UnknownObjectNameException(string message)
        : base(message)
    {
    }

    public UnknownObjectNameException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}