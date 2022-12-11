namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Query.Vectors;
using SharpHorizons.Query.Result;

/// <summary>Interprets some part of <see cref="IQueryResult"/> as <see cref="VectorCorrection"/>.</summary>
public interface IVectorCorrectionInterpreter : IPartInterpreter<VectorCorrection> { }
