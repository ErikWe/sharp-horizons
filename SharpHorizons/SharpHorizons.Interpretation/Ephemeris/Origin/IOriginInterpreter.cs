namespace SharpHorizons.Interpretation.Ephemeris.Origin;

using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Result;

/// <summary>Interprets <see cref="QueryResult"/> as <see cref="IOrigin"/>.</summary>
public interface IOriginInterpreter : IInterpreter<IOrigin> { }
