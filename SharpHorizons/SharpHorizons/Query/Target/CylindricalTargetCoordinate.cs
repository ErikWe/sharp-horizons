namespace SharpHorizons.Query.Target;

using SharpMeasures.Astronomy;

using System.Globalization;

/// <summary>Describes a <see cref="ITargetSite"/> using a <see cref="CylindricalCoordinate"/>.</summary>
internal sealed record class CylindricalTargetCoordinate : ITargetSite
{
    /// <summary>The <see cref="CylindricalCoordinate"/>, describing a <see cref="ITargetSite"/>.</summary>
    private CylindricalCoordinate Coordinate { get; }

    /// <summary>Describes a <see cref="ITargetSite"/> using <paramref name="coordinate"/>.</summary>
    /// <param name="coordinate"><inheritdoc cref="Coordinate" path="/summary"/></param>
    public CylindricalTargetCoordinate(CylindricalCoordinate coordinate)
    {
        Coordinate = coordinate;
    }

    TargetSiteIdentifier ITargetSite.ComposeIdentifier()
    {
        var azimuth = Coordinate.Azimuth.Degrees.ToString("F7", CultureInfo.InvariantCulture);
        var radialDistance = Coordinate.RadialDistance.Kilometres.ToString("F7", CultureInfo.InvariantCulture);
        var height = Coordinate.Height.Kilometres.ToString("F7", CultureInfo.InvariantCulture);

        return $"c:{azimuth},{radialDistance},{height}";
    }
}