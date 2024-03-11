namespace Itmo.ObjectOrientedProgramming.Lab3.Services.Messengers;

public interface ITelegramMessenger
{
    void GetMessage(string text);
    void PostMessage();
}