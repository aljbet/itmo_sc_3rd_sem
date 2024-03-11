namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class DetailBase
{
    protected DetailBase(string name)
    {
        Name = name;
    }

    public string Name { get; }
}