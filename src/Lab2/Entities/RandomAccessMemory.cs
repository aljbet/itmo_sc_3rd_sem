using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Attributes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class RandomAccessMemory : DetailBase
{
    public RandomAccessMemory(
        string name,
        int memoryAmount,
        IReadOnlyCollection<Tuple<double, double>> jedecFrequenciesAndVoltages,
        IReadOnlyCollection<XmpProfile> supportedXmpProfiles,
        RamFormFactor ramFormFactor,
        StandardDdr standardDdr,
        int powerConsumption)
        : base(name)
    {
        MemoryAmount = memoryAmount;
        JedecFrequenciesAndVoltages = jedecFrequenciesAndVoltages;
        SupportedXmpProfiles = supportedXmpProfiles;
        RamFormFactor = ramFormFactor;
        StandardDdr = standardDdr;
        PowerConsumption = powerConsumption;
    }

    public int MemoryAmount { get; }
    public IReadOnlyCollection<Tuple<double, double>> JedecFrequenciesAndVoltages { get; }
    public IReadOnlyCollection<XmpProfile> SupportedXmpProfiles { get; }
    public RamFormFactor RamFormFactor { get; }
    public StandardDdr StandardDdr { get; }
    public int PowerConsumption { get; }
}