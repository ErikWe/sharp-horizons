namespace SharpHorizons.Query.Origin;

using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;
using SharpHorizons.Query.Arguments.Composers.Origin;

using SharpMeasures.Astronomy;

/// <summary>Handles construction of <see cref="IOriginCoordinate"/> representing <see cref="GeodeticCoordinate"/>.</summary>
internal sealed class GeodeticOriginCoordinateFactory : IOriginCoordinateFactory<GeodeticCoordinate>
{
    /// <summary>Composes <see cref="IOriginCoordinateArgument"/> that describe <see cref="GeodeticCoordinate"/>.</summary>
    private IOriginCoordinateComposer<GeodeticCoordinate> OriginCoordinateComposer { get; }

    /// <summary>Composes <see cref="IOriginCoordinateTypeArgument"/> that describe <see cref="GeodeticCoordinate"/>.</summary>
    private IOriginCoordinateTypeComposer<GeodeticCoordinate> OriginCoordinateTypeComposer { get; }

    /// <summary><inheritdoc cref="CylindricalOriginCoordinateFactory" path="/summary"/></summary>
    /// <param name="originCoordinateComposer"><inheritdoc cref="OriginCoordinateComposer" path="/summary"/></param>
    /// <param name="originCoordinateTypeComposer"><inheritdoc cref="OriginCoordinateTypeComposer" path="/summary"/></param>
    public GeodeticOriginCoordinateFactory(IOriginCoordinateComposer<GeodeticCoordinate>? originCoordinateComposer = null, IOriginCoordinateTypeComposer<GeodeticCoordinate>? originCoordinateTypeComposer = null)
    {
        GeodeticCoordinateComposer? defaultComposer = null;

        if (originCoordinateComposer is null || originCoordinateTypeComposer is null)
        {
            defaultComposer = new GeodeticCoordinateComposer();
        }

        OriginCoordinateComposer = originCoordinateComposer ?? defaultComposer!;
        OriginCoordinateTypeComposer = originCoordinateTypeComposer ?? defaultComposer!;
    }

    IOriginCoordinate IOriginCoordinateFactory<GeodeticCoordinate>.Create(GeodeticCoordinate coordinate) => new GeodeticOriginCoordinate(coordinate, OriginCoordinateComposer, OriginCoordinateTypeComposer);
}
