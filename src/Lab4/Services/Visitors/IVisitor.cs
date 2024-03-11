using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems.Units;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Visitors;

public interface IVisitor
{
    void VisitFile(MyFile item);
    void VisitDirectory(MyDirectory item);
}