namespace SharpHorizons.Settings.Interpretation.Ephemeris.Target;

using Microsoft.Extensions.Configuration;

using SharpHorizons.Interpretation.Ephemeris.Target;

using System.Diagnostics.CodeAnalysis;

/// <summary>Allows options related to the interpretation of <see cref="IEphemerisTargetHeader"/> to be specified.</summary>
/// <remarks>Once specified, a <see cref="ITargetInterpretationOptionsProvider"/> should be used to access the options.</remarks>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class TargetInterpretationOptions
{
    /// <summary>The identifier of the <see cref="IConfigurationSection"/> associated with <see cref="TargetInterpretationOptions"/>.</summary>
    internal static string Section { get; } = "Interpretation:Ephemeris:Target";

    /// <inheritdoc cref="ITargetInterpretationOptionsProvider.BodyName"/>
    public string BodyName { get; set; } = null!;

    /// <inheritdoc cref="ITargetInterpretationOptionsProvider.GeodeticCoordinate"/>
    public string GeodeticCoordinate { get; set; } = null!;

    /// <inheritdoc cref="ITargetInterpretationOptionsProvider.CylindricalCoordinate"/>
    public string CylindricalCoordinate { get; set; } = null!;

    /// <inheritdoc cref="ITargetInterpretationOptionsProvider.ReferenceEllipsoid"/>
    public string ReferenceEllipsoid { get; set; } = null!;

    /// <inheritdoc cref="ITargetInterpretationOptionsProvider.Radii"/>
    public string Radii { get; set; } = null!;

    /// <summary>Applies the default values to the <see cref="TargetInterpretationOptions"/> <paramref name="options"/>.</summary>
    /// <param name="options">The default values are applied to this <see cref="TargetInterpretationOptions"/>.</param>
    public static void ApplyDefaults(TargetInterpretationOptions options)
    {
        options.BodyName = DefaultEphemerisTargetInterpretationSettings.Default.BodyName;
        options.GeodeticCoordinate = DefaultEphemerisTargetInterpretationSettings.Default.GeodeticCoordinate;
        options.CylindricalCoordinate = DefaultEphemerisTargetInterpretationSettings.Default.CylindricalCoordinate;
        options.ReferenceEllipsoid = DefaultEphemerisTargetInterpretationSettings.Default.ReferenceEllipsoid;
        options.Radii = DefaultEphemerisTargetInterpretationSettings.Default.Radii;
    }
}
