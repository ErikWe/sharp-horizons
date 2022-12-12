namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Query.Vectors;
using SharpHorizons.Settings.Interpretation.Ephemeris.Vectors;

/// <summary>Provides options for how the result of a <see cref="IVectorsQuery"/> is interpreted.</summary>
public interface IVectorsInterpretationOptionsProvider
{
    /// <inheritdoc cref="VectorsInterpretationOptions.OutputUnits"/>
    public abstract string OutputUnits { get; }

    /// <inheritdoc cref="VectorsInterpretationOptions.VectorCorrection"/>
    public abstract string VectorCorrection { get; }

    /// <inheritdoc cref="VectorsInterpretationOptions.VectorTableContent"/>
    public abstract string VectorTableContent { get; }

    /// <inheritdoc cref="VectorsInterpretationOptions.ReferencePlane"/>
    public abstract string ReferencePlane { get; }
}
