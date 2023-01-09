namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using SharpHorizons.Interpretation;
using SharpHorizons.Query.Result;

using System;
using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="ISmallPerturbersInterpreter"/>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class SmallPerturbersInterpreter : ISmallPerturbersInterpreter
{
    Optional<bool> IInterpreter<bool>.Interpret(QueryResult queryResult)
    {
        QueryResult.Validate(queryResult);

        var firstColonIndex = queryResult.Content.IndexOf(':', StringComparison.Ordinal);

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
