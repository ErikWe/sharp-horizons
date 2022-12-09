namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Query;
using SharpHorizons.Query.Result;
using SharpHorizons.Query.Vectors;
using SharpHorizons.Query.Vectors.Table;

using SharpMeasures;

/// <summary>Represents the header of the <see cref="IQueryResult"/> of a <see cref="IVectorsQuery"/>.</summary>
public interface IVectorsQueryHeader : IEphemerisQueryHeader
{
    /// <summary>Describes the <see cref="UnitOfLength"/> and <see cref="UnitOfTime"/> used in the result of the query.</summary>
    public abstract OutputUnits OutputUnits { get; }

    /// <summary>Describes what <see cref="VectorCorrection"/> are applied to the result of the query.</summary>
    public abstract VectorCorrection Correction { get; }

    /// <summary>Describes the <see cref="VectorTableContent"/> of the result of the query.</summary>
    public abstract VectorTableContent TableContent { get; }

    /// <summary>Describes the <see cref="Query.ReferencePlane"/> of the result of the query.</summary>
    public abstract ReferencePlane ReferencePlane { get; }
}
