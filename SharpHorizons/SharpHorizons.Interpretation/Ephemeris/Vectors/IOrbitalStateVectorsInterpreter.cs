namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Ephemeris.Vectors;
using SharpHorizons.Query.Result;

/// <summary>Interprets <see cref="QueryResult"/> as <see cref="IOrbitalStateVectors"/>.</summary>
public interface IOrbitalStateVectorsInterpreter : IVectorsEphemerisEntryInterpreter<IOrbitalStateVectors> { }
