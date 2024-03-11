using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Services.TextHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Services.TextHandlers.ParserChain;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public static class Program
{
    public static void Main()
    {
        var parser = new Parser(
            new ConnectChainLink()
                .AddNext(new DisconnectChainLink()
                    .AddNext(new TreeGotoChainLink()
                        .AddNext(new TreeListChainLink()
                            .AddNext(new FileShowChainLink()
                                .AddNext(new FileMoveChainLink()
                                    .AddNext(new FileCopyChainLink()
                                        .AddNext(new FileDeleteChainLink()
                                            .AddNext(new FileRenameChainLink()
                                                .AddNext(new LastChainLink()))))))))));
        var context = new Context(new Config(), new TreeVisitor(new Config()));
        while (true)
        {
            try
            {
                parser.Parse(Console.ReadLine()).Execute(context);
            }
            catch (Exception e) when (e is PathNotFoundException or UnknownCommandException
                                          or UnauthorizedAccessException or ArgumentException)
            {
                context.Config.DefaultWriter.Write(e.Message);
            }
            catch (ArgumentOutOfRangeException e)
            {
                context.Config.DefaultWriter.Write(e.Message + " must be >= 0");
            }
        }
    }
}