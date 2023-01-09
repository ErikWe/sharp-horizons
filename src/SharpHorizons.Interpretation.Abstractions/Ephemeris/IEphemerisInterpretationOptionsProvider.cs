namespace SharpHorizons.Interpretation.Ephemeris;

using SharpHorizons.Ephemeris;
using SharpHorizons.Query.Epoch;

using SharpMeasures;

using System.Collections.Generic;

/// <summary>Provides options related to the interpretation of <see cref="IEphemeris{TEntry}"/></summary>
public interface IEphemerisInterpretationOptionsProvider
{
    /// <summary>The <see cref="string"/> indicating the start of the ephemeris data.</summary>
    public abstract string EphemerisDataStart { get; }

    /// <summary>The number of blocks used for the ephemeris data.</summary>
    public abstract int EphemerisDataBlockCount { get; }

    /// <summary>The <see cref="string"/> indicating <see cref="LongitudeDefinition.WestPositive"/>.</summary>
    public abstract string WestPositiveLongitude { get; }

    /// <summary>The <see cref="string"/> indicating <see cref="LongitudeDefinition.EastPositive"/>.</summary>
    public abstract string EastPositiveLongitude { get; }

    /// <summary>The <see cref="string"/> indicating that the <see cref="IEpoch"/> of the first or last <see cref="IEphemerisEntry"/> represents an epoch before the common era (before year 0).</summary>
    public abstract string BoundaryEpochBCE { get; }

    /// <summary>The <see cref="string"/> indicating that the <see cref="IEpoch"/> of the first or last <see cref="IEphemerisEntry"/> represents an epoch in the common era (after year 0).</summary>
    public abstract string BoundaryEpochCE { get; }

    /// <summary>The key corresponding to the <see cref="IEpoch"/> of the first <see cref="IEphemerisEntry"/>.</summary>
    public abstract string StartEpoch { get; }

    /// <summary>The key corresponding to the <see cref="IEpoch"/> of the last <see cref="IEphemerisEntry"/>.</summary>
    public abstract string StopEpoch { get; }

    /// <summary>The key corresponding to the <see cref="Query.Epoch.TimeSystem"/>.</summary>
    public abstract string TimeSystem { get; }

    /// <summary>The key corresponding to the <see cref="Time"/> offset to UTC.</summary>
    public abstract string TimeZoneOffset { get; }

    /// <summary>The key corresponding to the <see cref="IStepSize"/>.</summary>
    public abstract string StepSize { get; }

    /// <summary>The keys corresponding to the inclusion of small-body perturbers.</summary>
    public abstract IEnumerable<string> SmallPerturbers { get; }

    /// <summary>The key corresponding to the <see cref="Query.ReferenceSystem"/>.</summary>
    public abstract string ReferenceSystem { get; }

    /// <summary>The <see cref="string"/> indicating the start of the <see cref="IEphemeris{TEntry}"/>.</summary>
    public abstract string StartOfEphemeris { get; }

    /// <summary>The <see cref="string"/> indicating the end of the <see cref="IEphemeris{TEntry}"/>.</summary>
    public abstract string EndOfEphemeris { get; }
}
