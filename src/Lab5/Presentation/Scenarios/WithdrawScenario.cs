#pragma warning disable CA2007
using Application.Services;
using Presentation.Services;
using Spectre.Console;

namespace Presentation.Scenarios;

public class WithdrawScenario : IWithdrawScenario
{
    private readonly IBankService _bankService;

    public WithdrawScenario(IBankService bankService)
    {
        _bankService = bankService ?? throw new ArgumentNullException(nameof(bankService));
    }

    public string Name => "withdraw money";

    public async Task<bool> RunAdmin(Logger logger)
    {
        Console.Clear();
        logger = logger ?? throw new ArgumentNullException(nameof(logger));
        int accountNumber = AnsiConsole.Ask<int>("Enter account number:");

        int money = AnsiConsole.Prompt(
            new TextPrompt<int>("Enter amount:"));

        await _bankService.Withdraw(accountNumber, money);
        logger.Log($"Account {accountNumber}: {money} withdrawn.");
        Console.WriteLine($"{money} successfully withdrawn from the account {accountNumber}.");
        return true;
    }

    public async Task<bool> RunUser(Logger logger)
    {
        Console.Clear();
        logger = logger ?? throw new ArgumentNullException(nameof(logger));
        int accountNumber = AnsiConsole.Ask<int>("Enter account number:");

        int pin = AnsiConsole.Prompt(
            new TextPrompt<int>("Enter pin:")
                .PromptStyle("red")
                .Secret());

        int money = AnsiConsole.Prompt(
            new TextPrompt<int>("Enter amount:"));

        await _bankService.Withdraw(accountNumber, pin, money);
        logger.Log($"Account {accountNumber}: {money} withdrawn.");
        Console.WriteLine($"{money} successfully withdrawn from the account {accountNumber}.");
        return true;
    }
}