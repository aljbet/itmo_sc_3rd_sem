#pragma warning disable CA2007
using Application.Services;
using Presentation.Services;
using Spectre.Console;

namespace Presentation.Scenarios;

public class ViewBalanceScenario : IViewBalanceScenario
{
    private readonly IBankService _bankService;

    public ViewBalanceScenario(IBankService bankService)
    {
        _bankService = bankService ?? throw new ArgumentNullException(nameof(bankService));
    }

    public string Name => "view balance";

    public async Task<bool> RunAdmin(Logger logger)
    {
        Console.Clear();
        int accountNumber = AnsiConsole.Ask<int>("Enter account number:");

        int balance = await _bankService.ViewBalance(accountNumber);
        Console.WriteLine($"Current balance on account {accountNumber}: {balance}.");
        return true;
    }

    public async Task<bool> RunUser(Logger logger)
    {
        Console.Clear();
        int accountNumber = AnsiConsole.Ask<int>("Enter account number:");

        int pin = AnsiConsole.Prompt(
            new TextPrompt<int>("Enter pin:")
                .PromptStyle("red")
                .Secret());

        int balance = await _bankService.ViewBalance(accountNumber, pin);
        Console.WriteLine($"Current balance on account {accountNumber}: {balance}.");
        return true;
    }
}