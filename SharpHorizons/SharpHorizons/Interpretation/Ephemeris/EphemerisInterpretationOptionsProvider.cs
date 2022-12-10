namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.Extensions.Options;

using System.Collections.Generic;

/// <inheritdoc cref="IEphemerisInterpretationOptionsProvider"/>
internal sealed class EphemerisInterpretationOptionsProvider : IEphemerisInterpretationOptionsProvider
{
    /// <inheritdoc cref="EphemerisInterpretationOptions"/>
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
    string IEphemerisInterpretationOptionsProvider.BoundaryEpochBCE => Options.BoundaryEpochBCE;
    string IEphemerisInterpretationOptionsProvider.BoundaryEpochCE => Options.BoundaryEpochCE;
    string IEphemerisInterpretationOptionsProvider.StartEpoch => Options.StartEpoch;
    string IEphemerisInterpretationOptionsProvider.StopEpoch => Options.StopEpoch;
    string IEphemerisInterpretationOptionsProvider.TimeSystem => Options.TimeSystem;
    string IEphemerisInterpretationOptionsProvider.TimeZoneOffset => Options.TimeZoneOffset;
    string IEphemerisInterpretationOptionsProvider.StepSize => Options.StepSize;
    IEnumerable<string> IEphemerisInterpretationOptionsProvider.SmallPerturbers => Options.SmallPerturbers;
}
