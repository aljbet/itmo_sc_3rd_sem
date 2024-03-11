namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Engines;

public class JumpingEngineNull : JumpingEngineBase
{
    public override double FuelWaste(double distance)
    {
        return 0;
    }
}