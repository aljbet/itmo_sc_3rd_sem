namespace Itmo.ObjectOrientedProgramming.Lab4.Entities;

public interface IContext
{
    void Connect(string path, string fileSystemMode);
    void Disconnect();
    void TreeGoto(string path);
    void TreeList(int depth, string writerMode);
    void FileShow(string path, string writerMode);
    void FileMove(string sourcePath, string destinationPath);
    void FileCopy(string sourcePath, string destinationPath);
    void FileDelete(string path);
    void FileRename(string path, string name);
}