﻿namespace SharpHorizons.Interpretation;

using Microsoft.Extensions.Options;

/// <summary>Provides options for how the result of a query is interpreted.</summary>
internal sealed class InterpretationOptionsProvider : IInterpretationOptionsProvider
{
    /// <inheritdoc cref="InterpretationOptions"/>
    private InterpretationOptions Options { get; }

    /// <inheritdoc cref="InterpretationOptionsProvider"/>
    /// <param name="options"><inheritdoc cref="Options" path="/summary"/></param>
    public InterpretationOptionsProvider(IOptions<InterpretationOptions> options)
    {
        Options = options.Value;
    }

    string IInterpretationOptionsProvider.HorizonsTimeZoneID => Options.HorizonsTimeZoneID;
    string IInterpretationOptionsProvider.RawTextSource => Options.RawTextSource;
    string IInterpretationOptionsProvider.RawTextVersion => Options.RawTextVersion;
    string IInterpretationOptionsProvider.BlockSeparator => Options.BlockSeparator;
    string IInterpretationOptionsProvider.UnavailableText => Options.UnavailableText;
}
