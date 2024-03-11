#pragma warning disable CA2007
using Presentation.Services.Roles;
using Spectre.Console;

namespace Presentation.Services;

public class ScenarioRunner
{
    private readonly List<IRole> _roles = new();

    public ScenarioRunner(IUserService userService, IAdminService adminService)
    {
        _roles.Add(userService);
        _roles.Add(adminService);
    }

    public async Task Start()
    {
        IRole role = AnsiConsole.Prompt(
            new SelectionPrompt<IRole>()
                .PageSize(10)
                .Title("Who are you?")
                .AddChoices(_roles)
                .UseConverter(x => x.Name));

        await role.Authorize();
    }
}