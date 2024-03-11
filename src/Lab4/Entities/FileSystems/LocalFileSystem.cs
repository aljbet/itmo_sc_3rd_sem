using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems.Units;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

public class LocalFileSystem : IFileSystem
{
    public bool DirectoryExists(string path)
    {
        return Directory.Exists(path);
    }

    public bool FileExists(string path)
    {
        return File.Exists(path);
    }

    public MyDirectory GetTree(string path)
    {
        return GetTree(new DirectoryInfo(path));
    }

    public string FileShow(string path)
    {
        return File.ReadAllText(path);
    }

    public void FileMove(string sourcePath, string destinationPath)
    {
        File.Move(sourcePath, destinationPath);
    }

    public void FileCopy(string sourcePath, string destinationPath)
    {
        File.Copy(sourcePath, destinationPath);
    }

    public void FileDelete(string path)
    {
        File.Delete(path);
    }

    public void FileRename(string path, string newName)
    {
        File.Move(path, newName);
    }

    private MyDirectory GetTree(DirectoryInfo directory)
    {
        directory = directory ?? throw new ArgumentNullException(nameof(directory));
        var root = new MyDirectory(directory.Name);
        foreach (DirectoryInfo directoryInfo in directory.GetDirectories())
        {
            root.AddChild(GetTree(directoryInfo));
        }

        foreach (FileInfo file in directory.GetFiles())
        {
            root.AddChild(new MyFile(file.Name));
        }

        return root;
    }
}