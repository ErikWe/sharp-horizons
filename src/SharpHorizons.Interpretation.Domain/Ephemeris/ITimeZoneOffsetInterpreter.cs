namespace SharpHorizons.Interpretation.Ephemeris;

using SharpHorizons.Query.Result;

using SharpMeasures;

/// <summary>Interprets <see cref="QueryResult"/> as the <see cref="Time"/> offset from UTC of the timezone used in the <see cref="QueryResult"/>.</summary>
public interface ITimeZoneOffsetInterpreter : IInterpreter<Time> { }
