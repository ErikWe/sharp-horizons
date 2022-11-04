namespace SharpHorizons.Query.Target;

using SharpHorizons.Composers.Arguments.Target;

using SharpMeasures.Astronomy;

/// <summary>Describes a <see cref="ITargetSite"/> using a <see cref="CylindricalCoordinate"/>.</summary>
internal sealed record class CylindricalTargetSiteCoordinate : ITargetSite
{
    /// <summary>The <see cref="CylindricalCoordinate"/>, describing a <see cref="ITargetSite"/>.</summary>
    private CylindricalCoordinate Coordinate { get; }

    /// <summary>Used to compose a <see cref="TargetSiteIdentifier"/> describing <see langword="this"/>.</summary>
    private ITargetSiteComposer<CylindricalCoordinate> Composer { get; }

    /// <summary>Describes a <see cref="ITargetSite"/> using <paramref name="coordinate"/>.</summary>
    /// <param name="coordinate"><inheritdoc cref="Coordinate" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    public CylindricalTargetSiteCoordinate(CylindricalCoordinate coordinate, ITargetSiteComposer<CylindricalCoordinate> composer)
    {
        Coordinate = coordinate;

        Composer = composer;
    }

    TargetSiteIdentifier ITargetSite.ComposeIdentifier() => Composer.Compose(Coordinate);
}