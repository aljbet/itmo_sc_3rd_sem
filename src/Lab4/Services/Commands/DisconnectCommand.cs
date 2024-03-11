using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Commands;

public class DisconnectCommand : ICommand
{
    public void Execute(IContext context)
    {
        context = context ?? throw new ArgumentNullException(nameof(context));
        context.Disconnect();
    }
}