namespace SharpHorizons.Query.Origin;

using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;

using SharpMeasures.Astronomy;

using System.Diagnostics.CodeAnalysis;

/// <summary>Represents the coordinate of the <see cref="IOrigin"/>, relative to some <see cref="IOriginObject"/>, expressed as a <see cref="GeodeticCoordinate"/>.</summary>
internal sealed record class GeodeticOriginCoordinate : IOriginCoordinate
{
    /// <summary>The <see cref="GeodeticCoordinate"/>, describing the <see cref="IOriginCoordinate"/>.</summary>
    public required GeodeticCoordinate Coordinate { get; init; }

    /// <summary>Used to compose a <see cref="IOriginCoordinateArgument"/> describing <see langword="this"/>.</summary>
    public required IOriginCoordinateComposer<GeodeticCoordinate> CoordinateComposer { private get; init; }

    /// <summary>Used to compose a <see cref="IOriginCoordinateTypeArgument"/> describing <see langword="this"/>.</summary>
    public required IOriginCoordinateTypeComposer<GeodeticCoordinate> CoordinateTypeComposer { private get; init; }

    /// <inheritdoc cref="GeodeticOriginCoordinate"/>
    public GeodeticOriginCoordinate() { }

    /// <inheritdoc cref="GeodeticOriginCoordinate"/>
    /// <param name="coordinate"><inheritdoc cref="Coordinate" path="/summary"/></param>
    /// <param name="coordinateComposer"><inheritdoc cref="CoordinateComposer" path="/summary"/></param>
    /// <param name="coordinateTypeComposer"><inheritdoc cref="CoordinateTypeComposer" path="/summary"/></param>
    [SetsRequiredMembers]
    public GeodeticOriginCoordinate(GeodeticCoordinate coordinate, IOriginCoordinateComposer<GeodeticCoordinate> coordinateComposer, IOriginCoordinateTypeComposer<GeodeticCoordinate> coordinateTypeComposer)
    {
        Coordinate = coordinate;

        CoordinateComposer = coordinateComposer;
        CoordinateTypeComposer = coordinateTypeComposer;
    }

    IOriginCoordinateArgument IOriginCoordinate.ComposeCoordinateArgument() => CoordinateComposer.Compose(Coordinate);
    IOriginCoordinateTypeArgument IOriginCoordinate.ComposeCoordinateTypeArgument() => CoordinateTypeComposer.Compose(Coordinate);
}
