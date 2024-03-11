using System;
using System.Linq;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems.Units;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Visitors;

public class TreeVisitor : IVisitor
{
    private IWriter? _writer;
    private Config _config;
    private StringBuilder _result;
    private int _currentDepth;
    private int _maxDepth;

    public TreeVisitor(Config config)
    {
        _config = config ?? throw new ArgumentNullException(nameof(config));
        _result = new StringBuilder();
        _currentDepth = 0;
        _maxDepth = 1;
    }

    public TreeVisitor SetMaxDepth(int maxDepth)
    {
        _maxDepth = maxDepth;
        return this;
    }

    public TreeVisitor SetWriter(IWriter writer)
    {
        _writer = writer ?? throw new ArgumentNullException(nameof(writer));
        return this;
    }

    public void VisitDirectory(MyDirectory item)
    {
        item = item ?? throw new ArgumentNullException(nameof(item));
        if (_writer is null) throw new ArgumentException("Writer is not set.");
        _currentDepth++;
        if (_currentDepth > _maxDepth)
        {
            _currentDepth--;
            return;
        }

        _result.Append(string.Concat(Enumerable.Repeat(_config.IndentSymbol, _currentDepth - 1))
                       + _config.DirectorySymbol + item.Name + '\n');
        foreach (FileSystemUnitBase child in item.Children)
        {
            child.AcceptVisitor(this);
        }

        _currentDepth--;
    }

    public void VisitFile(MyFile item)
    {
        item = item ?? throw new ArgumentNullException(nameof(item));
        if (_writer is null) throw new ArgumentException("Writer is not set.");
        _currentDepth++;
        if (_currentDepth > _maxDepth)
        {
            _currentDepth--;
            return;
        }

        _result.Append(
            string.Concat(Enumerable.Repeat(_config.IndentSymbol, _currentDepth - 1)) + _config.FileSymbol + item.Name +
            '\n');
        _currentDepth--;
    }

    public void WriteResult()
    {
        if (_writer is null) throw new ArgumentException("Writer is not set.");
        _writer.Write(_result.ToString());
    }

    public void ClearResult()
    {
        _result.Clear();
    }
}