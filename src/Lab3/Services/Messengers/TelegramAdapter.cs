using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services.Messengers;

public class TelegramAdapter : IMessenger
{
    private readonly ITelegramMessenger _adaptee;

    public TelegramAdapter(ITelegramMessenger telegram)
    {
        _adaptee = telegram ?? throw new ArgumentNullException(nameof(telegram));
    }

    public void ReceiveMessage(string text)
    {
        text = text ?? throw new ArgumentNullException(nameof(text));
        _adaptee.GetMessage(text);
    }

    public void PrintText()
    {
        _adaptee.PostMessage();
    }
}