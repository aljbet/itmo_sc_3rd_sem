using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Services.Displays;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services.Addressees;

public class DisplayAdapter : IAddressee
{
    public DisplayAdapter(IDisplay device)
    {
        Adaptee = device ?? throw new ArgumentNullException(nameof(device));
    }

    public IDisplay Adaptee { get; private set; }

    public void ReceiveMessage(Message message)
    {
        message = message ?? throw new ArgumentNullException(nameof(message));
        Adaptee.ReceiveMessage(message.Title + '\n' + message.Text + '\n');
    }
}