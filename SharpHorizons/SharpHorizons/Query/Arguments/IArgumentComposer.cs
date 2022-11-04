namespace SharpHorizons.Query.Arguments;

using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.VectorTable;

using System;

/// <summary>Composes <typeparamref name="TArgument"/> that describe <typeparamref name="T"/>.</summary>
/// <typeparam name="TArgument">The composed <see cref="IQueryArgument"/> is of this type.</typeparam>
/// <typeparam name="T">The composed <typeparamref name="TArgument"/> describe instances of this type.</typeparam>
public interface IArgumentComposer<TArgument, T> where TArgument : IQueryArgument
{
    /// <summary>Composes a <typeparamref name="TArgument"/> describing <paramref name="obj"/>.</summary>
    /// <param name="obj">The composed <typeparamref name="TArgument"/> describes this <typeparamref name="T"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    public abstract TArgument Compose(T obj);
}

/// <summary>Composes <see cref="IEphemerisTypeArgument"/> that describe <see cref="EphemerisType"/>.</summary>
public interface IEphemerisTypeComposer : IArgumentComposer<IEphemerisTypeArgument, EphemerisType> { }

/// <summary>Composes <see cref="IEpochCollectionArgument"/> that describe <typeparamref name="T"/>.</summary>
/// <typeparam name="T">The composed <see cref="IEpochCollectionArgument"/> describe instances of this type.</typeparam>
public interface IEpochCollectionComposer<T> : IArgumentComposer<IEpochCollectionArgument, T> { }

/// <summary>Composes <see cref="IEpochCollectionFormatArgument"/> that describe <see cref="EpochCollectionFormat"/>.</summary>
public interface IEpochCollectionFormatComposer : IArgumentComposer<IEpochCollectionFormatArgument, EpochCollectionFormat> { }

/// <summary>Composes <see cref="IGenerateEphemeridesArgument"/> that describe <see cref="GenerateEphemerides"/>.</summary>
public interface IGenerateEphemeridesComposer : IArgumentComposer<IGenerateEphemeridesArgument, GenerateEphemerides> { }

/// <summary>Composes <see cref="IObjectDataInclusionArgument"/> that describe <see cref="ObjectDataInclusion"/>.</summary>
public interface IObjectDataInclusionComposer : IArgumentComposer<IObjectDataInclusionArgument, ObjectDataInclusion> { }

/// <summary>Composes <see cref="IOriginArgument"/> that describe <typeparamref name="T"/>.</summary>
/// <typeparam name="T">The composed <see cref="IOriginArgument"/> describe instances of this type.</typeparam>
public interface IOriginComposer<T> : IArgumentComposer<IOriginArgument, T> { }

/// <summary>Composes <see cref="IOriginCoordinateArgument"/> that describe <typeparamref name="T"/>.</summary>
/// <typeparam name="T">The composed <see cref="IOriginCoordinateArgument"/> describe instances of this type.</typeparam>
public interface IOriginCoordinateComposer<T> : IArgumentComposer<IOriginCoordinateArgument, T> { }

/// <summary>Composes <see cref="IOriginCoordinateTypeArgument"/> that describe <typeparamref name="T"/>.</summary>
/// <typeparam name="T">The composed <see cref="IOriginCoordinateTypeArgument"/> describe instances of this type.</typeparam>
public interface IOriginCoordinateTypeComposer<T> : IArgumentComposer<IOriginCoordinateTypeArgument, T> { }

/// <summary>Composes <see cref="IOutputFormatArgument"/> that describe <see cref="OutputFormat"/>.</summary>
public interface IOutputFormatComposer : IArgumentComposer<IOutputFormatArgument, OutputFormat> { }

/// <summary>Composes <see cref="IOutputLabelsArgument"/> that describe <see cref="OutputLabels"/>.</summary>
public interface IOutputLabelsComposer : IArgumentComposer<IOutputLabelsArgument, OutputLabels> { }

/// <summary>Composes <see cref="IOutputUnitsArgument"/> that describe <see cref="OutputUnits"/>.</summary>
public interface IOutputUnitsComposer : IArgumentComposer<IOutputUnitsArgument, OutputUnits> { }

/// <summary>Composes <see cref="IReferencePlaneArgument"/> that describe <see cref="ReferencePlane"/>.</summary>
public interface IReferencePlaneComposer : IArgumentComposer<IReferencePlaneArgument, ReferencePlane> { }

/// <summary>Composes <see cref="IReferenceSystemArgument"/> that describe <see cref="ReferenceSystem"/>.</summary>
public interface IReferenceSystemComposer : IArgumentComposer<IReferenceSystemArgument, ReferenceSystem> { }

/// <summary>Composes <see cref="IStartEpochArgument"/> that describe <typeparamref name="T"/>.</summary>
/// <typeparam name="T">The composed <see cref="IStartEpochArgument"/> describe instances of this type.</typeparam>
public interface IStartEpochComposer<T> : IArgumentComposer<IStartEpochArgument, T> { }

/// <summary>Composes <see cref="IStepSizeArgument"/> that describe <typeparamref name="T"/>.</summary>
/// <typeparam name="T">The composed <see cref="IStepSizeArgument"/> describe instances of this type.</typeparam>
public interface IStepSizeComposer<T> : IArgumentComposer<IStepSizeArgument, T> { }

/// <summary>Composes <see cref="IStopEpochArgument"/> that describe <typeparamref name="T"/>.</summary>
/// <typeparam name="T">The composed <see cref="IStopEpochArgument"/> describe instances of this type.</typeparam>
public interface IStopEpochComposer<T> : IArgumentComposer<IStopEpochArgument, T> { }

/// <summary>Composes <see cref="ITargetArgument"/> that describe <typeparamref name="T"/>.</summary>
/// <typeparam name="T">The composed <see cref="ITargetArgument"/> describe instances of this type.</typeparam>
public interface ITargetComposer<T> : IArgumentComposer<ITargetArgument, T> { }

/// <summary>Composes <see cref="ITimeDeltaInclusionArgument"/> that describe <see cref="TimeDeltaInclusion"/>.</summary>
public interface ITimeDeltaInclusionComposer : IArgumentComposer<ITimeDeltaInclusionArgument, TimeDeltaInclusion> { }

/// <summary>Composes <see cref="ITimePrecisionArgument"/> that describe <see cref="TimePrecision"/>.</summary>
public interface ITimePrecisionComposer : IArgumentComposer<ITimePrecisionArgument, TimePrecision> { }

/// <summary>Composes <see cref="IVectorCorrectionArgument"/> that describe <see cref="VectorCorrection"/>.</summary>
public interface IVectorCorrectionComposer : IArgumentComposer<IVectorCorrectionArgument, VectorCorrection> { }

/// <summary>Composes <see cref="IVectorTableContentArgument"/> that describe <see cref="VectorTableContent"/>.</summary>
public interface IVectorTableContentComposer : IArgumentComposer<IVectorTableContentArgument, VectorTableContent> { }
