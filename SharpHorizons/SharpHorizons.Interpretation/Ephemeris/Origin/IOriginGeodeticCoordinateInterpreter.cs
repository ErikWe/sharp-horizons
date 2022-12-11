﻿namespace SharpHorizons.Interpretation.Ephemeris.Origin;

using SharpHorizons.Query.Result;

using SharpMeasures.Astronomy;

/// <summary>Interprets some part of <see cref="IQueryResult"/> as <see cref="GeodeticCoordinate"/>.</summary>
public interface IOriginGeodeticCoordinateInterpreter : IPartInterpreter<GeodeticCoordinate> { }