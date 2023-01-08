namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using SharpHorizons.Interpretation.Ephemeris.Origin;
using SharpHorizons.Interpretation.Ephemeris.Target;
using SharpHorizons.Query.Result;

using SharpMeasures;
using SharpMeasures.Astronomy;

using System;
using System.Globalization;

/// <summary>Interprets <see cref="QueryResult"/> as <see cref="GeodeticCoordinate"/> or <see cref="CylindricalCoordinate"/>.</summary>
internal sealed class CoordinateInterpreter : ITargetGeodeticCoordinateInterpreter, ITargetCylindricalCoordinateInterpreter, IOriginGeodeticCoordinateInterpreter, IOriginCylindricalCoordinateInterpreter
{
    Optional<GeodeticCoordinate> IInterpreter<GeodeticCoordinate>.Interpret(QueryResult queryResult)
    {
        if (Interpret(queryResult) is not (double longitude, double latitude, double altitude))
        {
            return new();
        }

        return new GeodeticCoordinate(longitude * Longitude.OneDegree, latitude * Latitude.OneDegree, altitude * Height.OneKilometre);
    }

    Optional<CylindricalCoordinate> IInterpreter<CylindricalCoordinate>.Interpret(QueryResult queryResult)
    {
        if (Interpret(queryResult) is not (double azimuth, double distance, double height))
        {
            return new();
        }

        return new CylindricalCoordinate(distance * Distance.OneKilometre, azimuth * Azimuth.OneDegree, height * Height.OneKilometre);
    }

    /// <summary>Attempts to interpret <paramref name="queryResult"/> as (<see cref="double"/>, <see cref="double"/>, <see cref="double"/>).</summary>
    /// <param name="queryResult">This <see cref="QueryResult"/> is interpreted.</param>
    /// <exception cref="ArgumentException"/>
    private static (double, double, double)? Interpret(QueryResult queryResult)
    {
        QueryResult.Validate(queryResult);

        if (queryResult.Content.Split(':') is not { Length: > 1 } colonSplit || colonSplit[1].Split('{') is not { Length: > 1 } bracketSplit || bracketSplit[0].Split(',') is not { Length: 3 } commaSplit)
        {
            return null;
        }

        if (TryParse(commaSplit[0]) is not int x || TryParse(commaSplit[1]) is not int y || TryParse(commaSplit[2]) is not int z)
        {
            return null;
        }

        return (x, y, z);
    }

    /// <summary>Attempts to parse an <see cref="int"/> from <paramref name="text"/>.</summary>
    /// <param name="text">An <see cref="int"/> is parsed from this <see cref="string"/>, if possible.</param>
    private static int? TryParse(string text)
    {
        var valid = int.TryParse(text, NumberStyles.Number, provider: null, out var value);

        return valid ? value : null;
    }
}
