using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Specification
{
    public Specification(
        string motherBoardName,
        string biosName,
        string cpuName,
        string cpuCoolingSystemName,
        IReadOnlyCollection<string> randomAccessMemoryUnitsNames,
        IReadOnlyCollection<string> storageUnitsNames,
        string? videoCardName,
        string computerCaseName,
        string powerUnitName,
        string? wiFiAdapterName)
    {
        MotherBoardName = motherBoardName;
        BiosName = biosName;
        CpuName = cpuName;
        CpuCoolingSystemName = cpuCoolingSystemName;
        RandomAccessMemoryUnitsNames = randomAccessMemoryUnitsNames;
        StorageUnitsNames = storageUnitsNames;
        VideoCardName = videoCardName;
        ComputerCaseName = computerCaseName;
        PowerUnitName = powerUnitName;
        WiFiAdapterName = wiFiAdapterName;
    }

    public string MotherBoardName { get; set; }
    public string BiosName { get; set; }
    public string CpuName { get; set; }
    public string CpuCoolingSystemName { get; set; }
    public IReadOnlyCollection<string> RandomAccessMemoryUnitsNames { get; set; }
    public IReadOnlyCollection<string> StorageUnitsNames { get; set; }
    public string? VideoCardName { get; set; }
    public string ComputerCaseName { get; set; }
    public string PowerUnitName { get; set; }
    public string? WiFiAdapterName { get; set; }
}