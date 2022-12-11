namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using Microsoft.Extensions.Options;

using SharpHorizons.Settings.Interpretation.Ephemeris.Vectors;

using System.Collections.Generic;

/// <inheritdoc cref="IVectorsInterpretationOptionsProvider"/>
internal sealed class VectorsInterpretationOptionsProvider : IVectorsInterpretationOptionsProvider
{
    /// <inheritdoc cref="VectorsInterpretationOptions"/>
    private VectorsInterpretationOptions Options { get; }

    /// <inheritdoc cref="IEphemerisInterpretationOptionsProvider"/>
    private IEphemerisInterpretationOptionsProvider EphemerisInterpretationOptionsProvider { get; }

    /// <inheritdoc cref="EphemerisInterpretationOptionsProvider"/>
    /// <param name="options"><inheritdoc cref="Options" path="/summary"/></param>
    /// <param name="ephemerisInterpretationOptionsProvider"><inheritdoc cref="EphemerisInterpretationOptionsProvider" path="/summary"/></param>
    public VectorsInterpretationOptionsProvider(IOptions<VectorsInterpretationOptions> options, IEphemerisInterpretationOptionsProvider ephemerisInterpretationOptionsProvider)
    {
        Options = options.Value;
        EphemerisInterpretationOptionsProvider = ephemerisInterpretationOptionsProvider;
    }

    string IInterpretationOptionsProvider.HorizonsTimeZoneID => EphemerisInterpretationOptionsProvider.HorizonsTimeZoneID;
    string IInterpretationOptionsProvider.RawTextSource => EphemerisInterpretationOptionsProvider.RawTextSource;
    string IInterpretationOptionsProvider.RawTextVersion => EphemerisInterpretationOptionsProvider.RawTextVersion;
    string IInterpretationOptionsProvider.BlockSeparator => EphemerisInterpretationOptionsProvider.BlockSeparator;
    string IInterpretationOptionsProvider.UnavailableText => EphemerisInterpretationOptionsProvider.UnavailableText;

    string IEphemerisInterpretationOptionsProvider.EphemerisDataStart => EphemerisInterpretationOptionsProvider.EphemerisDataStart;
    int IEphemerisInterpretationOptionsProvider.EphemerisDataBlockCount => EphemerisInterpretationOptionsProvider.EphemerisDataBlockCount;
    string IEphemerisInterpretationOptionsProvider.WestPositiveLongitude => EphemerisInterpretationOptionsProvider.WestPositiveLongitude;
    string IEphemerisInterpretationOptionsProvider.EastPositiveLongitude => EphemerisInterpretationOptionsProvider.EastPositiveLongitude;
    string IEphemerisInterpretationOptionsProvider.BoundaryEpochBCE => EphemerisInterpretationOptionsProvider.BoundaryEpochBCE;
    string IEphemerisInterpretationOptionsProvider.BoundaryEpochCE => EphemerisInterpretationOptionsProvider.BoundaryEpochCE;
    string IEphemerisInterpretationOptionsProvider.StartEpoch => EphemerisInterpretationOptionsProvider.StartEpoch;
    string IEphemerisInterpretationOptionsProvider.StopEpoch => EphemerisInterpretationOptionsProvider.StopEpoch;
    string IEphemerisInterpretationOptionsProvider.TimeSystem => EphemerisInterpretationOptionsProvider.TimeSystem;
    string IEphemerisInterpretationOptionsProvider.TimeZoneOffset => EphemerisInterpretationOptionsProvider.TimeZoneOffset;
    string IEphemerisInterpretationOptionsProvider.StepSize => EphemerisInterpretationOptionsProvider.StepSize;
    IEnumerable<string> IEphemerisInterpretationOptionsProvider.SmallPerturbers => EphemerisInterpretationOptionsProvider.SmallPerturbers;
    string IEphemerisInterpretationOptionsProvider.ReferenceSystem => EphemerisInterpretationOptionsProvider.ReferenceSystem;
    string IEphemerisInterpretationOptionsProvider.ReferencePlane => EphemerisInterpretationOptionsProvider.ReferencePlane;

    string IVectorsInterpretationOptionsProvider.OutputUnits => Options.OutputUnits;
    string IVectorsInterpretationOptionsProvider.VectorCorrection => Options.VectorCorrection;
    string IVectorsInterpretationOptionsProvider.VectorTableContent => Options.VectorTableContent;
}
