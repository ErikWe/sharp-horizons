namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Query.Vectors;

/// <summary>Provides options related to the interpretation of the result of <see cref="IVectorsQuery"/>.</summary>
public interface IVectorsInterpretationOptionsProvider
{
    /// <summary>The key corresponding to the <see cref="Query.OutputUnits"/>.</summary>
    public abstract string OutputUnits { get; }

    /// <summary>The key corresponding to the <see cref="Query.Vectors.VectorCorrection"/>.</summary>
    public abstract string VectorCorrection { get; }

    /// <summary>The key corresponding to the <see cref="Query.Vectors.Table.VectorTableContent"/>.</summary>
    public abstract string VectorTableContent { get; }

    /// <summary>The key corresponding to the <see cref="Query.ReferencePlane"/>.</summary>
    public abstract string ReferencePlane { get; }
}
