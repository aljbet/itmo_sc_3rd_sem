using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.TextHandlers.ParserChain;

public class FileDeleteChainLink : ChainLinkBase
{
    public FileDeleteChainLink()
        : base()
    {
    }

    public override ICommand Parse(IEnumerable<string> command)
    {
        command = command ?? throw new ArgumentNullException(nameof(command));
        var command2 = command.ToList();
        if (command2 is ["file", "delete", _]) return new FileDeleteCommand(command2[2]);

        if (Next is null) throw new ArgumentException(nameof(Next));
        return Next.Parse(command2);
    }
}