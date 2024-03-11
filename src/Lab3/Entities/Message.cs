using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class Message
{
    public Message(string title, string text, int importanceLevel)
    {
        Title = title ?? throw new ArgumentNullException(nameof(title));
        Text = text ?? throw new ArgumentNullException(nameof(text));
        ImportanceLevel = importanceLevel;
    }

    public string Title { get; private set; }
    public string Text { get; private set; }
    public int ImportanceLevel { get; private set; }
}