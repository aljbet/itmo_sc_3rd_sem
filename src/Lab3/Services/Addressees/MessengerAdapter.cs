using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Services.Messengers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services.Addressees;

public class MessengerAdapter : IAddressee
{
    public MessengerAdapter(IMessenger device)
    {
        Adaptee = device ?? throw new ArgumentNullException(nameof(device));
    }

    public IMessenger Adaptee { get; private set; }

    public void ReceiveMessage(Message message)
    {
        message = message ?? throw new ArgumentNullException(nameof(message));
        Adaptee.ReceiveMessage(message.Title + '\n' + message.Text + '\n');
    }
}