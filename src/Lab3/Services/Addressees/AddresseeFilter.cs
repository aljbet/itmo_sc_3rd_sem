using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services.Addressees;

public class AddresseeFilter : IAddressee
{
    private readonly int _minimalImportance;
    private readonly IAddressee _addressee;

    public AddresseeFilter(IAddressee addressee, int minimalImportance)
    {
        _addressee = addressee ?? throw new ArgumentNullException(nameof(addressee));
        _minimalImportance = minimalImportance;
    }

    public void ReceiveMessage(Message message)
    {
        message = message ?? throw new ArgumentNullException(nameof(message));
        if (message.ImportanceLevel > _minimalImportance) _addressee.ReceiveMessage(message);
    }
}