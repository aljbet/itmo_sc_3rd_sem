namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Engines;

public class JumpingEngineGamma : JumpingEngineBase
{
    public JumpingEngineGamma(double fuelConsumption)
        : base(fuelConsumption, Constants.BigLength)
    {
    }

    public override double FuelWaste(double distance)
    {
        return distance * distance * FuelConsumption;
    }
}