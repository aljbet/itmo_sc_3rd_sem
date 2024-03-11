using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Drives;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Factories;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class Director
{
    private readonly Factory<MotherBoard> _motherBoardFabric;
    private readonly Factory<Bios> _biosFabric;
    private readonly Factory<Cpu> _cpuFabric;
    private readonly Factory<CpuCoolingSystem> _cpucsFabric;
    private readonly Factory<RandomAccessMemory> _randomAccessMemoryFabric;
    private readonly Factory<DriveBase> _driveFabric;
    private readonly Factory<VideoCard> _videoCardFabric;
    private readonly Factory<ComputerCase> _computerCaseFabric;
    private readonly Factory<PowerUnit> _powerUnitFabric;
    private readonly Factory<WiFiAdapter> _wiFiAdapterFabric;

    public Director(ComputerBuilder builder)
    {
        Builder = builder;
        _motherBoardFabric = DefaultFactories.MotherBoardFactory;
        _biosFabric = DefaultFactories.BiosFactory;
        _cpuFabric = DefaultFactories.CpuFactory;
        _cpucsFabric = DefaultFactories.CpuCoolingSystemFactory;
        _randomAccessMemoryFabric = DefaultFactories.RamFactory;
        _driveFabric = DefaultFactories.DriveFactory;
        _videoCardFabric = DefaultFactories.VideoCardFactory;
        _computerCaseFabric = DefaultFactories.ComputerCaseFactory;
        _powerUnitFabric = DefaultFactories.PowerUnitFactory;
        _wiFiAdapterFabric = DefaultFactories.WiFiAdapterFactory;
    }

    public ComputerBuilder Builder { get; }

    public ComputerBuilderResult Direct(Specification specification)
    {
        var result = new ComputerBuilderResult();
        specification = specification ?? throw new ArgumentNullException(nameof(specification));

        MotherBoard? motherBoard = _motherBoardFabric.GetByName(specification.MotherBoardName);
        Builder.WithMotherBoard(motherBoard);

        Bios? bios = _biosFabric.GetByName(specification.BiosName);
        Builder.WithBios(bios);

        Cpu? cpu = _cpuFabric.GetByName(specification.CpuName);
        Builder.WithCpu(cpu);

        CpuCoolingSystem? cpuCoolingSystem = _cpucsFabric.GetByName(specification.CpuCoolingSystemName);
        Builder.WithCpuCoolingSystem(cpuCoolingSystem, result);

        IEnumerable<RandomAccessMemory> randomAccessMemoryUnits =
            specification.RandomAccessMemoryUnitsNames.Select(name =>
                _randomAccessMemoryFabric.GetByName(name) ?? throw new UnknownObjectNameException(name));
        Builder.WithRandomAccessMemoryUnits(randomAccessMemoryUnits);

        IEnumerable<DriveBase> storageUnits = specification.StorageUnitsNames.Select(name =>
            _driveFabric.GetByName(name) ?? throw new UnknownObjectNameException(name));
        Builder.WithStorageUnits(storageUnits);

        VideoCard? videoCard = _videoCardFabric.GetByName(specification.VideoCardName);
        Builder.WithVideoCard(videoCard);

        ComputerCase? computerCase = _computerCaseFabric.GetByName(specification.ComputerCaseName);
        Builder.WithCase(computerCase);

        WiFiAdapter? wiFiAdapter = _wiFiAdapterFabric.GetByName(specification.WiFiAdapterName);
        Builder.WithWiFiAdapter(wiFiAdapter);

        PowerUnit? powerUnit = _powerUnitFabric.GetByName(specification.PowerUnitName);
        Builder.WithPowerUnit(powerUnit, result);

        result.Computer = Builder.Build();
        return result;
    }

    public ComputerBuilderResult ValidateComputer(Computer computer)
    {
        computer = computer ?? throw new ArgumentNullException(nameof(computer));
        var result = new ComputerBuilderResult();
        Builder.WithMotherBoard(computer.MotherBoard);
        Builder.WithBios(computer.Bios);
        Builder.WithCpu(computer.Cpu);
        Builder.WithCpuCoolingSystem(computer.CpuCoolingSystem, result);
        Builder.WithRandomAccessMemoryUnits(computer.RandomAccessMemoryUnits);
        Builder.WithStorageUnits(computer.StorageUnits);
        Builder.WithVideoCard(computer.VideoCard);
        Builder.WithCase(computer.ComputerCase);
        Builder.WithPowerUnit(computer.PowerUnit, result);
        Builder.WithWiFiAdapter(computer.WiFiAdapter);
        result.Computer = Builder.Build();
        return result;
    }
}