namespace SharpHorizons.Query.Vectors;

using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.Vectors.Table;

using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

/// <inheritdoc cref="IVectorsQuery"/>
internal sealed record class VectorsQuery : IVectorsQuery
{
    /// <inheritdoc cref="IVectorTableContentValidator"/>
    private IVectorTableContentValidator TableContentValidator { get; }

    public required ITarget Target { get; init; }
    public required IOrigin Origin { get; init; }
    public required IEpochSelection Epochs { get; init; }

    public OutputFormat OutputFormat { get; init; } = OutputFormat.JSON;
    public ObjectDataInclusion ObjectDataInclusion { get; init; } = ObjectDataInclusion.Disable;
    public ReferencePlane ReferencePlane { get; init; } = ReferencePlane.Ecliptic;
    public ReferenceSystem ReferenceSystem { get; init; } = ReferenceSystem.ICRF;
    public OutputUnits OutputUnits { get; init; } = OutputUnits.KilometresAndSeconds;
    public VectorTableContent TableContent { get; init; } = new(VectorTableQuantities.StateVectors, VectorTableUncertainties.None);
    public VectorCorrection Correction { get; init; } = VectorCorrection.None;
    public TimePrecision TimePrecision { get; init; } = TimePrecision.Second;
    public ValueSeparation ValueSeparation { get; init; } = ValueSeparation.WhitespaceSeparation;
    public OutputLabels OutputLabels { get; init; } = OutputLabels.Disable;
    public TimeDeltaInclusion TimeDeltaInclusion { get; init; } = TimeDeltaInclusion.Disable;

    /// <inheritdoc cref="VectorsQuery"/>
    /// <param name="tableContentValidator"><inheritdoc cref="TableContentValidator" path="/summary"/></param>
    public VectorsQuery(IVectorTableContentValidator tableContentValidator)
    {
        TableContentValidator = tableContentValidator;
    }

    /// <inheritdoc cref="VectorsQuery"/>
    /// <param name="tableContentValidator"><inheritdoc cref="TableContentValidator" path="/summary"/></param>
    /// <param name="target"><inheritdoc cref="Target" path="/summary"/></param>
    /// <param name="origin"><inheritdoc cref="Origin" path="/summary"/></param>
    /// <param name="epochs"><inheritdoc cref="Epochs" path="/summary"/></param>
    [SetsRequiredMembers]
    public VectorsQuery(IVectorTableContentValidator tableContentValidator, ITarget target, IOrigin origin, IEpochSelection epochs) : this(tableContentValidator)
    {
        Target = target;
        Origin = origin;

        Epochs = epochs;
    }

    IVectorsQuery IVectorsQuery.WithConfiguration(OutputFormat outputFormat)
    {
        ValidateOutputFormat(outputFormat);

        return this with { OutputFormat = outputFormat };
    }

    IVectorsQuery IVectorsQuery.WithConfiguration(ObjectDataInclusion objectDataInclusion)
    {
        ValidateObjectDataInclusion(objectDataInclusion);

        return this with { ObjectDataInclusion = objectDataInclusion };
    }

    IVectorsQuery IVectorsQuery.WithConfiguration(ReferencePlane referencePlane)
    {
        ValidateReferencePlane(referencePlane);

        return this with { ReferencePlane = referencePlane };
    }

    IVectorsQuery IVectorsQuery.WithConfiguration(ReferenceSystem referenceSystem)
    {
        ValidateReferenceSystem(referenceSystem);

        return this with { ReferenceSystem = referenceSystem };
    }

    IVectorsQuery IVectorsQuery.WithConfiguration(OutputUnits outputUnits)
    {
        ValidateOutputUnits(outputUnits);

        return this with { OutputUnits = outputUnits };
    }

    IVectorsQuery IVectorsQuery.WithConfiguration(VectorTableContent tableContent)
    {
        ValidateTableContent(tableContent);

        return this with { TableContent = tableContent };
    }

    IVectorsQuery IVectorsQuery.WithConfiguration(VectorCorrection correction)
    {
        ValidateCorrection(correction);

        return this with { Correction = correction };
    }

    IVectorsQuery IVectorsQuery.WithConfiguration(TimePrecision timePrecision)
    {
        ValidateTimePrecision(timePrecision);

        return this with { TimePrecision = timePrecision };
    }

    IVectorsQuery IVectorsQuery.WithConfiguration(ValueSeparation valueSeparation)
    {
        ValidateValueSeparation(ValueSeparation);

        return this with { ValueSeparation = valueSeparation };
    }
    IVectorsQuery IVectorsQuery.WithConfiguration(OutputLabels outputLabels)
    {
        ValidateOutputLabels(outputLabels);

        return this with { OutputLabels = outputLabels };
    }

    IVectorsQuery IVectorsQuery.WithConfiguration(TimeDeltaInclusion timeDeltaInclusion)
    {
        ValidateTimeDeltaInclusion(timeDeltaInclusion);

        return this with { TimeDeltaInclusion = timeDeltaInclusion };
    }

