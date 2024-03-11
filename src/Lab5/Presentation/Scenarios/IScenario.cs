using Presentation.Services;

namespace Presentation.Scenarios;

public interface IScenario
{
    public string Name { get; }

    public Task<bool> RunAdmin(Logger logger);
    public Task<bool> RunUser(Logger logger);
}