using Itmo.ObjectOrientedProgramming.Lab2.Models.Attributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class WiFiAdapter : DetailBase
{
    public WiFiAdapter(
        string name,
        WiFiStandard standard,
        bool hasBluetoothModule,
        int pcieVersion,
        int powerConsumption)
        : base(name)
    {
        Standard = standard;
        HasBluetoothModule = hasBluetoothModule;
        PCIEVersion = pcieVersion;
        PowerConsumption = powerConsumption;
    }

    public WiFiStandard Standard { get; }
    public bool HasBluetoothModule { get; }
    public int PCIEVersion { get; }
    public int PowerConsumption { get; }
}