namespace SharpHorizons.Interpretation.Ephemeris.Origin;

using SharpHorizons.Query.Origin;

using SharpMeasures.Astronomy;

using System.Diagnostics.CodeAnalysis;

/// <summary>Represents data interpreted about the <see cref="IOrigin"/> of a query.</summary>
public interface IOriginDataInterpretation
{
    /// <summary>The <see cref="IOrigin"/> of the query, or the object relative to which the <see cref="IOrigin"/> is expressed.</summary>
    public abstract IOrigin Origin { get; }

    /// <summary>Indicates whether the center of <see cref="Origin"/> represented the <see cref="IOrigin"/> in the query, rather than <see cref="GeodeticCoordinate"/> and <see cref="CylindricalCoordinate"/>.</summary>
    [MemberNotNullWhen(false, nameof(GeodeticCoordinate), nameof(CylindricalCoordinate))]
    public virtual bool Geocentric => CylindricalCoordinate is null;

    /// <summary>The <see cref="SharpMeasures.Astronomy.GeodeticCoordinate"/>, relative to <see cref="Origin"/>, describing the <see cref="IOrigin"/> of the query - or <see langword="null"/> if no coordinate was used.</summary>
    public abstract GeodeticCoordinate? GeodeticCoordinate { get; }

    /// <summary>The <see cref="SharpMeasures.Astronomy.CylindricalCoordinate"/>, relative to <see cref="Origin"/>, describing the <see cref="IOrigin"/> of the query - or <see langword="null"/> if no coordinate was used.</summary>
    public abstract CylindricalCoordinate? CylindricalCoordinate { get; }

    /// <summary>The name of the site representing the <see cref="IOrigin"/> - or <see langword="null"/> if no site was used.</summary>
    public abstract string? SiteName { get; }

    /// <summary>The reference ellipsoid, relative to which <see cref="GeodeticCoordinate"/> and <see cref="CylindricalCoordinate"/> are expressed.</summary>
    public abstract ReferenceEllipsoidInterpretation? ReferenceEllipsoid { get; }

    /// <summary>The radii of the <see cref="Origin"/>.</summary>
    public abstract ObjectRadiiInterpretation? Radii { get; }
}
