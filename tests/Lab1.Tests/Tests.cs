using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.SpaceTypes;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.ShipTypes;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class Tests
{
    public static IEnumerable<object[]> TestShuttle => new List<object[]>
    {
        new object[]
        {
            new Shuttle(),
            ShipStatus.Broken,
        },
    };
    public static IEnumerable<object[]> TestVaclas => new List<object[]>
    {
        new object[]
        {
            new Vaclas(),
            ShipStatus.Ok,
        },
    };
    public static IEnumerable<object[]> TestMeridian => new List<object[]>
    {
        new object[]
        {
            new Meridian(),
            ShipStatus.Lost,
        },
    };
    public static IEnumerable<object[]> TestStella => new List<object[]>
    {
        new object[]
        {
            new Stella(),
            ShipStatus.Ok,
        },
    };
    public static IEnumerable<object[]> TestAugur => new List<object[]>
    {
        new object[]
        {
            new Augur(),
            ShipStatus.Dead,
        },
    };

    [Fact]
    public void HighDensitySpaceWithMediumLength1()
    {
        ICollection<SpaceBase> route = new List<SpaceBase>
        {
            new HighDensityNebula(Constants.MediumLength),
        };
        var shuttle = new Shuttle();
        var augur = new Augur();
        var myService = new RunService();
        FlightResult result1 = myService.Run(shuttle, route);
        FlightResult result2 = myService.Run(augur, route);
        Assert.Equal(ShipStatus.Lost, result1.CurrentStatus);
        Assert.Equal(ShipStatus.Lost, result2.CurrentStatus);
    }

    [Fact]
    public void HighDensitySpaceWithAntimatter()
    {
        ICollection<SpaceBase> route = new List<SpaceBase>
        {
            new HighDensityNebula(Constants.BigLength),
        };
        var vaclas = new Vaclas();
        var photonVaclas = new Vaclas();
        photonVaclas.Deflector.MakeDeflectorPhoton();
        var myService = new RunService();
        FlightResult result1 = myService.Run(vaclas, route);
        FlightResult result2 = myService.Run(photonVaclas, route);
        Assert.Equal(ShipStatus.Dead, result1.CurrentStatus);
        Assert.Equal(ShipStatus.Ok, result2.CurrentStatus);
    }

    [Fact]
    public void NitrineNebulaWithSpaceWhales()
    {
        ICollection<SpaceBase> route = new List<SpaceBase>
        {
            new NitrineParticlesNebula(Constants.SmallLength),
        };
        var vaclas = new Vaclas();
        var augur = new Augur();
        var meridian = new Meridian();
        var myService = new RunService();
        FlightResult result1 = myService.Run(vaclas, route);
        FlightResult result2 = myService.Run(augur, route);
        FlightResult result3 = myService.Run(meridian, route);
        Assert.Equal(ShipStatus.Broken, result1.CurrentStatus);
        Assert.Equal(ShipStatus.Ok, result2.CurrentStatus);
        Assert.False(augur.Deflector.IsWorking());
        Assert.Equal(ShipStatus.Ok, result3.CurrentStatus);
    }

    [Fact]
    public void CasualSpaceRoute()
    {
        ICollection<SpaceBase> route = new List<SpaceBase>
        {
            new CasualSpace(Constants.SmallLength, 0, 0),
        };
        var shuttle = new Shuttle();
        var vaclas = new Vaclas();
        ShipBase bestShip = new RunService().ChooseBest(shuttle, vaclas, route);
        Assert.Equal(shuttle, bestShip);
    }

    [Fact]
    public void HighDensitySpaceWithMediumLength2()
    {
        ICollection<SpaceBase> route = new List<SpaceBase>
        {
            new HighDensityNebula(Constants.MediumLength, 0),
        };
        var augur = new Augur();
        var stella = new Stella();
        ShipBase bestShip = new RunService().ChooseBest(augur, stella, route);
        Assert.Equal(stella, bestShip);
    }

    [Fact]
    public void NitrineSpaceWithMediumLength()
    {
        ICollection<SpaceBase> route = new List<SpaceBase>
        {
            new NitrineParticlesNebula(Constants.MediumLength),
        };
        var shuttle = new Shuttle();
        var vaclas = new Vaclas();
        ShipBase bestShip = new RunService().ChooseBest(shuttle, vaclas, route);
        Assert.Equal(vaclas, bestShip);
    }

    [Theory]
    [MemberData(nameof(TestShuttle))]
    [MemberData(nameof(TestVaclas))]
    [MemberData(nameof(TestMeridian))]
    [MemberData(nameof(TestStella))]
    [MemberData(nameof(TestAugur))]
    public void ComplexRoute(ShipBase ship, ShipStatus status)
    {
        ICollection<SpaceBase> route = new List<SpaceBase>
        {
            new NitrineParticlesNebula(Constants.MediumLength, 0),
            new CasualSpace(Constants.BigLength),
            new HighDensityNebula(Constants.SmallLength),
        };
        ShipStatus neededStatus = new RunService().Run(ship, route).CurrentStatus;

        Assert.Equal(status, neededStatus);
    }
}