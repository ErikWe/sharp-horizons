namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Ephemeris.Vectors;
using SharpHorizons.Query.Result;

/// <summary>Interprets <see cref="QueryResult"/> as an <typeparamref name="TEphemerisEntry"/>.</summary>
/// <typeparam name="TEphemerisEntry">The type of the interpreted <see cref="IVectorsEphemerisEntry"/>.</typeparam>
public interface IVectorsEphemerisEntryInterpreter<TEphemerisEntry> : IEphemerisEntryInterpreter<IVectorsHeader, TEphemerisEntry> where TEphemerisEntry : IVectorsEphemerisEntry { }
