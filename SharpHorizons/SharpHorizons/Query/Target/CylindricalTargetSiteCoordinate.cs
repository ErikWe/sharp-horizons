namespace SharpHorizons.Query.Target;

using SharpMeasures.Astronomy;

using System.Diagnostics.CodeAnalysis;

/// <summary>Describes a <see cref="ITargetSite"/> using a <see cref="CylindricalCoordinate"/>.</summary>
internal sealed record class CylindricalTargetSiteCoordinate : ITargetSite
{
    /// <summary>The <see cref="CylindricalCoordinate"/>, describing a <see cref="ITargetSite"/>.</summary>
    public required CylindricalCoordinate Coordinate { private get; init; }

    /// <summary>Used to compose a <see cref="TargetSiteIdentifier"/> describing <see langword="this"/>.</summary>
    public required ITargetSiteComposer<CylindricalCoordinate> Composer { private get; init; }

    /// <inheritdoc cref="CylindricalTargetSiteCoordinate"/>
    public CylindricalTargetSiteCoordinate() { }

    /// <inheritdoc cref="CylindricalTargetSiteCoordinate"/>
    /// <param name="coordinate"><inheritdoc cref="Coordinate" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    [SetsRequiredMembers]
    public CylindricalTargetSiteCoordinate(CylindricalCoordinate coordinate, ITargetSiteComposer<CylindricalCoordinate> composer)
    {
        Coordinate = coordinate;

        Composer = composer;
    }

    TargetSiteIdentifier ITargetSite.ComposeIdentifier() => Composer.Compose(Coordinate);
}