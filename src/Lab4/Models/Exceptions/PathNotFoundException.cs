using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models.Exceptions;

public class PathNotFoundException : Exception
{
    public PathNotFoundException()
    {
    }

    public PathNotFoundException(string message)
        : base(message)
    {
    }

    public PathNotFoundException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}