namespace SharpHorizons.Interpretation;

using Microsoft.Extensions.Options;

using SharpHorizons.Settings.Interpretation;

using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IInterpretationOptionsProvider"/>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
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
    string IInterpretationOptionsProvider.UnavailableText => Options.UnavailableText;
}
