using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.TextHandlers.ParserChain;

public abstract class ChainLinkBase
{
    protected ChainLinkBase? Next { get; private set; }

    public abstract ICommand Parse(IEnumerable<string> command);

    public ChainLinkBase AddNext(ChainLinkBase next)
    {
        Next = next;
        return this;
    }
}