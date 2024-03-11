using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Armors;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.ShipTypes;

public class Shuttle : ShipBase
{
    public Shuttle()
        : base(
            new ArmorClass1(),
            new ImpulseEngineClassC(Constants.EngineCDefaultFuelConsumption, Constants.StartVelocity),
            new JumpingEngineNull(),
            new DeflectorBase())
    {
    }
}