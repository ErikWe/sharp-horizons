namespace SharpHorizons.Query.Vectors;

using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.Vectors.Table;

using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

/// <summary>Validates <see cref="IVectorsQuery"/> and the components of <see cref="IVectorsQuery"/>.</summary>
public interface IVectorsQueryValidator
{
    /// <summary>Validates the <see cref="IVectorsQuery"/> <paramref name="vectorsQuery"/>, throwing an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="vectorsQuery">This <see cref="IVectorsQuery"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="vectorsQuery"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract void Validate([NotNull] IVectorsQuery vectorsQuery, [CallerArgumentExpression(nameof(vectorsQuery))] string? argumentExpression = null);

    /// <summary>Validates the <see cref="IVectorsQuery.Target"/> <paramref name="target"/>, throwing an <see cref="ArgumentNullException"/> if <see langword="null"/>.</summary>
    /// <param name="target">This <see cref="ITarget"/>, representing <see cref="IVectorsQuery.Target"/>, is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="target"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    public abstract void ValidateTarget([NotNull] ITarget target, [CallerArgumentExpression(nameof(target))] string? argumentExpression = null);

    /// <summary>Validates the <see cref="IVectorsQuery.Origin"/> <paramref name="origin"/>, throwing an <see cref="ArgumentNullException"/> if <see langword="null"/>.</summary>
    /// <param name="origin">This <see cref="IOrigin"/>, representing <see cref="IVectorsQuery.Origin"/>, is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="origin"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    public abstract void ValidateOrigin([NotNull] IOrigin origin, [CallerArgumentExpression(nameof(origin))] string? argumentExpression = null);

    /// <summary>Validates the <see cref="IVectorsQuery.EpochSelection"/> <paramref name="epochSelection"/>, throwing an <see cref="ArgumentNullException"/> if <see langword="null"/>.</summary>
    /// <param name="epochSelection">This <see cref="IEpochSelection"/>, representing <see cref="IVectorsQuery.EpochSelection"/>, is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="epochSelection"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    public abstract void ValidateEpochSelection([NotNull] IEpochSelection epochSelection, [CallerArgumentExpression(nameof(epochSelection))] string? argumentExpression = null);

    /// <summary>Validates the <see cref="IVectorsQuery.OutputFormat"/> <paramref name="outputFormat"/>, throwing an <see cref="ArgumentException"/> if invalid or unsupported.</summary>
    /// <param name="outputFormat">This <see cref="OutputFormat"/>, representing <see cref="IVectorsQuery.OutputFormat"/>, is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="outputFormat"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract void ValidateOutputFormat(OutputFormat outputFormat, [CallerArgumentExpression(nameof(outputFormat))] string? argumentExpression = null);

    /// <summary>Validates the <see cref="IVectorsQuery.ObjectDataInclusion"/> <paramref name="objectDataInclusion"/>, throwing an <see cref="InvalidEnumArgumentException"/> if invalid.</summary>
    /// <param name="objectDataInclusion">This <see cref="ObjectDataInclusion"/>, representing <see cref="IVectorsQuery.ObjectDataInclusion"/>, is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="objectDataInclusion"/>.</param>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract void ValidateObjectDataInclusion(ObjectDataInclusion objectDataInclusion, [CallerArgumentExpression(nameof(objectDataInclusion))] string? argumentExpression = null);

    /// <summary>Validates the <see cref="IVectorsQuery.ReferencePlane"/> <paramref name="referencePlane"/>, throwing an <see cref="ArgumentException"/> if invalid or unsupported.</summary>
    /// <param name="referencePlane">This <see cref="ReferencePlane"/>, representing <see cref="IVectorsQuery.ReferencePlane"/>, is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="referencePlane"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract void ValidateReferencePlane(ReferencePlane referencePlane, [CallerArgumentExpression(nameof(referencePlane))] string? argumentExpression = null);

