namespace SharpHorizons.Interpretation.Ephemeris.Target;

using SharpHorizons.Query.Target;

using SharpMeasures.Astronomy;

using System.Diagnostics.CodeAnalysis;

/// <summary>Represents the <see cref="ITarget"/>-related properties of a <see cref="IEphemerisHeader"/>.</summary>
public interface IEphemerisTargetHeader
{
    /// <summary>The <see cref="ITarget"/> of the query, or the object relative to which the <see cref="ITarget"/> is expressed.</summary>
    public abstract ITarget Target { get; }

    /// <summary>Indicates whether the center of <see cref="Target"/> represented the <see cref="ITarget"/> in the query, rather than <see cref="GeodeticCoordinate"/> and <see cref="CylindricalCoordinate"/>.</summary>
    [MemberNotNullWhen(false, nameof(GeodeticCoordinate), nameof(CylindricalCoordinate))]
    public virtual bool Geocentric => CylindricalCoordinate is null;

    /// <summary>The <see cref="SharpMeasures.Astronomy.GeodeticCoordinate"/>, relative to <see cref="Target"/>, describing the <see cref="ITarget"/> of the query - or <see langword="null"/> if no coordinate was used.</summary>
    public abstract GeodeticCoordinate? GeodeticCoordinate { get; }

    /// <summary>The <see cref="SharpMeasures.Astronomy.CylindricalCoordinate"/>, relative to <see cref="Target"/>, describing the <see cref="ITarget"/> of the query - or <see langword="null"/> if no coordinate was used.</summary>
    public abstract CylindricalCoordinate? CylindricalCoordinate { get; }

    /// <summary>The reference ellipsoid, relative to which <see cref="GeodeticCoordinate"/> and <see cref="CylindricalCoordinate"/> are expressed.</summary>
    public abstract ReferenceEllipsoidInterpretation? ReferenceEllipsoid { get; }

    /// <summary>The radii of the <see cref="Target"/>.</summary>
    public abstract ObjectRadiiInterpretation? Radii { get; }
}