    IVectorsQuery IVectorsQuery.WithConfiguration(OutputFormat? outputFormat, ObjectDataInclusion? objectDataInclusion, ReferencePlane? referencePlane, ReferenceSystem? referenceSystem, OutputUnits? outputUnits, VectorTableContent? tableContent, VectorCorrection? correction, TimePrecision? timePrecision, ValueSeparation? valueSeparation, OutputLabels? outputLabels, TimeDeltaInclusion? timeDeltaInclusion)
    {
        if (outputFormat is not null)
        {
            ValidateOutputFormat(outputFormat.Value);
        }

        if (objectDataInclusion is not null)
        {
            ValidateObjectDataInclusion(objectDataInclusion.Value);
        }

        if (referencePlane is not null)
        {
            ValidateReferencePlane(referencePlane.Value);
        }

        if (referenceSystem is not null)
        {
            ValidateReferenceSystem(referenceSystem.Value);
        }

        if (outputUnits is not null)
        {
            ValidateOutputUnits(outputUnits.Value);
        }

        if (tableContent is not null)
        {
            ValidateTableContent(tableContent.Value);
        }

        if (correction is not null)
        {
            ValidateCorrection(correction.Value);
        }

        if (timePrecision is not null)
        {
            ValidateTimePrecision(timePrecision.Value);
        }

        if (valueSeparation is not null)
        {
            ValidateValueSeparation(valueSeparation.Value);
        }

        if (outputLabels is not null)
        {
            ValidateOutputLabels(outputLabels.Value);
        }

        if (timeDeltaInclusion is not null)
        {
            ValidateTimeDeltaInclusion(timeDeltaInclusion.Value);
        }

        return this with
        {
            OutputFormat = outputFormat ?? OutputFormat,
            ObjectDataInclusion = objectDataInclusion ?? ObjectDataInclusion,
            ReferencePlane = referencePlane ?? ReferencePlane,
            ReferenceSystem = referenceSystem ?? ReferenceSystem,
            OutputUnits = outputUnits ?? OutputUnits,
            TableContent = tableContent ?? TableContent,
            Correction = correction ?? Correction,
            TimePrecision = timePrecision ?? TimePrecision,
            ValueSeparation = valueSeparation ?? ValueSeparation,
            OutputLabels = outputLabels ?? OutputLabels,
            TimeDeltaInclusion = timeDeltaInclusion ?? TimeDeltaInclusion
        };
    }

    /// <summary>Validates that <paramref name="outputFormat"/> represents an <see cref="Query.OutputFormat"/> supported by Horizons, and throws an exception otherwise.</summary>
    /// <param name="outputFormat">This <see cref="Query.OutputFormat"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="outputFormat"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    private static void ValidateOutputFormat(OutputFormat outputFormat, [CallerArgumentExpression(nameof(outputFormat))] string? argumentExpression = null)
    {
        InvalidEnumArgumentExceptionFactory.ThrowIfUnlisted(outputFormat, argumentExpression);

        if (outputFormat is OutputFormat.Unknown)
        {
            ArgumentExceptionFactory.UnsupportedEnumValue(outputFormat, argumentExpression);
        }
    }

    /// <summary>Validates that <paramref name="objectDataInclusion"/> represents an <see cref="Query.ObjectDataInclusion"/> supported by Horizons, and throws an exception otherwise.</summary>
    /// <param name="objectDataInclusion">This <see cref="Query.ObjectDataInclusion"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="objectDataInclusion"/>.</param>
    /// <exception cref="InvalidEnumArgumentException"/>
    private static void ValidateObjectDataInclusion(ObjectDataInclusion objectDataInclusion, [CallerArgumentExpression(nameof(objectDataInclusion))] string? argumentExpression = null)
    {
        InvalidEnumArgumentExceptionFactory.ThrowIfUnlisted(objectDataInclusion, argumentExpression);
    }

    /// <summary>Validates that <paramref name="referencePlane"/> represents an <see cref="Query.ReferencePlane"/> supported by Horizons, and throws an exception otherwise.</summary>
    /// <param name="referencePlane">This <see cref="Query.ReferencePlane"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="referencePlane"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    private static void ValidateReferencePlane(ReferencePlane referencePlane, [CallerArgumentExpression(nameof(referencePlane))] string? argumentExpression = null)
    {
        InvalidEnumArgumentExceptionFactory.ThrowIfUnlisted(referencePlane, argumentExpression);

        if (referencePlane is ReferencePlane.Unknown)
        {
            throw ArgumentExceptionFactory.UnsupportedEnumValue(referencePlane, argumentExpression);
        }
    }

    /// <summary>Validates that <paramref name="referenceSystem"/> represents an <see cref="Query.ReferenceSystem"/> supported by Horizons, and throws an exception otherwise.</summary>
    /// <param name="referenceSystem">This <see cref="Query.ReferenceSystem"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="referenceSystem"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    private static void ValidateReferenceSystem(ReferenceSystem referenceSystem, [CallerArgumentExpression(nameof(referenceSystem))] string? argumentExpression = null)
    {
        InvalidEnumArgumentExceptionFactory.ThrowIfUnlisted(referenceSystem, argumentExpression);

        if (referenceSystem is ReferenceSystem.Unknown)
        {
            throw ArgumentExceptionFactory.UnsupportedEnumValue(referenceSystem, argumentExpression);
        }
    }

