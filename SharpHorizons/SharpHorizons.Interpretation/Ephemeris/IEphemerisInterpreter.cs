namespace SharpHorizons.Interpretation.Ephemeris;

using SharpHorizons.Ephemeris;
using SharpHorizons.Query.Result;

/// <summary>Interprets <see cref="IQueryResult"/> as <typeparamref name="TEphemeris"/>, with each <see cref="IEphemerisEntry"/> described as an instance of <typeparamref name="TEphemerisEntry"/>.</summary>
/// <typeparam name="TEphemeris">The <see cref="IEphemeris{TEntry}"/>, with each <see cref="IEphemerisEntry"/> described as an instance of <typeparamref name="TEphemerisEntry"/>.</typeparam>
/// <typeparam name="TEphemerisEntry">The type of the <see cref="IEphemerisEntry"/> of the <typeparamref name="TEphemeris"/>.</typeparam>
public interface IEphemerisInterpreter<TEphemeris, TEphemerisEntry> : IInterpreter<TEphemeris> where TEphemeris : IEphemeris<TEphemerisEntry> where TEphemerisEntry : IEphemerisEntry { }
