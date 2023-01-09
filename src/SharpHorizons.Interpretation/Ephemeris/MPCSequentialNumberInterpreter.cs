namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using SharpHorizons.MPC;
using SharpHorizons.Query.Result;

using System;
using System.Diagnostics.CodeAnalysis;

/// <summary>Interprets <see cref="QueryResult"/> as <see cref="MPCSequentialNumber"/>.</summary>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class MPCSequentialNumberInterpreter : IInterpreter<MPCSequentialNumber>
{
    Optional<MPCSequentialNumber> IInterpreter<MPCSequentialNumber>.Interpret(QueryResult queryResult)
    {
        QueryResult.Validate(queryResult);

        var stopIndex = queryResult.Content.IndexOf(' ', StringComparison.Ordinal) - 1;

        if (stopIndex is -2)
        {
            return new();
        }

        if (int.TryParse(queryResult.Content[..stopIndex], out var id) is false)
        {
            return new();
        }

        return new MPCSequentialNumber(id);
    }
}
