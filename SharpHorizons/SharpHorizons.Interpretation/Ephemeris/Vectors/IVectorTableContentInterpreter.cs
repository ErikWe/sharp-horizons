namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Query.Result;
using SharpHorizons.Query.Vectors.Table;

/// <summary>Interprets some part of <see cref="IQueryResult"/> as <see cref="VectorTableContent"/>.</summary>
public interface IVectorTableContentInterpreter : IPartInterpreter<VectorTableContent> { }
