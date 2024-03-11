namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class PowerUnit : DetailBase
{
    public PowerUnit(
        string name,
        int peakLoad)
        : base(name)
    {
        PeakLoad = peakLoad;
    }

    public int PeakLoad { get; }
    public double RecommendedLoad => PeakLoad * 0.8;
}