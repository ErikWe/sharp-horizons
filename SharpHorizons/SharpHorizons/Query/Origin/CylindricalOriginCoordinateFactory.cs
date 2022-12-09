namespace SharpHorizons.Query.Origin;

using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;
using SharpHorizons.Query.Arguments.Composers.Origin;

using SharpMeasures.Astronomy;

/// <summary>Handles construction of <see cref="IOriginCoordinate"/> representing <see cref="CylindricalCoordinate"/>.</summary>
internal sealed class CylindricalOriginCoordinateFactory : IOriginCoordinateFactory<CylindricalCoordinate>
{
    /// <summary>Composes <see cref="IOriginCoordinateArgument"/> that describe <see cref="ICylindricalOriginCoordinate"/>.</summary>
    private IOriginCoordinateComposer<CylindricalCoordinate> OriginCoordinateComposer { get; }

    /// <summary>Composes <see cref="IOriginCoordinateTypeArgument"/> that describe <see cref="ICylindricalOriginCoordinate"/>.</summary>
    private IOriginCoordinateTypeComposer<CylindricalCoordinate> OriginCoordinateTypeComposer { get; }

    /// <inheritdoc cref="CylindricalOriginCoordinateFactory"/>
    /// <param name="originCoordinateComposer"><inheritdoc cref="OriginCoordinateComposer" path="/summary"/></param>
    /// <param name="originCoordinateTypeComposer"><inheritdoc cref="OriginCoordinateTypeComposer" path="/summary"/></param>
    public CylindricalOriginCoordinateFactory(IOriginCoordinateComposer<CylindricalCoordinate>? originCoordinateComposer = null, IOriginCoordinateTypeComposer<CylindricalCoordinate>? originCoordinateTypeComposer = null)
    {
        CylindricalCoordinateComposer? defaultComposer = null;

        if (originCoordinateComposer is null || originCoordinateTypeComposer is null)
        {
            defaultComposer = new CylindricalCoordinateComposer();
        }

        OriginCoordinateComposer = originCoordinateComposer ?? defaultComposer!;
        OriginCoordinateTypeComposer = originCoordinateTypeComposer ?? defaultComposer!;
    }

    IOriginCoordinate IOriginCoordinateFactory<CylindricalCoordinate>.Create(CylindricalCoordinate coordinate)
    {
        SharpMeasuresValidation.Validate(coordinate);

        return new CylindricalOriginCoordinate(coordinate, OriginCoordinateComposer, OriginCoordinateTypeComposer);
    }
}
