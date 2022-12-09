namespace SharpHorizons.Query.Target;

using SharpHorizons.Query.Arguments.Composers.Target;

using SharpMeasures.Astronomy;

using System.Diagnostics.CodeAnalysis;

/// <summary>Describes a <see cref="ITargetSite"/> using a <see cref="GeodeticCoordinate"/>.</summary>
internal sealed record class GeodeticTargetSiteCoordinate : ITargetSite
{
    /// <summary>The <see cref="GeodeticCoordinate"/>, describing a <see cref="ITargetSite"/>.</summary>
    public required GeodeticCoordinate Coordinate { private get; init; }

    /// <summary>Used to compose a <see cref="TargetSiteIdentifier"/> describing <see langword="this"/>.</summary>
    public required ITargetSiteComposer<GeodeticCoordinate> Composer { private get; init; }

    /// <inheritdoc cref="GeodeticTargetSiteCoordinate"/>
    public GeodeticTargetSiteCoordinate() { }

    /// <inheritdoc cref="GeodeticTargetSiteCoordinate"/>
    /// <param name="coordinate"><inheritdoc cref="Coordinate" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    [SetsRequiredMembers]
    public GeodeticTargetSiteCoordinate(GeodeticCoordinate coordinate, ITargetSiteComposer<GeodeticCoordinate> composer)
    {
        Coordinate = coordinate;

        Composer = composer;
    }

    TargetSiteIdentifier ITargetSite.ComposeIdentifier() => Composer.Compose(Coordinate);
}