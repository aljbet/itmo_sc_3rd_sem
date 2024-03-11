namespace Presentation.Services.Roles;

public interface IRole
{
    public string Name { get; }
    public Task Authorize();
    public Task<bool> ChooseAction();
}