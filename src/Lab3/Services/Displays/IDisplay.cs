namespace Itmo.ObjectOrientedProgramming.Lab3.Services.Displays;

public interface IDisplay
{
    void ReceiveMessage(string text);

    void PrintText();
}