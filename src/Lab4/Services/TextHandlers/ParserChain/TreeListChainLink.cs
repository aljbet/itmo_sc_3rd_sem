using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.TextHandlers.ParserChain;

public class TreeListChainLink : ChainLinkBase
{
    public TreeListChainLink()
        : base()
    {
    }

    public override ICommand Parse(IEnumerable<string> command)
    {
        command = command ?? throw new ArgumentNullException(nameof(command));
        var command2 = command.ToList();
        if (command2 is ["tree", "list"]) return new TreeListCommand(1, "console");

        if (command2 is ["tree", "list", "-d", _])
            return new TreeListCommand(int.Parse(command2[3], provider: new NumberFormatInfo()), "console");

        if (command2 is ["tree", "list", "-d", _, "-m", _])
            return new TreeListCommand(int.Parse(command2[3], provider: new NumberFormatInfo()), command2[5]);

        if (command2 is ["tree", "list", "-m", _])
            return new TreeListCommand(1, command2[3]);

        if (command2 is ["tree", "list", "-m", _, "-d", _])
            return new TreeListCommand(int.Parse(command2[5], provider: new NumberFormatInfo()), command2[3]);

        if (Next is null) throw new ArgumentException(nameof(Next));
        return Next.Parse(command2);
    }
}