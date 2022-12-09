namespace SharpHorizons.Interpretation.Ephemeris;

using SharpHorizons.Ephemeris;
using SharpHorizons.Interpretation.Ephemeris.Origin;
using SharpHorizons.Interpretation.Ephemeris.Target;
using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Result;

using SharpMeasures;

using System.Diagnostics.CodeAnalysis;

/// <summary>Represents the header of the <see cref="IQueryResult"/> of a ephemeris query.</summary>
public interface IEphemerisQueryHeader
{
    /// <summary>The <see cref="IEpoch"/> when the query was executed by Horizons.</summary>
    public abstract IEpoch QueryTime { get; }

    /// <inheritdoc cref="IEphemerisQueryTargetHeader"/>
    public abstract IEphemerisQueryTargetHeader TargetHeader { get; }

    /// <inheritdoc cref="IEphemerisQueryOriginHeader"/>
    public abstract IEphemerisQueryOriginHeader OriginHeader { get; }

    /// <summary>The <see cref="IEpoch"/> of the first <see cref="IEphemerisEntry"/>.</summary>
    public abstract IEpoch StartTime { get; }

    /// <summary>The <see cref="IEpoch"/> of the last <see cref="IEphemerisEntry"/>.</summary>
    public abstract IEpoch StopTime { get; }

    /// <summary>The <see cref="IStepSize"/> between each <see cref="IEphemerisEntry"/> - if one was used.</summary>
    public abstract IStepSize? StepSize { get; }

    /// <summary>Indicates whether the epochs were defined through a list of discrete epochs, rather than through a <see cref="StepSize"/>.</summary>
    [MemberNotNullWhen(false, nameof(StepSize))]
    public abstract bool UsedDiscreteTimeList { get; }

    /// <summary>The <see cref="Time"/> offset from UTC of the timezone used in the <see cref="IQueryResult"/>.</summary>
    public abstract Time TimeZoneOffset { get; }

    /// <summary>Indicates whether small perturbers were considered when executing the query.</summary>
    public abstract bool SmallPerturbers { get; }
}
