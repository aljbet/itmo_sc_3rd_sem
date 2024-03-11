using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.TextHandlers.ParserChain;

public class DisconnectChainLink : ChainLinkBase
{
    public DisconnectChainLink()
        : base()
    {
    }

    public override ICommand Parse(IEnumerable<string> command)
    {
        command = command ?? throw new ArgumentNullException(nameof(command));
        var command2 = command.ToList();
        if (command2 is ["disconnect"]) return new DisconnectCommand();

        if (Next is null) throw new ArgumentException(nameof(Next));
        return Next.Parse(command2);
    }
}