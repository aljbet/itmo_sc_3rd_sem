using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Drives;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Attributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Factories;

public static class DefaultFactories
{
    public static Factory<MotherBoard> MotherBoardFactory => new Factory<MotherBoard>(
        new List<MotherBoard>()
        {
            new MotherBoard(
                "ASUS EX-A320M-GAMING",
                Socket.AM4,
                20,
                4,
                ChipSet.A320,
                StandardDdr.DDR4,
                4,
                MotherBoardFormFactor.MicroATX,
                new Bios(
                    name: "Intel Bios",
                    biosType: BiosType.UEFI,
                    biosVersion: 1.20,
                    supportedCpus: new[] { "Intel Core i7", "AMD Ryzen 5" })),

            new MotherBoard(
                "MSI B450 TOMAHAWK",
                Socket.LGA1151,
                20,
                4,
                ChipSet.B450,
                StandardDdr.DDR4,
                4,
                MotherBoardFormFactor.MicroATX,
                new Bios(
                    name: "AMD Bios",
                    biosType: BiosType.UEFI,
                    biosVersion: 1.20,
                    supportedCpus: new[] { "AMD Ryzen 5", "AMD Ryzen 7" })),
        });

    public static Factory<Bios> BiosFactory => new Factory<Bios>(
        new List<Bios>()
        {
            new Bios(
                name: "Intel Bios",
                biosType: BiosType.UEFI,
                biosVersion: 1.20,
                supportedCpus: new[] { "Intel Core i7", "AMD Ryzen 5" }),

            new Bios(
                name: "AMD Bios",
                biosType: BiosType.UEFI,
                biosVersion: 1.20,
                supportedCpus: new[] { "AMD Ryzen 5", "AMD Ryzen 7" }),
        });

    public static Factory<Cpu> CpuFactory => new Factory<Cpu>(
        new List<Cpu>()
        {
            new Cpu(
                name: "Intel Core i7",
                coreFrequency: 4,
                coreAmount: 8,
                socket: Socket.AM4,
                hasVideoCore: false,
                maximumMemoryFrequency: 4,
                heatDissipation: 75,
                powerConsumption: 200),

            new Cpu(
                name: "AMD Ryzen 5",
                coreFrequency: 4,
                coreAmount: 8,
                socket: Socket.AM4,
                hasVideoCore: true,
                maximumMemoryFrequency: 4,
                heatDissipation: 85,
                powerConsumption: 350),

            new Cpu(
                name: "AMD Ryzen 7",
                coreFrequency: 4,
                coreAmount: 8,
                socket: Socket.LGA1151,
                hasVideoCore: true,
                maximumMemoryFrequency: 4,
                heatDissipation: 100,
                powerConsumption: 500),
        });

    public static Factory<CpuCoolingSystem> CpuCoolingSystemFactory => new Factory<CpuCoolingSystem>(
        new List<CpuCoolingSystem>()
        {
            new CpuCoolingSystem(
                "Corsair Cooling System",
                120,
                2,
                120,
                new[] { Socket.AM4, Socket.LGA1151, Socket.LGA1200 },
                100),

            new CpuCoolingSystem(
                "NZXT Cooling System",
                150,
                3,
                100,
                new[] { Socket.AM4, Socket.LGA775, Socket.LGA1155 },
                80),
        });

    public static Factory<RandomAccessMemory> RamFactory => new Factory<RandomAccessMemory>(
        new List<RandomAccessMemory>()
        {
            new RandomAccessMemory(
                name: "Kingston Random Access Memory",
                memoryAmount: 512,
                jedecFrequenciesAndVoltages: new[] { new Tuple<double, double>(1200, 1.2) },
                supportedXmpProfiles: new[] { new XmpProfile(name: "Kingston XMP Profile", timing: "18-18-36-54", voltage: 1.2, frequency: 1200) },
                ramFormFactor: RamFormFactor.SODIMM,
                standardDdr: StandardDdr.DDR4,
                powerConsumption: 300),

            new RandomAccessMemory(
                name: "Samsung Random Access Memory",
                memoryAmount: 1024,
                jedecFrequenciesAndVoltages: new[] { new Tuple<double, double>(1200, 1.2) },
                supportedXmpProfiles: new[] { new XmpProfile(name: "Samsung XMP Profile", timing: "18-18-36-54", voltage: 1.2, frequency: 1200) },
                ramFormFactor: RamFormFactor.DIMM,
                standardDdr: StandardDdr.DDR4,
                powerConsumption: 400),
        });

    public static Factory<DriveBase> DriveFactory => new Factory<DriveBase>(
        new List<DriveBase>()
        {
            new Ssd(
                name: "Samsung SSD",
                capacity: 500,
                powerConsumption: 200,
                connectionType: SsdConnection.SATA,
                maximumSpeed: 1000),

            new Hdd(
                name: "Seagate HDD",
                capacity: 500,
                powerConsumption: 400,
                spindleSpeed: 7200),
        });

    public static Factory<VideoCard> VideoCardFactory => new Factory<VideoCard>(
        new List<VideoCard>()
        {
            new VideoCard(
                name: "ASUS Video Card",
                height: 90,
                width: 90,
                memoryCapacity: 8,
                pcieVersion: 3,
                chipFrequency: 2.5,
                powerConsumption: 100),

            new VideoCard(
                name: "MSI Video Card",
                height: 95,
                width: 85,
                memoryCapacity: 16,
                pcieVersion: 3,
                chipFrequency: 2.5,
                powerConsumption: 400),
        });

    public static Factory<ComputerCase> ComputerCaseFactory => new Factory<ComputerCase>(
        new List<ComputerCase>()
        {
            new ComputerCase(
                name: "Corsair Computer Case",
                videoCardHeight: 100,
                videoCardWidth: 100,
                supportedMotherBoardFormFactors: new[] { MotherBoardFormFactor.MicroATX },
                height: 500,
                width: 500,
                depth: 500),
        });

    public static Factory<PowerUnit> PowerUnitFactory => new Factory<PowerUnit>(
        new List<PowerUnit>()
        {
            new PowerUnit(
                name: "AC Power Unit",
                peakLoad: 3200),

            new PowerUnit(
                name: "Corsair Power Unit",
                peakLoad: 1000),
        });

    public static Factory<WiFiAdapter> WiFiAdapterFactory => new Factory<WiFiAdapter>(
        new List<WiFiAdapter>()
        {
            new WiFiAdapter(
                name: "Intel WiFi Adapter",
                standard: WiFiStandard.WiFi5,
                hasBluetoothModule: true,
                pcieVersion: 3,
                powerConsumption: 100),

            new WiFiAdapter(
                name: "ASUS WiFi Adapter",
                standard: WiFiStandard.WiFi5,
                hasBluetoothModule: true,
                pcieVersion: 3,
                powerConsumption: 200),
        });
}