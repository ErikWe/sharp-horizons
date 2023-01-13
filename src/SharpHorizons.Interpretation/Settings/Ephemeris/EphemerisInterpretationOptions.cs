namespace SharpHorizons.Settings.Interpretation.Ephemeris;

using Microsoft.Extensions.Configuration;

using SharpHorizons.Ephemeris;
using SharpHorizons.Interpretation.Ephemeris;

using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;

/// <summary>Allows options related to the interpretation of <see cref="IEphemeris{TEntry}"/> to be specified.</summary>
/// <remarks>Once specified, a <see cref="IEphemerisInterpretationOptionsProvider"/> should be used to access the options.</remarks>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class EphemerisInterpretationOptions
{
    /// <summary>The identifier of the <see cref="IConfigurationSection"/> associated with <see cref="EphemerisInterpretationOptions"/>.</summary>
    internal static string Section { get; } = "Ephemeris";

    /// <inheritdoc cref="IEphemerisInterpretationOptionsProvider.EphemerisDataStart"/>
    public string EphemerisDataStart { get; set; } = null!;

    /// <inheritdoc cref="IEphemerisInterpretationOptionsProvider.EphemerisDataBlockCount"/>
    public int EphemerisDataBlockCount { get; set; }

    /// <inheritdoc cref="IEphemerisInterpretationOptionsProvider.WestPositiveLongitude"/>
    public string WestPositiveLongitude { get; set; } = null!;

    /// <inheritdoc cref="IEphemerisInterpretationOptionsProvider.EastPositiveLongitude"/>
    public string EastPositiveLongitude { get; set; } = null!;

    /// <inheritdoc cref="IEphemerisInterpretationOptionsProvider.BoundaryEpochBCE"/>
    public string BoundaryEpochBCE { get; set; } = null!;

    /// <inheritdoc cref="IEphemerisInterpretationOptionsProvider.BoundaryEpochCE"/>
    public string BoundaryEpochCE { get; set; } = null!;

    /// <inheritdoc cref="IEphemerisInterpretationOptionsProvider.StartEpoch"/>
    public string StartEpoch { get; set; } = null!;

    /// <inheritdoc cref="IEphemerisInterpretationOptionsProvider.StopEpoch"/>
    public string StopEpoch { get; set; } = null!;

    /// <inheritdoc cref="IEphemerisInterpretationOptionsProvider.TimeSystem"/>
    public string TimeSystem { get; set; } = null!;

    /// <inheritdoc cref="IEphemerisInterpretationOptionsProvider.TimeZoneOffset"/>
    public string TimeZoneOffset { get; set; } = null!;

    /// <inheritdoc cref="IEphemerisInterpretationOptionsProvider.StepSize"/>
    public string StepSize { get; set; } = null!;

    /// <inheritdoc cref="IEphemerisInterpretationOptionsProvider.SmallPerturbers"/>
    public IEnumerable<string> SmallPerturbers { get; set; } = null!;

    /// <inheritdoc cref="IEphemerisInterpretationOptionsProvider.ReferenceSystem"/>
    public string ReferenceSystem { get; set; } = null!;

    /// <inheritdoc cref="IEphemerisInterpretationOptionsProvider.StartOfEphemeris"/>
    public string StartOfEphemeris { get; set; } = null!;

    /// <inheritdoc cref="IEphemerisInterpretationOptionsProvider.EndOfEphemeris"/>
    public string EndOfEphemeris { get; set; } = null!;

    /// <summary>Applies the default values to the <see cref="EphemerisInterpretationOptions"/> <paramref name="options"/>.</summary>
    /// <param name="options">The default values are applied to this <see cref="EphemerisInterpretationOptions"/>.</param>
    public static void ApplyDefaults(EphemerisInterpretationOptions options)
    {
        options.EphemerisDataStart = DefaultEphemerisInterpretationSettings.Default.EphemerisDataStart;
        options.EphemerisDataBlockCount = DefaultEphemerisInterpretationSettings.Default.EphemerisDataBlockCount;

        options.WestPositiveLongitude = DefaultEphemerisInterpretationSettings.Default.WestPositiveLongitude;
        options.EastPositiveLongitude = DefaultEphemerisInterpretationSettings.Default.EastPositiveLongitude;

        options.BoundaryEpochBCE = DefaultEphemerisInterpretationSettings.Default.BoundaryEpochBCE;
        options.BoundaryEpochCE = DefaultEphemerisInterpretationSettings.Default.BoundaryEpochCE;

        options.StartEpoch = DefaultEphemerisInterpretationSettings.Default.StartEpoch;
        options.StopEpoch = DefaultEphemerisInterpretationSettings.Default.StopEpoch;
        options.TimeSystem = DefaultEphemerisInterpretationSettings.Default.TimeSystem;
        options.TimeZoneOffset = DefaultEphemerisInterpretationSettings.Default.TimeZoneOffset;
        options.StepSize = DefaultEphemerisInterpretationSettings.Default.StepSize;

        options.SmallPerturbers = WrapStringCollection(DefaultEphemerisInterpretationSettings.Default.SmallPerturbers);

        options.ReferenceSystem = DefaultEphemerisInterpretationSettings.Default.ReferenceSystem;

        options.StartOfEphemeris = DefaultEphemerisInterpretationSettings.Default.StartOfEphemeris;
        options.EndOfEphemeris = DefaultEphemerisInterpretationSettings.Default.EndOfEphemeris;
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
