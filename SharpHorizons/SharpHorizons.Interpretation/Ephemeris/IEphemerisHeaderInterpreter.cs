namespace SharpHorizons.Interpretation.Ephemeris;

using SharpHorizons.Query.Result;

/// <summary>Interprets <see cref="IQueryResult"/> as <see cref="IEphemerisHeader"/>.</summary>
/// <typeparam name="THeader">The type of the interpreted <see cref="IEphemerisHeader"/>.</typeparam>
public interface IEphemerisHeaderInterpreter<THeader> : IInterpreter<THeader> where THeader : IEphemerisHeader { }
