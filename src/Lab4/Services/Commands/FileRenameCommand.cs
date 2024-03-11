using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public class FileRenameCommand : ICommand
{
    private string _path;
    private string _name;

    public FileRenameCommand(string path, string name)
    {
        _path = path ?? throw new ArgumentNullException(nameof(path));
        _name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public void Execute(IContext context)
    {
        context = context ?? throw new ArgumentNullException(nameof(context));
        context.FileRename(_path, _name);
    }
}