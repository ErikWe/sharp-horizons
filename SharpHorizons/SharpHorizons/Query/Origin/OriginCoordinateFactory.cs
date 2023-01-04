namespace SharpHorizons.Query.Origin;

using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;
using SharpHorizons.Query.Arguments.Composers.Origin;

using SharpMeasures.Astronomy;

/// <inheritdoc cref="IOriginCoordinateFactory"/>
internal sealed class OriginCoordinateFactory : IOriginCoordinateFactory
{
    /// <summary>Composes <see cref="IOriginCoordinateArgument"/> that describe <see cref="CylindricalCoordinate"/>.</summary>
    private IOriginCoordinateComposer<CylindricalCoordinate> CylindricalOriginCoordinateComposer { get; }

    /// <summary>Composes <see cref="IOriginCoordinateTypeArgument"/> that describe <see cref="CylindricalCoordinate"/>.</summary>
    private IOriginCoordinateTypeComposer<CylindricalCoordinate> CylindricalOriginCoordinateTypeComposer { get; }

    /// <summary>Composes <see cref="IOriginCoordinateArgument"/> that describe <see cref="GeodeticCoordinate"/>.</summary>
    private IOriginCoordinateComposer<GeodeticCoordinate> GeodeticOriginCoordinateComposer { get; }

    /// <summary>Composes <see cref="IOriginCoordinateTypeArgument"/> that describe <see cref="GeodeticCoordinate"/>.</summary>
    private IOriginCoordinateTypeComposer<GeodeticCoordinate> GeodeticOriginCoordinateTypeComposer { get; }

    /// <inheritdoc cref="OriginCoordinateFactory"/>
    /// <param name="cylindricalOriginCoordinateComposer"><inheritdoc cref="CylindricalOriginCoordinateComposer" path="/summary"/></param>
    /// <param name="cylindricalOriginCoordinateTypeComposer"><inheritdoc cref="CylindricalOriginCoordinateTypeComposer" path="/summary"/></param>
    /// <param name="geodeticOriginCoordinateComposer"><inheritdoc cref="GeodeticOriginCoordinateComposer" path="/summary"/></param>
    /// <param name="geodeticOriginCoordinateTypeComposer"><inheritdoc cref="GeodeticOriginCoordinateTypeComposer" path="/summary"/></param>
    public OriginCoordinateFactory(IOriginCoordinateComposer<CylindricalCoordinate>? cylindricalOriginCoordinateComposer = null, IOriginCoordinateTypeComposer<CylindricalCoordinate>? cylindricalOriginCoordinateTypeComposer = null, IOriginCoordinateComposer<GeodeticCoordinate>? geodeticOriginCoordinateComposer = null, IOriginCoordinateTypeComposer<GeodeticCoordinate>? geodeticOriginCoordinateTypeComposer = null)
    {
        CylindricalCoordinateComposer? defaultCylindricalComposer = null;
        GeodeticCoordinateComposer? defaultGeodeticComposer = null;

        if (cylindricalOriginCoordinateComposer is null || cylindricalOriginCoordinateTypeComposer is null)
        {
            defaultCylindricalComposer = new CylindricalCoordinateComposer();
        }

        if (geodeticOriginCoordinateComposer is null || geodeticOriginCoordinateTypeComposer is null)
        {
            defaultGeodeticComposer = new GeodeticCoordinateComposer();
        }

        CylindricalOriginCoordinateComposer = cylindricalOriginCoordinateComposer ?? defaultCylindricalComposer!;
        CylindricalOriginCoordinateTypeComposer = cylindricalOriginCoordinateTypeComposer ?? defaultCylindricalComposer!;

        GeodeticOriginCoordinateComposer = geodeticOriginCoordinateComposer ?? defaultGeodeticComposer!;
        GeodeticOriginCoordinateTypeComposer = geodeticOriginCoordinateTypeComposer ?? defaultGeodeticComposer!;
    }

    IOriginCoordinate IOriginCoordinateFactory.Create(CylindricalCoordinate coordinate)
    {
        SharpMeasuresValidation.Validate(coordinate);

        return new CylindricalOriginCoordinate(coordinate, CylindricalOriginCoordinateComposer, CylindricalOriginCoordinateTypeComposer);
    }

    IOriginCoordinate IOriginCoordinateFactory.Create(GeodeticCoordinate coordinate)
    {
        SharpMeasuresValidation.Validate(coordinate);

        return new GeodeticOriginCoordinate(coordinate, GeodeticOriginCoordinateComposer, GeodeticOriginCoordinateTypeComposer);
    }
}
