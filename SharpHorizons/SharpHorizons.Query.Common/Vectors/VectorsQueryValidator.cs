namespace SharpHorizons.Query.Vectors;

using SharpHorizons.Query;
using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.Vectors.Table;

using System;
using System.Runtime.CompilerServices;

/// <inheritdoc cref="IVectorsQueryValidator"/>
public sealed class VectorsQueryValidator : IVectorsQueryValidator
{
    /// <inheritdoc cref="IVectorTableContentValidator"/>
    public IVectorTableContentValidator TableContentValidator { get; }

    /// <inheritdoc cref="VectorsQueryValidator"/>
    /// <param name="tableContentValidator"><inheritdoc cref="TableContentValidator" path="/summary"/></param>
    public VectorsQueryValidator(IVectorTableContentValidator? tableContentValidator = null)
    {
        TableContentValidator = tableContentValidator ?? new VectorTableContentValidator();
    }

    /// <inheritdoc/>
    public void Validate(IVectorsQuery vectorsQuery, [CallerArgumentExpression(nameof(vectorsQuery))] string? argumentExpression = null)
    {
        ArgumentNullException.ThrowIfNull(vectorsQuery);

        try
        {
            ValidateTarget(vectorsQuery.Target);
            ValidateOrigin(vectorsQuery.Origin);
            ValidateEpochSelection(vectorsQuery.EpochSelection);

            ValidateOutputFormat(vectorsQuery.OutputFormat);
            ValidateObjectDataInclusion(vectorsQuery.ObjectDataInclusion);
            ValidateReferencePlane(vectorsQuery.ReferencePlane);
            ValidateReferenceSystem(vectorsQuery.ReferenceSystem);
            ValidateOutputUnits(vectorsQuery.OutputUnits);
            ValidateTableContent(vectorsQuery.TableContent);
            ValidateCorrection(vectorsQuery.Correction);
            ValidateTimePrecision(vectorsQuery.TimePrecision);
            ValidateValueSeparation(vectorsQuery.ValueSeparation);
            ValidateOutputLabels(vectorsQuery.OutputLabels);
            ValidateTimeDeltaInclusion(vectorsQuery.TimeDeltaInclusion);
        }
        catch (Exception e)
        {
            throw ArgumentExceptionFactory.InvalidState<IVectorsQuery>(argumentExpression, e);
        }
    }

    /// <inheritdoc/>
    public void ValidateTarget(ITarget target, [CallerArgumentExpression(nameof(target))] string? argumentExpression = null)
    {
        ArgumentNullException.ThrowIfNull(target, argumentExpression);
    }

    /// <inheritdoc/>
    public void ValidateOrigin(IOrigin origin, [CallerArgumentExpression(nameof(origin))] string? argumentExpression = null)
    {
        ArgumentNullException.ThrowIfNull(origin, argumentExpression);
    }

    /// <inheritdoc/>
    public void ValidateEpochSelection(IEpochSelection epochSelection, [CallerArgumentExpression(nameof(epochSelection))] string? argumentExpression = null)
    {
        ArgumentNullException.ThrowIfNull(epochSelection, argumentExpression);
    }

    /// <inheritdoc/>
    public void ValidateCorrection(VectorCorrection correction, [CallerArgumentExpression(nameof(correction))] string? argumentExpression = null)
    {
        InvalidEnumArgumentExceptionUtility.ThrowIfUnlisted(correction, argumentExpression);

        try
        {
            UnsupportedVectorCorrectionException.ThrowIfJustAberration(correction);
        }
        catch (UnsupportedVectorCorrectionException e)
        {
            throw ArgumentExceptionFactory.InvalidState<VectorCorrection>(argumentExpression, e);
        }
    }

    /// <inheritdoc/>
    public void ValidateObjectDataInclusion(ObjectDataInclusion objectDataInclusion, [CallerArgumentExpression(nameof(objectDataInclusion))] string? argumentExpression = null)
    {
        InvalidEnumArgumentExceptionUtility.ThrowIfUnlisted(objectDataInclusion, argumentExpression);
    }

