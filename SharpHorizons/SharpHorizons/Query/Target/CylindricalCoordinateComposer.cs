namespace SharpHorizons.Query.Target;

using SharpMeasures.Astronomy;

using System.Globalization;

/// <summary>Composes <see cref="TargetSiteIdentifier"/> that describe <see cref="CylindricalCoordinate"/>.</summary>
internal sealed class CylindricalCoordinateComposer : ITargetSiteComposer<CylindricalCoordinate>
{
    TargetSiteIdentifier ITargetSiteComposer<CylindricalCoordinate>.Compose(CylindricalCoordinate obj)
    {
        var azimuth = obj.Azimuth.Degrees.ToString("F7", CultureInfo.InvariantCulture);
        var radialDistance = obj.RadialDistance.Kilometres.ToString("F7", CultureInfo.InvariantCulture);
        var height = obj.Height.Kilometres.ToString("F7", CultureInfo.InvariantCulture);

        return $"c:{azimuth},{radialDistance},{height}";
    }
}
