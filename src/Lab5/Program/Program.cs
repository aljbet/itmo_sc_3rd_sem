#pragma warning disable CA2007

using Application.Exceptions;
using Application.Models;
using Application.Services;
using DataBase.Repositories;
using Itmo.Dev.Platform.Postgres.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Scenarios;
using Presentation.Services;
using Presentation.Services.Roles;

try
{
    var collection = new ServiceCollection();

    collection.AddScoped<ScenarioRunner>();
    collection.AddScoped<IBankService, BankService>();
    collection.AddScoped<IAdminService, AdminService>();
    collection.AddScoped<IUserService, UserService>();
    collection.AddScoped<ICreateAccountScenario, CreateAccountScenario>();
    collection.AddScoped<IDepositScenario, DepositScenario>();
    collection.AddScoped<IWithdrawScenario, WithdrawScenario>();
    collection.AddScoped<IViewBalanceScenario, ViewBalanceScenario>();
    collection.AddScoped<IHistoryScenario, HistoryScenario>();
    collection.AddScoped<IExitScenario, ExitScenario>();
    collection.AddScoped<IAccountRepository, AccountRepository>();

    collection.AddPlatformPostgres(builder => builder.Configure(
        configuration =>
        {
            configuration.Host = "localhost";
            configuration.Port = 5432;
            configuration.Username = "postgres";
            configuration.Password = "postgres";
            configuration.Database = "postgres";
            configuration.SslMode = "Prefer";
        }));
    collection.AddPlatformMigrations(typeof(ServiceCollectionExtensions).Assembly);
    using IServiceScope scope = collection.BuildServiceProvider().CreateScope();
    ScenarioRunner? scenarioRunner = scope.ServiceProvider.GetService<ScenarioRunner>();

    if (scenarioRunner is not null) await scenarioRunner.Start();
}
catch (Exception e) when (e is AccountExistenceException or BalanceException or WrongPinException
                              or WrongSystemPasswordException)
{
    Console.WriteLine(e.Message);
}