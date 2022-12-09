namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using SharpHorizons.MPC;
using SharpHorizons.Query.Result;

using System;

/// <summary>Interprets some part of <see cref="IQueryResult"/> as <see cref="MPCSequentialNumber"/>.</summary>
internal sealed class MPCSequentialNumberInterpreter : IPartInterpreter<MPCSequentialNumber>
{
    Optional<MPCSequentialNumber> IPartInterpreter<MPCSequentialNumber>.TryInterpret(string queryPart)
    {
        ArgumentNullException.ThrowIfNull(queryPart);

        var stopIndex = queryPart.IndexOf(' ') - 1;

        if (stopIndex is -2)
        {
            return new();
        }

        if (int.TryParse(queryPart[..stopIndex], out var id) is false)
        {
            return new();
        }

        return new MPCSequentialNumber(id);
    }
}
