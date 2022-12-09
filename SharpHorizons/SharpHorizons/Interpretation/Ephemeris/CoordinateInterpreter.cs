namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using SharpHorizons.Interpretation.Ephemeris.Origin;
using SharpHorizons.Interpretation.Ephemeris.Target;
using SharpHorizons.Query.Result;

using SharpMeasures;
using SharpMeasures.Astronomy;

using System;
using System.Globalization;

/// <summary>Interprets some part of <see cref="IQueryResult"/> as <see cref="GeodeticCoordinate"/> or <see cref="CylindricalCoordinate"/>.</summary>
internal sealed class CoordinateInterpreter : ITargetGeodeticCoordinateInterpreter, ITargetCylindricalCoordinateInterpreter, IOriginGeodeticCoordinateInterpreter, IOriginCylindricalCoordinateInterpreter
{
    Optional<GeodeticCoordinate> IPartInterpreter<GeodeticCoordinate>.Interpret(string queryPart)
    {
        if (Interpret(queryPart) is not (double longitude, double latitude, double altitude))
        {
            return new();
        }

        return new GeodeticCoordinate(longitude * Longitude.OneDegree, latitude * Latitude.OneDegree, altitude * Height.OneKilometre);
    }

    Optional<CylindricalCoordinate> IPartInterpreter<CylindricalCoordinate>.Interpret(string queryPart)
    {
        if (Interpret(queryPart) is not (double azimuth, double distance, double height))
        {
            return new();
        }

        return new CylindricalCoordinate(distance * Distance.OneKilometre, azimuth * Azimuth.OneDegree, height * Height.OneKilometre);
    }

    /// <summary>Attempts to interpret <paramref name="queryPart"/> as (<see cref="double"/>, <see cref="double"/>, <see cref="double"/>).</summary>
    /// <param name="queryPart">This <see cref="string"/> is interpreted.</param>
    /// <exception cref="ArgumentNullException"/>
    private static (double, double, double)? Interpret(string queryPart)
    {
        ArgumentNullException.ThrowIfNull(queryPart);

        if (queryPart.Split(':') is not { Length: > 1 } colonSplit || colonSplit[1].Split('{') is not { Length: > 1 } bracketSplit || bracketSplit[0].Split(',') is not { Length: 3 } commaSplit)
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
        var valid = int.TryParse(text, NumberStyles.Number | NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite, provider: null, out var value);

        return valid ? value : null;
    }
}
