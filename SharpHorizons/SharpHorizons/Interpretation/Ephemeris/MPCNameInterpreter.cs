namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using SharpHorizons.Identity;
using SharpHorizons.Query.Result;

/// <summary>Interprets some part of <see cref="IQueryResult"/> as <see cref="MPCName"/>.</summary>
internal sealed class MPCNameInterpreter : IPartInterpreter<MPCName>
{
    Optional<MPCName> IPartInterpreter<MPCName>.TryInterpret(string queryPart)
    {
        if (queryPart.Split('(') is not { Length: > 1 } parenthesisSplit)
        {
            return new();
        }

        var startIndex = parenthesisSplit[0].IndexOf(' ') + 1;

        if (startIndex is 0)
        {
            return new();
        }

        return new MPCName(parenthesisSplit[0][startIndex..]);
    }
}
