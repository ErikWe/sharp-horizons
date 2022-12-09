namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using SharpHorizons.MPC;
using SharpHorizons.Query.Result;

using System;

/// <summary>Interprets some part of <see cref="IQueryResult"/> as <see cref="MPCCometName"/>.</summary>
internal sealed class MPCCometNameInterpreter : IPartInterpreter<MPCCometName>
{
    Optional<MPCCometName> IPartInterpreter<MPCCometName>.TryInterpret(string queryPart)
    {
        ArgumentNullException.ThrowIfNull(queryPart);

        if (TryInterpretNumberedCometName(queryPart) is MPCCometName numberedCometName)
        {
            return numberedCometName;
        }

        if (TryInterpretUnnumberedCometName(queryPart) is MPCCometName unnumberedCometName)
        {
            return unnumberedCometName;
        }

        return new();
    }

    /// <summary>Attempts to interpret the <see cref="MPCCometName"/> of a numbered <see cref="MPCComet"/> from <paramref name="queryPart"/>.</summary>
    /// <param name="queryPart">A <see cref="MPCCometName"/> is interpreted from this <see cref="string"/>, if possible.</param>
    private static MPCCometName? TryInterpretNumberedCometName(string queryPart)
    {
        var startIndex = queryPart.IndexOf('/') + 1;

        if (startIndex is 0)
        {
            return null;
        }

        var stopIndex = queryPart.IndexOf('(');

        if (stopIndex is -1)
        {
            stopIndex = queryPart.Length;
        }

        return new(queryPart[startIndex..stopIndex].Trim());
    }

    /// <summary>Attempts to interpret the <see cref="MPCCometName"/> of an unnumbered <see cref="MPCComet"/> from <paramref name="queryPart"/>.</summary>
    /// <param name="queryPart">A <see cref="MPCCometName"/> is interpreted from this <see cref="string"/>, if possible.</param>
    private static MPCCometName? TryInterpretUnnumberedCometName(string queryPart)
    {
        var stopIndex = queryPart.IndexOf('(');

        if (stopIndex is -1)
        {
            return null;
        }

        return new(queryPart[..stopIndex].Trim());
    }
}
