namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Engines;

public class JumpingEngineAlpha : JumpingEngineBase
{
    public JumpingEngineAlpha(double fuelConsumption)
        : base(fuelConsumption, Constants.SmallLength)
    {
    }

    public override double FuelWaste(double distance)
    {
        return distance * FuelConsumption;
    }
}