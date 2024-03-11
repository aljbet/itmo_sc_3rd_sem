using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Services.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Services.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Services.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Services.Messengers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services;

public class Facade
{
    private readonly List<Topic> _topics = new List<Topic>()
    {
        new Topic("user", new User()),
        new Topic("filter user", new AddresseeFilter(new User(), 50)),
        new Topic("console log addressee", new LogAddresseeDecorator(new User(), new ConsoleLogger())),
        new Topic("default messenger", new MessengerAdapter(new DefaultMessenger())),
        new Topic("default display", new DisplayAdapter(new DefaultDisplay())),
        new Topic("group addressee", new AddresseeGroup(new List<IAddressee>()
        {
            new User(),
            new AddresseeFilter(new MessengerAdapter(new DefaultMessenger()), 20),
            new DisplayAdapter(new DefaultDisplay()),
        })),
    };

    public void SendMessage(string topicName, Message message)
    {
        message = message ?? throw new ArgumentNullException(nameof(message));
        GetByName(topicName).SendMessage(message);
    }

    public Topic GetByName(string topicName)
    {
        return _topics.FirstOrDefault(x => x.Name.Equals(topicName, StringComparison.OrdinalIgnoreCase)) ??
                      throw new ArgumentException($"Topic \"{topicName}\" does not exist");
    }
}