#pragma warning disable CA2007

using System.Threading.Tasks;
using Application.Exceptions;
using Application.Models;
using Application.Services;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class BankTests
{
    [Theory]
    [InlineData(0, 0)]
    public async Task CreateAccountTest(int accountNumber, int pin)
    {
        IAccountRepository repository = Substitute.For<IAccountRepository>();
        var bankService = new BankService(repository);

        await bankService.CreateAccount(accountNumber, pin);
        await repository.Received().CheckIfAccountExists(accountNumber);
        await repository.Received().AddAccount(accountNumber, pin);
    }

    [Theory]
    [InlineData(0, 0, 100, 5)]
    public async Task DepositTest(int accountNumber, int pin, int currentBalance, int money)
    {
        IAccountRepository repository = Substitute.For<IAccountRepository>();
        var bankService = new BankService(repository);
        repository.CheckIfAccountExists(accountNumber).Returns(new Account(accountNumber, pin, currentBalance));

        await bankService.Deposit(accountNumber, money);
        await repository.Received().CheckIfAccountExists(accountNumber);
        await repository.Received().UpdateBalance(accountNumber, currentBalance + money);
    }

    [Theory]
    [InlineData(0, 0, 100, 5)]
    public async Task WithdrawTest(int accountNumber, int pin, int currentBalance, int money)
    {
        IAccountRepository repository = Substitute.For<IAccountRepository>();
        var bankService = new BankService(repository);
        repository.CheckIfAccountExists(accountNumber).Returns(new Account(accountNumber, pin, currentBalance));

        await bankService.Withdraw(accountNumber, money);
        await repository.Received().CheckIfAccountExists(accountNumber);
        await repository.Received().UpdateBalance(accountNumber, currentBalance - money);
    }

    [Theory]
    [InlineData(0, 0, 100, 150)]
    public async Task FailedWithdrawTest(int accountNumber, int pin, int currentBalance, int money)
    {
        IAccountRepository repository = Substitute.For<IAccountRepository>();
        var bankService = new BankService(repository);
        repository.CheckIfAccountExists(accountNumber).Returns(new Account(accountNumber, pin, currentBalance));

        await Assert.ThrowsAsync<BalanceException>(() => bankService.Withdraw(accountNumber, money));
    }

    [Theory]
    [InlineData(0, 0, 0)]
    public async Task ViewBalanceTest(int accountNumber, int pin, int currentBalance)
    {
        IAccountRepository repository = Substitute.For<IAccountRepository>();
        var bankService = new BankService(repository);
        repository.CheckIfAccountExists(accountNumber).Returns(new Account(accountNumber, pin, currentBalance));

        await bankService.ViewBalance(accountNumber, pin);
        await repository.Received().CheckIfAccountExists(accountNumber);
    }

    [Theory]
    [InlineData(0, 0)]
    public async Task UnknownAccountTest(int accountNumber, int pin)
    {
        IAccountRepository repository = Substitute.For<IAccountRepository>();
        var bankService = new BankService(repository);

        await Assert.ThrowsAsync<AccountExistenceException>(() => bankService.ViewBalance(accountNumber, pin));
    }

    [Theory]
    [InlineData(0, 0, 100, 1)]
    public async Task WrongPinTest(int accountNumber, int correctPin, int currentBalance, int wrongPin)
    {
        IAccountRepository repository = Substitute.For<IAccountRepository>();
        var bankService = new BankService(repository);
        repository.CheckIfAccountExists(accountNumber).Returns(new Account(accountNumber, correctPin, currentBalance));

        await Assert.ThrowsAsync<WrongPinException>(() => bankService.Deposit(accountNumber, wrongPin, currentBalance));
    }
}