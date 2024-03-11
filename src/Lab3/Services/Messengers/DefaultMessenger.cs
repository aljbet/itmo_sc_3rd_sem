using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services.Messengers;

public class DefaultMessenger : IMessenger
{
    public DefaultMessenger()
    {
        Text = string.Empty;
    }

    public DefaultMessenger(string text)
    {
        Text = text ?? throw new ArgumentNullException(nameof(text));
    }

    public string Text { get; private set; }

    public void ReceiveMessage(string text)
    {
        Text = text ?? throw new ArgumentNullException(nameof(text));
    }

    public void PrintText()
    {
        Console.WriteLine(Text + "messenger");
    }
}