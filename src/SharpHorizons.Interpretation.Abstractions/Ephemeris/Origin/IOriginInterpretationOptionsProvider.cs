namespace SharpHorizons.Interpretation.Ephemeris.Origin;

using SharpHorizons.Query.Origin;

/// <summary>Provides options related to the interpretation of <see cref="IEphemerisOriginHeader"/>.</summary>
public interface IOriginInterpretationOptionsProvider
{
    /// <summary>The key corresponding to the name of the <see cref="IOrigin"/>.</summary>
    public abstract string BodyName { get; }

    /// <summary>The key corresponding to the <see cref="ObservationSiteName"/>.</summary>
    public abstract string SiteName { get; }

    /// <summary>The <see cref="string"/> indicating that a geocentric site was used.</summary>
    public abstract string GeocentricSite { get; }

    /// <summary>The <see cref="string"/> indicating that a custom site was used.</summary>
    public abstract string CustomSite { get; }

    /// <summary>The key corresponding to the <see cref="SharpMeasures.Astronomy.GeodeticCoordinate"/> of the <see cref="IOrigin"/>.</summary>
    public abstract string GeodeticCoordinate { get; }

    /// <summary>The key corresponding to the <see cref="SharpMeasures.Astronomy.CylindricalCoordinate"/> of the <see cref="IOrigin"/>.</summary>
    public abstract string CylindricalCoordinate { get; }

    /// <summary>The key corresponding to the <see cref="ReferenceEllipsoidInterpretation"/> of the <see cref="IOrigin"/>.</summary>
    public abstract string ReferenceEllipsoid { get; }

    /// <summary>The key corresponding to the <see cref="ObjectRadiiInterpretation"/> of the <see cref="IOrigin"/>.</summary>
    public abstract string Radii { get; }
}
