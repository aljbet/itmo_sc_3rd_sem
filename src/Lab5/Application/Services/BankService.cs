#pragma warning disable CA2007
using Application.Exceptions;
using Application.Models;

namespace Application.Services;

public class BankService : IBankService
{
    private readonly IAccountRepository _repository;

    public BankService(IAccountRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task CreateAccount(int accountNumber, int pin)
    {
        Account? account = await _repository.CheckIfAccountExists(accountNumber);
        if (account is not null)
            throw new AccountExistenceException($"Account {accountNumber} already exists.");

        await _repository.AddAccount(accountNumber, pin);
    }

    public async Task Deposit(int accountNumber, int pin, int money)
    {
        Account account = await _repository.CheckIfAccountExists(accountNumber) ??
                           throw new AccountExistenceException($"Account {accountNumber} does not exist.");

        if (account.Pin != pin)
            throw new WrongPinException("Wrong pin.");

        await _repository.UpdateBalance(accountNumber, account.Balance + money);
    }

    public async Task Deposit(int accountNumber, int money)
    {
        Account account = await _repository.CheckIfAccountExists(accountNumber) ??
                           throw new AccountExistenceException($"Account {accountNumber} does not exist.");

        await _repository.UpdateBalance(accountNumber, account.Balance + money);
    }

    public async Task Withdraw(int accountNumber, int pin, int money)
    {
        Account account = await _repository.CheckIfAccountExists(accountNumber) ??
                           throw new AccountExistenceException($"Account {accountNumber} does not exist.");

        if (account.Pin != pin)
            throw new WrongPinException("Wrong pin.");

        if (account.Balance < money)
            throw new BalanceException("Not enough money.");

        await _repository.UpdateBalance(accountNumber, account.Balance - money);
    }

    public async Task Withdraw(int accountNumber, int money)
    {
        Account account = await _repository.CheckIfAccountExists(accountNumber) ??
                           throw new AccountExistenceException($"Account {accountNumber} does not exist.");

        if (account.Balance < money)
            throw new BalanceException("Not enough money.");

        await _repository.UpdateBalance(accountNumber, account.Balance - money);
    }

    public async Task<int> ViewBalance(int accountNumber, int pin)
    {
        Account account = await _repository.CheckIfAccountExists(accountNumber) ??
                           throw new AccountExistenceException($"Account {accountNumber} does not exist.");

        if (account.Pin != pin)
            throw new WrongPinException("Wrong pin.");

        return account.Balance;
    }

    public async Task<int> ViewBalance(int accountNumber)
    {
        Account account = await _repository.CheckIfAccountExists(accountNumber) ??
                           throw new AccountExistenceException($"Account {accountNumber} does not exist.");

        return account.Balance;
    }
}