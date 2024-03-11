using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public class FileCopyCommand : ICommand
{
    private string _sourcePath;
    private string _destinationPath;

    public FileCopyCommand(string sourcePath, string destinationPath)
    {
        _sourcePath = sourcePath ?? throw new ArgumentNullException(nameof(sourcePath));
        _destinationPath = destinationPath ?? throw new ArgumentNullException(nameof(destinationPath));
    }

    public void Execute(IContext context)
    {
        context = context ?? throw new ArgumentNullException(nameof(context));
        context.FileCopy(_sourcePath, _destinationPath);
    }
}