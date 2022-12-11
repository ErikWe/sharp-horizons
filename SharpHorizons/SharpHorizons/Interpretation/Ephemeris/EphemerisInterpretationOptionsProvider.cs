namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.Extensions.Options;

using SharpHorizons.Settings.Interpretation.Ephemeris;

using System.Collections.Generic;

/// <inheritdoc cref="IEphemerisInterpretationOptionsProvider"/>
internal sealed class EphemerisInterpretationOptionsProvider : IEphemerisInterpretationOptionsProvider
{
    /// <inheritdoc cref="EphemerisInterpretationOptions"/>
    private EphemerisInterpretationOptions Options { get; }

    /// <inheritdoc cref="IInterpretationOptionsProvider"/>
    private IInterpretationOptionsProvider InterpretationOptionsProvider { get; }

    /// <inheritdoc cref="EphemerisInterpretationOptionsProvider"/>
    /// <param name="options"><inheritdoc cref="Options" path="/summary"/></param>
    /// <param name="interpretationOptionsProvider"><inheritdoc cref="InterpretationOptionsProvider" path="/summary"/></param>
    public EphemerisInterpretationOptionsProvider(IOptions<EphemerisInterpretationOptions> options, IInterpretationOptionsProvider interpretationOptionsProvider)
    {
        Options = options.Value;
        InterpretationOptionsProvider = interpretationOptionsProvider;
    }

    string IInterpretationOptionsProvider.HorizonsTimeZoneID => InterpretationOptionsProvider.HorizonsTimeZoneID;
    string IInterpretationOptionsProvider.RawTextSource => InterpretationOptionsProvider.RawTextSource;
    string IInterpretationOptionsProvider.RawTextVersion => InterpretationOptionsProvider.RawTextVersion;
    string IInterpretationOptionsProvider.BlockSeparator => InterpretationOptionsProvider.BlockSeparator;
    string IInterpretationOptionsProvider.UnavailableText => InterpretationOptionsProvider.UnavailableText;

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
    string IEphemerisInterpretationOptionsProvider.ReferenceSystem => Options.ReferenceSystem;
    string IEphemerisInterpretationOptionsProvider.ReferencePlane => Options.ReferencePlane;
}
