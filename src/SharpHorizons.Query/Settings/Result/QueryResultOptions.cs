﻿namespace SharpHorizons.Settings.Query.Result;

using Microsoft.Extensions.Configuration;

using SharpHorizons.Query.Result;

using System.Diagnostics.CodeAnalysis;

/// <summary>Allows options related to query results to be specified.</summary>
/// <remarks>Once specified, a <see cref="IQueryResultOptionsProvider"/> should be used to access the options.</remarks>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class QueryResultOptions
{
    /// <summary>The identifier of the <see cref="IConfigurationSection"/> associated with <see cref="QueryResultOptions"/>.</summary>
    internal static string Section { get; } = "Result";

    /// <inheritdoc cref="IQueryResultOptionsProvider.RawTextSource"/>
    public string RawTextSource { get; set; } = null!;

    /// <inheritdoc cref="IQueryResultOptionsProvider.RawTextVersion"/>
    public string RawTextVersion { get; set; } = null!;

    /// <summary>Applies the default values to the <see cref="QueryResultOptions"/> <paramref name="options"/>.</summary>
    /// <param name="options">The default values are applied to this <see cref="QueryResultOptions"/>.</param>
    public static void ApplyDefaults(QueryResultOptions options)
    {
        options.RawTextSource = DefaultQueryResultSettings.Default.RawTextSource;
        options.RawTextVersion = DefaultQueryResultSettings.Default.RawTextVersion;
    }
}
