namespace SharpHorizons.Interpretation.Ephemeris;

using SharpHorizons.Query;
using SharpHorizons.Query.Result;

/// <summary>Interprets some part of <see cref="IQueryResult"/> as <see cref="ReferencePlane"/>.</summary>
public interface IReferencePlaneInterpreter : IPartInterpreter<ReferencePlane> { }
