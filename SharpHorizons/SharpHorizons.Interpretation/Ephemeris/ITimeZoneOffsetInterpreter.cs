namespace SharpHorizons.Interpretation.Ephemeris;

using SharpHorizons.Query.Result;

using SharpMeasures;

/// <summary>Interprets some part of <see cref="IQueryResult"/> as the <see cref="Time"/> offset from UTC of the timezone used in the <see cref="IQueryResult"/>.</summary>
public interface ITimeZoneOffsetInterpreter : IPartInterpreter<Time> { }
