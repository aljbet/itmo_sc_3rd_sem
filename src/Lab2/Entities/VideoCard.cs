namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class VideoCard : DetailBase
{
    public VideoCard(
        string name,
        double height,
        double width,
        int memoryCapacity,
        int pcieVersion,
        double chipFrequency,
        int powerConsumption)
        : base(name)
    {
        Height = height;
        Width = width;
        MemoryCapacity = memoryCapacity;
        PCIEVersion = pcieVersion;
        ChipFrequency = chipFrequency;
        PowerConsumption = powerConsumption;
    }

    public double Height { get; }
    public double Width { get; }
    public int MemoryCapacity { get; }
    public int PCIEVersion { get; }
    public double ChipFrequency { get; }
    public int PowerConsumption { get; }
}