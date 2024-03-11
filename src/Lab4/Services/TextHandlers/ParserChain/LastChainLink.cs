using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.TextHandlers.ParserChain;

public class LastChainLink : ChainLinkBase
{
    public LastChainLink()
        : base()
    {
    }

    public override ICommand Parse(IEnumerable<string> command)
    {
        throw new UnknownCommandException($"Command {string.Concat(command)} is unknown.");
    }
}