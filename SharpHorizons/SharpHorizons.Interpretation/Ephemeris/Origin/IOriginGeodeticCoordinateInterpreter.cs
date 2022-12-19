namespace SharpHorizons.Interpretation.Ephemeris.Origin;

using SharpHorizons.Query.Result;

using SharpMeasures.Astronomy;

/// <summary>Interprets <see cref="QueryResult"/> as <see cref="GeodeticCoordinate"/>.</summary>
public interface IOriginGeodeticCoordinateInterpreter : IInterpreter<GeodeticCoordinate> { }
