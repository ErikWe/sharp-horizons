namespace SharpHorizons.Interpretation.Ephemeris.Origin;

using Microsoft.Extensions.Configuration;

using SharpHorizons.Query.Origin;

/// <summary>Specifies the keys present in the result of queries, related to the <see cref="IOrigin"/>, used for interpretation.</summary>
internal sealed class OriginInterpretationKeyOptions
{
    /// <summary>Describes the name of the <see cref="IConfigurationSection"/> which describes <see cref="OriginInterpretationKeyOptions"/>.</summary>
    internal static string Section { get; } = "Interpretation:Ephemeris:Origin";

    /// <summary>The key corresponding to the name of the <see cref="IOrigin"/>.</summary>
    public string BodyName { get; set; } = null!;

    /// <summary>The key corresponding to the <see cref="SharpMeasures.Astronomy.GeodeticCoordinate"/> of the <see cref="IOrigin"/>.</summary>
    public string GeodeticCoordinate { get; set; } = null!;

    /// <summary>The key corresponding to the <see cref="SharpMeasures.Astronomy.CylindricalCoordinate"/> of the <see cref="IOrigin"/>.</summary>
    public string CylindricalCoordinate { get; set; } = null!;

    /// <summary>The key corresponding to the <see cref="ReferenceEllipsoidInterpretation"/> of the <see cref="IOrigin"/>.</summary>
    public string ReferenceEllipsoid { get; set; } = null!;

    /// <summary>The key corresponding to the <see cref="ObjectRadiiInterpretation"/> of the <see cref="IOrigin"/>.</summary>
    public string Radii { get; set; } = null!;

    /// <summary>Applies the default values to <paramref name="options"/>.</summary>
    /// <param name="options">The default values are applied to these <see cref="OriginInterpretationKeyOptions"/>.</param>
    public static void ApplyDefaults(OriginInterpretationKeyOptions options)
    {
        options.BodyName = DefaultOriginInterpretationKeys.Default.BodyName;
        options.GeodeticCoordinate = DefaultOriginInterpretationKeys.Default.GeodeticCoordinate;
        options.CylindricalCoordinate = DefaultOriginInterpretationKeys.Default.CylindricalCoordinate;
        options.ReferenceEllipsoid = DefaultOriginInterpretationKeys.Default.ReferenceEllipsoid;
        options.Radii = DefaultOriginInterpretationKeys.Default.Radii;
    }
}