namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class ComputerBuilderResult
{
    public ComputerBuilderResult()
    {
        Computer = null;
        ErrorMessage = "OK";
    }

    public ComputerBuilderResult(Computer computer)
    {
        Computer = computer;
        ErrorMessage = "OK";
    }

    public ComputerBuilderResult(string errorMessage)
    {
        Computer = null;
        ErrorMessage = errorMessage;
    }

    public ComputerBuilderResult(Computer computer, string errorMessage)
    {
        Computer = computer;
        ErrorMessage = errorMessage;
    }

    public Computer? Computer { get; set; }
    public string ErrorMessage { get; set; }
}