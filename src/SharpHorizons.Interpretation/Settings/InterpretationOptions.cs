namespace SharpHorizons.Settings.Interpretation;

using Microsoft.Extensions.Configuration;

using SharpHorizons.Interpretation;
using SharpHorizons.Query.Result;

using System.Diagnostics.CodeAnalysis;

/// <summary>Allows options related to the interpretation of <see cref="QueryResult"/> to be specified.</summary>
/// <remarks>Once specified, a <see cref="IInterpretationOptionsProvider"/> should be used to access the options.</remarks>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class InterpretationOptions
{
    /// <summary>The identifier of the <see cref="IConfigurationSection"/> associated with <see cref="InterpretationOptions"/>.</summary>
    internal static string Section { get; } = "Interpretation";

    /// <inheritdoc cref="IInterpretationOptionsProvider.HorizonsTimeZoneID"/>
    public string HorizonsTimeZoneID { get; set; } = null!;

    /// <inheritdoc cref="IInterpretationOptionsProvider.BlockSeparator"/>
    public string BlockSeparator { get; set; } = null!;

    /// <inheritdoc cref="IInterpretationOptionsProvider.UnavailableText"/>
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
