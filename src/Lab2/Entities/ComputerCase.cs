using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Attributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class ComputerCase : DetailBase
{
    public ComputerCase(
        string name,
        double videoCardHeight,
        double videoCardWidth,
        IReadOnlyCollection<MotherBoardFormFactor> supportedMotherBoardFormFactors,
        double height,
        double width,
        double depth)
    : base(name)
    {
        VideoCardHeight = videoCardHeight;
        VideoCardWidth = videoCardWidth;
        SupportedMotherBoardFormFactors = supportedMotherBoardFormFactors;
        Height = height;
        Width = width;
        Depth = depth;
    }

    public double VideoCardHeight { get; }
    public double VideoCardWidth { get; }
    public IReadOnlyCollection<MotherBoardFormFactor> SupportedMotherBoardFormFactors { get; }
    public double Height { get; }
    public double Width { get; }
    public double Depth { get; }
}