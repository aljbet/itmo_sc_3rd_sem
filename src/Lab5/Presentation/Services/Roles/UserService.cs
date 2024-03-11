#pragma warning disable CA2007
using Presentation.Scenarios;
using Spectre.Console;

namespace Presentation.Services.Roles;

public class UserService : IUserService
{
    private readonly Logger _logger = new Logger();
    private readonly List<IScenario> _scenarios = new();

    public UserService(
        ICreateAccountScenario createAccountScenario,
        IDepositScenario depositScenario,
        IWithdrawScenario withdrawScenario,
        IViewBalanceScenario viewBalanceScenario,
        IHistoryScenario historyScenario,
        IExitScenario exitScenario)
    {
        _scenarios.Add(createAccountScenario);
        _scenarios.Add(depositScenario);
        _scenarios.Add(withdrawScenario);
        _scenarios.Add(viewBalanceScenario);
        _scenarios.Add(historyScenario);
        _scenarios.Add(exitScenario);
    }

    public string Name => "user";

    public async Task Authorize()
    {
        while (await ChooseAction())
        {
        }
    }

    public async Task<bool> ChooseAction()
    {
        IScenario action = AnsiConsole.Prompt(
            new SelectionPrompt<IScenario>()
                .Title("Select action")
                .AddChoices(_scenarios)
                .UseConverter(x => x.Name));
        return await action.RunUser(_logger);
    }
}