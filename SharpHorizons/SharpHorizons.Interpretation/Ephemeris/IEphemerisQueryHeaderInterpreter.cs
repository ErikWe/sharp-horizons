namespace SharpHorizons.Interpretation.Ephemeris;

using SharpHorizons.Query.Result;

/// <summary>Interprets <see cref="IQueryResult"/> as <see cref="IEphemerisQueryHeader"/>.</summary>
/// <typeparam name="THeader">The type of the interpreted <see cref="IEphemerisQueryHeader"/>.</typeparam>
public interface IEphemerisQueryHeaderInterpreter<THeader> : IInterpreter<THeader> where THeader : IEphemerisQueryHeader { }
