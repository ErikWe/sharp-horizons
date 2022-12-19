namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Ephemeris;
using SharpHorizons.Ephemeris.Vectors;
using SharpHorizons.Query.Result;

/// <summary>Interprets <see cref="QueryResult"/> as an <see cref="IEphemeris{TEntry}"/> with entries of type <typeparamref name="TEphemerisEntry"/>.</summary>
/// <typeparam name="TEphemerisEntry">The type of the <see cref="IVectorsEphemerisEntry"/> of the interpreted <see cref="IEphemeris{TEntry}"/>.</typeparam>
public interface IVectorsEphemerisInterpreter<TEphemerisEntry> : IEphemerisInterpreter<IVectorsHeader, TEphemerisEntry> where TEphemerisEntry : IVectorsEphemerisEntry { }
