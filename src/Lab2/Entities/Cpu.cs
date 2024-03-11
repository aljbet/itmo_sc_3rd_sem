using Itmo.ObjectOrientedProgramming.Lab2.Models.Attributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Cpu : DetailBase
{
    public Cpu(
        string name,
        int coreFrequency,
        int coreAmount,
        Socket socket,
        bool hasVideoCore,
        double maximumMemoryFrequency,
        int heatDissipation,
        int powerConsumption)
        : base(name)
    {
        CoreFrequency = coreFrequency;
        CoreAmount = coreAmount;
        Socket = socket;
        HasVideoCore = hasVideoCore;
        MaximumMemoryFrequency = maximumMemoryFrequency;
        HeatDissipation = heatDissipation;
        PowerConsumption = powerConsumption;
    }

    public int CoreFrequency { get; }
    public int CoreAmount { get; }
    public Socket Socket { get; }
    public bool HasVideoCore { get; }
    public double MaximumMemoryFrequency { get; }
    public int HeatDissipation { get; }
    public int PowerConsumption { get; }
}