#pragma warning disable CA2007
using Application.Exceptions;
using Presentation.Scenarios;
using Spectre.Console;

namespace Presentation.Services.Roles;

public class AdminService : IAdminService
{
    private readonly Logger _logger = new Logger();
    private readonly List<IScenario> _scenarios = new();

    public AdminService(
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

    public string Name => "admin";

    public async Task Authorize()
    {
        string password = AnsiConsole.Prompt(
            new TextPrompt<string>("Enter password:")
                .PromptStyle("red")
                .Secret());
        if (password != Config.SystemPassword)
        {
            throw new WrongSystemPasswordException("Wrong system password.");
        }

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
        return await action.RunAdmin(_logger);
    }
}