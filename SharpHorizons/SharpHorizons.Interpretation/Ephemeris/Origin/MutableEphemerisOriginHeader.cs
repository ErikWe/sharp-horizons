namespace SharpHorizons.Interpretation.Ephemeris.Origin;

using SharpHorizons.Query.Origin;

using SharpMeasures.Astronomy;

/// <summary>A mutable <see cref="IEphemerisOriginHeader"/>.</summary>
internal sealed class MutableEphemerisOriginHeader : IEphemerisOriginHeader
{
    public IOrigin Origin { get; set; } = null!;

    public GeodeticCoordinate? GeodeticCoordinate { get; set; }
    public CylindricalCoordinate? CylindricalCoordinate { get; set; }

    public ObservationSiteName? SiteName { get; set; }

    public ReferenceEllipsoidInterpretation? ReferenceEllipsoid { get; set; }

    public ObjectRadiiInterpretation? Radii { get; set; }
}
