using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Armors;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.ShipTypes;

public class Augur : ShipBase
{
    public Augur()
        : base(
            new ArmorClass3(),
            new ImpulseEngineClassE(Constants.EngineEDefaultFuelConsumption, Constants.StartVelocity),
            new JumpingEngineAlpha(Constants.DefaultGravitationalMatterConsumption),
            new DeflectorClass3())
    {
    }
}