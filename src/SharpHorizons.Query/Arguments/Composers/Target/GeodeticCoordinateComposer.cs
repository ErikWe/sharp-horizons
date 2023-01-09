namespace SharpHorizons.Query.Arguments.Composers.Target;

using SharpHorizons.Query.Target;

using SharpMeasures.Astronomy;

using System.Diagnostics.CodeAnalysis;
using System.Globalization;

/// <summary>Composes <see cref="TargetSiteIdentifier"/> that describe <see cref="GeodeticCoordinate"/>.</summary>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class GeodeticCoordinateComposer : ITargetSiteComposer<GeodeticCoordinate>
{
    TargetSiteIdentifier ITargetSiteComposer<GeodeticCoordinate>.Compose(GeodeticCoordinate obj)
    {
        SharpMeasuresValidation.Validate(obj);

        var longitude = obj.Longitude.Degrees.ToString("F7", CultureInfo.InvariantCulture);
        var latitude = obj.Latitude.Degrees.ToString("F7", CultureInfo.InvariantCulture);
        var height = obj.Height.Kilometres.ToString("F7", CultureInfo.InvariantCulture);

        return new($"g:{longitude},{latitude},{height}");
    }
}
