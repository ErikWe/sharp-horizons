namespace SharpHorizons.Interpretation.Ephemeris.Origin;

using SharpHorizons.Query.Result;
using SharpHorizons.Query.Origin;

/// <summary>Interprets some part of <see cref="IQueryResult"/> as <see cref="IOrigin"/>.</summary>
public interface IOriginInterpreter : IPartInterpreter<IOrigin> { }
