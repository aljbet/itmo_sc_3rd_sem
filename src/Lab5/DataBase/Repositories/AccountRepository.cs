#pragma warning disable CA2007
using Application.Models;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Npgsql;

namespace DataBase.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AccountRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task AddAccount(int accountNumber, int pin)
    {
        const string query =
            """
            insert into accounts
            values(:accountNumber, :pin, 0);
            """;

        NpgsqlConnection a = await _connectionProvider.GetConnectionAsync(CancellationToken.None);

        await using var command = new NpgsqlCommand(query, a);
        command
            .AddParameter("accountNumber", accountNumber)
            .AddParameter("pin", pin);
        await command.ExecuteNonQueryAsync();
    }

    public async Task<Account?> CheckIfAccountExists(int accountNumber)
    {
        const string query =
            """
            select * from accounts
            where account_number = :accountNumber;
            """;

        NpgsqlConnection a = await _connectionProvider.GetConnectionAsync(CancellationToken.None);

        await using var command = new NpgsqlCommand(query, a);
        command.AddParameter("accountNumber", accountNumber);
        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();
        if (!await reader.ReadAsync()) return null;
        return new Account(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2));
    }

    public async Task UpdateBalance(int accountNumber, int newBalance)
    {
        const string query =
            """
            update accounts
            set balance = :newBalance
            where account_number = :accountNumber;
            """;

        NpgsqlConnection a = await _connectionProvider.GetConnectionAsync(CancellationToken.None);

        await using var command = new NpgsqlCommand(query, a);
        command
            .AddParameter("accountNumber", accountNumber)
            .AddParameter("newBalance", newBalance);
        await command.ExecuteNonQueryAsync();
    }
}