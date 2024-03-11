namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Drives;

public class DriveBase : DetailBase
{
    public DriveBase(string name, int capacity, int powerConsumption)
        : base(name)
    {
        Capacity = capacity;
        PowerConsumption = powerConsumption;
    }

    public int Capacity { get; }
    public int PowerConsumption { get; }
}