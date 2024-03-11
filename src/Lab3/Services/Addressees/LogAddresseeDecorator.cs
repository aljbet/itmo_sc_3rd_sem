using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Services.Loggers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services.Addressees;

public class LogAddresseeDecorator : IAddressee
{
    private readonly IAddressee _wrappee;
    private readonly ILogger _logger;

    public LogAddresseeDecorator(IAddressee wrappee, ILogger logger)
    {
        _wrappee = wrappee ?? throw new ArgumentNullException(nameof(wrappee));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public void ReceiveMessage(Message message)
    {
        message = message ?? throw new ArgumentNullException(nameof(message));
        _logger.Log($"{DateTime.Now} received a message \"{message.Text}\"");
        _wrappee.ReceiveMessage(message);
    }
}