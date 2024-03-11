using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Armors;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.ShipTypes;

public class Meridian : ShipBase
{
    public Meridian()
        : base(
            new ArmorClass2(),
            new ImpulseEngineClassE(Constants.EngineEDefaultFuelConsumption, Constants.StartVelocity),
            new JumpingEngineNull(),
            new DeflectorClass2())
    {
        HasAntinitrineEmitter = true;
    }
}