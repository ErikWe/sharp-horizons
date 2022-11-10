namespace SharpHorizons.Query.Origin;

using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;

using SharpMeasures.Astronomy;

/// <inheritdoc cref="ICylindricalOriginCoordinate"/>
internal sealed record class CylindricalOriginCoordinate : ICylindricalOriginCoordinate
{
    /// <inheritdoc/>
    public CylindricalCoordinate Coordinate { get; }

    /// <summary>Used to compose a <see cref="IOriginCoordinateArgument"/> describing <see langword="this"/>.</summary>
    private IOriginCoordinateComposer<CylindricalCoordinate> CoordinateComposer { get; }

    /// <summary>Used to compose a <see cref="IOriginCoordinateTypeArgument"/> describing <see langword="this"/>.</summary>
    private IOriginCoordinateTypeComposer<CylindricalCoordinate> CoordinateTypeComposer { get; }

    /// <summary>Describes a <see cref="IOriginCoordinate"/> using <paramref name="coordinate"/>.</summary>
    /// <param name="coordinate"><inheritdoc cref="Coordinate" path="/summary"/></param>
    /// <param name="coordinateComposer"><inheritdoc cref="CoordinateComposer" path="/summary"/></param>
    /// <param name="coordinateTypeComposer"><inheritdoc cref="CoordinateTypeComposer" path="/summary"/></param>
    public CylindricalOriginCoordinate(CylindricalCoordinate coordinate, IOriginCoordinateComposer<CylindricalCoordinate> coordinateComposer, IOriginCoordinateTypeComposer<CylindricalCoordinate> coordinateTypeComposer)
    {
        Coordinate = coordinate;

        CoordinateComposer = coordinateComposer;
        CoordinateTypeComposer = coordinateTypeComposer;
    }

    IOriginCoordinateArgument IOriginCoordinate.ComposeCoordinateArgument() => CoordinateComposer.Compose(Coordinate);
    IOriginCoordinateTypeArgument IOriginCoordinate.ComposeCoordinateTypeArgument() => CoordinateTypeComposer.Compose(Coordinate);
}