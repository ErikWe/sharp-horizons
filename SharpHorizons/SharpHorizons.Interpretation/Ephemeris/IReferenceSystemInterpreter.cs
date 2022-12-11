namespace SharpHorizons.Interpretation.Ephemeris;

using SharpHorizons.Query;
using SharpHorizons.Query.Result;

/// <summary>Interprets some part of <see cref="IQueryResult"/> as <see cref="ReferenceSystem"/>.</summary>
public interface IReferenceSystemInterpreter : IPartInterpreter<ReferenceSystem> { }
