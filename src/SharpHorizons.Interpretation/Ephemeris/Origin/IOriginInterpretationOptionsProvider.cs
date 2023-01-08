namespace SharpHorizons.Interpretation.Ephemeris.Origin;

using SharpHorizons.Settings.Interpretation.Ephemeris.Origin;

/// <summary>Provides options related to the interpretation of <see cref="IEphemerisOriginHeader"/>.</summary>
public interface IOriginInterpretationOptionsProvider
{
    /// <inheritdoc cref="OriginInterpretationOptions.BodyName"/>
    public abstract string BodyName { get; }

    /// <inheritdoc cref="OriginInterpretationOptions.SiteName"/>
    public abstract string SiteName { get; }

    /// <inheritdoc cref="OriginInterpretationOptions.GeocentricSite"/>
    public abstract string GeocentricSite { get; }

    /// <inheritdoc cref="OriginInterpretationOptions.CustomSite"/>
    public abstract string CustomSite { get; }

    /// <inheritdoc cref="OriginInterpretationOptions.GeodeticCoordinate"/>
    public abstract string GeodeticCoordinate { get; }

    /// <inheritdoc cref="OriginInterpretationOptions.CylindricalCoordinate"/>
    public abstract string CylindricalCoordinate { get; }

    /// <inheritdoc cref="OriginInterpretationOptions.ReferenceEllipsoid"/>
    public abstract string ReferenceEllipsoid { get; }

    /// <inheritdoc cref="OriginInterpretationOptions.Radii"/>
    public abstract string Radii { get; }
}
