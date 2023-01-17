namespace SharpHorizons.Query.Vectors;

using SharpHorizons.Ephemeris;
using SharpHorizons.Ephemeris.Vectors;
using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.Vectors.Table;

using SharpMeasures;

using System;

/// <summary>Describes a query for an <see cref="IEphemeris{TEntry}"/> of <see cref="IOrbitalStateVectors"/>-related properties, such as <see cref="Position3"/> and <see cref="Velocity3"/>, of a <see cref="ITarget"/> relative to an <see cref="IOrigin"/>.</summary>
public interface IVectorsQuery : IEquatable<IVectorsQuery>
{
    /// <summary>The <see cref="ITarget"/>, which the resulting <see cref="IEphemeris{TEntry}"/> describes.</summary>
    public abstract ITarget Target { get; }

    /// <summary>The <see cref="IOrigin"/>, relative to which the <see cref="ITarget"/> is described in the resulting <see cref="IEphemeris{TEntry}"/>.</summary>
    public abstract IOrigin Origin { get; }

    /// <summary>The <see cref="IEpochSelection"/>, describing the <see cref="IEpoch"/> of the individual <see cref="IEphemerisEntry"/> in the resulting <see cref="IEphemeris{TEntry}"/>.</summary>
    public abstract IEpochSelection EpochSelection { get; }

    /// <summary>Determines how the result of the <see cref="IVectorsQuery"/> is formatted.</summary>
    public abstract OutputFormat OutputFormat { get; }

    /// <summary>Determines whether object data is included in the result of the <see cref="IVectorsQuery"/>.</summary>
    public abstract ObjectDataInclusion ObjectDataInclusion { get; }

    /// <summary>Used together with <see cref="ReferenceSystem"/> to determine the coordinate basis used in the resulting <see cref="IEphemeris{TEntry}"/>.</summary>
    public abstract ReferencePlane ReferencePlane { get; }

    /// <summary>Used together with <see cref="ReferencePlane"/> to determine the coordinate basis used in the resulting <see cref="IEphemeris{TEntry}"/>.</summary>
    public abstract ReferenceSystem ReferenceSystem { get; }

    /// <summary>Determines what <see cref="UnitOfLength"/> and <see cref="UnitOfTime"/> are used in the resulting <see cref="IEphemeris{TEntry}"/>.</summary>
    public abstract OutputUnits OutputUnits { get; }

    /// <summary>Determines what quantities and associated uncertainties are included in the result of the query.</summary>
    public abstract VectorTableContent TableContent { get; }

    /// <summary>Determines what corrections to apply to the result of the query.</summary>
    public abstract VectorCorrection Correction { get; }

    /// <summary>Determines with what precision time is expressed in the query and in the result of the query.</summary>
    public abstract TimePrecision TimePrecision { get; }

    /// <summary>Determines how values are separated in the result of the query.</summary>
    public abstract ValueSeparation ValueSeparation { get; }

    /// <summary>Determines whether the individual values in the result of the query are labelled.</summary>
    public abstract OutputLabels OutputLabels { get; }

    /// <summary>Determines whether the <see cref="Time"/> difference between <see cref="TimeSystem.TDB"/> and <see cref="TimeSystem.UT"/> is included in the result of the query.</summary>
    public abstract TimeDeltaInclusion TimeDeltaInclusion { get; }
}
