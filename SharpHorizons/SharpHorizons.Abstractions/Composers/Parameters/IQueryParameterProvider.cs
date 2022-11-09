namespace SharpHorizons.Composers.Parameters;

/// <summary>Provides the <see cref="IQueryParameterIdentifier"/> corresponding to the available parameters.</summary>
public interface IQueryParameterProvider
{
    /// <summary><inheritdoc cref="ICommandParameterIdentifier" path="/summary"/></summary>
    public abstract ICommandParameterIdentifier Command { get; }

    /// <summary><inheritdoc cref="IElementLabelsParameterIdentifier" path="/summary"/></summary>
    public abstract IElementLabelsParameterIdentifier ElementLabels { get; }

    /// <summary><inheritdoc cref="IEphemerisTypeParameterIdentifier" path="/summary"/></summary>
    public abstract IEphemerisTypeParameterIdentifier EphemerisType { get; }

    /// <summary><inheritdoc cref="IEpochCollectionParameterIdentifier" path="/summary"/></summary>
    public abstract IEpochCollectionParameterIdentifier EpochCollection { get; }

    /// <summary><inheritdoc cref="ICommandParameterIdentifier" path="/summary"/></summary>
    public abstract IEpochCollectionFormatParameterIdentifier EpochCollectionFormat { get; }

    /// <summary><inheritdoc cref="IGenerateEphemeridesParameterIdentifier" path="/summary"/></summary>
    public abstract IGenerateEphemeridesParameterIdentifier GenerateEphemerides { get; }

    /// <summary><inheritdoc cref="IObjectDataInclusionParameterIdentifier" path="/summary"/></summary>
    public abstract IObjectDataInclusionParameterIdentifier ObjectDataInclusion { get; }

    /// <summary><inheritdoc cref="IOriginParameterIdentifier" path="/summary"/></summary>
    public abstract IOriginParameterIdentifier Origin { get; }

    /// <summary><inheritdoc cref="IOriginCoordinateParameterIdentifier" path="/summary"/></summary>
    public abstract IOriginCoordinateParameterIdentifier OriginCoordinate { get; }

    /// <summary><inheritdoc cref="IOriginCoordinateTypeParameterIdentifier" path="/summary"/></summary>
    public abstract IOriginCoordinateTypeParameterIdentifier OriginCoordinateType { get; }

    /// <summary><inheritdoc cref="IOutputFormatParameterIdentifier" path="/summary"/></summary>
    public abstract IOutputFormatParameterIdentifier OutputFormat { get; }

    /// <summary><inheritdoc cref="IOutputUnitsParameterIdentifier" path="/summary"/></summary>
    public abstract IOutputUnitsParameterIdentifier OutputUnits { get; }

    /// <summary><inheritdoc cref="IReferencePlaneParameterIdentifier" path="/summary"/></summary>
    public abstract IReferencePlaneParameterIdentifier ReferencePlane { get; }

    /// <summary><inheritdoc cref="IReferenceSystemParameterIdentifier" path="/summary"/></summary>
    public abstract IReferenceSystemParameterIdentifier ReferenceSystem { get; }

    /// <summary><inheritdoc cref="IStartEpochParameterIdentifier" path="/summary"/></summary>
    public abstract IStartEpochParameterIdentifier StartEpoch { get; }

    /// <summary><inheritdoc cref="IStepSizeParameterIdentifier" path="/summary"/></summary>
    public abstract IStepSizeParameterIdentifier StepSize { get; }

    /// <summary><inheritdoc cref="IStopEpochParameterIdentifier" path="/summary"/></summary>
    public abstract IStopEpochParameterIdentifier StopEpoch { get; }

    /// <summary><inheritdoc cref="ITimeDeltaInclusionParameterIdentifier" path="/summary"/></summary>
    public abstract ITimeDeltaInclusionParameterIdentifier TimeDeltaInclusion { get; }

    /// <summary><inheritdoc cref="ITimePrecisionParameterIdentifier" path="/summary"/></summary>
    public abstract ITimePrecisionParameterIdentifier TimePrecision { get; }

    /// <summary><inheritdoc cref="IValueSeparationParameterIdentifier" path="/summary"/></summary>
    public abstract IValueSeparationParameterIdentifier ValueSeparation { get; }

    /// <summary><inheritdoc cref="IVectorCorrectionParameterIdentifier" path="/summary"/></summary>
    public abstract IVectorCorrectionParameterIdentifier VectorCorrection { get; }

    /// <summary><inheritdoc cref="IVectorLabelsParameterIdentifier" path="/summary"/></summary>
    public abstract IVectorLabelsParameterIdentifier VectorLabels { get; }

    /// <summary><inheritdoc cref="IVectorTableContentParameterIdentifier" path="/summary"/></summary>
    public abstract IVectorTableContentParameterIdentifier VectorTableContent { get; }
}
