using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Factories;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class ConfiguratorTests
{
    private Specification _specification = new Specification(
        motherBoardName: "ASUS EX-A320M-GAMING",
        biosName: "Intel Bios",
        cpuName: "Intel Core i7",
        cpuCoolingSystemName: "Corsair Cooling System",
        randomAccessMemoryUnitsNames: new[] { "Kingston Random Access Memory" },
        storageUnitsNames: new[] { "Samsung SSD" },
        videoCardName: "ASUS Video Card",
        computerCaseName: "Corsair Computer Case",
        powerUnitName: "AC Power Unit",
        wiFiAdapterName: "Intel WiFi Adapter");

    [Fact]
    public void OkBuildTest()
    {
        ComputerBuilderResult computer = new Configurator().MakeComputer(_specification);
        Assert.NotNull(computer.Computer);
        Assert.Equal("OK", computer.ErrorMessage);
    }

    [Theory]
    [InlineData("Corsair Power Unit")]
    public void NotEnoughPowerWarning(string powerUnitName)
    {
        Specification specification = _specification;
        specification.PowerUnitName = powerUnitName;

        ComputerBuilderResult computer = new Configurator().MakeComputer(specification);
        Assert.NotNull(computer.Computer);
        Assert.Equal("PowerUnit may be not enough", computer.ErrorMessage);
    }

    [Theory]
    [InlineData("AMD Ryzen 5", "NZXT Cooling System")]
    public void NotEnoughHeatDissipation(string cpuName, string cpuCoolingSystemName)
    {
        ComputerBuilderResult computer = new Configurator().MakeComputer(_specification);
        Assert.NotNull(computer.Computer);

        ComputerBuilder builder = new ComputerBuilder().Direct(computer.Computer)
            .WithCpu(DefaultFactories.CpuFactory.GetByName(cpuName))
            .WithCpuCoolingSystem(DefaultFactories.CpuCoolingSystemFactory.GetByName(cpuCoolingSystemName), computer);

        computer = new Director(builder).ValidateComputer(builder.Build());
        Assert.NotNull(computer.Computer);
        Assert.Equal("CpuCoolingSystem is not enough, no guarantee for performance", computer.ErrorMessage);
    }

    [Theory]
    [InlineData("ASUS EX-A320M-GAMING", "AMD Bios")]
    [InlineData("MSI B450 TOMAHAWK", "intel bios")]
    public void MotherBoardAndBiosFailure(string motherBoardName, string biosName)
    {
        Specification specification = _specification;
        specification.MotherBoardName = motherBoardName;
        specification.BiosName = biosName;

        ComputerBuilderResult computer = new Configurator().MakeComputer(specification);
        Assert.Null(computer.Computer);
        Assert.Equal("Incompatible elements: MotherBoard and Bios", computer.ErrorMessage);
    }

    [Theory]
    [InlineData("MSI B450 TOMAHAWK", "AMD Bios", "Intel Core i7")]
    public void MotherBoardAndCpuFailure(string motherBoardName, string biosName, string cpuName)
    {
        Specification specification = _specification;
        specification.MotherBoardName = motherBoardName;
        specification.BiosName = biosName;
        specification.CpuName = cpuName;

        ComputerBuilderResult computer = new Configurator().MakeComputer(specification);
        Assert.Null(computer.Computer);
        Assert.Equal("Incompatible elements: MotherBoard and Cpu", computer.ErrorMessage);
    }

    [Theory]
    [InlineData("MSI B450 TOMAHAWK", "AMD Bios", "AMD Ryzen 7", "NZXT Cooling System")]
    public void CpuAndCoolerBuild(string motherBoardName, string biosName, string cpuName, string cpuCoolingSystemName)
    {
        Specification specification = _specification;
        specification.MotherBoardName = motherBoardName;
        specification.BiosName = biosName;
        specification.CpuName = cpuName;
        specification.CpuCoolingSystemName = cpuCoolingSystemName;

        ComputerBuilderResult computer = new Configurator().MakeComputer(specification);
        Assert.Null(computer.Computer);
        Assert.Equal("Incompatible elements: Cpu and CpuCoolingSystem", computer.ErrorMessage);
    }

    [Theory]
    [InlineData("random name")]
    public void CpuAndVideoCoreBuild(string videoCardName)
    {
        Specification specification = _specification;
        specification.VideoCardName = videoCardName;

        ComputerBuilderResult computer = new Configurator().MakeComputer(specification);
        Assert.Null(computer.Computer);
        Assert.Equal("Missing essential argument: VideoCard", computer.ErrorMessage);
    }
}