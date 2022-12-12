namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Interpretation.Ephemeris;

/// <inheritdoc cref="IVectorsHeaderInterpretationProvider"/>
internal sealed class VectorsHeaderInterpretationProvider : IVectorsHeaderInterpretationProvider
{
    public IVectorsOutputUnitsInterpreter OutputUnitsInterpreter { get; private init; }
    public IVectorCorrectionInterpreter CorrectionInterpreter { get; private init; }
    public IVectorTableContentInterpreter TableContentInterpreter { get; private init; }
    public IReferencePlaneInterpreter ReferencePlaneInterpreter { get; private init; }

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
