using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Armors;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.ShipTypes;

public class Vaclas : ShipBase
{
    public Vaclas()
        : base(
            new ArmorClass2(),
            new ImpulseEngineClassE(Constants.EngineEDefaultFuelConsumption, Constants.StartVelocity),
            new JumpingEngineGamma(Constants.DefaultGravitationalMatterConsumption),
            new DeflectorClass1())
    {
    }
}