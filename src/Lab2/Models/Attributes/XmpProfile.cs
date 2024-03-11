namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Attributes;

public class XmpProfile
{
    public XmpProfile(string name, string timing, double voltage, int frequency)
    {
        Name = name;
        Timing = timing;
        Voltage = voltage;
        Frequency = frequency;
    }

    public string Name { get; }
    public string Timing { get; }
    public double Voltage { get; }
    public int Frequency { get; }
}