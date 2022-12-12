namespace SharpHorizons.Interpretation.Ephemeris;

using SharpHorizons.Ephemeris;
using SharpHorizons.Interpretation.Ephemeris.Origin;
using SharpHorizons.Interpretation.Ephemeris.Target;
using SharpHorizons.Query;
using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Result;

using SharpMeasures;

/// <summary>Represents the header of the <see cref="IQueryResult"/> of an ephemeris query.</summary>
public interface IEphemerisHeader
{
    /// <summary>The <see cref="IEpoch"/> when the query was executed by Horizons.</summary>
    public abstract IEpoch QueryEpoch { get; }

    /// <inheritdoc cref="IEphemerisTargetHeader"/>
    public abstract IEphemerisTargetHeader TargetHeader { get; }

    /// <inheritdoc cref="IEphemerisOriginHeader"/>
    public abstract IEphemerisOriginHeader OriginHeader { get; }

    /// <summary>The <see cref="IEpoch"/> of the first <see cref="IEphemerisEntry"/>.</summary>
    public abstract IEpoch StartEpoch { get; }

    /// <summary>The <see cref="IEpoch"/> of the last <see cref="IEphemerisEntry"/>.</summary>
    public abstract IEpoch StopEpoch { get; }

    /// <summary>The <see cref="IStepSize"/> between each <see cref="IEphemerisEntry"/> - if one was used.</summary>
    public abstract IStepSize? StepSize { get; }

    /// <summary>Represents the <see cref="Query.Epoch.EpochSelectionMode"/> that was used.</summary>
    public virtual EpochSelectionMode EpochSelectionMode => StepSize is null ? EpochSelectionMode.Collection : EpochSelectionMode.Range;

    /// <summary>Represents the <see cref="Query.Epoch.TimeSystem"/> used to express the <see cref="IEpoch"/> in the <see cref="IQueryResult"/>.</summary>
    public abstract TimeSystem TimeSystem { get; }

    /// <summary>The <see cref="Time"/> offset from UTC of the timezone used to express the <see cref="IEpoch"/> in the <see cref="IQueryResult"/>.</summary>
    public abstract Time TimeZoneOffset { get; }

    /// <summary>Indicates whether small perturbers were considered when executing the query.</summary>
    public abstract bool SmallPerturbers { get; }

    /// <summary>Represents the <see cref="Query.ReferenceSystem"/> used in the <see cref="IQueryResult"/>.</summary>
    public abstract ReferenceSystem ReferenceSystem { get; }

    /// <inheritdoc cref="EphemerisQuantities"/>
    public abstract EphemerisQuantities Quantities { get; }
}
