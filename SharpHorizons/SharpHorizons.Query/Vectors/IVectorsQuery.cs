namespace SharpHorizons.Query.Vectors;

using SharpHorizons.Epoch;
using SharpHorizons.Calendars;
using SharpHorizons.Query;
using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.VectorTable;

using SharpMeasures;

/// <summary>Describes a query for the <see cref="IOrbitalStateVectors"/>, the <see cref="Position3"/> and <see cref="Velocity3"/>, of a <see cref="ITarget"/> relative to an <see cref="IOrigin"/>.</summary>
public interface IVectorsQuery
{
    /// <summary>The <see cref="ITarget"/>, for which the <see cref="IOrbitalStateVectors"/> are queried.</summary>
    public abstract ITarget Target { get; }

    /// <summary>The <see cref="IOrigin"/>, relative to which the <see cref="IOrbitalStateVectors"/> of the <see cref="ITarget"/> are expressed.</summary>
    public abstract IOrigin Origin { get; }

    /// <summary>Determines the <see cref="IEpoch"/> of the <see cref="IOrbitalStateVectors"/>.</summary>
    public abstract IEpochSelection Epochs { get; }

    /// <summary>Determines how the result of the query is formatted.</summary>
    public abstract OutputFormat OutputFormat { get; }

    /// <summary>Determines whether object data is included in the result of the query.</summary>
    public abstract ObjectDataInclusion ObjectDataInclusion { get; }

    /// <summary>Used together with <see cref="ReferenceSystem"/> to determine the coordinate basis.</summary>
    public abstract ReferencePlane ReferencePlane { get; }

    /// <summary>Used together with <see cref="ReferencePlane"/> to determine the coordinate basis.</summary>
    public abstract ReferenceSystem ReferenceSystem { get; }

    /// <summary>Determines what units of length and time are used to express the resulting <see cref="IOrbitalStateVectors"/>.</summary>
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

    /// <summary>Determines whether the difference between Barycentric Dynamical Time (TDB) and Universal Time (UT) is included in the result of the query.</summary>
    public abstract TimeDeltaInclusion TimeDeltaInclusion { get; }

    /// <summary>Constructs a new <see cref="IVectorsQuery"/> with an updated <see cref="OutputFormat"/>.</summary>
    /// <param name="outputFormat"><inheritdoc cref="OutputFormat" path="/summary"/></param>
    public abstract IVectorsQuery WithConfiguration(OutputFormat outputFormat);

    /// <summary>Constructs a new <see cref="IVectorsQuery"/> with an updated <see cref="ObjectDataInclusion"/>.</summary>
    /// <param name="objectDataInclusion"><inheritdoc cref="ObjectDataInclusion" path="/summary"/></param>
    public abstract IVectorsQuery WithConfiguration(ObjectDataInclusion objectDataInclusion);

    /// <summary>Constructs a new <see cref="IVectorsQuery"/> with an updated <see cref="ReferencePlane"/>.</summary>
    /// <param name="referencePlane"><inheritdoc cref="ReferencePlane" path="/summary"/></param>
    public abstract IVectorsQuery WithConfiguration(ReferencePlane referencePlane);

    /// <summary>Constructs a new <see cref="IVectorsQuery"/> with an updated <see cref="ReferenceSystem"/>.</summary>
    /// <param name="referenceSystem"><inheritdoc cref="ReferenceSystem" path="/summary"/></param>
    public abstract IVectorsQuery WithConfiguration(ReferenceSystem referenceSystem);

    /// <summary>Constructs a new <see cref="IVectorsQuery"/> with an updated <see cref="OutputUnits"/>.</summary>
    /// <param name="outputUnits"><inheritdoc cref="OutputUnits" path="/summary"/></param>
    public abstract IVectorsQuery WithConfiguration(OutputUnits outputUnits);

    /// <summary>Constructs a new <see cref="IVectorsQuery"/> with an updated <see cref="TableContent"/>.</summary>
    /// <param name="tableContent"><inheritdoc cref="TableContent" path="/summary"/></param>
    public abstract IVectorsQuery WithConfiguration(VectorTableContent tableContent);

    /// <summary>Constructs a new <see cref="IVectorsQuery"/> with an updated <see cref="Correction"/>.</summary>
    /// <param name="correction"><inheritdoc cref="Correction" path="/summary"/></param>
    public abstract IVectorsQuery WithConfiguration(VectorCorrection correction);

    /// <summary>Constructs a new <see cref="IVectorsQuery"/> with an updated <see cref="TimePrecision"/>.</summary>
    /// <param name="timePrecision"><inheritdoc cref="TimePrecision" path="/summary"/></param>
    public abstract IVectorsQuery WithConfiguration(TimePrecision timePrecision);

    /// <summary>Constructs a new <see cref="IVectorsQuery"/> with an updated <see cref="ValueSeparation"/>.</summary>
    /// <param name="valueSeparation"><inheritdoc cref="ValueSeparation" path="/summary"/></param>
    public abstract IVectorsQuery WithConfiguration(ValueSeparation valueSeparation);

    /// <summary>Constructs a new <see cref="IVectorsQuery"/> with an updated <see cref="OutputLabels"/>.</summary>
    /// <param name="outputLabels"><inheritdoc cref="OutputLabels" path="/summary"/></param>
    public abstract IVectorsQuery WithConfiguration(OutputLabels outputLabels);

    /// <summary>Constructs a new <see cref="IVectorsQuery"/> with an updated <see cref="TimeDeltaInclusion"/>.</summary>
    /// <param name="timeDeltaInclusion"><inheritdoc cref="TimeDeltaInclusion" path="/summary"/></param>
    public abstract IVectorsQuery WithConfiguration(TimeDeltaInclusion timeDeltaInclusion);

    /// <summary>Constructs a new <see cref="IVectorsQuery"/> with the new configuration. Properties that correspond to a <see langword="null"/> parameter are not modified.</summary>
    /// <param name="outputFormat"><inheritdoc cref="OutputFormat" path="/summary"/></param>
    /// <param name="objectDataInclusion"><inheritdoc cref="ObjectDataInclusion" path="/summary"/></param>
    /// <param name="referencePlane"><inheritdoc cref="ReferencePlane" path="/summary"/></param>
    /// <param name="referenceSystem"><inheritdoc cref="ReferenceSystem" path="/summary"/></param>
    /// <param name="outputUnits"><inheritdoc cref="OutputUnits" path="/summary"/></param>
    /// <param name="tableContent"><inheritdoc cref="TableContent" path="/summary"/></param>
    /// <param name="correction"><inheritdoc cref="Correction" path="/summary"/></param>
    /// <param name="timePrecision"><inheritdoc cref="TimePrecision" path="/summary"/></param>
    /// <param name="valueSeparation"><inheritdoc cref="ValueSeparation" path="/summary"/></param>
    /// <param name="outputLabels"><inheritdoc cref="OutputLabels" path="/summary"/></param>
    /// <param name="timeDeltaInclusion"><inheritdoc cref="TimeDeltaInclusion" path="/summary"/></param>
    public abstract IVectorsQuery WithConfiguration(OutputFormat? outputFormat = null, ObjectDataInclusion? objectDataInclusion = null, ReferencePlane? referencePlane = null, ReferenceSystem? referenceSystem = null, OutputUnits? outputUnits = null,
        VectorTableContent? tableContent = null, VectorCorrection? correction = null, TimePrecision? timePrecision = null, ValueSeparation? valueSeparation = null, OutputLabels? outputLabels = null, TimeDeltaInclusion? timeDeltaInclusion = null);
}
