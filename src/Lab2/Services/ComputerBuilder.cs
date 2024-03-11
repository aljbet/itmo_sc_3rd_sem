using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Drives;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Attributes;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class ComputerBuilder
{
    public MotherBoard? MotherBoard { get; set; }
    public Bios? Bios { get; set; }
    public Cpu? Cpu { get; set; }
    public CpuCoolingSystem? CpuCoolingSystem { get; set; }
    public IEnumerable<RandomAccessMemory>? RandomAccessMemoryUnits { get; set; }
    public IEnumerable<DriveBase>? StorageUnits { get; set; }
    public VideoCard? VideoCard { get; set; }
    public ComputerCase? ComputerCase { get; set; }
    public PowerUnit? PowerUnit { get; set; }
    public WiFiAdapter? WiFiAdapter { get; set; }

    public ComputerBuilder WithMotherBoard(MotherBoard? motherBoard)
    {
        MotherBoard = motherBoard ?? throw new MissingEssentialArgumentException(nameof(motherBoard));
        return this;
    }

    public ComputerBuilder WithBios(Bios? bios)
    {
        Bios = bios ?? throw new MissingEssentialArgumentException(nameof(bios));
        if (MotherBoard is not null && Bios.Name != MotherBoard.Bios.Name)
            throw new IncompatibleElementsException("MotherBoard and Bios");
        return this;
    }

    public ComputerBuilder WithCpu(Cpu? cpu)
    {
        Cpu = cpu ?? throw new MissingEssentialArgumentException(nameof(cpu));
        if (MotherBoard is not null && Cpu.Socket != MotherBoard.Socket)
            throw new IncompatibleElementsException("MotherBoard and Cpu");
        if (Bios is not null && !Bios.SupportedCpus.Contains(Cpu.Name))
            throw new IncompatibleElementsException("Bios and Cpu");
        return this;
    }

    public ComputerBuilder WithCpuCoolingSystem(CpuCoolingSystem? cpuCoolingSystem, ComputerBuilderResult result)
    {
        result = result ?? throw new ArgumentNullException(nameof(result));
        CpuCoolingSystem = cpuCoolingSystem ?? throw new MissingEssentialArgumentException(nameof(cpuCoolingSystem));
        if (Cpu is not null && !CpuCoolingSystem.SupportedSockets.Contains(Cpu.Socket))
            throw new IncompatibleElementsException("Cpu and CpuCoolingSystem");
        if (Cpu is not null && Cpu.HeatDissipation > CpuCoolingSystem.ThermalDesignPower)
            result.ErrorMessage = "CpuCoolingSystem is not enough, no guarantee for performance";
        return this;
    }

    public ComputerBuilder WithRandomAccessMemoryUnits(IEnumerable<RandomAccessMemory> randomAccessMemoryUnits)
    {
        RandomAccessMemoryUnits = randomAccessMemoryUnits ??
                                  throw new MissingEssentialArgumentException(nameof(randomAccessMemoryUnits));
        if (MotherBoard is not null && RandomAccessMemoryUnits.Count() > MotherBoard.RamSlotsAmount)
            throw new IncompatibleElementsException("MotherBoard and RandomAccessMemoryUnits");
        if (RandomAccessMemoryUnits.Any(unit => MotherBoard is not null && unit.StandardDdr != MotherBoard.StandardDdr))
            throw new IncompatibleElementsException("MotherBoard and RandomAccessMemoryUnits");

        return this;
    }

    public ComputerBuilder WithStorageUnits(IEnumerable<DriveBase> storageUnits)
    {
        StorageUnits = storageUnits ?? throw new MissingEssentialArgumentException(nameof(storageUnits));
        if (!ConnectionMotherBoardToSsd()) throw new IncompatibleElementsException("MotherBoard and StorageUnits");
        return this;
    }

    public ComputerBuilder WithVideoCard(VideoCard? videoCard)
    {
        VideoCard = videoCard;
        if (Cpu is not null && !Cpu.HasVideoCore && VideoCard is null)
            throw new MissingEssentialArgumentException(nameof(VideoCard));
        if (MotherBoard is not null && CountSsdWithPcie() + 1 > MotherBoard.PcieLinesAmount)
            throw new IncompatibleElementsException("MotherBoard and VideoCard");
        return this;
    }

    public ComputerBuilder WithCase(ComputerCase? computerCase)
    {
        ComputerCase = computerCase ?? throw new MissingEssentialArgumentException(nameof(computerCase));
        if (MotherBoard is not null &&
            !ComputerCase.SupportedMotherBoardFormFactors.Contains(MotherBoard.MotherBoardFormFactor))
            throw new IncompatibleElementsException("MotherBoard and ComputerCase");

        if (MotherBoard is not null && CpuCoolingSystem is not null &&
            (MotherBoard.GetHeightFromFormFactor + CpuCoolingSystem.Height >= ComputerCase.Height ||
             MotherBoard.GetWidthFromFormFactor + CpuCoolingSystem.Width >= ComputerCase.Width ||
             CpuCoolingSystem.Depth >= ComputerCase.Depth))
            throw new IncompatibleElementsException("MotherBoard, CpuCoolingSystem and ComputerCase");

        if (VideoCard is not null && VideoCard.Height > ComputerCase.VideoCardHeight &&
            VideoCard.Width > ComputerCase.VideoCardWidth)
            throw new IncompatibleElementsException("VideoCard and ComputerCase");
        return this;
    }

    public ComputerBuilder WithWiFiAdapter(WiFiAdapter? wifiAdapter)
    {
        WiFiAdapter = wifiAdapter;
        return this;
    }

    public ComputerBuilder WithPowerUnit(PowerUnit? powerUnit, ComputerBuilderResult result)
    {
        result = result ?? throw new ArgumentNullException(nameof(result));
        PowerUnit = powerUnit ?? throw new MissingEssentialArgumentException(nameof(powerUnit));
        Cpu = Cpu ?? throw new MissingEssentialArgumentException(nameof(Cpu));
        VideoCard = VideoCard ?? throw new MissingEssentialArgumentException(nameof(VideoCard));

        int totalPowerConsumption = Cpu.PowerConsumption + RamPowerConsumption() + StoragePowerConsumption() +
                                    VideoCard.PowerConsumption;
        if (WiFiAdapter is not null) totalPowerConsumption += WiFiAdapter.PowerConsumption;

        if (totalPowerConsumption >= PowerUnit.PeakLoad)
            throw new IncompatibleElementsException("PowerUnit and Computer");
        if (totalPowerConsumption >= PowerUnit.RecommendedLoad)
            result.ErrorMessage = "PowerUnit may be not enough";
        return this;
    }

    public Computer Build()
    {
        return new Computer(
            MotherBoard ?? throw new MissingEssentialArgumentException(nameof(MotherBoard)),
            Bios ?? throw new MissingEssentialArgumentException(nameof(Bios)),
            Cpu ?? throw new MissingEssentialArgumentException(nameof(Cpu)),
            CpuCoolingSystem ?? throw new MissingEssentialArgumentException(nameof(CpuCoolingSystem)),
            RandomAccessMemoryUnits ?? throw new MissingEssentialArgumentException(nameof(RandomAccessMemoryUnits)),
            StorageUnits ?? throw new MissingEssentialArgumentException(nameof(StorageUnits)),
            VideoCard,
            ComputerCase ?? throw new MissingEssentialArgumentException(nameof(ComputerCase)),
            PowerUnit ?? throw new MissingEssentialArgumentException(nameof(PowerUnit)),
            WiFiAdapter);
    }

    public ComputerBuilder Direct(Computer computer)
    {
        computer = computer ?? throw new ArgumentNullException(nameof(computer));
        MotherBoard = computer.MotherBoard;
        Bios = computer.Bios;
        Cpu = computer.Cpu;
        CpuCoolingSystem = computer.CpuCoolingSystem;
        RandomAccessMemoryUnits = computer.RandomAccessMemoryUnits;
        StorageUnits = computer.StorageUnits;
        VideoCard = computer.VideoCard;
        ComputerCase = computer.ComputerCase;
        PowerUnit = computer.PowerUnit;
        WiFiAdapter = computer.WiFiAdapter;
        return this;
    }

    private int CountSsdWithPcie()
    {
        int kPcie = 0;
        StorageUnits = StorageUnits ?? throw new MissingEssentialArgumentException(nameof(StorageUnits));
        foreach (DriveBase db in StorageUnits)
        {
            if (db is not Ssd ssd) continue;
            if (ssd.ConnectionType == SsdConnection.PCIE) kPcie++;
        }

        return kPcie;
    }

    private int CountSsdWithSata()
    {
        int kSata = 0;
        StorageUnits = StorageUnits ?? throw new MissingEssentialArgumentException(nameof(StorageUnits));
        foreach (DriveBase db in StorageUnits)
        {
            if (db is not Ssd ssd) continue;
            if (ssd.ConnectionType == SsdConnection.SATA) kSata++;
        }

        return kSata;
    }

    private bool ConnectionMotherBoardToSsd()
    {
        return (MotherBoard is not null) && (CountSsdWithPcie() <= MotherBoard.PcieLinesAmount) &&
               (CountSsdWithSata() <= MotherBoard.SataPortsAmount);
    }

    private int RamPowerConsumption()
    {
        RandomAccessMemoryUnits = RandomAccessMemoryUnits ??
                                  throw new MissingEssentialArgumentException(nameof(RandomAccessMemoryUnits));

        return RandomAccessMemoryUnits.Sum(unit => unit.PowerConsumption);
    }

    private int StoragePowerConsumption()
    {
        StorageUnits = StorageUnits ?? throw new MissingEssentialArgumentException(nameof(StorageUnits));
        return StorageUnits.Sum(unit => unit.PowerConsumption);
    }
}