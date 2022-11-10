namespace SharpHorizons.Query.Parameters;

/// <summary><inheritdoc cref="IQueryParameterProvider" path="/summary"/></summary>
internal sealed class QueryParameterProvider : IQueryParameterProvider
{
    /// <inheritdoc/>
    public ICommandParameterIdentifier Command { get; }

    /// <inheritdoc/>
    public IElementLabelsParameterIdentifier ElementLabels { get; }

    /// <inheritdoc/>
    public IEphemerisTypeParameterIdentifier EphemerisType { get; }

    /// <inheritdoc/>
    public IEpochCollectionParameterIdentifier EpochCollection { get; }

    /// <inheritdoc/>
    public IEpochCollectionFormatParameterIdentifier EpochCollectionFormat { get; }

    /// <inheritdoc/>
    public IGenerateEphemeridesParameterIdentifier GenerateEphemerides { get; }

    /// <inheritdoc/>
    public IObjectDataInclusionParameterIdentifier ObjectDataInclusion { get; }

    /// <inheritdoc/>
    public IOriginParameterIdentifier Origin { get; }

    /// <inheritdoc/>
    public IOriginCoordinateParameterIdentifier OriginCoordinate { get; }

    /// <inheritdoc/>
    public IOriginCoordinateTypeParameterIdentifier OriginCoordinateType { get; }

    /// <inheritdoc/>
    public IOutputFormatParameterIdentifier OutputFormat { get; }

    /// <inheritdoc/>
    public IOutputUnitsParameterIdentifier OutputUnits { get; }

    /// <inheritdoc/>
    public IReferencePlaneParameterIdentifier ReferencePlane { get; }

    /// <inheritdoc/>
    public IReferenceSystemParameterIdentifier ReferenceSystem { get; }

    /// <inheritdoc/>
    public IStartEpochParameterIdentifier StartEpoch { get; }

    /// <inheritdoc/>
    public IStepSizeParameterIdentifier StepSize { get; }

    /// <inheritdoc/>
    public IStopEpochParameterIdentifier StopEpoch { get; }

    /// <inheritdoc/>
    public ITimeDeltaInclusionParameterIdentifier TimeDeltaInclusion { get; }

    /// <inheritdoc/>
    public ITimePrecisionParameterIdentifier TimePrecision { get; }

    /// <inheritdoc/>
    public IValueSeparationParameterIdentifier ValueSeparation { get; }

    /// <inheritdoc/>
    public IVectorCorrectionParameterIdentifier VectorCorrection { get; }

    /// <inheritdoc/>
    public IVectorLabelsParameterIdentifier VectorLabels { get; }

    /// <inheritdoc/>
    public IVectorTableContentParameterIdentifier VectorTableContent { get; }

    public QueryParameterProvider(ICommandParameterIdentifier command, IElementLabelsParameterIdentifier elementLabels, IEphemerisTypeParameterIdentifier ephemerisType, IEpochCollectionParameterIdentifier epochCollection, IEpochCollectionFormatParameterIdentifier epochCollectionFormat,
        IGenerateEphemeridesParameterIdentifier generateEphemerides, IObjectDataInclusionParameterIdentifier objectDataInclusion, IOriginParameterIdentifier origin, IOriginCoordinateParameterIdentifier originCoordinate, IOriginCoordinateTypeParameterIdentifier originCoordinateType,
        IOutputFormatParameterIdentifier outputFormat, IOutputUnitsParameterIdentifier outputUnits, IReferencePlaneParameterIdentifier referencePlane, IReferenceSystemParameterIdentifier referenceSystem, IStartEpochParameterIdentifier startEpoch,
        IStepSizeParameterIdentifier stepSize, IStopEpochParameterIdentifier stopEpoch, ITimeDeltaInclusionParameterIdentifier timeDeltaInclusion, ITimePrecisionParameterIdentifier timePrecision, IValueSeparationParameterIdentifier valueSeparation,
        IVectorCorrectionParameterIdentifier vectorCorrection, IVectorLabelsParameterIdentifier vectorLabels, IVectorTableContentParameterIdentifier vectorTableContent)
    {
        Command = command;
        ElementLabels = elementLabels;
        EphemerisType = ephemerisType;
        EpochCollection = epochCollection;
        EpochCollectionFormat = epochCollectionFormat;
        GenerateEphemerides = generateEphemerides;
        ObjectDataInclusion = objectDataInclusion;
        Origin = origin;
        OriginCoordinate = originCoordinate;
        OriginCoordinateType = originCoordinateType;
        OutputFormat = outputFormat;
        OutputUnits = outputUnits;
        ReferencePlane = referencePlane;
        ReferenceSystem = referenceSystem;
        StartEpoch = startEpoch;
        StepSize = stepSize;
        StopEpoch = stopEpoch;
        TimeDeltaInclusion = timeDeltaInclusion;
        TimePrecision = timePrecision;
        ValueSeparation = valueSeparation;
        VectorCorrection = vectorCorrection;
        VectorLabels = vectorLabels;
        VectorTableContent = vectorTableContent;
    }
}
