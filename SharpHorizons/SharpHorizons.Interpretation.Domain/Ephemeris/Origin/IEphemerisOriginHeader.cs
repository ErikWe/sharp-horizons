namespace SharpHorizons.Interpretation.Ephemeris.Origin;

using SharpHorizons.Query.Origin;

using SharpMeasures.Astronomy;

/// <summary>Represents the <see cref="IOrigin"/>-related properties of an <see cref="IEphemerisHeader"/>.</summary>
public interface IEphemerisOriginHeader
{
    /// <summary>The <see cref="IOrigin"/> of the query, or the object relative to which the <see cref="IOrigin"/> is expressed.</summary>
    public abstract IOrigin Origin { get; }

    /// <summary>The <see cref="SharpMeasures.Astronomy.GeodeticCoordinate"/>, relative to <see cref="Origin"/>, describing the <see cref="IOrigin"/> of the query - or <see langword="null"/> if no coordinate was used.</summary>
    public abstract GeodeticCoordinate? GeodeticCoordinate { get; }

    /// <summary>The <see cref="SharpMeasures.Astronomy.CylindricalCoordinate"/>, relative to <see cref="Origin"/>, describing the <see cref="IOrigin"/> of the query - or <see langword="null"/> if no coordinate was used.</summary>
    public abstract CylindricalCoordinate? CylindricalCoordinate { get; }

    /// <summary>The name of the site representing the <see cref="IOrigin"/> - or <see langword="null"/> if no site was used.</summary>
    public abstract ObservationSiteName? SiteName { get; }

    /// <summary>The reference ellipsoid, relative to which <see cref="GeodeticCoordinate"/> and <see cref="CylindricalCoordinate"/> are expressed.</summary>
    public abstract ReferenceEllipsoidInterpretation? ReferenceEllipsoid { get; }

    /// <summary>The radii of the <see cref="Origin"/>.</summary>
    public abstract ObjectRadiiInterpretation? Radii { get; }
}
