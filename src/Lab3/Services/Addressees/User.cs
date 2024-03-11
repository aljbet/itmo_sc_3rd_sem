using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services.Addressees;

public class User : IAddressee
{
    private readonly List<MessageWithStatus> _receivedMessages = new();

    public void ReceiveMessage(Message message)
    {
        message = message ?? throw new ArgumentNullException(nameof(message));
        _receivedMessages.Add(new MessageWithStatus(message));
    }

    public void MarkAsRead(Message message)
    {
        message = message ?? throw new ArgumentNullException(nameof(message));
        MessageWithStatus? readMessage = _receivedMessages.FirstOrDefault(x => x.Message == message);
        readMessage = readMessage ?? throw new ArgumentException($"Message \"{message.Title}\" was not received by this user");
        if (readMessage.IsRead)
            throw new ArgumentException("Cannot read message that is already read");

        readMessage.IsRead = true;
    }

    public bool IsRead(Message message)
    {
        message = message ?? throw new ArgumentNullException(nameof(message));
        MessageWithStatus? readMessage = _receivedMessages.FirstOrDefault(x => x.Message == message);
        readMessage = readMessage ?? throw new ArgumentException($"Message \"{message.Title}\" was not received by this user");
        return readMessage.IsRead;
    }
}