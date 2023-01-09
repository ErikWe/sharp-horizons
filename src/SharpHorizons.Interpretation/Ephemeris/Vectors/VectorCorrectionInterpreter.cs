namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using Microsoft.CodeAnalysis;

using SharpHorizons.Interpretation;
using SharpHorizons.Query.Result;
using SharpHorizons.Query.Vectors;

using System;
using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IVectorCorrectionInterpreter"/>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class VectorCorrectionInterpreter : IVectorCorrectionInterpreter
{
    Optional<VectorCorrection> IInterpreter<VectorCorrection>.Interpret(QueryResult queryResult)
    {
        QueryResult.Validate(queryResult);

        var firstColonIndex = queryResult.Content.IndexOf(':', StringComparison.Ordinal);

        if (firstColonIndex is -1)
        {
            return new();
        }

        if (queryResult.Content[(firstColonIndex + 1)..].Split(' ', StringSplitOptions.RemoveEmptyEntries) is not { Length: > 0 } spaceSplit)
        {
            return new();
        }

        return spaceSplit[0] switch
        {
            "GEOMETRIC" => VectorCorrection.None,
            "LT" => VectorCorrection.LightTime,
            "LT+S" => VectorCorrection.LightTime | VectorCorrection.Aberration,
            _ => new()
        };
    }
}
