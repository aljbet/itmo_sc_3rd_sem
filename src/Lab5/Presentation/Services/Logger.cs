using System.Text;

namespace Presentation.Services;

public class Logger
{
    private readonly StringBuilder _history = new StringBuilder();

    public void Log(string message)
    {
        _history.Append(message + '\n');
    }

    public void ShowHistory()
    {
        Console.Write(_history);
    }

    public void ClearHistory()
    {
        _history.Clear();
    }
}