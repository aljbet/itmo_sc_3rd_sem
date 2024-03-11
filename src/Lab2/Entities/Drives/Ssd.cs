using Itmo.ObjectOrientedProgramming.Lab2.Models.Attributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Drives;

public class Ssd : DriveBase
{
    public Ssd(
        string name,
        int capacity,
        int powerConsumption,
        SsdConnection connectionType,
        int maximumSpeed)
        : base(name, capacity, powerConsumption)
    {
        ConnectionType = connectionType;
        MaximumSpeed = maximumSpeed;
    }

    public SsdConnection ConnectionType { get; }
    public int MaximumSpeed { get; }
}