﻿namespace SharpHorizons.Interpretation;

using Microsoft.Extensions.Configuration;

using NodaTime;

using SharpHorizons.Query.Result;

/// <summary>Specifies how a <see cref="IQueryResult"/> is interpreted.</summary>
internal sealed class InterpretationOptions
{
    /// <summary>Describes the name of the <see cref="IConfigurationSection"/> which describes <see cref="InterpretationOptions"/>.</summary>
    internal static string Section { get; } = "Interpretation";

    /// <summary>The ID of the Horizons time zone, as defined in TZDB and <see cref="IDateTimeZoneProvider"/>.</summary>
    public string HorizonsTimeZoneID { get; set; } = null!;

    /// <summary>The key corresponding to the source in a response formatted as raw text.</summary>
    public string RawTextSource { get; set; } = null!;

    /// <summary>The key corresponding to the version in a response formatted as raw text.</summary>
    public string RawTextVersion { get; set; } = null!;

    /// <summary>Part of the <see cref="string"/> acting as a separator between blocks.</summary>
    public string BlockSeparator { get; set; } = null!;

    /// <summary>The <see cref="string"/> indicating an unavilable value.</summary>
    public string UnavailableText { get; set; } = null!;

    /// <summary>Applies the default values to <paramref name="options"/>.</summary>
    /// <param name="options">The default values are applied to these <see cref="InterpretationOptions"/>.</param>
    public static void ApplyDefaults(InterpretationOptions options)
    {
        options.HorizonsTimeZoneID = DefaultInterpretation.Default.HorizonsTimeZoneID;
        options.RawTextSource = DefaultInterpretation.Default.RawTextSource;
        options.RawTextVersion = DefaultInterpretation.Default.RawTextVersion;
        options.BlockSeparator = DefaultInterpretation.Default.BlockSeparator;
        options.UnavailableText = DefaultInterpretation.Default.UnavailableText;
    }
}