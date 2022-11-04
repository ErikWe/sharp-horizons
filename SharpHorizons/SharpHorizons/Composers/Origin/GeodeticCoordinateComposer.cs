namespace SharpHorizons.Composers.Origin;

using SharpHorizons.Query;

using SharpMeasures.Astronomy;

using System;
using System.Globalization;

/// <summary>Composes <see cref="IOriginCoordinateArgument"/> and <see cref="IOriginCoordinateTypeArgument"/> that describe <see cref="GeodeticCoordinate"/>.</summary>
internal sealed class GeodeticCoordinateComposer : IOriginCoordinateComposer<GeodeticCoordinate>, IOriginCoordinateTypeComposer<GeodeticCoordinate>
{
    IOriginCoordinateArgument IArgumentComposer<IOriginCoordinateArgument, GeodeticCoordinate>.Compose(GeodeticCoordinate obj)
    {
        ArgumentNullException.ThrowIfNull(obj);

        var longitude = obj.Longitude.Degrees.ToString("F7", CultureInfo.InvariantCulture);
        var latitude = obj.Latitude.Degrees.ToString("F7", CultureInfo.InvariantCulture);
        var height = obj.Height.Kilometres.ToString("F7", CultureInfo.InvariantCulture);

        return new QueryArgument($"{longitude},{latitude},{height}");
    }

    IOriginCoordinateTypeArgument IArgumentComposer<IOriginCoordinateTypeArgument, GeodeticCoordinate>.Compose(GeodeticCoordinate obj) => new QueryArgument("GEODETIC");
}
