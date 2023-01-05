namespace SharpHorizons.Query.Vectors;

using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.Vectors.Table;

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

/// <summary>Validates <see cref="IVectorsQuery"/> and the components of <see cref="IVectorsQuery"/>.</summary>
public interface IVectorsQueryValidator
{
    /// <summary>Validates the components of <paramref name="vectorsQuery"/>.</summary>
    /// <param name="vectorsQuery">The components of this <see cref="IVectorsQuery"/> is validated.</param>
    /// <param name="argumentExpression">THe expression used as the argument for <paramref name="vectorsQuery"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract void Validate(IVectorsQuery vectorsQuery, [CallerArgumentExpression(nameof(vectorsQuery))] string? argumentExpression = null);

    /// <summary>Validates that <paramref name="target"/> represents a valid <see cref="ITarget"/>.</summary>
    /// <param name="target">This <see cref="ITarget"/> is validated.</param>
    /// <param name="argumentExpression">THe expression used as the argument for <paramref name="target"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    public abstract void ValidateTarget(ITarget target, [CallerArgumentExpression(nameof(target))] string? argumentExpression = null);

    /// <summary>Validates that <paramref name="origin"/> represents a valid <see cref="IOrigin"/>.</summary>
    /// <param name="origin">This <see cref="IOrigin"/> is validated.</param>
    /// <param name="argumentExpression">THe expression used as the argument for <paramref name="origin"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    public abstract void ValidateOrigin(IOrigin origin, [CallerArgumentExpression(nameof(origin))] string? argumentExpression = null);

    /// <summary>Validates that <paramref name="epochSelection"/> represents a valid <see cref="IEpochSelection"/>.</summary>
    /// <param name="epochSelection">This <see cref="IEpochSelection"/> is validated.</param>
    /// <param name="argumentExpression">THe expression used as the argument for <paramref name="epochSelection"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    public abstract void ValidateEpochSelection(IEpochSelection epochSelection, [CallerArgumentExpression(nameof(epochSelection))] string? argumentExpression = null);

    /// <summary>Validates that <paramref name="outputFormat"/> represents an <see cref="OutputFormat"/> supported by Horizons, and throws an <see cref="ArgumentException"/> otherwise.</summary>
    /// <param name="outputFormat">This <see cref="OutputFormat"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="outputFormat"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract void ValidateOutputFormat(OutputFormat outputFormat, [CallerArgumentExpression(nameof(outputFormat))] string? argumentExpression = null);

    /// <summary>Validates that <paramref name="objectDataInclusion"/> represents an <see cref="ObjectDataInclusion"/> supported by Horizons, and throws an <see cref="InvalidEnumArgumentException"/> otherwise.</summary>
    /// <param name="objectDataInclusion">This <see cref="ObjectDataInclusion"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="objectDataInclusion"/>.</param>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract void ValidateObjectDataInclusion(ObjectDataInclusion objectDataInclusion, [CallerArgumentExpression(nameof(objectDataInclusion))] string? argumentExpression = null);

    /// <summary>Validates that <paramref name="referencePlane"/> represents an <see cref="ReferencePlane"/> supported by Horizons, and throws an <see cref="ArgumentException"/> otherwise.</summary>
    /// <param name="referencePlane">This <see cref="ReferencePlane"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="referencePlane"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract void ValidateReferencePlane(ReferencePlane referencePlane, [CallerArgumentExpression(nameof(referencePlane))] string? argumentExpression = null);

    /// <summary>Validates that <paramref name="referenceSystem"/> represents an <see cref="ReferenceSystem"/> supported by Horizons, and throws an <see cref="ArgumentException"/> otherwise.</summary>
    /// <param name="referenceSystem">This <see cref="ReferenceSystem"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="referenceSystem"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract void ValidateReferenceSystem(ReferenceSystem referenceSystem, [CallerArgumentExpression(nameof(referenceSystem))] string? argumentExpression = null);

    /// <summary>Validates that <paramref name="outputUnits"/> represents an <see cref="OutputUnits"/> supported by Horizons, and throws an <see cref="ArgumentException"/> otherwise.</summary>
    /// <param name="outputUnits">This <see cref="OutputUnits"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="outputUnits"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract void ValidateOutputUnits(OutputUnits outputUnits, [CallerArgumentExpression(nameof(outputUnits))] string? argumentExpression = null);

    /// <summary>Validates that <paramref name="tableContent"/> represents a <see cref="VectorTableContent"/> supported by Horizons, and throws an <see cref="ArgumentException"/> otherwise.</summary>
    /// <param name="tableContent">This <see cref="VectorTableContent"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="tableContent"/>.</param>
    /// <exception cref="ArgumentException"/>
    public abstract void ValidateTableContent(VectorTableContent tableContent, [CallerArgumentExpression(nameof(tableContent))] string? argumentExpression = null);

    /// <summary>Validates that <paramref name="correction"/> represents an <see cref="VectorCorrection"/> supported by Horizons, and throws an <see cref="ArgumentException"/> otherwise.</summary>
    /// <param name="correction">This <see cref="VectorCorrection"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="correction"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract void ValidateCorrection(VectorCorrection correction, [CallerArgumentExpression(nameof(correction))] string? argumentExpression = null);

    /// <summary>Validates that <paramref name="timePrecision"/> represents an <see cref="TimePrecision"/> supported by Horizons, and throws an <see cref="ArgumentException"/> otherwise.</summary>
    /// <param name="timePrecision">This <see cref="TimePrecision"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="timePrecision"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract void ValidateTimePrecision(TimePrecision timePrecision, [CallerArgumentExpression(nameof(timePrecision))] string? argumentExpression = null);

    /// <summary>Validates that <paramref name="valueSeparation"/> represents an <see cref="ValueSeparation"/> supported by Horizons, and throws an <see cref="ArgumentException"/> otherwise.</summary>
    /// <param name="valueSeparation">This <see cref="ValueSeparation"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="valueSeparation"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract void ValidateValueSeparation(ValueSeparation valueSeparation, [CallerArgumentExpression(nameof(valueSeparation))] string? argumentExpression = null);

    /// <summary>Validates that <paramref name="outputLabels"/> represents an <see cref="OutputLabels"/> supported by Horizons, and throws an <see cref="InvalidEnumArgumentException"/> otherwise.</summary>
    /// <param name="outputLabels">This <see cref="OutputLabels"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="outputLabels"/>.</param>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract void ValidateOutputLabels(OutputLabels outputLabels, [CallerArgumentExpression(nameof(outputLabels))] string? argumentExpression = null);

    /// <summary>Validates that <paramref name="timeDeltaInclusion"/> represents an <see cref="TimeDeltaInclusion"/> supported by Horizons, and throws an <see cref="InvalidEnumArgumentException"/> otherwise.</summary>
    /// <param name="timeDeltaInclusion">This <see cref="TimeDeltaInclusion"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="timeDeltaInclusion"/>.</param>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract void ValidateTimeDeltaInclusion(TimeDeltaInclusion timeDeltaInclusion, [CallerArgumentExpression(nameof(timeDeltaInclusion))] string? argumentExpression = null);
}
