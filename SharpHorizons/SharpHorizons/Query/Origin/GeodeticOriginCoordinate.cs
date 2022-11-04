namespace SharpHorizons.Query.Origin;

using SharpHorizons.Composers.Arguments;

using SharpMeasures.Astronomy;

/// <inheritdoc cref="IGeodeticOriginCoordinate"/>
internal sealed record class GeodeticOriginCoordinate : IGeodeticOriginCoordinate
{
    /// <inheritdoc/>
    public GeodeticCoordinate Coordinate { get; }

    /// <summary>Used to compose a <see cref="IOriginCoordinateArgument"/> describing <see langword="this"/>.</summary>
    private IOriginCoordinateComposer<GeodeticCoordinate> CoordinateComposer { get; }

    /// <summary>Used to compose a <see cref="IOriginCoordinateTypeArgument"/> describing <see langword="this"/>.</summary>
    private IOriginCoordinateTypeComposer<GeodeticCoordinate> CoordinateTypeComposer { get; }

    /// <summary>Describes a <see cref="IOriginCoordinate"/> using <paramref name="coordinate"/>.</summary>
    /// <param name="coordinate"><inheritdoc cref="Coordinate" path="/summary"/></param>
    /// <param name="coordinateComposer"><inheritdoc cref="CoordinateComposer" path="/summary"/></param>
    /// <param name="coordinateTypeComposer"><inheritdoc cref="CoordinateTypeComposer" path="/summary"/></param>
    public GeodeticOriginCoordinate(GeodeticCoordinate coordinate, IOriginCoordinateComposer<GeodeticCoordinate> coordinateComposer, IOriginCoordinateTypeComposer<GeodeticCoordinate> coordinateTypeComposer)
    {
        Coordinate = coordinate;

        CoordinateComposer = coordinateComposer;
        CoordinateTypeComposer = coordinateTypeComposer;
    }

    IOriginCoordinateArgument IOriginCoordinate.ComposeCoordinateArgument() => CoordinateComposer.Compose(Coordinate);
    IOriginCoordinateTypeArgument IOriginCoordinate.ComposeCoordinateTypeArgument() => CoordinateTypeComposer.Compose(Coordinate);
}