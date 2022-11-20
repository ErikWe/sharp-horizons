namespace SharpHorizons.Interpretation.Ephemeris.Target;

using Microsoft.Extensions.Configuration;

using SharpHorizons.Query.Target;

/// <summary>Specifies the keys present in the result of queries, related to the <see cref="ITarget"/>, used for interpretation.</summary>
internal sealed class TargetInterpretationKeyOptions
{
    /// <summary>Describes the name of the <see cref="IConfigurationSection"/> which describes <see cref="TargetInterpretationKeyOptions"/>.</summary>
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
    /// <param name="options">The default values are applied to these <see cref="TargetInterpretationKeyOptions"/>.</param>
    public static void ApplyDefaults(TargetInterpretationKeyOptions options)
    {
        options.BodyName = DefaultTargetInterpretationKeys.Default.BodyName;
        options.GeodeticCoordinate = DefaultTargetInterpretationKeys.Default.GeodeticCoordinate;
        options.CylindricalCoordinate = DefaultTargetInterpretationKeys.Default.CylindricalCoordinate;
        options.ReferenceEllipsoid = DefaultTargetInterpretationKeys.Default.ReferenceEllipsoid;
        options.Radii = DefaultTargetInterpretationKeys.Default.Radii;
    }
}