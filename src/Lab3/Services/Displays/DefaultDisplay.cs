using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services.Displays;

public class DefaultDisplay : IDisplay
{
    private DisplayDriver _driver;

    public DefaultDisplay()
    {
        Text = string.Empty;
        _driver = new DisplayDriver();
    }

    public DefaultDisplay(string text, DisplayDriver displayDriver)
    {
        Text = text ?? throw new ArgumentNullException(nameof(text));
        _driver = displayDriver ?? throw new ArgumentNullException(nameof(displayDriver));
    }

    public string Text { get; private set; }

    public void ReceiveMessage(string text)
    {
        Text = text ?? throw new ArgumentNullException(nameof(text));
    }

    public void PrintText()
    {
        _driver.ClearOutput();
        Console.WriteLine(_driver.WithColor(Text));
    }
}