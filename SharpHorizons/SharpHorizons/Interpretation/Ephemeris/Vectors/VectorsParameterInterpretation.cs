namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Epoch;
using SharpHorizons.Interpretation.Ephemeris.Origin;
using SharpHorizons.Interpretation.Ephemeris.Target;
using SharpHorizons.Query;
using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.VectorTable;

using System;

/// <inheritdoc cref="IVectorsParameterInterpretation"/>
internal sealed class VectorsParameterInterpretation : IVectorsParameterInterpretation
{
    public required DateTime QueryTime { get; init; }

    public required ITargetDataInterpretation Target { get; init; }
    public required IOriginDataInterpretation Origin { get; init; }

    public required IEpoch StartTime { get; init; }
    public required IEpoch StopTime { get; init; }
    public required IStepSize? StepSize { get; init; }

    public required bool SmallPerturbers { get; init; }

    public required OutputUnits OutputUnits { get; init; }
    public required VectorCorrection Correction { get; init; }
    public required VectorTableContent TableContent { get; init; }
    public required ReferencePlane ReferencePlane { get; init; }

    /// <inheritdoc cref="VectorsParameterInterpretation"/>
    public VectorsParameterInterpretation() { }
}
