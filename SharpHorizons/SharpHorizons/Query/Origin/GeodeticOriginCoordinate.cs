namespace SharpHorizons.Query.Origin;

using SharpHorizons.Query.Arguments;

using SharpMeasures.Astronomy;

using System.Globalization;

/// <summary>Describes a <see cref="IOriginCoordinate"/> using a <see cref="GeodeticCoordinate"/>.</summary>
internal sealed record class GeodeticOriginCoordinate : IOriginCoordinate
{
    /// <summary>The <see cref="GeodeticCoordinate"/>, describing a <see cref="IOriginCoordinate"/>.</summary>
    private GeodeticCoordinate Coordinate { get; }

    /// <summary>Describes a <see cref="IOriginCoordinate"/> using <paramref name="coordinate"/>.</summary>
    /// <param name="coordinate"><inheritdoc cref="Coordinate" path="/summary"/></param>
    public GeodeticOriginCoordinate(GeodeticCoordinate coordinate)
    {
        Coordinate = coordinate;
    }

    IOriginCoordinateArgument IOriginCoordinate.ComposeCoordinateArgument()
    {
        var longitude = Coordinate.Longitude.Degrees.ToString("F7", CultureInfo.InvariantCulture);
        var latitude = Coordinate.Latitude.Degrees.ToString("F7", CultureInfo.InvariantCulture);
        var height = Coordinate.Height.Kilometres.ToString("F7", CultureInfo.InvariantCulture);

        return new OriginCoordinateArgument($"{longitude},{latitude},{height}");
    }

    IOriginCoordinateTypeArgument IOriginCoordinate.ComposeCoordinateTypeArgument() => new OriginCoordinateTypeArgument("GEODETIC");
}