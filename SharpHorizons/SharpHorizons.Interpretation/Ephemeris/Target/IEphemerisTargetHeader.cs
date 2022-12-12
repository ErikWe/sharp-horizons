namespace SharpHorizons.Interpretation.Ephemeris.Target;

using SharpHorizons.Query.Target;

using SharpMeasures.Astronomy;

/// <summary>Represents the <see cref="ITarget"/>-related properties of an <see cref="IEphemerisHeader"/>.</summary>
public interface IEphemerisTargetHeader
{
    /// <summary>The <see cref="ITarget"/> of the query, or the object relative to which the <see cref="ITarget"/> is expressed.</summary>
    public abstract ITarget Target { get; }

    /// <summary>The <see cref="SharpMeasures.Astronomy.GeodeticCoordinate"/>, relative to <see cref="Target"/>, describing the <see cref="ITarget"/> of the query - or <see langword="null"/> if no coordinate was used.</summary>
    public abstract GeodeticCoordinate? GeodeticCoordinate { get; }

    /// <summary>The <see cref="SharpMeasures.Astronomy.CylindricalCoordinate"/>, relative to <see cref="Target"/>, describing the <see cref="ITarget"/> of the query - or <see langword="null"/> if no coordinate was used.</summary>
    public abstract CylindricalCoordinate? CylindricalCoordinate { get; }

    /// <summary>The reference ellipsoid, relative to which <see cref="GeodeticCoordinate"/> and <see cref="CylindricalCoordinate"/> are expressed.</summary>
    public abstract ReferenceEllipsoidInterpretation? ReferenceEllipsoid { get; }

    /// <summary>The radii of the <see cref="Target"/>.</summary>
    public abstract ObjectRadiiInterpretation? Radii { get; }
}
