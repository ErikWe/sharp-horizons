namespace SharpHorizons.Query.Origin;

using SharpHorizons.Query.Arguments;

using SharpMeasures.Astronomy;

using System.Globalization;

/// <summary>Describes a <see cref="IOriginCoordinate"/> using a <see cref="CylindricalCoordinate"/>.</summary>
internal sealed record class CylindricalOriginCoordinate : IOriginCoordinate
{
    /// <summary>The <see cref="CylindricalCoordinate"/>, describing a <see cref="IOriginCoordinate"/>.</summary>
    private CylindricalCoordinate Coordinate { get; }

    /// <summary>Describes a <see cref="IOriginCoordinate"/> using <paramref name="coordinate"/>.</summary>
    /// <param name="coordinate"><inheritdoc cref="Coordinate" path="/summary"/></param>
    public CylindricalOriginCoordinate(CylindricalCoordinate coordinate)
    {
        Coordinate = coordinate;
    }

    IOriginCoordinateArgument IOriginCoordinate.ComposeCoordinateArgument()
    {
        var azimuth = Coordinate.Azimuth.Degrees.ToString("F7", CultureInfo.InvariantCulture);
        var radialDistance = Coordinate.RadialDistance.Kilometres.ToString("F7", CultureInfo.InvariantCulture);
        var height = Coordinate.Height.Kilometres.ToString("F7", CultureInfo.InvariantCulture);

        return new OriginCoordinateArgument($"{azimuth},{radialDistance},{height}");
    }

    IOriginCoordinateTypeArgument IOriginCoordinate.ComposeCoordinateTypeArgument() => new OriginCoordinateTypeArgument("CYLINDRICAL");
}