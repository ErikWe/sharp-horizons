namespace SharpHorizons.Interpretation.Ephemeris;

using SharpHorizons.Ephemeris;
using SharpHorizons.Query.Result;

/// <summary>Interprets <see cref="QueryResult"/> as the <see cref="IEpoch"/> of the first <see cref="IEphemerisEntry"/>.</summary>
public interface IEphemerisStartEpochInterpreter : IInterpreter<IEpoch> { }
