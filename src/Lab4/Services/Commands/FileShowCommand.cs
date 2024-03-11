using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public class FileShowCommand : ICommand
{
    private string _path;
    private string _writerMode;

    public FileShowCommand(string path, string writerMode)
    {
        _path = path ?? throw new ArgumentNullException(nameof(path));
        _writerMode = writerMode ?? throw new ArgumentNullException(nameof(writerMode));
    }

    public void Execute(IContext context)
    {
        context = context ?? throw new ArgumentNullException(nameof(context));
        context.FileShow(_path, _writerMode);
    }
}