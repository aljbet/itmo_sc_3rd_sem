using System;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.ShipTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Deflectors;

public class DeflectorBase
{
    public DeflectorBase()
    {
        CanFightSpaceWhale = false;
        AsteroidStrength = 0;
        MeteorStrength = 0;
        AntimatterStrength = 0;
    }

    public bool CanFightSpaceWhale { get; set; }
    protected int AsteroidStrength { get; set; }
    protected int MeteorStrength { get; set; }
    private int AntimatterStrength { get; set; }

    public void MakeDeflectorPhoton()
    {
        AntimatterStrength = 3;
    }

    public bool IsWorking()
    {
        return AsteroidStrength > 0 && MeteorStrength > 0;
    }

    public void StopWorking()
    {
        CanFightSpaceWhale = false;
        AsteroidStrength = 0;
        MeteorStrength = 0;
        AntimatterStrength = 0;
    }

    public void TakeAsteroidDamage()
    {
        AsteroidStrength--;
    }

    public void TakeMeteorDamage()
    {
        MeteorStrength--;
    }

    public void TakeAntimatterDamage(ShipBase ship)
    {
        ship = ship ?? throw new ArgumentNullException(nameof(ship));
        if (AntimatterStrength == 0) ship.ShipFlightResult.CurrentStatus = ShipStatus.Dead;
        else AntimatterStrength--;
    }
}