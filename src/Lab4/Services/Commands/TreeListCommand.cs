using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public class TreeListCommand : ICommand
{
    private int _depth;
    private string _writerMode;

    public TreeListCommand(int depth, string writerMode)
    {
        _depth = depth;
        _writerMode = writerMode ?? throw new ArgumentNullException(nameof(writerMode));
    }

    public void Execute(IContext context)
    {
        context = context ?? throw new ArgumentNullException(nameof(context));
        context.TreeList(_depth, _writerMode);
    }
}