namespace SharpHorizons.Query.Vectors;

using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.Vectors.Table;

using System;
using System.ComponentModel;

/// <summary>Handles incremental construction of <see cref="IVectorsQuery"/>.</summary>
public interface IVectorsQueryBuilder
{
    /// <summary>Constructs the <see cref="IVectorsQuery"/>.</summary>
    /// <remarks>Repeated invokation of <see cref="Build"/> will result in separate instances of <see cref="IVectorsQuery"/>.</remarks>
    /// <exception cref="InvalidOperationException"/>
    public abstract IVectorsQuery Build();

    /// <summary>Specifies the <see cref="IVectorsQuery.Target"/> of the <see cref="IVectorsQuery"/>.</summary>
    /// <param name="target">The <see cref="IVectorsQuery.Target"/> of the <see cref="IVectorsQuery"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    public abstract IVectorsQueryBuilder SpecifyTarget(ITarget target);

    /// <summary>Specifies the <see cref="IVectorsQuery.Origin"/> of the <see cref="IVectorsQuery"/>.</summary>
    /// <param name="origin">The <see cref="IVectorsQuery.Origin"/> of the <see cref="IVectorsQuery"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    public abstract IVectorsQueryBuilder SpecifyOrigin(IOrigin origin);

    /// <summary>Specifies the <see cref="IVectorsQuery.EpochSelection"/> of the <see cref="IVectorsQuery"/>.</summary>
    /// <param name="epochSelection">The <see cref="IVectorsQuery.EpochSelection"/> of the <see cref="IVectorsQuery"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    public abstract IVectorsQueryBuilder SpecifyEpochSelection(IEpochSelection epochSelection);

    /// <summary>Specifies the <see cref="IVectorsQuery.OutputFormat"/> of the <see cref="IVectorsQuery"/>.</summary>
    /// <param name="outputFormat">The <see cref="IVectorsQuery.OutputFormat"/> of the <see cref="IVectorsQuery"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract IVectorsQueryBuilder SpecifyOutputFormat(OutputFormat outputFormat);

    /// <summary>Specifies the <see cref="IVectorsQuery.ObjectDataInclusion"/> of the <see cref="IVectorsQuery"/>.</summary>
    /// <param name="objectDataInclusion">The <see cref="IVectorsQuery.ObjectDataInclusion"/> of the <see cref="IVectorsQuery"/>.</param>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract IVectorsQueryBuilder SpecifyObjectDataInclusion(ObjectDataInclusion objectDataInclusion);

    /// <summary>Specifies the <see cref="IVectorsQuery.ReferencePlane"/> of the <see cref="IVectorsQuery"/>.</summary>
    /// <param name="referencePlane">The <see cref="IVectorsQuery.ReferencePlane"/> of the <see cref="IVectorsQuery"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract IVectorsQueryBuilder SpecifyReferencePlane(ReferencePlane referencePlane);

    /// <summary>Specifies the <see cref="IVectorsQuery.ReferenceSystem"/> of the <see cref="IVectorsQuery"/>.</summary>
    /// <param name="referenceSystem">The <see cref="IVectorsQuery.ReferenceSystem"/> of the <see cref="IVectorsQuery"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract IVectorsQueryBuilder SpecifyReferenceSystem(ReferenceSystem referenceSystem);

    /// <summary>Specifies the <see cref="IVectorsQuery.OutputUnits"/> of the <see cref="IVectorsQuery"/>.</summary>
    /// <param name="outputUnits">The <see cref="IVectorsQuery.OutputUnits"/> of the <see cref="IVectorsQuery"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract IVectorsQueryBuilder SpecifyOutputUnits(OutputUnits outputUnits);

    /// <summary>Specifies the <see cref="IVectorsQuery.TableContent"/> of the <see cref="IVectorsQuery"/>.</summary>
    /// <param name="tableContent">The <see cref="IVectorsQuery.TableContent"/> of the <see cref="IVectorsQuery"/>.</param>
    /// <exception cref="ArgumentException"/>
    public abstract IVectorsQueryBuilder SpecifyTableContent(VectorTableContent tableContent);

    /// <summary>Specifies the <see cref="IVectorsQuery.Correction"/> of the <see cref="IVectorsQuery"/>.</summary>
    /// <param name="correction">The <see cref="IVectorsQuery.Correction"/> of the <see cref="IVectorsQuery"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract IVectorsQueryBuilder SpecifyCorrection(VectorCorrection correction);

    /// <summary>Specifies the <see cref="IVectorsQuery.TimePrecision"/> of the <see cref="IVectorsQuery"/>.</summary>
    /// <param name="timePrecision">The <see cref="IVectorsQuery.TimePrecision"/> of the <see cref="IVectorsQuery"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract IVectorsQueryBuilder SpecifyTimePrecision(TimePrecision timePrecision);

    /// <summary>Specifies the <see cref="IVectorsQuery.ValueSeparation"/> of the <see cref="IVectorsQuery"/>.</summary>
    /// <param name="valueSeparation">The <see cref="IVectorsQuery.ValueSeparation"/> of the <see cref="IVectorsQuery"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract IVectorsQueryBuilder SpecifyValueSeparation(ValueSeparation valueSeparation);

    /// <summary>Specifies the <see cref="IVectorsQuery.OutputLabels"/> of the <see cref="IVectorsQuery"/>.</summary>
    /// <param name="outputLabels">The <see cref="IVectorsQuery.OutputLabels"/> of the <see cref="IVectorsQuery"/>.</param>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract IVectorsQueryBuilder SpecifyOutputLabels(OutputLabels outputLabels);

    /// <summary>Specifies the <see cref="IVectorsQuery.TimeDeltaInclusion"/> of the <see cref="IVectorsQuery"/>.</summary>
    /// <param name="timeDeltaInclusion">The <see cref="IVectorsQuery.TimeDeltaInclusion"/> of the <see cref="IVectorsQuery"/>.</param>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract IVectorsQueryBuilder SpecifyTimeDeltaInclusion(TimeDeltaInclusion timeDeltaInclusion);
}
