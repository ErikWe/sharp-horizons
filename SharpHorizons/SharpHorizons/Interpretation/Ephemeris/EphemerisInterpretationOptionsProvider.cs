namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.Extensions.Options;

/// <inheritdoc cref="IEphemerisInterpretationOptionsProvider"/>
internal sealed class EphemerisInterpretationOptionsProvider : IEphemerisInterpretationOptionsProvider
{
    /// <summary><inheritdoc cref="EphemerisInterpretationOptions" path="/summary"/></summary>
    private EphemerisInterpretationOptions Options { get; }

    /// <inheritdoc cref="EphemerisInterpretationOptionsProvider"/>
    /// <param name="options"><inheritdoc cref="Options" path="/summary"/></param>
    public EphemerisInterpretationOptionsProvider(IOptions<EphemerisInterpretationOptions> options)
    {
        Options = options.Value;
    }

    string IEphemerisInterpretationOptionsProvider.EphemerisDataStart => Options.EphemerisDataStart;
    int IEphemerisInterpretationOptionsProvider.EphemerisDataBlockCount => Options.EphemerisDataBlockCount;
    string IEphemerisInterpretationOptionsProvider.WestPositiveLongitude => Options.WestPositiveLongitude;
    string IEphemerisInterpretationOptionsProvider.EastPositiveLongitude => Options.EastPositiveLongitude;
}
