namespace SharpHorizons.Interpretation.Ephemeris;

using SharpHorizons.Ephemeris;
using SharpHorizons.Query.Result;

/// <summary>Interprets <see cref="QueryResult"/> as the <see cref="IEpoch"/> of the last <see cref="IEphemerisEntry"/>.</summary>
public interface IEphemerisStopEpochInterpreter : IInterpreter<IEpoch> { }
