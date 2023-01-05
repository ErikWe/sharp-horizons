namespace SharpHorizons.Tests.QueryCases.VectorsCases.IVectorsQueryComposerCases;

using SharpHorizons.Query;
using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.Vectors;
using SharpHorizons.Query.Vectors.Table;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class SloppyVectorsQuery : IVectorsQuery
{
    public ITarget Target => throw new NotImplementedException();

    public IOrigin Origin => throw new NotImplementedException();

    public IEpochSelection EpochSelection => throw new NotImplementedException();

    public OutputFormat OutputFormat => throw new NotImplementedException();

    public ObjectDataInclusion ObjectDataInclusion => throw new NotImplementedException();

    public ReferencePlane ReferencePlane => throw new NotImplementedException();

    public ReferenceSystem ReferenceSystem => throw new NotImplementedException();

    public OutputUnits OutputUnits => throw new NotImplementedException();

    public VectorTableContent TableContent => throw new NotImplementedException();

    public VectorCorrection Correction => throw new NotImplementedException();

    public TimePrecision TimePrecision => throw new NotImplementedException();

    public ValueSeparation ValueSeparation => throw new NotImplementedException();

    public OutputLabels OutputLabels => throw new NotImplementedException();

    public TimeDeltaInclusion TimeDeltaInclusion => throw new NotImplementedException();

    public IVectorsQuery WithConfiguration(OutputFormat outputFormat)
    {
        throw new NotImplementedException();
    }

    public IVectorsQuery WithConfiguration(ObjectDataInclusion objectDataInclusion)
    {
        throw new NotImplementedException();
    }

    public IVectorsQuery WithConfiguration(ReferencePlane referencePlane)
    {
        throw new NotImplementedException();
    }

    public IVectorsQuery WithConfiguration(ReferenceSystem referenceSystem)
    {
        throw new NotImplementedException();
    }

    public IVectorsQuery WithConfiguration(OutputUnits outputUnits)
    {
        throw new NotImplementedException();
    }

    public IVectorsQuery WithConfiguration(VectorTableContent tableContent)
    {
        throw new NotImplementedException();
    }

    public IVectorsQuery WithConfiguration(VectorCorrection correction)
    {
        throw new NotImplementedException();
    }

    public IVectorsQuery WithConfiguration(TimePrecision timePrecision)
    {
        throw new NotImplementedException();
    }

    public IVectorsQuery WithConfiguration(ValueSeparation valueSeparation)
    {
        throw new NotImplementedException();
    }

    public IVectorsQuery WithConfiguration(OutputLabels outputLabels)
    {
        throw new NotImplementedException();
    }

    public IVectorsQuery WithConfiguration(TimeDeltaInclusion timeDeltaInclusion)
    {
        throw new NotImplementedException();
    }

    public IVectorsQuery WithConfiguration(OutputFormat? outputFormat = null, ObjectDataInclusion? objectDataInclusion = null, ReferencePlane? referencePlane = null, ReferenceSystem? referenceSystem = null, OutputUnits? outputUnits = null, VectorTableContent? tableContent = null, VectorCorrection? correction = null, TimePrecision? timePrecision = null, ValueSeparation? valueSeparation = null, OutputLabels? outputLabels = null, TimeDeltaInclusion? timeDeltaInclusion = null)
    {
        throw new NotImplementedException();
    }

    public IVectorsQuery WithEpochSelection(IEpochSelection epochSelection)
    {
        throw new NotImplementedException();
    }

    public IVectorsQuery WithOrigin(IOrigin origin)
    {
        throw new NotImplementedException();
    }

    public IVectorsQuery WithTarget(ITarget target)
    {
        throw new NotImplementedException();
    }
}
