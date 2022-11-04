namespace SharpHorizons.Query.Target;

using SharpMeasures.Astronomy;

internal sealed class TargetSiteFactory : ITargetSiteFactory
{
    /// <summary>Composes <see cref="TargetSiteIdentifier"/> that describe <see cref="CylindricalCoordinate"/>.</summary>
    private ITargetSiteComposer<CylindricalCoordinate> CylindricalCoordinateComposer { get; }

    /// <summary>Composes <see cref="TargetSiteIdentifier"/> that describe <see cref="GeodeticCoordinate"/>.</summary>
    private ITargetSiteComposer<GeodeticCoordinate> GeodeticCoordinateComposer { get; }

    /// <summary><inheritdoc cref="TargetSiteFactory" path="/summary"/></summary>
    /// <param name="cylindricalCoordinateComposer"><inheritdoc cref="CylindricalCoordinateComposer" path="/summary"/></param>
    /// <param name="geodeticCoordinateComposer"><inheritdoc cref="GeodeticCoordinateComposer" path="/summary"/></param>
    public TargetSiteFactory(ITargetSiteComposer<CylindricalCoordinate>? cylindricalCoordinateComposer = null, ITargetSiteComposer<GeodeticCoordinate>? geodeticCoordinateComposer = null)
    {
        CylindricalCoordinateComposer = cylindricalCoordinateComposer ?? new CylindricalCoordinateComposer();
        GeodeticCoordinateComposer = geodeticCoordinateComposer ?? new GeodeticCoordinateComposer();
    }

    ITargetSite ITargetSiteFactory.Create(CylindricalCoordinate coordinate) => new CylindricalTargetSiteCoordinate(coordinate, CylindricalCoordinateComposer);
    ITargetSite ITargetSiteFactory.Create(GeodeticCoordinate coordinate) => new GeodeticTargetSiteCoordinate(coordinate, GeodeticCoordinateComposer);
}
