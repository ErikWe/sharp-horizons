﻿namespace SharpHorizons.Vectors;

using SharpHorizons.Query;
using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.VectorTable;

using SharpMeasures;

/// <inheritdoc cref="IVectorsQuery"/>
internal sealed record class VectorsQuery : IVectorsQuery
{
    /// <inheritdoc/>
    public ITarget Target { get; }

    /// <inheritdoc/>
    public IOrigin Origin { get; }

    /// <inheritdoc/>
    public IEpochSelection Epochs { get; }

    /// <inheritdoc/>
    public OutputFormat OutputFormat { get; init; } = OutputFormat.JSON;

    /// <inheritdoc/>
    public ObjectDataInclusion ObjectDataInclusion { get; init; } = ObjectDataInclusion.Disable;

    /// <inheritdoc/>
    public ReferencePlane ReferencePlane { get; init; } = ReferencePlane.Ecliptic;

    /// <inheritdoc/>
    public ReferenceSystem ReferenceSystem { get; init; } = ReferenceSystem.ICRF;

    /// <inheritdoc/>
    public OutputUnits OutputUnits { get; init; } = OutputUnits.KilometresAndSeconds;

    /// <inheritdoc/>
    public VectorTableContent TableContent { get; init; } = new(VectorTableQuantities.StateVectors, VectorTableUncertainties.None);

    /// <inheritdoc/>
    public VectorCorrection Correction { get; init; } = VectorCorrection.None;

    /// <inheritdoc/>
    public TimePrecision TimePrecision { get; init; } = TimePrecision.Second;

    /// <inheritdoc/>
    public ValueSeparation ValueSeparation { get; init; } = ValueSeparation.WhitespaceSeparation;

    /// <inheritdoc/>
    public OutputLabels OutputLabels { get; init; } = OutputLabels.Disable;

    /// <inheritdoc/>
    public TimeDeltaInclusion TimeDeltaInclusion { get; init; } = TimeDeltaInclusion.Disable;

    /// <summary>Describes a query to retrieve the orbital state vectors, the <see cref="Position3"/> and <see cref="Velocity3"/>, of <paramref name="target"/>.</summary>
    /// <param name="target"><inheritdoc cref="Target" path="/summary"/></param>
    /// <param name="origin"><inheritdoc cref="Origin" path="/summary"/></param>
    /// <param name="epochs"><inheritdoc cref="Epochs" path="/summary"/></param>
    private VectorsQuery(ITarget target, IOrigin origin, IEpochSelection epochs)
    {
        Target = target;
        Origin = origin;

        Epochs = epochs;
    }

    /// <summary><inheritdoc cref="VectorsQueryInstantiation" path="/summary"/></summary>
    public static VectorsQueryInstantiation Instantiation => (target, origin, epochs) => new VectorsQuery(target, origin, epochs);

    IVectorsQuery IVectorsQuery.WithConfiguration(OutputFormat outputFormat) => this with { OutputFormat = outputFormat };
    IVectorsQuery IVectorsQuery.WithConfiguration(ObjectDataInclusion objectDataInclusion) => this with { ObjectDataInclusion = objectDataInclusion };
    IVectorsQuery IVectorsQuery.WithConfiguration(ReferencePlane referencePlane) => this with { ReferencePlane = referencePlane };
    IVectorsQuery IVectorsQuery.WithConfiguration(ReferenceSystem referenceSystem) => this with { ReferenceSystem = referenceSystem };
    IVectorsQuery IVectorsQuery.WithConfiguration(OutputUnits outputUnits) => this with { OutputUnits = outputUnits };
    IVectorsQuery IVectorsQuery.WithConfiguration(VectorTableContent tableContent) => this with { TableContent = tableContent };
    IVectorsQuery IVectorsQuery.WithConfiguration(VectorCorrection correction) => this with { Correction = correction };
    IVectorsQuery IVectorsQuery.WithConfiguration(TimePrecision timePrecision) => this with { TimePrecision = timePrecision };
    IVectorsQuery IVectorsQuery.WithConfiguration(ValueSeparation valueSeparation) => this with { ValueSeparation = valueSeparation };
    IVectorsQuery IVectorsQuery.WithConfiguration(OutputLabels outputLabels) => this with { OutputLabels = outputLabels };
    IVectorsQuery IVectorsQuery.WithConfiguration(TimeDeltaInclusion timeDeltaInclusion) => this with { TimeDeltaInclusion = timeDeltaInclusion };
    IVectorsQuery IVectorsQuery.WithConfiguration(OutputFormat? outputFormat, ObjectDataInclusion? objectDataInclusion, ReferencePlane? referencePlane, ReferenceSystem? referenceSystem, OutputUnits? outputUnits, VectorTableContent? tableContent, VectorCorrection? correction, TimePrecision? timePrecision, ValueSeparation? valueSeparation, OutputLabels? outputLabels, TimeDeltaInclusion? timeDeltaInclusion) => this with
    {
        OutputFormat = outputFormat ?? OutputFormat,
        ObjectDataInclusion = objectDataInclusion ?? ObjectDataInclusion,
        ReferencePlane = referencePlane ?? ReferencePlane,
        ReferenceSystem = referenceSystem ?? ReferenceSystem,
        OutputUnits = outputUnits ?? OutputUnits,
        TableContent = tableContent ?? TableContent,
        Correction = correction ?? Correction,
        TimePrecision = timePrecision ?? TimePrecision,
        ValueSeparation = valueSeparation ?? ValueSeparation,
        OutputLabels = outputLabels ?? OutputLabels,
        TimeDeltaInclusion = timeDeltaInclusion ?? TimeDeltaInclusion
    };
}
