namespace SharpHorizons.Interpretation.Ephemeris;

using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Result;

/// <summary>Interprets some part of <see cref="IQueryResult"/> as <see cref="TimeSystem"/>.</summary>
public interface ITimeSystemInterpreter : IPartInterpreter<TimeSystem> { }
