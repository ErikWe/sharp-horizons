namespace SharpHorizons.Query.Arguments.Composers.Target;

using SharpHorizons.Query.Target;

using SharpMeasures.Astronomy;

using System.Diagnostics.CodeAnalysis;
using System.Globalization;

/// <summary>Composes <see cref="TargetSiteIdentifier"/> that describe <see cref="CylindricalCoordinate"/>.</summary>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class CylindricalCoordinateComposer : ITargetSiteComposer<CylindricalCoordinate>
{
    TargetSiteIdentifier ITargetSiteComposer<CylindricalCoordinate>.Compose(CylindricalCoordinate obj)
    {
        SharpMeasuresValidation.Validate(obj);

        var azimuth = obj.Azimuth.Degrees.ToString("F7", CultureInfo.InvariantCulture);
        var radialDistance = obj.RadialDistance.Kilometres.ToString("F7", CultureInfo.InvariantCulture);
        var height = obj.Height.Kilometres.ToString("F7", CultureInfo.InvariantCulture);

        return new($"c:{azimuth},{radialDistance},{height}");
    }
}
