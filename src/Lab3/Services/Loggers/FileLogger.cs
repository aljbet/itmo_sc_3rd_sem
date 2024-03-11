using System;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services.Loggers;

public class FileLogger : ILogger
{
    private string _path;

    public FileLogger(string path)
    {
        _path = path ?? throw new ArgumentNullException(nameof(path));
    }

    public void Log(string message)
    {
        message = message ?? throw new ArgumentNullException(nameof(message));
        File.AppendAllText(_path, message);
    }
}