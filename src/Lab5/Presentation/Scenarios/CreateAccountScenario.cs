#pragma warning disable CA2007
using Application.Services;
using Presentation.Services;
using Spectre.Console;

namespace Presentation.Scenarios;

public class CreateAccountScenario : ICreateAccountScenario
{
    private readonly IBankService _bankService;

    public CreateAccountScenario(IBankService bankService)
    {
        _bankService = bankService ?? throw new ArgumentNullException(nameof(bankService));
    }

    public string Name => "create account";

    public async Task<bool> RunAdmin(Logger logger)
    {
        return await Run(logger);
    }

    public async Task<bool> RunUser(Logger logger)
    {
        return await Run(logger);
    }

    private async Task<bool> Run(Logger logger)
    {
        Console.Clear();
        logger = logger ?? throw new ArgumentNullException(nameof(logger));
        int accountNumber = AnsiConsole.Ask<int>("Enter account number:");

        int pin = AnsiConsole.Prompt(
            new TextPrompt<int>("Enter pin:")
                .PromptStyle("red")
                .Secret());

        await _bankService.CreateAccount(accountNumber, pin);
        logger.Log($"Account {accountNumber}: created.");
        Console.WriteLine($"Account {accountNumber}: successfully created.");
        return true;
    }
}