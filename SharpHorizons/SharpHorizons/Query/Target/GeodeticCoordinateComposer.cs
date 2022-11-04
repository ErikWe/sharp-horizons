﻿namespace SharpHorizons.Query.Target;

using SharpMeasures.Astronomy;

using System.Globalization;

/// <summary>Composes <see cref="TargetSiteIdentifier"/> that describe <see cref="GeodeticCoordinate"/>.</summary>
internal sealed class GeodeticCoordinateComposer : ITargetSiteComposer<GeodeticCoordinate>
{
    TargetSiteIdentifier ITargetSiteComposer<GeodeticCoordinate>.Compose(GeodeticCoordinate obj)
    {
        var longitude = obj.Longitude.Degrees.ToString("F7", CultureInfo.InvariantCulture);
        var latitude = obj.Latitude.Degrees.ToString("F7", CultureInfo.InvariantCulture);
        var height = obj.Height.Kilometres.ToString("F7", CultureInfo.InvariantCulture);

        return $"g:{longitude},{latitude},{height}";
    }
}
