using System;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems.Units;

public class MyFile : FileSystemUnitBase
{
    public MyFile(string name)
        : base(name)
    {
    }

    public override void AcceptVisitor(IVisitor visitor)
    {
        visitor = visitor ?? throw new ArgumentNullException(nameof(visitor));
        visitor.VisitFile(this);
    }
}