namespace SharpHorizons.Settings.Interpretation.Ephemeris;

using Microsoft.Extensions.Configuration;

using SharpHorizons.Ephemeris;
using SharpHorizons.Query.Epoch;

using SharpMeasures;

using System.Collections.Generic;
using System.Collections.Specialized;

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

    /// <summary>The <see cref="string"/> indicating that the <see cref="IEpoch"/> of the first or last <see cref="IEphemerisEntry"/> represents an epoch before the common era (before year 0).</summary>
    public string BoundaryEpochBCE { get; set; } = null!;

    /// <summary>The <see cref="string"/> indicating that the <see cref="IEpoch"/> of the first or last <see cref="IEphemerisEntry"/> represents an epoch in the common era (after year 0).</summary>
    public string BoundaryEpochCE { get; set; } = null!;

    /// <summary>The key corresponding to the <see cref="IEpoch"/> of the first <see cref="IEphemerisEntry"/>.</summary>
    public string StartEpoch { get; set; } = null!;

    /// <summary>The key corresponding to the <see cref="IEpoch"/> of the last <see cref="IEphemerisEntry"/>.</summary>
    public string StopEpoch { get; set; } = null!;

    /// <summary>The key corresponding to the <see cref="SharpHorizons.Query.Epoch.TimeSystem"/>.</summary>
    public string TimeSystem { get; set; } = null!;

    /// <summary>The key corresponding to the <see cref="Time"/> offset to UTC.</summary>
    public string TimeZoneOffset { get; set; } = null!;

    /// <summary>The key corresponding to the <see cref="IStepSize"/>.</summary>
    public string StepSize { get; set; } = null!;

    /// <summary>The keys corresponding to the inclusion of small-body perturbers.</summary>
    public IEnumerable<string> SmallPerturbers { get; set; } = null!;

    /// <summary>The key corresponding to the <see cref="SharpHorizons.Query.ReferenceSystem"/>.</summary>
    public string ReferenceSystem { get; set; } = null!;

    /// <summary>The <see cref="string"/> indicating the start of the <see cref="IEphemeris{TEntry}"/>.</summary>
    public string StartOfEphemeris { get; set; } = null!;

    /// <summary>The <see cref="string"/> indicating the end of the <see cref="IEphemeris{TEntry}"/>.</summary>
    public string EndOfEphemeris { get; set; } = null!;

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

        options.StartEpoch = DefaultEphemerisInterpretation.Default.StartEpoch;
        options.StopEpoch = DefaultEphemerisInterpretation.Default.StopEpoch;
        options.TimeSystem = DefaultEphemerisInterpretation.Default.TimeSystem;
        options.TimeZoneOffset = DefaultEphemerisInterpretation.Default.TimeZoneOffset;
        options.StepSize = DefaultEphemerisInterpretation.Default.StepSize;

        options.SmallPerturbers = WrapStringCollection(DefaultEphemerisInterpretation.Default.SmallPerturbers);

        options.ReferenceSystem = DefaultEphemerisInterpretation.Default.ReferenceSystem;

        options.StartOfEphemeris = DefaultEphemerisInterpretation.Default.StartOfEphemeris;
        options.EndOfEphemeris = DefaultEphemerisInterpretation.Default.EndOfEphemeris;
    }

    /// <summary>Wraps a <see cref="StringCollection"/>, <paramref name="collection"/>, as an <see cref="IEnumerable{T}"/> of <see cref="string"/>.</summary>
    /// <param name="collection">This <see cref="StringCollection"/> is wrapped as an <see cref="IEnumerable{T}"/> of <see cref="string"/>.</param>
    private static IEnumerable<string> WrapStringCollection(StringCollection collection)
    {
        foreach (var item in collection)
        {
            if (item is not null)
            {
                yield return item;
            }
        }
    }
}
