namespace Application.Models;

public interface IAccountRepository
{
    Task AddAccount(int accountNumber, int pin);
    Task<Account?> CheckIfAccountExists(int accountNumber);
    Task UpdateBalance(int accountNumber, int newBalance);
}