    /// <inheritdoc/>
    public void ValidateOutputFormat(OutputFormat outputFormat, [CallerArgumentExpression(nameof(outputFormat))] string? argumentExpression = null)
    {
        InvalidEnumArgumentExceptionUtility.ThrowIfUnlisted(outputFormat, argumentExpression);

        if (outputFormat is OutputFormat.Unknown)
        {
            throw ArgumentExceptionFactory.UnsupportedEnumValue(outputFormat, argumentExpression);
        }
    }

    /// <inheritdoc/>
    public void ValidateOutputLabels(OutputLabels outputLabels, [CallerArgumentExpression(nameof(outputLabels))] string? argumentExpression = null)
    {
        InvalidEnumArgumentExceptionUtility.ThrowIfUnlisted(outputLabels, argumentExpression);
    }

    /// <inheritdoc/>
    public void ValidateOutputUnits(OutputUnits outputUnits, [CallerArgumentExpression(nameof(outputUnits))] string? argumentExpression = null)
    {
        InvalidEnumArgumentExceptionUtility.ThrowIfUnlisted(outputUnits, argumentExpression);

        if (outputUnits is OutputUnits.Unknown)
        {
            throw ArgumentExceptionFactory.UnsupportedEnumValue(outputUnits, argumentExpression);
        }
    }

    /// <inheritdoc/>
    public void ValidateReferencePlane(ReferencePlane referencePlane, [CallerArgumentExpression(nameof(referencePlane))] string? argumentExpression = null)
    {
        InvalidEnumArgumentExceptionUtility.ThrowIfUnlisted(referencePlane, argumentExpression);

        if (referencePlane is ReferencePlane.Unknown)
        {
            throw ArgumentExceptionFactory.UnsupportedEnumValue(referencePlane, argumentExpression);
        }
    }

    /// <inheritdoc/>
    public void ValidateReferenceSystem(ReferenceSystem referenceSystem, [CallerArgumentExpression(nameof(referenceSystem))] string? argumentExpression = null)
    {
        InvalidEnumArgumentExceptionUtility.ThrowIfUnlisted(referenceSystem, argumentExpression);

        if (referenceSystem is ReferenceSystem.Unknown)
        {
            throw ArgumentExceptionFactory.UnsupportedEnumValue(referenceSystem, argumentExpression);
        }
    }

    /// <inheritdoc/>
    public void ValidateTableContent(VectorTableContent tableContent, [CallerArgumentExpression(nameof(tableContent))] string? argumentExpression = null)
    {
        TableContentValidator.ThrowIfUnsupported(tableContent, argumentExpression);
    }

    /// <inheritdoc/>
    public void ValidateTimeDeltaInclusion(TimeDeltaInclusion timeDeltaInclusion, [CallerArgumentExpression(nameof(timeDeltaInclusion))] string? argumentExpression = null)
    {
        InvalidEnumArgumentExceptionUtility.ThrowIfUnlisted(timeDeltaInclusion, argumentExpression);
    }

    /// <inheritdoc/>
    public void ValidateTimePrecision(TimePrecision timePrecision, [CallerArgumentExpression(nameof(timePrecision))] string? argumentExpression = null)
    {
        InvalidEnumArgumentExceptionUtility.ThrowIfUnlisted(timePrecision, argumentExpression);

        if (timePrecision is TimePrecision.Unknown)
        {
            throw ArgumentExceptionFactory.UnsupportedEnumValue(timePrecision, argumentExpression);
        }
    }

    /// <inheritdoc/>
    public void ValidateValueSeparation(ValueSeparation valueSeparation, [CallerArgumentExpression(nameof(valueSeparation))] string? argumentExpression = null)
    {
        InvalidEnumArgumentExceptionUtility.ThrowIfUnlisted(valueSeparation, argumentExpression);

        if (valueSeparation is ValueSeparation.Unknown)
        {
            throw ArgumentExceptionFactory.UnsupportedEnumValue(valueSeparation, argumentExpression);
        }
    }
}
