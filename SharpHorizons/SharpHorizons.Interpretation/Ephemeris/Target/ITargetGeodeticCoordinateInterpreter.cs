namespace SharpHorizons.Interpretation.Ephemeris.Target;

using SharpHorizons.Query.Result;

using SharpMeasures.Astronomy;

/// <summary>Interprets <see cref="QueryResult"/> as <see cref="GeodeticCoordinate"/>.</summary>
public interface ITargetGeodeticCoordinateInterpreter : IInterpreter<GeodeticCoordinate> { }
