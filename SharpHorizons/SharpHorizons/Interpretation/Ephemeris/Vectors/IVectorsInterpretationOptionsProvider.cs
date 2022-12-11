namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Query.Vectors;

/// <summary>Provides options for how the result of a <see cref="IVectorsQuery"/> is interpreted.</summary>
public interface IVectorsInterpretationOptionsProvider : IEphemerisInterpretationOptionsProvider
{
    /// <inheritdoc cref="VectorsInterpretationOptions.OutputUnits"/>
    public abstract string OutputUnits { get; }

    /// <inheritdoc cref="VectorsInterpretationOptions.VectorCorrection"/>
    public abstract string VectorCorrection { get; }

    /// <inheritdoc cref="VectorsInterpretationOptions.VectorTableContent"/>
    public abstract string VectorTableContent { get; }
}
