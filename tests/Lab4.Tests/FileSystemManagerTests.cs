using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Services.TextHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Services.TextHandlers.ParserChain;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class FileSystemManagerTests
{
    private readonly Parser _parser = new Parser();

    [Theory]
    [InlineData("connect test_path")]
    [InlineData("connect test_path -m local")]
    public void ConnectTest(string command)
    {
        IContext context = Substitute.For<IContext>();
        _parser.SetFirstChainLink(new ConnectChainLink()).Parse(command).Execute(context);
        context.Received().Connect("test_path", "local");
    }

    [Theory]
    [InlineData("disconnect")]
    public void DisconnectTest(string command)
    {
        IContext context = Substitute.For<IContext>();
        _parser.SetFirstChainLink(new DisconnectChainLink()).Parse(command).Execute(context);
        context.Received().Disconnect();
    }

    [Theory]
    [InlineData("tree goto test_path")]
    public void TreeGotoTest(string command)
    {
        IContext context = Substitute.For<IContext>();
        _parser.SetFirstChainLink(new TreeGotoChainLink()).Parse(command).Execute(context);
        context.Received().TreeGoto("test_path");
    }

    [Theory]
    [InlineData("tree list")]
    [InlineData("tree list -d 1")]
    [InlineData("tree list -d 1 -m console")]
    [InlineData("tree list -m console")]
    public void TreeListDefaultDepthTest(string command)
    {
        IContext context = Substitute.For<IContext>();
        _parser.SetFirstChainLink(new TreeListChainLink()).Parse(command).Execute(context);
        context.Received().TreeList(1, "console");
    }

    [Theory]
    [InlineData("tree list -d 5")]
    [InlineData("tree list -d 5 -m console")]
    [InlineData("tree list -m console -d 5")]
    public void TreeListCustomDepthTest(string command)
    {
        IContext context = Substitute.For<IContext>();
        _parser.SetFirstChainLink(new TreeListChainLink()).Parse(command).Execute(context);
        context.Received().TreeList(5, "console");
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(-5)]
    public void TreeListInvalidDepthTest(int depth)
    {
        IContext context = Substitute.For<IContext>();
        _parser.SetFirstChainLink(new TreeListChainLink()).Parse("tree list -d " + depth).Execute(context);
        context
            .When(x => x.TreeList(depth, "console"))
            .Do(x => throw new ArgumentOutOfRangeException(nameof(depth)));
    }

    [Theory]
    [InlineData("file show test_path -m console")]
    [InlineData("file show test_path")]
    public void FileShowTest(string command)
    {
        IContext context = Substitute.For<IContext>();
        _parser.SetFirstChainLink(new FileShowChainLink()).Parse(command).Execute(context);
        context.Received().FileShow("test_path", "console");
    }

    [Theory]
    [InlineData("file move test_path new_path")]
    public void FileMoveTest(string command)
    {
        IContext context = Substitute.For<IContext>();
        _parser.SetFirstChainLink(new FileMoveChainLink()).Parse(command).Execute(context);
        context.Received().FileMove("test_path", "new_path");
    }

    [Theory]
    [InlineData("file copy test_path new_path")]
    public void FileCopyTest(string command)
    {
        IContext context = Substitute.For<IContext>();
        _parser.SetFirstChainLink(new FileCopyChainLink()).Parse(command).Execute(context);
        context.Received().FileCopy("test_path", "new_path");
    }

    [Theory]
    [InlineData("file delete test_path")]
    public void FileDeleteTest(string command)
    {
        IContext context = Substitute.For<IContext>();
        _parser.SetFirstChainLink(new FileDeleteChainLink()).Parse(command).Execute(context);
        context.Received().FileDelete("test_path");
    }

    [Theory]
    [InlineData("file rename test_path new_name")]
    public void FileRenameTest(string command)
    {
        IContext context = Substitute.For<IContext>();
        _parser.SetFirstChainLink(new FileRenameChainLink()).Parse(command).Execute(context);
        context.Received().FileRename("test_path", "new_name");
    }

    [Theory]
    [InlineData("conct")]
    [InlineData("file delete")]
    [InlineData("file show -m console")]
    public void InvalidCommandTest(string command)
    {
        Assert.Throws<UnknownCommandException>(() => _parser.SetFirstChainLink(new ConnectChainLink()
            .AddNext(new DisconnectChainLink()
                .AddNext(new TreeGotoChainLink()
                    .AddNext(new TreeListChainLink()
                        .AddNext(new FileShowChainLink()
                            .AddNext(new FileMoveChainLink()
                                .AddNext(new FileCopyChainLink()
                                    .AddNext(new FileDeleteChainLink()
                                        .AddNext(new FileRenameChainLink()
                                            .AddNext(new LastChainLink())))))))))).Parse(command));
    }
}