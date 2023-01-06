namespace SharpHorizons.Settings.Interpretation.Ephemeris.Origin;

using Microsoft.Extensions.Configuration;

using SharpHorizons.Interpretation.Ephemeris;
using SharpHorizons.Interpretation.Ephemeris.Origin;
using SharpHorizons.Query.Origin;

/// <summary>Allows options related to the interpretation of <see cref="IEphemerisOriginHeader"/> to be specified.</summary>
internal sealed class OriginInterpretationOptions
{
    /// <summary>The identifier of the <see cref="IConfigurationSection"/> associated with <see cref="OriginInterpretationOptions"/>.</summary>
    internal static string Section { get; } = "Interpretation:Ephemeris:Origin";

    /// <summary>The key corresponding to the name of the <see cref="IOrigin"/>.</summary>
    public string BodyName { get; set; } = null!;

    /// <summary>The key corresponding to the <see cref="ObservationSiteName"/>.</summary>
    public string SiteName { get; set; } = null!;

    /// <summary>The <see cref="string"/> indicating that a geocentric site was used.</summary>
    public string GeocentricSite { get; set; } = null!;

    /// <summary>The <see cref="string"/> indicating that a custom site was used.</summary>
    public string CustomSite { get; set; } = null!;

    /// <summary>The key corresponding to the <see cref="SharpMeasures.Astronomy.GeodeticCoordinate"/> of the <see cref="IOrigin"/>.</summary>
    public string GeodeticCoordinate { get; set; } = null!;

    /// <summary>The key corresponding to the <see cref="SharpMeasures.Astronomy.CylindricalCoordinate"/> of the <see cref="IOrigin"/>.</summary>
    public string CylindricalCoordinate { get; set; } = null!;

    /// <summary>The key corresponding to the <see cref="ReferenceEllipsoidInterpretation"/> of the <see cref="IOrigin"/>.</summary>
    public string ReferenceEllipsoid { get; set; } = null!;

    /// <summary>The key corresponding to the <see cref="ObjectRadiiInterpretation"/> of the <see cref="IOrigin"/>.</summary>
    public string Radii { get; set; } = null!;

    /// <summary>Applies the default values to the <see cref="OriginInterpretationOptions"/> <paramref name="options"/>.</summary>
    /// <param name="options">The default values are applied to this <see cref="OriginInterpretationOptions"/>.</param>
    public static void ApplyDefaults(OriginInterpretationOptions options)
    {
        options.BodyName = DefaultEphemerisOriginInterpretationSettings.Default.BodyName;
        options.SiteName = DefaultEphemerisOriginInterpretationSettings.Default.SiteName;
        options.GeocentricSite = DefaultEphemerisOriginInterpretationSettings.Default.GeocentricSite;
        options.CustomSite = DefaultEphemerisOriginInterpretationSettings.Default.CustomSite;
        options.GeodeticCoordinate = DefaultEphemerisOriginInterpretationSettings.Default.GeodeticCoordinate;
        options.CylindricalCoordinate = DefaultEphemerisOriginInterpretationSettings.Default.CylindricalCoordinate;
        options.ReferenceEllipsoid = DefaultEphemerisOriginInterpretationSettings.Default.ReferenceEllipsoid;
        options.Radii = DefaultEphemerisOriginInterpretationSettings.Default.Radii;
    }
}
