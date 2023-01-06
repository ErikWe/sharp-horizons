namespace SharpHorizons.Interpretation.Ephemeris.Target;

using SharpHorizons.Query.Target;

using SharpMeasures.Astronomy;

/// <summary>A mutable <see cref="IEphemerisTargetHeader"/>.</summary>
internal sealed class MutableEphemerisTargetHeader : IEphemerisTargetHeader
{
    public ITarget Target { get; set; } = null!;

    public GeodeticCoordinate? GeodeticCoordinate { get; set; }
    public CylindricalCoordinate? CylindricalCoordinate { get; set; }

    public ReferenceEllipsoidInterpretation? ReferenceEllipsoid { get; set; }

    public ObjectRadiiInterpretation? Radii { get; set; }
}
