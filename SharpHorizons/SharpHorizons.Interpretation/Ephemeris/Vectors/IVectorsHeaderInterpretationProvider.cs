namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

/// <summary>Provides the <see cref="IPartInterpreter{TInterpretation}"/> related to interpreting a <see cref="IVectorsHeader"/>.</summary>
public interface IVectorsHeaderInterpretationProvider
{
    /// <inheritdoc cref="IVectorsOutputUnitsInterpreter"/>
    public abstract IVectorsOutputUnitsInterpreter OutputUnitsInterpreter { get; }

    /// <inheritdoc cref="IVectorCorrectionInterpreter"/>
    public abstract IVectorCorrectionInterpreter CorrectionInterpreter { get; }

    /// <inheritdoc cref="IVectorTableContentInterpreter"/>
    public abstract IVectorTableContentInterpreter TableContentInterpreter { get; }

    /// <inheritdoc cref="IReferencePlaneInterpreter"/>
    public abstract IReferencePlaneInterpreter ReferencePlaneInterpreter { get; }
}
