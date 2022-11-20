namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using Microsoft.CodeAnalysis;

using SharpHorizons.Ephemeris;
using SharpHorizons.Ephemeris.Vectors;
using SharpHorizons.Interpretation.Ephemeris;
using SharpHorizons.Query.Result;

/// <summary>Interprets <see cref="IQueryResult"/> as an <see cref="IEphemeris{TEntry}"/> of <see cref="IOrbitalStateVectors"/>.</summary>
internal sealed class OrbitalStateVectorsInterpreter : IEphemerisInterpreter<IOrbitalStateVectorsEphemeris, IOrbitalStateVectors>
{
    Optional<IOrbitalStateVectorsEphemeris> IInterpreter<IOrbitalStateVectorsEphemeris>.TryInterpret(IQueryResult queryResult)
    {
        throw new System.Exception();
    }
}
