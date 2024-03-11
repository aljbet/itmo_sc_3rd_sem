using System;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems.Units;

public class MyDirectory : FileSystemUnitBase
{
    public MyDirectory(string name)
        : base(name)
    {
        Children = new Collection<FileSystemUnitBase>();
    }

    public Collection<FileSystemUnitBase> Children { get; private set; }

    public void AddChild(FileSystemUnitBase child)
    {
        Children.Add(child);
    }

    public override void AcceptVisitor(IVisitor visitor)
    {
        visitor = visitor ?? throw new ArgumentNullException(nameof(visitor));
        visitor.VisitDirectory(this);
    }
}