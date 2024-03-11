using System;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Services.TextHandlers.ParserChain;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.TextHandlers;

public class Parser
{
    private ChainLinkBase? _firstChainLink;

    public Parser()
    {
        _firstChainLink = null;
    }

    public Parser(ChainLinkBase firstChainLink)
    {
        _firstChainLink = firstChainLink ?? throw new ArgumentNullException(nameof(firstChainLink));
    }

    public ICommand Parse(string? command)
    {
        command = command ?? throw new ArgumentNullException(nameof(command));
        if (_firstChainLink is null) throw new ArgumentException("First chain link is not set.");
        return _firstChainLink.Parse(command.Split(' ')) ??
               throw new UnknownCommandException($"Command {command} is unknown.");
    }

    public Parser SetFirstChainLink(ChainLinkBase firstChainLink)
    {
        _firstChainLink = firstChainLink ?? throw new ArgumentNullException(nameof(firstChainLink));
        return this;
    }
}