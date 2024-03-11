using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Factories;

public class Factory<T>
    where T : DetailBase
{
    private readonly IEnumerable<T> _details;

    public Factory(IEnumerable<T> details)
    {
        details = details ?? throw new ArgumentNullException(nameof(details));
        if (details.Any(x => x == null))
        {
            throw new ArgumentNullException(nameof(details));
        }

        _details = details;
    }

    public T? GetByName(string? name)
    {
        return _details.FirstOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }
}