namespace SharpHorizons.Query.Parameters;

/// <summary>Provides the <see cref="IQueryParameterIdentifier"/> associated with the available parameters.</summary>
public interface IQueryParameterIdentifierProvider
{
    /// <inheritdoc cref="ICommandParameterIdentifier"/>
    public abstract ICommandParameterIdentifier Command { get; }

    /// <inheritdoc cref="IEphemerisTypeParameterIdentifier"/>
    public abstract IEphemerisTypeParameterIdentifier EphemerisType { get; }

    /// <inheritdoc cref="ICalendarTypeParameterIdentifier"/>
    public abstract ICalendarTypeParameterIdentifier CalendarType { get; }

    /// <inheritdoc cref="IEpochCollectionParameterIdentifier"/>
    public abstract IEpochCollectionParameterIdentifier EpochCollection { get; }

    /// <inheritdoc cref="IEpochCollectionFormatParameterIdentifier"/>
    public abstract IEpochCollectionFormatParameterIdentifier EpochCollectionFormat { get; }

    /// <inheritdoc cref="IGenerateEphemerisParameterIdentifier"/>
    public abstract IGenerateEphemerisParameterIdentifier GenerateEphemeris { get; }

    /// <inheritdoc cref="IObjectDataInclusionParameterIdentifier"/>
    public abstract IObjectDataInclusionParameterIdentifier ObjectDataInclusion { get; }

    /// <inheritdoc cref="IOriginParameterIdentifier"/>
    public abstract IOriginParameterIdentifier Origin { get; }

    /// <inheritdoc cref="IOriginCoordinateParameterIdentifier"/>
    public abstract IOriginCoordinateParameterIdentifier OriginCoordinate { get; }

    /// <inheritdoc cref="IOriginCoordinateTypeParameterIdentifier"/>
    public abstract IOriginCoordinateTypeParameterIdentifier OriginCoordinateType { get; }

    /// <inheritdoc cref="IOutputFormatParameterIdentifier"/>
    public abstract IOutputFormatParameterIdentifier OutputFormat { get; }

    /// <inheritdoc cref="IOutputUnitsParameterIdentifier"/>
    public abstract IOutputUnitsParameterIdentifier OutputUnits { get; }

    /// <inheritdoc cref="IReferencePlaneParameterIdentifier"/>
    public abstract IReferencePlaneParameterIdentifier ReferencePlane { get; }

    /// <inheritdoc cref="IReferenceSystemParameterIdentifier"/>
    public abstract IReferenceSystemParameterIdentifier ReferenceSystem { get; }

    /// <inheritdoc cref="IStartEpochParameterIdentifier"/>
    public abstract IStartEpochParameterIdentifier StartEpoch { get; }

    /// <inheritdoc cref="IStepSizeParameterIdentifier"/>
    public abstract IStepSizeParameterIdentifier StepSize { get; }

    /// <inheritdoc cref="IStopEpochParameterIdentifier"/>
    public abstract IStopEpochParameterIdentifier StopEpoch { get; }

    /// <inheritdoc cref="ITimeDeltaInclusionParameterIdentifier"/>
    public abstract ITimeDeltaInclusionParameterIdentifier TimeDeltaInclusion { get; }

    /// <inheritdoc cref="ITimePrecisionParameterIdentifier"/>
    public abstract ITimePrecisionParameterIdentifier TimePrecision { get; }

    /// <inheritdoc cref="ITimeSystemParameterIdentifier"/>
    public abstract ITimeSystemParameterIdentifier TimeSystem { get; }

    /// <inheritdoc cref="ITimeZoneParameterIdentifier"/>
    public abstract ITimeZoneParameterIdentifier TimeZone { get; }

    /// <inheritdoc cref="IValueSeparationParameterIdentifier"/>
    public abstract IValueSeparationParameterIdentifier ValueSeparation { get; }

    /// <inheritdoc cref="IVectorCorrectionParameterIdentifier"/>
    public abstract IVectorCorrectionParameterIdentifier VectorCorrection { get; }

    /// <inheritdoc cref="IVectorLabelsParameterIdentifier"/>
    public abstract IVectorLabelsParameterIdentifier VectorLabels { get; }

    /// <inheritdoc cref="IVectorTableContentParameterIdentifier"/>
    public abstract IVectorTableContentParameterIdentifier VectorTableContent { get; }
}
