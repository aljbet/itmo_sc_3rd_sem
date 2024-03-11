using System;
using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services.Displays;

public class DisplayDriver
{
    private Color _color;

    public void ClearOutput()
    {
        Console.Clear();
    }

    public void SetColor(Color color)
    {
        _color = color;
    }

    public string WithColor(string message)
    {
        return Crayon.Output.Rgb(_color.R, _color.G, _color.B).Text(message);
    }
}