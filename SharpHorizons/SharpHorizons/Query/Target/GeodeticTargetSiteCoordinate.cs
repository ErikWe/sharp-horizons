namespace SharpHorizons.Query.Target;

using SharpMeasures.Astronomy;

/// <summary>Describes a <see cref="ITargetSite"/> using a <see cref="GeodeticCoordinate"/>.</summary>
internal sealed record class GeodeticTargetSiteCoordinate : ITargetSite
{
    /// <summary>The <see cref="GeodeticCoordinate"/>, describing a <see cref="ITargetSite"/>.</summary>
    private GeodeticCoordinate Coordinate { get; }

    /// <summary>Used to compose a <see cref="TargetSiteIdentifier"/> describing <see langword="this"/>.</summary>
    private ITargetSiteComposer<GeodeticCoordinate> Composer { get; }

    /// <summary>Describes a <see cref="ITargetSite"/> using <paramref name="coordinate"/>.</summary>
    /// <param name="coordinate"><inheritdoc cref="Coordinate" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    public GeodeticTargetSiteCoordinate(GeodeticCoordinate coordinate, ITargetSiteComposer<GeodeticCoordinate> composer)
    {
        Coordinate = coordinate;

        Composer = composer;
    }

    TargetSiteIdentifier ITargetSite.ComposeIdentifier() => Composer.Compose(Coordinate);
}