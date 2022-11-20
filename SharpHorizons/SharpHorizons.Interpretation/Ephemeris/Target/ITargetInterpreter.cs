namespace SharpHorizons.Interpretation.Ephemeris.Target;

using SharpHorizons.Query.Result;
using SharpHorizons.Query.Target;

/// <summary>Interprets some part of <see cref="IQueryResult"/> as <see cref="ITarget"/>.</summary>
public interface ITargetInterpreter : IPartInterpreter<ITarget> { }
