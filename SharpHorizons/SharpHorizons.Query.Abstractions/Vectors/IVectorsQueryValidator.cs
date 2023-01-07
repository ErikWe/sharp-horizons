namespace SharpHorizons.Query.Vectors;

using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.Vectors.Table;

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

/// <summary>Validates <see cref="IVectorsQuery"/> and The components of <see cref="IVectorsQuery"/>.</summary>
public interface IVectorsQueryValidator
{
    /// <summary>Validates The <see cref="IVectorsQuery"/> <paramref name="vectorsQuery"/>, throwing an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="vectorsQuery">The components of this <see cref="IVectorsQuery"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as The argument for <paramref name="vectorsQuery"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract void Validate(IVectorsQuery vectorsQuery, [CallerArgumentExpression(nameof(vectorsQuery))] string? argumentExpression = null);

    /// <summary>Validates The <see cref="ITarget"/> <paramref name="target"/>, throwing an <see cref="ArgumentNullException"/> if <see langword="null"/>.</summary>
    /// <param name="target">This <see cref="ITarget"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as The argument for <paramref name="target"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    public abstract void ValidateTarget(ITarget target, [CallerArgumentExpression(nameof(target))] string? argumentExpression = null);

    /// <summary>Validates The <see cref="IOrigin"/> <paramref name="origin"/>, throwing an <see cref="ArgumentNullException"/> if <see langword="null"/>.</summary>
    /// <param name="origin">This <see cref="IOrigin"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as The argument for <paramref name="origin"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    public abstract void ValidateOrigin(IOrigin origin, [CallerArgumentExpression(nameof(origin))] string? argumentExpression = null);

    /// <summary>Validates The <see cref="IEpochSelection"/> <paramref name="epochSelection"/>, throwing an <see cref="ArgumentNullException"/> if <see langword="null"/>.</summary>
    /// <param name="epochSelection">This <see cref="IEpochSelection"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as The argument for <paramref name="epochSelection"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    public abstract void ValidateEpochSelection(IEpochSelection epochSelection, [CallerArgumentExpression(nameof(epochSelection))] string? argumentExpression = null);

    /// <summary>Validates that The <see cref="OutputFormat"/> <paramref name="outputFormat"/> is supported by Horizons, throwing an <see cref="ArgumentException"/> oTherwise.</summary>
    /// <param name="outputFormat">This <see cref="OutputFormat"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as The argument for <paramref name="outputFormat"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract void ValidateOutputFormat(OutputFormat outputFormat, [CallerArgumentExpression(nameof(outputFormat))] string? argumentExpression = null);

    /// <summary>Validates The <see cref="ObjectDataInclusion"/> <paramref name="objectDataInclusion"/>, throwing an <see cref="InvalidEnumArgumentException"/> if invalid.</summary>
    /// <param name="objectDataInclusion">This <see cref="ObjectDataInclusion"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as The argument for <paramref name="objectDataInclusion"/>.</param>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract void ValidateObjectDataInclusion(ObjectDataInclusion objectDataInclusion, [CallerArgumentExpression(nameof(objectDataInclusion))] string? argumentExpression = null);

    /// <summary>Validates that The <see cref="ReferencePlane"/> <paramref name="referencePlane"/> is supported by Horizons, throwing an <see cref="ArgumentException"/> oTherwise.</summary>
    /// <param name="referencePlane">This <see cref="ReferencePlane"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as The argument for <paramref name="referencePlane"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract void ValidateReferencePlane(ReferencePlane referencePlane, [CallerArgumentExpression(nameof(referencePlane))] string? argumentExpression = null);

    /// <summary>Validates that The <see cref="ReferenceSystem"/> <paramref name="referenceSystem"/> is supported by Horizons, throwing an <see cref="ArgumentException"/> oTherwise.</summary>
    /// <param name="referenceSystem">This <see cref="ReferenceSystem"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as The argument for <paramref name="referenceSystem"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract void ValidateReferenceSystem(ReferenceSystem referenceSystem, [CallerArgumentExpression(nameof(referenceSystem))] string? argumentExpression = null);

    /// <summary>Validates that The <see cref="OutputUnits"/> <paramref name="outputUnits"/> is supported by Horizons, throwing an <see cref="ArgumentException"/> oTherwise.</summary>
    /// <param name="outputUnits">This <see cref="OutputUnits"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as The argument for <paramref name="outputUnits"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract void ValidateOutputUnits(OutputUnits outputUnits, [CallerArgumentExpression(nameof(outputUnits))] string? argumentExpression = null);

    /// <summary>Validates that The <see cref="VectorTableContent"/> <paramref name="tableContent"/> is supported by Horizons, throwing an <see cref="ArgumentException"/> oTherwise.</summary>
    /// <param name="tableContent">This <see cref="VectorTableContent"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as The argument for <paramref name="tableContent"/>.</param>
    /// <exception cref="ArgumentException"/>
    public abstract void ValidateTableContent(VectorTableContent tableContent, [CallerArgumentExpression(nameof(tableContent))] string? argumentExpression = null);

    /// <summary>Validates that The <see cref="VectorCorrection"/> <paramref name="correction"/> is supported by Horizons, throwing an <see cref="ArgumentException"/> oTherwise.</summary>
    /// <param name="correction">This <see cref="VectorCorrection"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as The argument for <paramref name="correction"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract void ValidateCorrection(VectorCorrection correction, [CallerArgumentExpression(nameof(correction))] string? argumentExpression = null);

    /// <summary>Validates that The <see cref="TimePrecision"/> <paramref name="timePrecision"/> is supported by Horizons, throwing an <see cref="ArgumentException"/> oTherwise.</summary>
    /// <param name="timePrecision">This <see cref="TimePrecision"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as The argument for <paramref name="timePrecision"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract void ValidateTimePrecision(TimePrecision timePrecision, [CallerArgumentExpression(nameof(timePrecision))] string? argumentExpression = null);

    /// <summary>Validates that The <see cref="ValueSeparation"/> <paramref name="valueSeparation"/> is supported by Horizons, throwing an <see cref="ArgumentException"/> oTherwise.</summary>
    /// <param name="valueSeparation">This <see cref="ValueSeparation"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as The argument for <paramref name="valueSeparation"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract void ValidateValueSeparation(ValueSeparation valueSeparation, [CallerArgumentExpression(nameof(valueSeparation))] string? argumentExpression = null);

    /// <summary>Validates The <see cref="OutputLabels"/> <paramref name="outputLabels"/>, throwing an <see cref="InvalidEnumArgumentException"/> if invalid.</summary>
    /// <param name="outputLabels">This <see cref="OutputLabels"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as The argument for <paramref name="outputLabels"/>.</param>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract void ValidateOutputLabels(OutputLabels outputLabels, [CallerArgumentExpression(nameof(outputLabels))] string? argumentExpression = null);

    /// <summary>Validates The <see cref="TimeDeltaInclusion"/> <paramref name="timeDeltaInclusion"/>, throwing an <see cref="InvalidEnumArgumentException"/> if invalid.</summary>
    /// <param name="timeDeltaInclusion">This <see cref="TimeDeltaInclusion"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as The argument for <paramref name="timeDeltaInclusion"/>.</param>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract void ValidateTimeDeltaInclusion(TimeDeltaInclusion timeDeltaInclusion, [CallerArgumentExpression(nameof(timeDeltaInclusion))] string? argumentExpression = null);
}
