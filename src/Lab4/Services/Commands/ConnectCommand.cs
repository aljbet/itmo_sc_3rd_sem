using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public class ConnectCommand : ICommand
{
    private string _path;
    private string _fileSystemMode;

    public ConnectCommand(string path, string mode)
    {
        _path = path ?? throw new ArgumentNullException(nameof(path));
        _fileSystemMode = mode;
    }

    public void Execute(IContext context)
    {
        context = context ?? throw new ArgumentNullException(nameof(context));
        context.Connect(_path, _fileSystemMode);
    }
}