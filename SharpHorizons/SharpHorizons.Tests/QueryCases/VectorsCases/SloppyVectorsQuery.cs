namespace SharpHorizons.Tests.QueryCases.VectorsCases;

using SharpHorizons.Query;
using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.Vectors;
using SharpHorizons.Query.Vectors.Table;

public record class SloppyVectorsQuery : IVectorsQuery
{
    public virtual ITarget Target { get; init; } = null!;
    public virtual IOrigin Origin { get; init; } = null!;
    public virtual IEpochSelection EpochSelection { get; init; } = null!;
    public virtual OutputFormat OutputFormat { get; init; }
    public virtual ObjectDataInclusion ObjectDataInclusion { get; init; }
    public virtual ReferencePlane ReferencePlane { get; init; }
    public virtual ReferenceSystem ReferenceSystem { get; init; }
    public virtual OutputUnits OutputUnits { get; init; }
    public virtual VectorTableContent TableContent { get; init; }
    public virtual VectorCorrection Correction { get; init; }
    public virtual TimePrecision TimePrecision { get; init; }
    public virtual ValueSeparation ValueSeparation { get; init; }
    public virtual OutputLabels OutputLabels { get; init; }
    public virtual TimeDeltaInclusion TimeDeltaInclusion { get; init; }
}
