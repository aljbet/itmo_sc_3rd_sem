using System;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems.Units;

public abstract class FileSystemUnitBase
{
    protected FileSystemUnitBase(string name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public string Name { get; private set; }

    public abstract void AcceptVisitor(IVisitor visitor);
}