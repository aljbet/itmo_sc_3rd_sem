using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Services;
using Itmo.ObjectOrientedProgramming.Lab3.Services.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Services.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Services.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Services.Messengers;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class MailTests
{
    private readonly User _defaultUser = new User();
    private readonly Message _defaultMessage = new Message("test message", "hello world", 99);

    [Fact]
    public void UserReceivesMessageTest()
    {
        User user = _defaultUser;
        var topic = new Topic("my topic", user);
        Message message = _defaultMessage;

        topic.SendMessage(message);

        Assert.False(user.IsRead(message));
    }

    [Fact]
    public void UserReadsMessageTest()
    {
        User user = _defaultUser;
        var topic = new Topic("my topic", user);
        Message message = _defaultMessage;

        topic.SendMessage(message);
        user.MarkAsRead(message);

        Assert.True(user.IsRead(message));
    }

    [Fact]
    public void UserReadsAlreadyReadMessageTest()
    {
        User user = _defaultUser;
        var topic = new Topic("my topic", user);
        Message message = _defaultMessage;

        topic.SendMessage(message);
        user.MarkAsRead(message);

        Assert.Throws<ArgumentException>(() => user.MarkAsRead(message));
    }

    [Fact]
    public void DidNotPassImportanceFilterTest()
    {
        IAddressee addressee = Substitute.For<IAddressee>();
        var message = new Message("test message", "hello world", 5);
        var addresseeFilter = new AddresseeFilter(addressee, 50);
        var topic = new Topic("my topic", addresseeFilter);

        topic.SendMessage(message);

        addressee.DidNotReceive().ReceiveMessage(message);
    }

    [Fact]
    public void PassedImportanceFilterTest()
    {
        IAddressee addressee = Substitute.For<IAddressee>();
        var message = new Message("test message", "hello world", 60);
        var addresseeFilter = new AddresseeFilter(addressee, 50);
        var topic = new Topic("my topic", addresseeFilter);

        topic.SendMessage(message);

        addressee.Received().ReceiveMessage(message);
    }

    [Fact]
    public void LoggingTest()
    {
        var displayAdapter = new DisplayAdapter(new DefaultDisplay());
        ILogger logger = Substitute.For<ILogger>();
        var logAddressee = new LogAddresseeDecorator(displayAdapter, logger);
        var topic = new Topic("my topic", logAddressee);
        Message message = _defaultMessage;

        topic.SendMessage(message);

        logger.Received().Log($"{DateTime.Now} received a message \"{message.Text}\"");
    }

    [Fact]
    public void MessengerTest()
    {
        IMessenger messenger = Substitute.For<IMessenger>();
        var messengerAdapter = new MessengerAdapter(messenger);
        Message message = _defaultMessage;
        var topic = new Topic("my topic", messengerAdapter);

        topic.SendMessage(message);

        messenger.Received().ReceiveMessage("test message\nhello world\n");
    }

    [Fact]
    public void AddresseeGroupTest()
    {
        IAddressee user = Substitute.For<IAddressee>();
        IAddressee messenger = Substitute.For<IAddressee>();
        IAddressee display = Substitute.For<IAddressee>();

        var addresseeGroup = new AddresseeGroup(new List<IAddressee>() { user, messenger, display });
        Message message = _defaultMessage;
        var topic = new Topic("my topic", addresseeGroup);

        topic.SendMessage(message);
        user.Received().ReceiveMessage(message);
        messenger.Received().ReceiveMessage(message);
        display.Received().ReceiveMessage(message);
    }

    [Fact]
    public void FacadeTest()
    {
        var facade = new Facade();
        facade.SendMessage("default messenger", _defaultMessage);
        IAddressee messengerAdapter = facade.GetByName("default messenger").Addressee;
        Assert.True(messengerAdapter is MessengerAdapter);
        if (messengerAdapter is MessengerAdapter ma)
        {
            IMessenger messenger = ma.Adaptee;
            if (messenger is DefaultMessenger dm) Assert.Equal("test message\nhello world\n", dm.Text);
        }
    }
}