namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using Microsoft.Extensions.Options;

using SharpHorizons.Settings.Interpretation.Ephemeris.Vectors;

/// <inheritdoc cref="IVectorsInterpretationOptionsProvider"/>
internal sealed class VectorsInterpretationOptionsProvider : IVectorsInterpretationOptionsProvider
{
    /// <inheritdoc cref="VectorsInterpretationOptions"/>
    private VectorsInterpretationOptions Options { get; }

    /// <inheritdoc cref="EphemerisInterpretationOptionsProvider"/>
    /// <param name="options"><inheritdoc cref="Options" path="/summary"/></param>
    public VectorsInterpretationOptionsProvider(IOptions<VectorsInterpretationOptions> options)
    {
        Options = options.Value;
    }

    string IVectorsInterpretationOptionsProvider.OutputUnits => Options.OutputUnits;
    string IVectorsInterpretationOptionsProvider.VectorCorrection => Options.VectorCorrection;
    string IVectorsInterpretationOptionsProvider.VectorTableContent => Options.VectorTableContent;
    string IVectorsInterpretationOptionsProvider.ReferencePlane => Options.ReferencePlane;
}
