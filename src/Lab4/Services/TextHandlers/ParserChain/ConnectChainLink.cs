using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.TextHandlers.ParserChain;

public class ConnectChainLink : ChainLinkBase
{
    public ConnectChainLink()
        : base()
    {
    }

    public override ICommand Parse(IEnumerable<string> command)
    {
        command = command ?? throw new ArgumentNullException(nameof(command));
        var command2 = command.ToList();
        if (command2 is ["connect", _]) return new ConnectCommand(command2[1], "local");
        if (command2 is ["connect", _, "-m", _]) return new ConnectCommand(command2[1], command2[3]);

        if (Next is null) throw new ArgumentException(nameof(Next));
        return Next.Parse(command2);
    }
}