using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Attributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class CpuCoolingSystem : DetailBase
{
    public CpuCoolingSystem(
        string name,
        double height,
        double width,
        double depth,
        IReadOnlyCollection<Socket> supportedSockets,
        int thermalDesignPower)
        : base(name)
    {
        Height = height;
        Width = width;
        Depth = depth;
        SupportedSockets = supportedSockets;
        ThermalDesignPower = thermalDesignPower;
    }

    public double Height { get; }
    public double Width { get; }
    public double Depth { get; }
    public IReadOnlyCollection<Socket> SupportedSockets { get; }
    public int ThermalDesignPower { get; }
}