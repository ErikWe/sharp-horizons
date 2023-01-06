namespace SharpHorizons.Query.Vectors;

using SharpHorizons.Query;
using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.Vectors.Table;

using System;

/// <inheritdoc cref="IVectorsQueryValidator"/>
internal sealed class VectorsQueryValidator : IVectorsQueryValidator
{
    /// <inheritdoc cref="IVectorTableContentValidator"/>
    public IVectorTableContentValidator TableContentValidator { get; }

    /// <summary>Provides <see langword="this"/> as a <see cref="IVectorsQueryValidator"/>.</summary>
    private IVectorsQueryValidator Validator => this;

    /// <inheritdoc cref="VectorsQueryValidator"/>
    /// <param name="tableContentValidator"><inheritdoc cref="TableContentValidator" path="/summary"/></param>
    public VectorsQueryValidator(IVectorTableContentValidator? tableContentValidator = null)
    {
        TableContentValidator = tableContentValidator ?? new VectorTableContentValidator();
    }

    void IVectorsQueryValidator.Validate(IVectorsQuery vectorsQuery, string? argumentExpression)
    {
        ArgumentNullException.ThrowIfNull(vectorsQuery);

        try
        {
            Validator.ValidateTarget(vectorsQuery.Target);
            Validator.ValidateOrigin(vectorsQuery.Origin);
            Validator.ValidateEpochSelection(vectorsQuery.EpochSelection);

            Validator.ValidateOutputFormat(vectorsQuery.OutputFormat);
            Validator.ValidateObjectDataInclusion(vectorsQuery.ObjectDataInclusion);
            Validator.ValidateReferencePlane(vectorsQuery.ReferencePlane);
            Validator.ValidateReferenceSystem(vectorsQuery.ReferenceSystem);
            Validator.ValidateOutputUnits(vectorsQuery.OutputUnits);
            Validator.ValidateTableContent(vectorsQuery.TableContent);
            Validator.ValidateCorrection(vectorsQuery.Correction);
            Validator.ValidateTimePrecision(vectorsQuery.TimePrecision);
            Validator.ValidateValueSeparation(vectorsQuery.ValueSeparation);
            Validator.ValidateOutputLabels(vectorsQuery.OutputLabels);
            Validator.ValidateTimeDeltaInclusion(vectorsQuery.TimeDeltaInclusion);
        }
        catch (Exception e)
        {
            throw ArgumentExceptionFactory.InvalidState<IVectorsQuery>(argumentExpression, e);
        }
    }

    void IVectorsQueryValidator.ValidateTarget(ITarget target, string? argumentExpression)
    {
        ArgumentNullException.ThrowIfNull(target, argumentExpression);
    }

    void IVectorsQueryValidator.ValidateOrigin(IOrigin origin, string? argumentExpression)
    {
        ArgumentNullException.ThrowIfNull(origin, argumentExpression);
    }

    void IVectorsQueryValidator.ValidateEpochSelection(IEpochSelection epochSelection, string? argumentExpression)
    {
        ArgumentNullException.ThrowIfNull(epochSelection, argumentExpression);
    }

    void IVectorsQueryValidator.ValidateCorrection(VectorCorrection correction, string? argumentExpression)
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

    void IVectorsQueryValidator.ValidateObjectDataInclusion(ObjectDataInclusion objectDataInclusion, string? argumentExpression)
    {
        InvalidEnumArgumentExceptionUtility.ThrowIfUnlisted(objectDataInclusion, argumentExpression);
    }

    void IVectorsQueryValidator.ValidateOutputFormat(OutputFormat outputFormat, string? argumentExpression)
    {
        InvalidEnumArgumentExceptionUtility.ThrowIfUnlisted(outputFormat, argumentExpression);

        if (outputFormat is OutputFormat.Unknown)
        {
            throw ArgumentExceptionFactory.UnsupportedEnumValue(outputFormat, argumentExpression);
        }
    }

    void IVectorsQueryValidator.ValidateOutputLabels(OutputLabels outputLabels, string? argumentExpression)
    {
        InvalidEnumArgumentExceptionUtility.ThrowIfUnlisted(outputLabels, argumentExpression);
    }

    void IVectorsQueryValidator.ValidateOutputUnits(OutputUnits outputUnits, string? argumentExpression)
    {
        InvalidEnumArgumentExceptionUtility.ThrowIfUnlisted(outputUnits, argumentExpression);

        if (outputUnits is OutputUnits.Unknown)
        {
            throw ArgumentExceptionFactory.UnsupportedEnumValue(outputUnits, argumentExpression);
        }
    }

    void IVectorsQueryValidator.ValidateReferencePlane(ReferencePlane referencePlane, string? argumentExpression)
    {
        InvalidEnumArgumentExceptionUtility.ThrowIfUnlisted(referencePlane, argumentExpression);

        if (referencePlane is ReferencePlane.Unknown)
        {
            throw ArgumentExceptionFactory.UnsupportedEnumValue(referencePlane, argumentExpression);
        }
    }

    void IVectorsQueryValidator.ValidateReferenceSystem(ReferenceSystem referenceSystem, string? argumentExpression)
    {
        InvalidEnumArgumentExceptionUtility.ThrowIfUnlisted(referenceSystem, argumentExpression);

        if (referenceSystem is ReferenceSystem.Unknown)
        {
            throw ArgumentExceptionFactory.UnsupportedEnumValue(referenceSystem, argumentExpression);
        }
    }

    void IVectorsQueryValidator.ValidateTableContent(VectorTableContent tableContent, string? argumentExpression)
    {
        TableContentValidator.ThrowIfUnsupported(tableContent, argumentExpression);
    }

    void IVectorsQueryValidator.ValidateTimeDeltaInclusion(TimeDeltaInclusion timeDeltaInclusion, string? argumentExpression)
    {
        InvalidEnumArgumentExceptionUtility.ThrowIfUnlisted(timeDeltaInclusion, argumentExpression);
    }

    void IVectorsQueryValidator.ValidateTimePrecision(TimePrecision timePrecision, string? argumentExpression)
    {
        InvalidEnumArgumentExceptionUtility.ThrowIfUnlisted(timePrecision, argumentExpression);

        if (timePrecision is TimePrecision.Unknown)
        {
            throw ArgumentExceptionFactory.UnsupportedEnumValue(timePrecision, argumentExpression);
        }
    }

    void IVectorsQueryValidator.ValidateValueSeparation(ValueSeparation valueSeparation, string? argumentExpression)
    {
        InvalidEnumArgumentExceptionUtility.ThrowIfUnlisted(valueSeparation, argumentExpression);

        if (valueSeparation is ValueSeparation.Unknown)
        {
            throw ArgumentExceptionFactory.UnsupportedEnumValue(valueSeparation, argumentExpression);
        }
    }
}
