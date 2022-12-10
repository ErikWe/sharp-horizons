namespace SharpHorizons.Interpretation.Ephemeris;

using SharpHorizons.Ephemeris;
using SharpHorizons.Query.Result;

/// <summary>Interprets some part of <see cref="IQueryResult"/> as the <see cref="IEpoch"/> of the last <see cref="IEphemerisEntry"/>.</summary>
public interface IEphemerisStopEpochInterpreter : IPartInterpreter<IEpoch> { }
