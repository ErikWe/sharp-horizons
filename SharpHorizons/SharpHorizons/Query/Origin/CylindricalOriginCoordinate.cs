namespace SharpHorizons.Query.Origin;

using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;

using SharpMeasures.Astronomy;

using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="ICylindricalOriginCoordinate"/>
internal sealed record class CylindricalOriginCoordinate : ICylindricalOriginCoordinate
{
    public required CylindricalCoordinate Coordinate { get; init; }

    /// <summary>Used to compose a <see cref="IOriginCoordinateArgument"/> describing <see langword="this"/>.</summary>
    public required IOriginCoordinateComposer<CylindricalCoordinate> CoordinateComposer { private get; init; }

    /// <summary>Used to compose a <see cref="IOriginCoordinateTypeArgument"/> describing <see langword="this"/>.</summary>
    public required IOriginCoordinateTypeComposer<CylindricalCoordinate> CoordinateTypeComposer { private get; init; }

    /// <inheritdoc cref="CylindricalOriginCoordinate"/>
    public CylindricalOriginCoordinate() { }

    /// <inheritdoc cref="CylindricalOriginCoordinate"/>
    /// <param name="coordinate"><inheritdoc cref="Coordinate" path="/summary"/></param>
    /// <param name="coordinateComposer"><inheritdoc cref="CoordinateComposer" path="/summary"/></param>
    /// <param name="coordinateTypeComposer"><inheritdoc cref="CoordinateTypeComposer" path="/summary"/></param>
    [SetsRequiredMembers]
    public CylindricalOriginCoordinate(CylindricalCoordinate coordinate, IOriginCoordinateComposer<CylindricalCoordinate> coordinateComposer, IOriginCoordinateTypeComposer<CylindricalCoordinate> coordinateTypeComposer)
    {
        Coordinate = coordinate;

        CoordinateComposer = coordinateComposer;
        CoordinateTypeComposer = coordinateTypeComposer;
    }

    IOriginCoordinateArgument IOriginCoordinate.ComposeCoordinateArgument() => CoordinateComposer.Compose(Coordinate);
    IOriginCoordinateTypeArgument IOriginCoordinate.ComposeCoordinateTypeArgument() => CoordinateTypeComposer.Compose(Coordinate);
}