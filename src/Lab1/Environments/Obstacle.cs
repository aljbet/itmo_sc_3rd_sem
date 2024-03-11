namespace Itmo.ObjectOrientedProgramming.Lab1.Environments;

public class Obstacle
{
    public Obstacle(int populationSize)
    {
        PopulationSize = populationSize;
    }

    public int PopulationSize { get; init; }
}