namespace SharpHorizons.Query.Arguments.Composers.Origin;

using SharpMeasures.Astronomy;

using System;
using System.Globalization;

/// <summary>Composes <see cref="IOriginCoordinateArgument"/> and <see cref="IOriginCoordinateTypeArgument"/> that describe <see cref="CylindricalCoordinate"/>.</summary>
internal sealed class CylindricalCoordinateComposer : IOriginCoordinateComposer<CylindricalCoordinate>, IOriginCoordinateTypeComposer<CylindricalCoordinate>
{
    IOriginCoordinateArgument IArgumentComposer<IOriginCoordinateArgument, CylindricalCoordinate>.Compose(CylindricalCoordinate obj)
    {
        ArgumentNullException.ThrowIfNull(obj);

        var azimuth = obj.Azimuth.Degrees.ToString("F7", CultureInfo.InvariantCulture);
        var radialDistance = obj.RadialDistance.Kilometres.ToString("F7", CultureInfo.InvariantCulture);
        var height = obj.Height.Kilometres.ToString("F7", CultureInfo.InvariantCulture);

        return new QueryArgument($"{azimuth},{radialDistance},{height}");
    }

    IOriginCoordinateTypeArgument IArgumentComposer<IOriginCoordinateTypeArgument, CylindricalCoordinate>.Compose(CylindricalCoordinate obj) => new QueryArgument("CYLINDRICAL");
}
