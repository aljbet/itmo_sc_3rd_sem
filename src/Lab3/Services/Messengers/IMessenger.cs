namespace Itmo.ObjectOrientedProgramming.Lab3.Services.Messengers;

public interface IMessenger
{
    void ReceiveMessage(string text);
    void PrintText();
}