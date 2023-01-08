namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using SharpHorizons.Interpretation;
using SharpHorizons.Query.Result;

/// <inheritdoc cref="ISmallPerturbersInterpreter"/>
internal sealed class SmallPerturbersInterpreter : ISmallPerturbersInterpreter
{
    Optional<bool> IInterpreter<bool>.Interpret(QueryResult queryResult)
    {
        QueryResult.Validate(queryResult);

        var firstColonIndex = queryResult.Content.IndexOf(':');

        if (firstColonIndex is -1)
        {
            return new();
        }

        return queryResult.Content[(firstColonIndex + 1)..].Trim().ToUpperInvariant() switch
        {
            "YES" => true,
            "NO" => false,
            _ => new()
        };
    }
}
