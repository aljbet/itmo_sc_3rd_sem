using Presentation.Services;

namespace Presentation.Scenarios;

public class ExitScenario : IExitScenario
{
    public string Name => "exit";

    public Task<bool> RunAdmin(Logger logger)
    {
        Console.Clear();
        return Task.FromResult(false);
    }

    public Task<bool> RunUser(Logger logger)
    {
        Console.Clear();
        return Task.FromResult(false);
    }
}