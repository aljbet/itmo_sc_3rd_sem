namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Drives;

public class Hdd : DriveBase
{
    public Hdd(
        string name,
        int capacity,
        int powerConsumption,
        int spindleSpeed)
        : base(name, capacity, powerConsumption)
    {
        SpindleSpeed = spindleSpeed;
    }

    public int SpindleSpeed { get; }
}