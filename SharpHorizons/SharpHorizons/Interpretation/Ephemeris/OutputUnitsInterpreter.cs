namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;
using SharpHorizons.Interpretation.Ephemeris.Vectors;
using SharpHorizons.Query;

/// <inheritdoc cref="IVectorsOutputUnitsInterpreter"/>
internal sealed class OutputUnitsInterpreter : IVectorsOutputUnitsInterpreter
{
    Optional<OutputUnits> IPartInterpreter<OutputUnits>.Interpret(string queryPart)
    {
        var firstColonIndex = queryPart.IndexOf(':');

        if (firstColonIndex is -1)
        {
            return new();
        }

        return queryPart[(firstColonIndex + 1)..].Trim() switch
        {
            "KM-S" => OutputUnits.KilometresAndSeconds,
            "KM-D" => OutputUnits.KilometresAndDays,
            "AU-D" => OutputUnits.AstronomicalUnitsAndDays,
            _ => new()
        };
    }
}
