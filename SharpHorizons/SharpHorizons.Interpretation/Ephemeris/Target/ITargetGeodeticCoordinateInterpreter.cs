namespace SharpHorizons.Interpretation.Ephemeris.Target;

using SharpHorizons.Query.Result;

using SharpMeasures.Astronomy;

/// <summary>Interprets some part of <see cref="IQueryResult"/> as <see cref="GeodeticCoordinate"/>.</summary>
public interface ITargetGeodeticCoordinateInterpreter : IPartInterpreter<GeodeticCoordinate> { }