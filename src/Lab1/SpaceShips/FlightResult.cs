namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips;

public class FlightResult
{
    public FlightResult()
    {
        CurrentStatus = ShipStatus.Ok;
        TotalFuelCost = 0;
    }

    public ShipStatus CurrentStatus { get; set; }
    public double TotalFuelCost { get; set; }
}