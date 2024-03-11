using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class Configurator
{
    public ComputerBuilderResult ValidateComputer(Computer computer)
    {
        return new Director(new ComputerBuilder()).ValidateComputer(computer);
    }

    public ComputerBuilderResult MakeComputer(Specification specification)
    {
        try
        {
            return new Director(new ComputerBuilder()).Direct(specification);
        }
        catch (MissingEssentialArgumentException e)
        {
            return new ComputerBuilderResult("Missing essential argument: " + e.Message);
        }
        catch (IncompatibleElementsException e)
        {
            return new ComputerBuilderResult("Incompatible elements: " + e.Message);
        }
        catch (UnknownObjectNameException e)
        {
            return new ComputerBuilderResult("Unknown object name: " + e.Message);
        }
    }
}