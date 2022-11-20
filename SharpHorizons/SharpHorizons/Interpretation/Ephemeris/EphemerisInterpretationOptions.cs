namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.Extensions.Configuration;

/// <summary>Specifies how the result of an ephemeris query is interpreted.</summary>
internal sealed class EphemerisInterpretationOptions
{
    /// <summary>Describes the name of the <see cref="IConfigurationSection"/> which describes <see cref="EphemerisInterpretationOptions"/>.</summary>
    internal static string Section { get; } = "Interpretation:Ephemeris";

    /// <summary>The <see cref="string"/> indicating the start of the ephemeris data.</summary>
    public string EphemerisDataStart { get; set; } = null!;

    /// <summary>The number of blocks used for the ephemeris data.</summary>
    public int EphemerisDataBlockCount { get; set; }

    /// <summary>The <see cref="string"/> indicating <see cref="LongitudeInterpretation.WestPositive"/>.</summary>
    public string WestPositiveLongitude { get; set; } = null!;

    /// <summary>The <see cref="string"/> indicating <see cref="LongitudeInterpretation.EastPositive"/>.</summary>
    public string EastPositiveLongitude { get; set; } = null!;

    /// <summary>Applies the default values to <paramref name="options"/>.</summary>
    /// <param name="options">The default values are applied to these <see cref="EphemerisInterpretationOptions"/>.</param>
    public static void ApplyDefaults(EphemerisInterpretationOptions options)
    {
        options.EphemerisDataStart = DefaultEphemerisInterpretation.Default.EphemerisDataStart;
        options.EphemerisDataBlockCount = DefaultEphemerisInterpretation.Default.EphemerisDataBlockCount;
        options.WestPositiveLongitude = DefaultEphemerisInterpretation.Default.WestPositiveLongitude;
        options.EastPositiveLongitude = DefaultEphemerisInterpretation.Default.EastPositiveLongitude;
    }
}