    /// <summary>Validates that <paramref name="outputUnits"/> represents an <see cref="Query.OutputUnits"/> supported by Horizons, and throws an exception otherwise.</summary>
    /// <param name="outputUnits">This <see cref="Query.OutputUnits"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="outputUnits"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    private static void ValidateOutputUnits(OutputUnits outputUnits, [CallerArgumentExpression(nameof(outputUnits))] string? argumentExpression = null)
    {
        InvalidEnumArgumentExceptionFactory.ThrowIfUnlisted(outputUnits, argumentExpression);

        if (outputUnits is OutputUnits.Unknown)
        {
            throw ArgumentExceptionFactory.UnsupportedEnumValue(outputUnits, argumentExpression);
        }
    }

    /// <summary>Validates that <paramref name="tableContent"/> represents a <see cref="VectorTableContent"/> supported by Horizons, and throws an exception otherwise.</summary>
    /// <param name="tableContent">This <see cref="VectorTableContent"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="tableContent"/>.</param>
    /// <exception cref="ArgumentException"/>
    private void ValidateTableContent(VectorTableContent tableContent, [CallerArgumentExpression(nameof(tableContent))] string? argumentExpression = null)
    {
        TableContentValidator.ThrowIfUnsupported(tableContent, argumentExpression);
    }

    /// <summary>Validates that <paramref name="correction"/> represents an <see cref="VectorCorrection"/> supported by Horizons, and throws an exception otherwise.</summary>
    /// <param name="correction">This <see cref="VectorCorrection"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="correction"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    private static void ValidateCorrection(VectorCorrection correction, [CallerArgumentExpression(nameof(correction))] string? argumentExpression = null)
    {
        InvalidEnumArgumentExceptionFactory.ThrowIfUnlisted(correction, argumentExpression);

        try
        {
            UnsupportedVectorCorrectionException.ThrowIfJustAberration(correction);
        }
        catch (UnsupportedVectorCorrectionException e)
        {
            throw ArgumentExceptionFactory.InvalidState<VectorCorrection>(argumentExpression, e);
        }
    }

    /// <summary>Validates that <paramref name="timePrecision"/> represents an <see cref="Query.TimePrecision"/> supported by Horizons, and throws an exception otherwise.</summary>
    /// <param name="timePrecision">This <see cref="Query.TimePrecision"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="timePrecision"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    private static void ValidateTimePrecision(TimePrecision timePrecision, [CallerArgumentExpression(nameof(timePrecision))] string? argumentExpression = null)
    {
        InvalidEnumArgumentExceptionFactory.ThrowIfUnlisted(timePrecision, argumentExpression);

        if (timePrecision is TimePrecision.Unknown)
        {
            throw ArgumentExceptionFactory.UnsupportedEnumValue(timePrecision, argumentExpression);
        }
    }

    /// <summary>Validates that <paramref name="valueSeparation"/> represents an <see cref="Query.ValueSeparation"/> supported by Horizons, and throws an exception otherwise.</summary>
    /// <param name="valueSeparation">This <see cref="Query.ValueSeparation"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="valueSeparation"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    private static void ValidateValueSeparation(ValueSeparation valueSeparation, [CallerArgumentExpression(nameof(valueSeparation))] string? argumentExpression = null)
    {
        InvalidEnumArgumentExceptionFactory.ThrowIfUnlisted(valueSeparation, argumentExpression);

        if (valueSeparation is ValueSeparation.Unknown)
        {
            throw ArgumentExceptionFactory.UnsupportedEnumValue(valueSeparation, argumentExpression);
        }
    }

    /// <summary>Validates that <paramref name="outputLabels"/> represents an <see cref="Query.OutputLabels"/> supported by Horizons, and throws an exception otherwise.</summary>
    /// <param name="outputLabels">This <see cref="Query.OutputLabels"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="outputLabels"/>.</param>
    /// <exception cref="InvalidEnumArgumentException"/>
    private static void ValidateOutputLabels(OutputLabels outputLabels, [CallerArgumentExpression(nameof(outputLabels))] string? argumentExpression = null)
    {
        InvalidEnumArgumentExceptionFactory.ThrowIfUnlisted(outputLabels, argumentExpression);
    }

    /// <summary>Validates that <paramref name="timeDeltaInclusion"/> represents an <see cref="Query.TimeDeltaInclusion"/> supported by Horizons, and throws an exception otherwise.</summary>
    /// <param name="timeDeltaInclusion">This <see cref="Query.TimeDeltaInclusion"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="timeDeltaInclusion"/>.</param>
    /// <exception cref="InvalidEnumArgumentException"/>
    private static void ValidateTimeDeltaInclusion(TimeDeltaInclusion timeDeltaInclusion, [CallerArgumentExpression(nameof(timeDeltaInclusion))] string? argumentExpression = null)
    {
        InvalidEnumArgumentExceptionFactory.ThrowIfUnlisted(timeDeltaInclusion, argumentExpression);
    }
}
