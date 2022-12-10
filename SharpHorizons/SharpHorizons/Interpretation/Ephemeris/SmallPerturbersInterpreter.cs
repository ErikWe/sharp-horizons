namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using SharpHorizons.Interpretation;

/// <inheritdoc cref="ISmallPerturbersInterpreter"/>
internal sealed class SmallPerturbersInterpreter : ISmallPerturbersInterpreter
{
    Optional<bool> IPartInterpreter<bool>.Interpret(string queryPart)
    {
        var firstColonIndex = queryPart.IndexOf(':');

        if (firstColonIndex is -1)
        {
            return new();
        }

        return queryPart[(firstColonIndex + 1)..].Trim().ToUpperInvariant() switch
        {
            "YES" => true,
            "NO" => false,
            _ => new()
        };
    }
}
