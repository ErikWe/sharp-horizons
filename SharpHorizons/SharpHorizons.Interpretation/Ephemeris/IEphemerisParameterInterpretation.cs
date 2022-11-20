namespace SharpHorizons.Interpretation.Ephemeris;

using SharpHorizons.Epoch;
using SharpHorizons.Ephemeris;
using SharpHorizons.Interpretation.Ephemeris.Origin;
using SharpHorizons.Interpretation.Ephemeris.Target;
using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;

using System;

/// <summary>Represents data interpreted about the parameters of a query for an ephemeris.</summary>
public interface IEphemerisParameterInterpretation
{
    /// <summary>The <see cref="DateTime"/> describing when the query was executed by Horizons.</summary>
    public abstract DateTime QueryTime { get; }

    /// <summary>Represents data interpreted about the <see cref="ITarget"/> of the query.</summary>
    public abstract ITargetDataInterpretation Target { get; }

    /// <summary>Represents data interpreted about the <see cref="IOrigin"/> of the query.</summary>
    public abstract IOriginDataInterpretation Origin { get; }

    /// <summary>The <see cref="IEpoch"/> of the first <see cref="IEphemerisEntry"/>.</summary>
    public abstract IEpoch StartTime { get; }

    /// <summary>The <see cref="IEpoch"/> of the last <see cref="IEphemerisEntry"/>.</summary>
    public abstract IEpoch StopTime { get; }

    /// <summary>The <see cref="IStepSize"/> between each <see cref="IEphemerisEntry"/> - if one was used.</summary>
    public abstract IStepSize? StepSize { get; }

    /// <summary>Describes whether small perturbers were considered when executing the query.</summary>
    public abstract bool SmallPerturbers { get; }
}
