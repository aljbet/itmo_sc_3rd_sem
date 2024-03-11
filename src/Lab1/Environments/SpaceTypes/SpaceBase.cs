namespace Itmo.ObjectOrientedProgramming.Lab1.Environments.SpaceTypes;

public abstract class SpaceBase
{
    protected SpaceBase(double length)
    {
        Length = length;
    }

    public double Length { get; set; }
}