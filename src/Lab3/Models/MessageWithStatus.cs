using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public class MessageWithStatus
{
    public MessageWithStatus(Message message, bool isRead = false)
    {
        Message = message ?? throw new ArgumentNullException(nameof(message));
        IsRead = isRead;
    }

    public Message Message { get; set; }
    public bool IsRead { get; set; }
}