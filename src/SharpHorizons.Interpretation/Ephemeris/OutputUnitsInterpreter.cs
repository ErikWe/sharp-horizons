﻿namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using SharpHorizons.Interpretation.Ephemeris.Vectors;
using SharpHorizons.Query;
using SharpHorizons.Query.Result;

using System;
using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IVectorsOutputUnitsInterpreter"/>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class OutputUnitsInterpreter : IVectorsOutputUnitsInterpreter
{
    Optional<OutputUnits> IInterpreter<OutputUnits>.Interpret(QueryResult queryResult)
    {
        QueryResult.Validate(queryResult);

        var firstColonIndex = queryResult.Content.IndexOf(':', StringComparison.Ordinal);

        if (firstColonIndex is -1)
        {
            return new();
        }

        return queryResult.Content[(firstColonIndex + 1)..].Trim() switch
        {
            "KM-S" => OutputUnits.KilometresAndSeconds,
            "KM-D" => OutputUnits.KilometresAndDays,
            "AU-D" => OutputUnits.AstronomicalUnitsAndDays,
            _ => new()
        };
    }
}
