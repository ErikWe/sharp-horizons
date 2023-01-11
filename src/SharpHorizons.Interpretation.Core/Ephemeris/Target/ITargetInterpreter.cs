namespace SharpHorizons.Interpretation.Ephemeris.Target;

using SharpHorizons.Query.Result;
using SharpHorizons.Query.Target;

/// <summary>Interprets <see cref="QueryResult"/> as <see cref="ITarget"/>.</summary>
public interface ITargetInterpreter : IInterpreter<ITarget> { }
