namespace SharpHorizons.Interpretation.Ephemeris.Target;

using Microsoft.Extensions.Options;

using SharpHorizons.Settings.Interpretation.Ephemeris.Target;

using System.Collections.Generic;

/// <inheritdoc cref="ITargetInterpretationOptionsProvider"/>
internal sealed class TargetInterpretationOptionsProvider : ITargetInterpretationOptionsProvider
{
    /// <inheritdoc cref="TargetInterpretationOptions"/>
    private TargetInterpretationOptions Options { get; }

    /// <inheritdoc cref="IEphemerisInterpretationOptionsProvider"/>
    private IEphemerisInterpretationOptionsProvider EphemerisInterpretationOptionsProvider { get; }

    /// <inheritdoc cref="TargetInterpretationOptionsProvider"/>
    /// <param name="options"><inheritdoc cref="Options" path="/summary"/></param>
    /// <param name="ephemerisInterpretationOptionsProvider"><inheritdoc cref="EphemerisInterpretationOptionsProvider" path="/summary"/></param>
    public TargetInterpretationOptionsProvider(IOptions<TargetInterpretationOptions> options, IEphemerisInterpretationOptionsProvider ephemerisInterpretationOptionsProvider)
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

    string ITargetInterpretationOptionsProvider.BodyName => Options.BodyName;
    string ITargetInterpretationOptionsProvider.GeodeticCoordinate => Options.GeodeticCoordinate;
    string ITargetInterpretationOptionsProvider.CylindricalCoordinate => Options.CylindricalCoordinate;
    string ITargetInterpretationOptionsProvider.ReferenceEllipsoid => Options.ReferenceEllipsoid;
    string ITargetInterpretationOptionsProvider.Radii => Options.Radii;
}
