namespace SharpHorizons.Settings.Interpretation;

using Microsoft.Extensions.Configuration;

using NodaTime;

using SharpHorizons.Query.Result;

/// <summary>Allows options related to the interpretation of <see cref="QueryResult"/> to be specified.</summary>
internal sealed class InterpretationOptions
{
    /// <summary>The identifier of the <see cref="IConfigurationSection"/> associated with <see cref="InterpretationOptions"/>.</summary>
    internal static string Section { get; } = "Interpretation";

    /// <summary>The ID of the Horizons time zone, as defined in TZDB and <see cref="IDateTimeZoneProvider"/>.</summary>
    public string HorizonsTimeZoneID { get; set; } = null!;

    /// <summary>Part of the <see cref="string"/> acting as a separator between blocks.</summary>
    public string BlockSeparator { get; set; } = null!;

    /// <summary>The <see cref="string"/> indicating an unavilable value.</summary>
    public string UnavailableText { get; set; } = null!;

    /// <summary>Applies the default values to the <see cref="InterpretationOptions"/> <paramref name="options"/>.</summary>
    /// <param name="options">The default values are applied to this <see cref="InterpretationOptions"/>.</param>
    public static void ApplyDefaults(InterpretationOptions options)
    {
        options.HorizonsTimeZoneID = DefaultInterpretationSettings.Default.HorizonsTimeZoneID;
        options.BlockSeparator = DefaultInterpretationSettings.Default.BlockSeparator;
        options.UnavailableText = DefaultInterpretationSettings.Default.UnavailableText;
    }
}
