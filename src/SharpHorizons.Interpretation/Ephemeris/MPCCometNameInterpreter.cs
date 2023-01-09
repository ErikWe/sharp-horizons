namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using SharpHorizons.MPC;
using SharpHorizons.Query.Result;

using System;
using System.Diagnostics.CodeAnalysis;

/// <summary>Interprets <see cref="QueryResult"/> as <see cref="MPCCometName"/>.</summary>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class MPCCometNameInterpreter : IInterpreter<MPCCometName>
{
    Optional<MPCCometName> IInterpreter<MPCCometName>.Interpret(QueryResult queryResult)
    {
        QueryResult.Validate(queryResult);

        if (TryInterpretNumberedCometName(queryResult) is MPCCometName numberedCometName)
        {
            return numberedCometName;
        }

        if (TryInterpretUnnumberedCometName(queryResult) is MPCCometName unnumberedCometName)
        {
            return unnumberedCometName;
        }

        return new();
    }

    /// <summary>Attempts to interpret the <see cref="MPCCometName"/> of a numbered <see cref="MPCComet"/> from <paramref name="queryResult"/>.</summary>
    /// <param name="queryResult">A <see cref="MPCCometName"/> is interpreted from this <see cref="QueryResult"/>, if possible.</param>
    private static MPCCometName? TryInterpretNumberedCometName(QueryResult queryResult)
    {
        var startIndex = queryResult.Content.IndexOf('/', StringComparison.Ordinal) + 1;

        if (startIndex is 0)
        {
            return null;
        }

        var stopIndex = queryResult.Content.IndexOf('(', StringComparison.Ordinal);

        if (stopIndex is -1)
        {
            stopIndex = queryResult.Content.Length;
        }

        return new(queryResult.Content[startIndex..stopIndex].Trim());
    }

    /// <summary>Attempts to interpret the <see cref="MPCCometName"/> of an unnumbered <see cref="MPCComet"/> from <paramref name="queryResult"/>.</summary>
    /// <param name="queryResult">A <see cref="MPCCometName"/> is interpreted from this <see cref="QueryResult"/>, if possible.</param>
    private static MPCCometName? TryInterpretUnnumberedCometName(QueryResult queryResult)
    {
        var stopIndex = queryResult.Content.IndexOf('(', StringComparison.Ordinal);

        if (stopIndex is -1)
        {
            return null;
        }

        return new(queryResult.Content[..stopIndex].Trim());
    }
}
