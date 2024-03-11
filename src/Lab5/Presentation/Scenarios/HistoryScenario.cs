#pragma warning disable CA2007
using Presentation.Services;

namespace Presentation.Scenarios;

public class HistoryScenario : IHistoryScenario
{
    public string Name => "history";

    public async Task<bool> RunAdmin(Logger logger)
    {
        return await Run(logger);
    }

    public async Task<bool> RunUser(Logger logger)
    {
        return await Run(logger);
    }

    private Task<bool> Run(Logger logger)
    {
        Console.Clear();
        logger = logger ?? throw new ArgumentNullException(nameof(logger));
        logger.ShowHistory();
        return Task.FromResult(true);
    }
}