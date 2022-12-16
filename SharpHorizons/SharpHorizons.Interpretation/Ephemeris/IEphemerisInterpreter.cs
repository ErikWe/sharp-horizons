namespace SharpHorizons.Interpretation.Ephemeris;

using SharpHorizons.Ephemeris;
using SharpHorizons.Query.Result;

/// <summary>Interprets <see cref="IQueryResult"/> as an <see cref="IEphemeris{TEntry}"/>,of <see cref="IEphemerisEntry"/> described as an instance of <typeparamref name="TEphemerisEntry"/>.</summary>
/// <typeparam name="TEphemerisEntry">The type of the <see cref="IEphemerisEntry"/> of the <see cref="IEphemeris{TEntry}"/>.</typeparam>
public interface IEphemerisInterpreter<TEphemerisEntry> : IInterpreter<IEphemeris<TEphemerisEntry>> where TEphemerisEntry : IEphemerisEntry { }
