namespace SharpHorizons.Interpretation.Ephemeris;

using SharpHorizons.Settings.Interpretation.Ephemeris;

using System.Collections.Generic;

/// <summary>Provides options for how the result of an ephemeris query is interpreted.</summary>
public interface IEphemerisInterpretationOptionsProvider
{
    /// <inheritdoc cref="EphemerisInterpretationOptions.EphemerisDataStart"/>
    public abstract string EphemerisDataStart { get; }

    /// <inheritdoc cref="EphemerisInterpretationOptions.EphemerisDataBlockCount"/>
    public abstract int EphemerisDataBlockCount { get; }

    /// <inheritdoc cref="EphemerisInterpretationOptions.WestPositiveLongitude"/>
    public abstract string WestPositiveLongitude { get; }

    /// <inheritdoc cref="EphemerisInterpretationOptions.EastPositiveLongitude"/>
    public abstract string EastPositiveLongitude { get; }

    /// <inheritdoc cref="EphemerisInterpretationOptions.BoundaryEpochBCE"/>
    public abstract string BoundaryEpochBCE { get; }

    /// <inheritdoc cref="EphemerisInterpretationOptions.BoundaryEpochCE"/>
    public abstract string BoundaryEpochCE { get; }

    /// <inheritdoc cref="EphemerisInterpretationOptions.StartEpoch"/>
    public abstract string StartEpoch { get; }

    /// <inheritdoc cref="EphemerisInterpretationOptions.StopEpoch"/>
    public abstract string StopEpoch { get; }

    /// <inheritdoc cref="EphemerisInterpretationOptions.TimeSystem"/>
    public abstract string TimeSystem { get; }

    /// <inheritdoc cref="EphemerisInterpretationOptions.TimeZoneOffset"/>
    public abstract string TimeZoneOffset { get; }

    /// <inheritdoc cref="EphemerisInterpretationOptions.StepSize"/>
    public abstract string StepSize { get; }

    /// <inheritdoc cref="EphemerisInterpretationOptions.SmallPerturbers"/>
    public abstract IEnumerable<string> SmallPerturbers { get; }

    /// <inheritdoc cref="EphemerisInterpretationOptions.ReferenceSystem"/>
    public abstract string ReferenceSystem { get; }

    /// <inheritdoc cref="EphemerisInterpretationOptions.StartOfEphemeris"/>
    public abstract string StartOfEphemeris { get; }

    /// <inheritdoc cref="EphemerisInterpretationOptions.EndOfEphemeris"/>
    public abstract string EndOfEphemeris { get; }
}
