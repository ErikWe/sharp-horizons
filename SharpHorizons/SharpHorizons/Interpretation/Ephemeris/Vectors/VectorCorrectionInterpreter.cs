namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using Microsoft.CodeAnalysis;

using SharpHorizons.Interpretation;
using SharpHorizons.Query.Vectors;

using System;

/// <inheritdoc cref="IVectorCorrectionInterpreter"/>
internal sealed class VectorCorrectionInterpreter : IVectorCorrectionInterpreter
{
    Optional<VectorCorrection> IPartInterpreter<VectorCorrection>.Interpret(string queryPart)
    {
        var firstColonIndex = queryPart.IndexOf(':');

        if (firstColonIndex is -1)
        {
            return new();
        }

        if (queryPart[(firstColonIndex + 1)..].Split(' ', StringSplitOptions.RemoveEmptyEntries) is not { Length: > 0 } spaceSplit)
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
