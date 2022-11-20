namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using SharpHorizons.Identity;
using SharpHorizons.Query.Result;

/// <summary>Interprets some part of <see cref="IQueryResult"/> as <see cref="MPCCometDesignation"/>.</summary>
internal sealed class MPCCometDesignationInterpreter : IPartInterpreter<MPCCometDesignation>
{
    Optional<MPCCometDesignation> IPartInterpreter<MPCCometDesignation>.TryInterpret(string queryPart)
    {
        if (TryInterpretNumberedDesignation(queryPart) is MPCCometDesignation numberedDesignation)
        {
            return numberedDesignation;
        }

        if (TryInterpretUnnumberedDesignation(queryPart) is MPCCometDesignation unnumberedDesignation)
        {
            return unnumberedDesignation;
        }

        return new();
    }

    /// <summary>Attempts to interpret a numbered <see cref="MPCCometDesignation"/> from <paramref name="queryPart"/>.</summary>
    /// <param name="queryPart">A <see cref="MPCCometDesignation"/> is interpreted from this <see cref="string"/>, if possible.</param>
    private static MPCCometDesignation? TryInterpretNumberedDesignation(string queryPart)
    {
        var stopIndex = queryPart.IndexOf('/');

        if (stopIndex is -1)
        {
            return null;
        }

        var designation = queryPart[..stopIndex];

        if (char.IsLetter(designation[^1]) is false || int.TryParse(designation[..^1], out var _) is false)
        {
            return null;
        }

        return designation;
    }

    /// <summary>Attempts to interpret an unnumbered <see cref="MPCCometDesignation"/> from <paramref name="queryPart"/>.</summary>
    /// <param name="queryPart">A <see cref="MPCCometDesignation"/> is interpreted from this <see cref="string"/>, if possible.</param>
    private static MPCCometDesignation? TryInterpretUnnumberedDesignation(string queryPart)
    {
        var startIndex = queryPart.IndexOf('(') + 1;

        if (startIndex is 0)
        {
            return null;
        }

        var stopIndex = queryPart.IndexOf(')') - 1;

        if (stopIndex is -2)
        {
            return null;
        }

        var designation = queryPart[startIndex..stopIndex];

        if (designation[1] is '/' is false || char.IsLetter(designation[0]) is false || designation.Contains(' ') is false)
        {
            return null;
        }

        return designation;
    }
}
