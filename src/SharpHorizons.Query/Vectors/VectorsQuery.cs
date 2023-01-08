namespace SharpHorizons.Query.Vectors;

using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.Vectors.Table;

using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IVectorsQuery"/>
internal sealed record class VectorsQuery : IVectorsQuery
{
    public required ITarget Target { get; init; }
    public required IOrigin Origin { get; init; }
    public required IEpochSelection EpochSelection { get; init; }

    public OutputFormat OutputFormat { get; init; } = OutputFormat.JSON;
    public ObjectDataInclusion ObjectDataInclusion { get; init; } = ObjectDataInclusion.Disable;
    public ReferencePlane ReferencePlane { get; init; } = ReferencePlane.Ecliptic;
    public ReferenceSystem ReferenceSystem { get; init; } = ReferenceSystem.ICRF;
    public OutputUnits OutputUnits { get; init; } = OutputUnits.KilometresAndSeconds;
    public VectorTableContent TableContent { get; init; } = new(VectorTableQuantities.StateVectors, VectorTableUncertainties.None);
    public VectorCorrection Correction { get; init; } = VectorCorrection.None;
    public TimePrecision TimePrecision { get; init; } = TimePrecision.Second;
    public ValueSeparation ValueSeparation { get; init; } = ValueSeparation.WhitespaceSeparation;
    public OutputLabels OutputLabels { get; init; } = OutputLabels.Disable;
    public TimeDeltaInclusion TimeDeltaInclusion { get; init; } = TimeDeltaInclusion.Disable;

    /// <inheritdoc cref="VectorsQuery"/>
    public VectorsQuery() { }

    /// <inheritdoc cref="VectorsQuery"/>
    /// <param name="target"><inheritdoc cref="Target" path="/summary"/></param>
    /// <param name="origin"><inheritdoc cref="Origin" path="/summary"/></param>
    /// <param name="epochSelection"><inheritdoc cref="EpochSelection" path="/summary"/></param>
    [SetsRequiredMembers]
    public VectorsQuery(ITarget target, IOrigin origin, IEpochSelection epochSelection)
    {
        Target = target;
        Origin = origin;

        EpochSelection = epochSelection;
    }
}
