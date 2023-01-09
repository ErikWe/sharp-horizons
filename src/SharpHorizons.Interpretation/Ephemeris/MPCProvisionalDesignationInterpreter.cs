namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using SharpHorizons.MPC;
using SharpHorizons.Query.Result;

using System;
using System.Diagnostics.CodeAnalysis;

/// <summary>Interprets <see cref="QueryResult"/> as <see cref="MPCProvisionalDesignation"/>.</summary>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class MPCProvisionalDesignationInterpreter : IInterpreter<MPCProvisionalDesignation>
{
    Optional<MPCProvisionalDesignation> IInterpreter<MPCProvisionalDesignation>.Interpret(QueryResult queryResult)
    {
        QueryResult.Validate(queryResult);

        var startIndex = queryResult.Content.IndexOf('(', StringComparison.Ordinal) + 1;

        if (startIndex is 0)
        {
            return new();
        }

        var stopIndex = queryResult.Content.IndexOf(')', StringComparison.Ordinal) - 1;

        if (stopIndex is -2)
        {
            return new();
        }

        var designation = queryResult.Content[startIndex..stopIndex].Trim();

        if (designation.Contains(' ', StringComparison.Ordinal) is false || designation.Contains('/', StringComparison.Ordinal))
        {
            return new();
        }

        return new MPCProvisionalDesignation(designation);
    }
}
