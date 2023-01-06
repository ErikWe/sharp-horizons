namespace SharpHorizons.Settings.Interpretation.Ephemeris.Target;

using Microsoft.Extensions.Configuration;

using SharpHorizons.Interpretation.Ephemeris;
using SharpHorizons.Interpretation.Ephemeris.Target;
using SharpHorizons.Query.Target;

/// <summary>Allows options related to the interpretation of <see cref="IEphemerisTargetHeader"/> to be specified.</summary>
internal sealed class TargetInterpretationOptions
{
    /// <summary>The identifier of the <see cref="IConfigurationSection"/> associated with <see cref="TargetInterpretationOptions"/>.</summary>
    internal static string Section { get; } = "Interpretation:Ephemeris:Target";

    /// <summary>The key corresponding to the name of the <see cref="ITarget"/>.</summary>
    public string BodyName { get; set; } = null!;

    /// <summary>The key corresponding to the <see cref="SharpMeasures.Astronomy.GeodeticCoordinate"/> of the <see cref="ITarget"/>.</summary>
    public string GeodeticCoordinate { get; set; } = null!;

    /// <summary>The key corresponding to the <see cref="SharpMeasures.Astronomy.CylindricalCoordinate"/> of the <see cref="ITarget"/>.</summary>
    public string CylindricalCoordinate { get; set; } = null!;

    /// <summary>The key corresponding to the <see cref="ReferenceEllipsoidInterpretation"/> of the <see cref="ITarget"/>.</summary>
    public string ReferenceEllipsoid { get; set; } = null!;

    /// <summary>The key corresponding to the <see cref="ObjectRadiiInterpretation"/> of the <see cref="ITarget"/>.</summary>
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
