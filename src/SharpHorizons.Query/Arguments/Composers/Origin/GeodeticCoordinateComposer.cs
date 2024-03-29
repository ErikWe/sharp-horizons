﻿namespace SharpHorizons.Query.Arguments.Composers.Origin;

using SharpMeasures.Astronomy;

using System.Diagnostics.CodeAnalysis;
using System.Globalization;

/// <summary>Composes <see cref="IOriginCoordinateArgument"/> and <see cref="IOriginCoordinateTypeArgument"/> that describe <see cref="GeodeticCoordinate"/>.</summary>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class GeodeticCoordinateComposer : IOriginCoordinateComposer<GeodeticCoordinate>, IOriginCoordinateTypeComposer<GeodeticCoordinate>
{
    IOriginCoordinateArgument IArgumentComposer<IOriginCoordinateArgument, GeodeticCoordinate>.Compose(GeodeticCoordinate obj)
    {
        SharpMeasuresValidation.Validate(obj);

        var longitude = obj.Longitude.Degrees.ToString("F7", CultureInfo.InvariantCulture);
        var latitude = obj.Latitude.Degrees.ToString("F7", CultureInfo.InvariantCulture);
        var height = obj.Height.Kilometres.ToString("F7", CultureInfo.InvariantCulture);

        return new QueryArgument($"{longitude},{latitude},{height}");
    }

    IOriginCoordinateTypeArgument IArgumentComposer<IOriginCoordinateTypeArgument, GeodeticCoordinate>.Compose(GeodeticCoordinate obj) => new QueryArgument("G");
}
