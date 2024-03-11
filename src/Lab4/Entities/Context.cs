using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities;

public class Context : IContext
{
    private IFileSystem? _fileSystem;
    private string? _workingPath;
    private TreeVisitor _treeVisitor;

    public Context(Config config, TreeVisitor treeVisitor)
    {
        Config = config ?? throw new ArgumentNullException(nameof(config));
        _treeVisitor = treeVisitor ?? throw new ArgumentNullException(nameof(treeVisitor));
    }

    public Config Config { get; }

    public void Connect(string path, string fileSystemMode)
    {
        _workingPath = path ?? throw new ArgumentNullException(nameof(path));
        fileSystemMode = fileSystemMode ?? throw new ArgumentNullException(nameof(fileSystemMode));
        _fileSystem = Config.GetFileSystem(fileSystemMode);
        if (!_fileSystem.DirectoryExists(_workingPath))
            throw new PathNotFoundException($"Path \"{path}\" does not exist.");
    }

    public void Disconnect()
    {
        _fileSystem = null;
        _workingPath = null;
    }

    public void TreeGoto(string path)
    {
        _workingPath = GetPath(path);
        _fileSystem = _fileSystem ?? throw new PathNotFoundException("File system is not connected.");
        if (!_fileSystem.DirectoryExists(_workingPath))
            throw new PathNotFoundException($"Path \"{path}\" does not exist.");
    }

    public void TreeList(int depth, string writerMode)
    {
        if (depth < 0) throw new ArgumentOutOfRangeException(nameof(depth));
        writerMode = writerMode ?? throw new ArgumentNullException(nameof(writerMode));
        _fileSystem = _fileSystem ?? throw new PathNotFoundException("File system is not connected.");
        _workingPath = _workingPath ?? throw new PathNotFoundException("File system is not connected.");
        _treeVisitor.SetWriter(Config.GetWriter(writerMode))
            .SetMaxDepth(depth)
            .VisitDirectory(_fileSystem.GetTree(_workingPath));
        _treeVisitor.WriteResult();
        _treeVisitor.ClearResult();
    }

    public void FileShow(string path, string writerMode)
    {
        path = path ?? throw new ArgumentNullException(nameof(path));
        writerMode = writerMode ?? throw new ArgumentNullException(nameof(writerMode));
        _fileSystem = _fileSystem ?? throw new PathNotFoundException("File system is not connected.");
        Config.GetWriter(writerMode).Write(_fileSystem.FileShow(FileExistenceCheck(GetPath(path))));
    }

    public void FileMove(string sourcePath, string destinationPath)
    {
        sourcePath = sourcePath ?? throw new ArgumentNullException(nameof(sourcePath));
        destinationPath = destinationPath ?? throw new ArgumentNullException(nameof(destinationPath));
        _fileSystem = _fileSystem ?? throw new PathNotFoundException("File system is not connected.");
        _fileSystem.FileMove(FileExistenceCheck(GetPath(sourcePath)), GetPath(destinationPath));
    }

    public void FileCopy(string sourcePath, string destinationPath)
    {
        sourcePath = sourcePath ?? throw new ArgumentNullException(nameof(sourcePath));
        destinationPath = destinationPath ?? throw new ArgumentNullException(nameof(destinationPath));
        _fileSystem = _fileSystem ?? throw new PathNotFoundException("File system is not connected.");
        _fileSystem.FileCopy(FileExistenceCheck(GetPath(sourcePath)), GetPath(destinationPath));
    }

    public void FileDelete(string path)
    {
        path = path ?? throw new ArgumentNullException(nameof(path));
        _fileSystem = _fileSystem ?? throw new PathNotFoundException("File system is not connected.");
        _fileSystem.FileDelete(FileExistenceCheck(GetPath(path)));
    }

    public void FileRename(string path, string name)
    {
        path = path ?? throw new ArgumentNullException(nameof(path));
        name = name ?? throw new ArgumentNullException(nameof(name));
        _fileSystem = _fileSystem ?? throw new PathNotFoundException("File system is not connected.");
        path = FileExistenceCheck(GetPath(path));
        name = path[..path.LastIndexOf('\\')] + name;
        _fileSystem.FileRename(path, name);
    }

    private string GetPath(string path)
    {
        path = path ?? throw new ArgumentNullException(nameof(path));
        if (path[..2] == "..") return _workingPath + path[2..];
        return path;
    }

    private string FileExistenceCheck(string path)
    {
        _fileSystem = _fileSystem ?? throw new PathNotFoundException("File system is not connected.");
        if (_fileSystem.FileExists(path)) return path;
        throw new PathNotFoundException($"Path \"{path}\" does not exist.");
    }
}