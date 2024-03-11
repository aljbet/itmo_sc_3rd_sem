using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public class FileDeleteCommand : ICommand
{
    private string _path;

    public FileDeleteCommand(string path)
    {
        _path = path ?? throw new ArgumentNullException(nameof(path));
    }

    public void Execute(IContext context)
    {
        context = context ?? throw new ArgumentNullException(nameof(context));
        context.FileDelete(_path);
    }
}