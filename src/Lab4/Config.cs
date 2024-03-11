using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class Config
{
    private Dictionary<string, IFileSystem> _nameToFileSystem
        = new Dictionary<string, IFileSystem>()
        {
            { "local", new LocalFileSystem() },
        };

    private Dictionary<string, IWriter> _nameToWriter
        = new Dictionary<string, IWriter>()
        {
            { "console", new ConsoleWriter() },
        };

    public IWriter DefaultWriter { get; } = new ConsoleWriter();
    public string FileSymbol { get; } = "file: ";
    public string DirectorySymbol { get; } = "directory: ";
    public string IndentSymbol { get; } = "\t";

    public IFileSystem GetFileSystem(string name)
    {
        if (_nameToFileSystem.TryGetValue(name, out IFileSystem? system))
            return system;
        throw new UnknownCommandException($"Unknown file system mode: {name}");
    }

    public IWriter GetWriter(string name)
    {
        if (_nameToWriter.TryGetValue(name, out IWriter? writer))
            return writer;
        throw new UnknownCommandException($"Unknown writer mode: {name}");
    }
}