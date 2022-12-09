namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.Extensions.Configuration;

using SharpHorizons.Query.Epoch;

/// <summary>Specifies how the result of an ephemeris query is interpreted.</summary>
internal sealed class EphemerisInterpretationOptions
{
    /// <summary>Describes the name of the <see cref="IConfigurationSection"/> which describes <see cref="EphemerisInterpretationOptions"/>.</summary>
    internal static string Section { get; } = "Interpretation:Ephemeris";

    /// <summary>The <see cref="string"/> indicating the start of the ephemeris data.</summary>
    public string EphemerisDataStart { get; set; } = null!;

    /// <summary>The number of blocks used for the ephemeris data.</summary>
    public int EphemerisDataBlockCount { get; set; }

    /// <summary>The <see cref="string"/> indicating <see cref="LongitudeDefinition.WestPositive"/>.</summary>
    public string WestPositiveLongitude { get; set; } = null!;

    /// <summary>The <see cref="string"/> indicating <see cref="LongitudeDefinition.EastPositive"/>.</summary>
    public string EastPositiveLongitude { get; set; } = null!;

    /// <summary>The <see cref="string"/> indicating that the <see cref="IStartEpoch"/> or <see cref="IStopEpoch"/> represents an epoch before the common era (before year 0).</summary>
    public string BoundaryEpochBCE { get; set; } = null!;

    /// <summary>The <see cref="string"/> indicating that the <see cref="IStartEpoch"/> or <see cref="IStopEpoch"/> represents an epoch in the common era (after year 0).</summary>
    public string BoundaryEpochCE { get; set; } = null!;

    /// <summary>Applies the default values to <paramref name="options"/>.</summary>
    /// <param name="options">The default values are applied to these <see cref="EphemerisInterpretationOptions"/>.</param>
    public static void ApplyDefaults(EphemerisInterpretationOptions options)
    {
        options.EphemerisDataStart = DefaultEphemerisInterpretation.Default.EphemerisDataStart;
        options.EphemerisDataBlockCount = DefaultEphemerisInterpretation.Default.EphemerisDataBlockCount;

        options.WestPositiveLongitude = DefaultEphemerisInterpretation.Default.WestPositiveLongitude;
        options.EastPositiveLongitude = DefaultEphemerisInterpretation.Default.EastPositiveLongitude;

        options.BoundaryEpochBCE = DefaultEphemerisInterpretation.Default.BoundaryEpochBCE;
        options.BoundaryEpochCE = DefaultEphemerisInterpretation.Default.BoundaryEpochCE;
    }
}