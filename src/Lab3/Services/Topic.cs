using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Services.Addressees;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services;

public class Topic
{
    public Topic(string name, IAddressee addressee)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Addressee = addressee ?? throw new ArgumentNullException(nameof(addressee));
    }

    public IAddressee Addressee { get; private set; }

    public string Name { get; private set; }

    public void SendMessage(Message message)
    {
        message = message ?? throw new ArgumentNullException(nameof(message));
        Addressee.ReceiveMessage(message);
    }
}