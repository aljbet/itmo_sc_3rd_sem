using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Armors;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.ShipTypes;

public class Stella : ShipBase
{
    public Stella()
        : base(
        new ArmorClass1(),
        new ImpulseEngineClassC(Constants.EngineCDefaultFuelConsumption, Constants.StartVelocity),
        new JumpingEngineOmega(Constants.DefaultGravitationalMatterConsumption),
        new DeflectorClass1())
    {
    }
}