    /// <summary>Validates the <see cref="IVectorsQuery.ReferenceSystem"/> <paramref name="referenceSystem"/>, throwing an <see cref="ArgumentException"/> if invalid or unsupported.</summary>
    /// <param name="referenceSystem">This <see cref="ReferenceSystem"/>, representing <see cref="IVectorsQuery.ReferenceSystem"/>, is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="referenceSystem"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract void ValidateReferenceSystem(ReferenceSystem referenceSystem, [CallerArgumentExpression(nameof(referenceSystem))] string? argumentExpression = null);

    /// <summary>Validates the <see cref="IVectorsQuery.OutputUnits"/> <paramref name="outputUnits"/>, throwing an <see cref="ArgumentException"/> if invalid or unsupported.</summary>
    /// <param name="outputUnits">This <see cref="OutputUnits"/>, representing <see cref="IVectorsQuery.OutputUnits"/>, is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="outputUnits"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract void ValidateOutputUnits(OutputUnits outputUnits, [CallerArgumentExpression(nameof(outputUnits))] string? argumentExpression = null);

    /// <summary>Validates the <see cref="IVectorsQuery.TableContent"/> <paramref name="tableContent"/>, throwing an <see cref="ArgumentException"/> if invalid or unsupported.</summary>
    /// <param name="tableContent">This <see cref="VectorTableContent"/>, representing <see cref="IVectorsQuery.TableContent"/>, is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="tableContent"/>.</param>
    /// <exception cref="ArgumentException"/>
    public abstract void ValidateTableContent(VectorTableContent tableContent, [CallerArgumentExpression(nameof(tableContent))] string? argumentExpression = null);

    /// <summary>Validates the <see cref="IVectorsQuery.Correction"/> <paramref name="correction"/>, throwing an <see cref="ArgumentException"/> if invalid or unsupported.</summary>
    /// <param name="correction">This <see cref="VectorCorrection"/>, representing <see cref="IVectorsQuery.Correction"/>, is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="correction"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract void ValidateCorrection(VectorCorrection correction, [CallerArgumentExpression(nameof(correction))] string? argumentExpression = null);

    /// <summary>Validates the <see cref="IVectorsQuery.TimePrecision"/> <paramref name="timePrecision"/>, throwing an <see cref="ArgumentException"/> if invalid or unsupported.</summary>
    /// <param name="timePrecision">This <see cref="TimePrecision"/>, representing <see cref="IVectorsQuery.TimePrecision"/>, is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="timePrecision"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract void ValidateTimePrecision(TimePrecision timePrecision, [CallerArgumentExpression(nameof(timePrecision))] string? argumentExpression = null);

    /// <summary>Validates the <see cref="IVectorsQuery.ValueSeparation"/> <paramref name="valueSeparation"/>, throwing an <see cref="ArgumentException"/> if invalid or unsupported.</summary>
    /// <param name="valueSeparation">This <see cref="ValueSeparation"/>, representing <see cref="IVectorsQuery.ValueSeparation"/>, is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="valueSeparation"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract void ValidateValueSeparation(ValueSeparation valueSeparation, [CallerArgumentExpression(nameof(valueSeparation))] string? argumentExpression = null);

    /// <summary>Validates the <see cref="IVectorsQuery.OutputLabels"/> <paramref name="outputLabels"/>, throwing an <see cref="InvalidEnumArgumentException"/> if invalid.</summary>
    /// <param name="outputLabels">This <see cref="OutputLabels"/>, representing <see cref="IVectorsQuery.OutputLabels"/>, is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="outputLabels"/>.</param>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract void ValidateOutputLabels(OutputLabels outputLabels, [CallerArgumentExpression(nameof(outputLabels))] string? argumentExpression = null);

    /// <summary>Validates the <see cref="IVectorsQuery.TimeDeltaInclusion"/> <paramref name="timeDeltaInclusion"/>, throwing an <see cref="InvalidEnumArgumentException"/> if invalid.</summary>
    /// <param name="timeDeltaInclusion">This <see cref="TimeDeltaInclusion"/>, representing <see cref="IVectorsQuery.TimeDeltaInclusion"/>, is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="timeDeltaInclusion"/>.</param>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract void ValidateTimeDeltaInclusion(TimeDeltaInclusion timeDeltaInclusion, [CallerArgumentExpression(nameof(timeDeltaInclusion))] string? argumentExpression = null);
}
