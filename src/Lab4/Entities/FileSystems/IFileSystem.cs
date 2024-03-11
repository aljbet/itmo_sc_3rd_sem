using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems.Units;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

public interface IFileSystem
{
    bool DirectoryExists(string path);

    bool FileExists(string path);

    MyDirectory GetTree(string path);

    string FileShow(string path);

    void FileMove(string sourcePath, string destinationPath);

    void FileCopy(string sourcePath, string destinationPath);

    void FileDelete(string path);

    void FileRename(string path, string newName);
}