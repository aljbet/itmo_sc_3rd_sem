using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Drives;
namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Computer
{
    public Computer(
        MotherBoard motherBoard,
        Bios bios,
        Cpu cpu,
        CpuCoolingSystem cpuCoolingSystem,
        IEnumerable<RandomAccessMemory> randomAccessMemoryUnits,
        IEnumerable<DriveBase> storageUnits,
        VideoCard? videoCard,
        ComputerCase computerCase,
        PowerUnit powerUnit,
        WiFiAdapter? wiFiAdapter)
    {
        MotherBoard = motherBoard;
        Bios = bios;
        Cpu = cpu;
        CpuCoolingSystem = cpuCoolingSystem;
        RandomAccessMemoryUnits = randomAccessMemoryUnits;
        StorageUnits = storageUnits;
        VideoCard = videoCard;
        ComputerCase = computerCase;
        PowerUnit = powerUnit;
        WiFiAdapter = wiFiAdapter;
    }

    public MotherBoard MotherBoard { get; }
    public Bios Bios { get; }
    public Cpu Cpu { get; }
    public CpuCoolingSystem CpuCoolingSystem { get; }
    public IEnumerable<RandomAccessMemory> RandomAccessMemoryUnits { get; }
    public IEnumerable<DriveBase> StorageUnits { get; }
    public VideoCard? VideoCard { get; }
    public ComputerCase ComputerCase { get; }
    public PowerUnit PowerUnit { get; }
    public WiFiAdapter? WiFiAdapter { get; }
}