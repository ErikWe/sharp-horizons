namespace SharpHorizons.Settings.Interpretation.Ephemeris.Target;

using Microsoft.Extensions.Configuration;

using SharpHorizons.Interpretation.Ephemeris;
using SharpHorizons.Interpretation.Ephemeris.Target;
using SharpHorizons.Query.Target;

/// <summary>Options for how the <see cref="IEphemerisQueryTargetHeader"/> is interpreted.</summary>
internal sealed class TargetInterpretationOptions
{
    /// <summary>Describes the name of the <see cref="IConfigurationSection"/> which describes <see cref="TargetInterpretationOptions"/>.</summary>
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

    /// <summary>Applies the default values to <paramref name="options"/>.</summary>
    /// <param name="options">The default values are applied to these <see cref="TargetInterpretationOptions"/>.</param>
    public static void ApplyDefaults(TargetInterpretationOptions options)
    {
        options.BodyName = DefaultEphemerisTargetInterpretation.Default.BodyName;
        options.GeodeticCoordinate = DefaultEphemerisTargetInterpretation.Default.GeodeticCoordinate;
        options.CylindricalCoordinate = DefaultEphemerisTargetInterpretation.Default.CylindricalCoordinate;
        options.ReferenceEllipsoid = DefaultEphemerisTargetInterpretation.Default.ReferenceEllipsoid;
        options.Radii = DefaultEphemerisTargetInterpretation.Default.Radii;
    }
}