namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Interpretation.Ephemeris;

using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IVectorsHeaderInterpretationProvider"/>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class VectorsHeaderInterpretationProvider : IVectorsHeaderInterpretationProvider
{
    public IVectorsOutputUnitsInterpreter OutputUnitsInterpreter { get; }
    public IVectorCorrectionInterpreter CorrectionInterpreter { get; }
    public IVectorTableContentInterpreter TableContentInterpreter { get; }
    public IReferencePlaneInterpreter ReferencePlaneInterpreter { get; }

    /// <inheritdoc cref="VectorsHeaderInterpretationProvider"/>
    /// <param name="outputUnitsInterpreter"><inheritdoc cref="OutputUnitsInterpreter" path="/summary"/></param>
    /// <param name="correctionInterpreter"><inheritdoc cref="CorrectionInterpreter" path="/summary"/></param>
    /// <param name="tableContentInterpreter"><inheritdoc cref="TableContentInterpreter" path="/summary"/></param>
    /// <param name="referencePlaneInterpreter"><inheritdoc cref="ReferencePlaneInterpreter" path="/summary"/></param>
    public VectorsHeaderInterpretationProvider(IVectorsOutputUnitsInterpreter outputUnitsInterpreter, IVectorCorrectionInterpreter correctionInterpreter, IVectorTableContentInterpreter tableContentInterpreter, IReferencePlaneInterpreter referencePlaneInterpreter)
    {
        OutputUnitsInterpreter = outputUnitsInterpreter;
        CorrectionInterpreter = correctionInterpreter;
        TableContentInterpreter = tableContentInterpreter;
        ReferencePlaneInterpreter = referencePlaneInterpreter;
    }
}
