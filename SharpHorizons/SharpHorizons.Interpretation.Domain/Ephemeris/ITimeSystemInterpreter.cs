namespace SharpHorizons.Interpretation.Ephemeris;

using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Result;

/// <summary>Interprets <see cref="QueryResult"/> as <see cref="TimeSystem"/>.</summary>
public interface ITimeSystemInterpreter : IInterpreter<TimeSystem> { }
