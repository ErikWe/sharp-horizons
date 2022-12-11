namespace SharpHorizons.Interpretation.Ephemeris.Origin;

using Microsoft.Extensions.Options;

using SharpHorizons.Settings.Interpretation.Ephemeris.Origin;

using System.Collections.Generic;

/// <inheritdoc cref="IOriginInterpretationOptionsProvider"/>
internal sealed class OriginInterpretationOptionsProvider : IOriginInterpretationOptionsProvider
{
    /// <inheritdoc cref="OriginInterpretationOptions"/>
    private OriginInterpretationOptions Options { get; }

    /// <inheritdoc cref="IEphemerisInterpretationOptionsProvider"/>
    private IEphemerisInterpretationOptionsProvider EphemerisInterpretationOptionsProvider { get; }

    /// <inheritdoc cref="OriginInterpretationOptionsProvider"/>
    /// <param name="options"><inheritdoc cref="Options" path="/summary"/></param>
    /// <param name="ephemerisInterpretationOptionsProvider"><inheritdoc cref="EphemerisInterpretationOptionsProvider" path="/summary"/></param>
    public OriginInterpretationOptionsProvider(IOptions<OriginInterpretationOptions> options, IEphemerisInterpretationOptionsProvider ephemerisInterpretationOptionsProvider)
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

    string IOriginInterpretationOptionsProvider.BodyName => Options.BodyName;
    string IOriginInterpretationOptionsProvider.SiteName => Options.SiteName;
    string IOriginInterpretationOptionsProvider.GeocentricSite => Options.GeocentricSite;
    string IOriginInterpretationOptionsProvider.CustomSite => Options.CustomSite;
    string IOriginInterpretationOptionsProvider.GeodeticCoordinate => Options.GeodeticCoordinate;
    string IOriginInterpretationOptionsProvider.CylindricalCoordinate => Options.CylindricalCoordinate;
    string IOriginInterpretationOptionsProvider.ReferenceEllipsoid => Options.ReferenceEllipsoid;
    string IOriginInterpretationOptionsProvider.Radii => Options.Radii;
}
