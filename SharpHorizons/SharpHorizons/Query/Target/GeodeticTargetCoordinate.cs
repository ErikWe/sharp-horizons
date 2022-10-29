namespace SharpHorizons.Query.Target;

using SharpMeasures.Astronomy;

using System.Globalization;

/// <summary>Describes a <see cref="ITargetSite"/> using a <see cref="GeodeticCoordinate"/>.</summary>
internal sealed record class GeodeticTargetCoordinate : ITargetSite
{
    /// <summary>The <see cref="GeodeticCoordinate"/>, describing a <see cref="ITargetSite"/>.</summary>
    private GeodeticCoordinate Coordinate { get; }

    /// <summary>Describes a <see cref="ITargetSite"/> using <paramref name="coordinate"/>.</summary>
    /// <param name="coordinate"><inheritdoc cref="Coordinate" path="/summary"/></param>
    public GeodeticTargetCoordinate(GeodeticCoordinate coordinate)
    {
        Coordinate = coordinate;
    }

    TargetSiteIdentifier ITargetSite.ComposeIdentifier()
    {
        var longitude = Coordinate.Longitude.Degrees.ToString("F7", CultureInfo.InvariantCulture);
        var latitude = Coordinate.Latitude.Degrees.ToString("F7", CultureInfo.InvariantCulture);
        var height = Coordinate.Height.Kilometres.ToString("F7", CultureInfo.InvariantCulture);

        return $"g:{longitude},{latitude},{height}";
    }
}