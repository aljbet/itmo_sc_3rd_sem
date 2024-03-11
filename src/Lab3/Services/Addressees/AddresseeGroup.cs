using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services.Addressees;

public class AddresseeGroup : IAddressee
{
    private readonly IEnumerable<IAddressee> _addressees;

    public AddresseeGroup(IEnumerable<IAddressee> addressees)
    {
        _addressees = addressees ?? throw new ArgumentNullException(nameof(addressees));
    }

    public void ReceiveMessage(Message message)
    {
        message = message ?? throw new ArgumentNullException(nameof(message));
        foreach (IAddressee addressee in _addressees)
        {
            addressee.ReceiveMessage(message);
        }
    }
}