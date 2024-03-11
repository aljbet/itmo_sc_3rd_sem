using System;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Armors;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.ShipTypes;

public abstract class ShipBase
{
    protected ShipBase(
        ArmorBase armor,
        ImpulseEngineBase impulseEngine,
        JumpingEngineBase jumpingEngine,
        DeflectorBase deflector)
    {
        Armor = armor ?? throw new ArgumentNullException(nameof(armor));
        ImpulseEngine = impulseEngine ?? throw new ArgumentNullException(nameof(impulseEngine));
        JumpingEngine = jumpingEngine ?? throw new ArgumentNullException(nameof(jumpingEngine));
        Deflector = deflector ?? throw new ArgumentNullException(nameof(deflector));
        ShipFlightResult = new FlightResult();
        HasAntinitrineEmitter = false;
    }

    public ImpulseEngineBase ImpulseEngine { get; set; }

    public JumpingEngineBase JumpingEngine { get; set; }

    public DeflectorBase Deflector { get; set; }

    public ArmorBase Armor { get; set; }

    public FlightResult ShipFlightResult { get; set; }
    public bool HasAntinitrineEmitter { get; set; }

    public void TakeAsteroidDamage()
    {
        if (Deflector.IsWorking()) Deflector.TakeAsteroidDamage();
        else if (Armor.IsWorking()) Armor.TakeAsteroidDamage();
        else ShipFlightResult.CurrentStatus = ShipStatus.Broken;
    }

    public void TakeMeteorDamage()
    {
        if (Deflector.IsWorking()) Deflector.TakeMeteorDamage();
        else if (Armor.IsWorking()) Armor.TakeMeteorDamage();
        else ShipFlightResult.CurrentStatus = ShipStatus.Broken;
    }

    public void TakeAntimatterDamage()
    {
        if (Deflector.IsWorking()) Deflector.TakeAntimatterDamage(this);
    }

    public void TakeSpaceWhaleDamage()
    {
        if (Deflector.CanFightSpaceWhale) Deflector.StopWorking();
        else ShipFlightResult.CurrentStatus = ShipStatus.Broken;
    }
}