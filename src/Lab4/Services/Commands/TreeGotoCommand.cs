using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public class TreeGotoCommand : ICommand
{
    private string _path;

    public TreeGotoCommand(string path)
    {
        _path = path ?? throw new ArgumentNullException(nameof(path));
    }

    public void Execute(IContext context)
    {
        context = context ?? throw new ArgumentNullException(nameof(context));
        context.TreeGoto(_path);
    }
}