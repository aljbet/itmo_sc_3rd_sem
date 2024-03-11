using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services.Loggers;

public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        message = message ?? throw new ArgumentNullException(nameof(message));
        Console.WriteLine(message);
    }
}