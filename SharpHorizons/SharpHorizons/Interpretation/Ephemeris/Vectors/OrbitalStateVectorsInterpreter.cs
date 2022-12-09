namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using Microsoft.CodeAnalysis;

using SharpHorizons.Ephemeris.Vectors;
using SharpHorizons.Query.Result;

using System;

/// <inheritdoc cref="IOrbitalStateVectorsInterpreter"/>
internal sealed class OrbitalStateVectorsInterpreter : IOrbitalStateVectorsInterpreter
{
    Optional<IOrbitalStateVectorsEphemeris> IInterpreter<IOrbitalStateVectorsEphemeris>.Interpret(IQueryResult queryResult)
    {
        ArgumentNullException.ThrowIfNull(queryResult);

        throw new Exception();
    }
}
