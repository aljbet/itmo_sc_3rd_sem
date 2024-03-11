namespace Application.Services;

public interface IBankService
{
    Task CreateAccount(int accountNumber, int pin);

    Task Deposit(int accountNumber, int pin, int money);

    Task Deposit(int accountNumber, int money);

    Task Withdraw(int accountNumber, int pin, int money);

    Task Withdraw(int accountNumber, int money);

    Task<int> ViewBalance(int accountNumber, int pin);

    Task<int> ViewBalance(int accountNumber);
}