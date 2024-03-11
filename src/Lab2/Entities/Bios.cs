using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Attributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Bios : DetailBase
{
    public Bios(
        string name,
        BiosType biosType,
        double biosVersion,
        IReadOnlyCollection<string> supportedCpus)
        : base(name)
    {
        BiosType = biosType;
        BiosVersion = biosVersion;
        SupportedCpus = supportedCpus;
    }

    public BiosType BiosType { get; }
    public double BiosVersion { get; }
    public IReadOnlyCollection<string> SupportedCpus { get; }
}