namespace SharpHorizons.Settings.Interpretation.Ephemeris.Origin;

using Microsoft.Extensions.Configuration;

using SharpHorizons.Interpretation.Ephemeris.Origin;

using System.Diagnostics.CodeAnalysis;

/// <summary>Allows options related to the interpretation of <see cref="IEphemerisOriginHeader"/> to be specified.</summary>
/// <remarks>Once specified, a <see cref="IOriginInterpretationOptionsProvider"/> should be used to access the options.</remarks>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class OriginInterpretationOptions
{
    /// <summary>The identifier of the <see cref="IConfigurationSection"/> associated with <see cref="OriginInterpretationOptions"/>.</summary>
    internal static string Section { get; } = "Ephemeris:Origin";

    /// <inheritdoc cref="IOriginInterpretationOptionsProvider.BodyName"/>
    public string BodyName { get; set; } = null!;

    /// <inheritdoc cref="IOriginInterpretationOptionsProvider.SiteName"/>
    public string SiteName { get; set; } = null!;

    /// <inheritdoc cref="IOriginInterpretationOptionsProvider.GeocentricSite"/>
    public string GeocentricSite { get; set; } = null!;

    /// <inheritdoc cref="IOriginInterpretationOptionsProvider.CustomSite"/>
    public string CustomSite { get; set; } = null!;

    /// <inheritdoc cref="IOriginInterpretationOptionsProvider.GeodeticCoordinate"/>
    public string GeodeticCoordinate { get; set; } = null!;

    /// <inheritdoc cref="IOriginInterpretationOptionsProvider.CylindricalCoordinate"/>
    public string CylindricalCoordinate { get; set; } = null!;

    /// <inheritdoc cref="IOriginInterpretationOptionsProvider.ReferenceEllipsoid"/>
    public string ReferenceEllipsoid { get; set; } = null!;

    /// <inheritdoc cref="IOriginInterpretationOptionsProvider.Radii"/>
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
