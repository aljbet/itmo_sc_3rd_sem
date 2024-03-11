using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.TextHandlers.ParserChain;

public class FileShowChainLink : ChainLinkBase
{
    public FileShowChainLink()
        : base()
    {
    }

    public override ICommand Parse(IEnumerable<string> command)
    {
        command = command ?? throw new ArgumentNullException(nameof(command));
        var command2 = command.ToList();
        if (command2 is ["file", "show", _])
            return new FileShowCommand(command2[2], "console");

        if (command2 is ["file", "show", _, "-m", _])
            return new FileShowCommand(command2[2], command2[4]);

        if (Next is null) throw new ArgumentException(nameof(Next));
        return Next.Parse(command2);
    }
}