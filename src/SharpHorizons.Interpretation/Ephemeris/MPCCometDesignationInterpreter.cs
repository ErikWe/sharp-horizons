namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using SharpHorizons.MPC;
using SharpHorizons.Query.Result;

using System;
using System.Diagnostics.CodeAnalysis;

/// <summary>Interprets <see cref="QueryResult"/> as <see cref="MPCCometDesignation"/>.</summary>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class MPCCometDesignationInterpreter : IInterpreter<MPCCometDesignation>
{
    Optional<MPCCometDesignation> IInterpreter<MPCCometDesignation>.Interpret(QueryResult queryResult)
    {
        QueryResult.Validate(queryResult);

        if (TryInterpretNumberedDesignation(queryResult) is MPCCometDesignation numberedDesignation)
        {
            return numberedDesignation;
        }

        if (TryInterpretUnnumberedDesignation(queryResult) is MPCCometDesignation unnumberedDesignation)
        {
            return unnumberedDesignation;
        }

        return new();
    }

    /// <summary>Attempts to interpret a numbered <see cref="MPCCometDesignation"/> from <paramref name="queryResult"/>.</summary>
    /// <param name="queryResult">A <see cref="MPCCometDesignation"/> is interpreted from this <see cref="QueryResult"/>, if possible.</param>
    private static MPCCometDesignation? TryInterpretNumberedDesignation(QueryResult queryResult)
    {
        var stopIndex = queryResult.Content.IndexOf('/', StringComparison.Ordinal);

        if (stopIndex is -1)
        {
            return null;
        }

        var designation = queryResult.Content[..stopIndex];

        if (char.IsLetter(designation[^1]) is false || int.TryParse(designation[..^1], out var _) is false)
        {
            return null;
        }

        return new(designation);
    }

    /// <summary>Attempts to interpret an unnumbered <see cref="MPCCometDesignation"/> from <paramref name="queryResult"/>.</summary>
    /// <param name="queryResult">A <see cref="MPCCometDesignation"/> is interpreted from this <see cref="QueryResult"/>, if possible.</param>
    private static MPCCometDesignation? TryInterpretUnnumberedDesignation(QueryResult queryResult)
    {
        var startIndex = queryResult.Content.IndexOf('(', StringComparison.Ordinal) + 1;

        if (startIndex is 0)
        {
            return null;
        }

        var stopIndex = queryResult.Content.IndexOf(')', StringComparison.Ordinal) - 1;

        if (stopIndex is -2)
        {
            return null;
        }

        var designation = queryResult.Content[startIndex..stopIndex];

        if (designation[1] is '/' is false || char.IsLetter(designation[0]) is false || designation.Contains(' ', StringComparison.Ordinal) is false)
        {
            return null;
        }

        return new(designation);
    }
}
