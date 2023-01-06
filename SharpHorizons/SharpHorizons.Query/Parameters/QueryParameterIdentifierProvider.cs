namespace SharpHorizons.Query.Parameters;

using Microsoft.Extensions.Options;

using SharpHorizons.Settings.Query.Parameters;

/// <inheritdoc cref="IQueryParameterIdentifierProvider"/>
internal sealed class QueryParameterIdentifierProvider : IQueryParameterIdentifierProvider
{
    public ICommandParameterIdentifier Command { get; }
    public IEphemerisTypeParameterIdentifier EphemerisType { get; }
    public ICalendarTypeParameterIdentifier CalendarType { get; }
    public IEpochCollectionParameterIdentifier EpochCollection { get; }
    public IEpochCollectionFormatParameterIdentifier EpochCollectionFormat { get; }
    public IGenerateEphemerisParameterIdentifier GenerateEphemeris { get; }
    public IObjectDataInclusionParameterIdentifier ObjectDataInclusion { get; }
    public IOriginParameterIdentifier Origin { get; }
    public IOriginCoordinateParameterIdentifier OriginCoordinate { get; }
    public IOriginCoordinateTypeParameterIdentifier OriginCoordinateType { get; }
    public IOutputFormatParameterIdentifier OutputFormat { get; }
    public IOutputUnitsParameterIdentifier OutputUnits { get; }
    public IReferencePlaneParameterIdentifier ReferencePlane { get; }
    public IReferenceSystemParameterIdentifier ReferenceSystem { get; }
    public IStartEpochParameterIdentifier StartEpoch { get; }
    public IStepSizeParameterIdentifier StepSize { get; }
    public IStopEpochParameterIdentifier StopEpoch { get; }
    public ITimeDeltaInclusionParameterIdentifier TimeDeltaInclusion { get; }
    public ITimePrecisionParameterIdentifier TimePrecision { get; }
    public ITimeSystemParameterIdentifier TimeSystem { get; }
    public ITimeZoneParameterIdentifier TimeZone { get; }
    public IValueSeparationParameterIdentifier ValueSeparation { get; }
    public IVectorCorrectionParameterIdentifier VectorCorrection { get; }
    public IVectorLabelsParameterIdentifier VectorLabels { get; }
    public IVectorTableContentParameterIdentifier VectorTableContent { get; }

    /// <inheritdoc cref="QueryParameterIdentifierProvider"/>
    /// <param name="parameterIdentifierOptions">Provides the <see cref="ParameterIdentifierOptions"/>.</param>
    public QueryParameterIdentifierProvider(IOptions<ParameterIdentifierOptions> parameterIdentifierOptions)
    {
        Command = new QueryParameterIdentifier(parameterIdentifierOptions.Value.Command);
        EphemerisType = new QueryParameterIdentifier(parameterIdentifierOptions.Value.EphemerisType);
        CalendarType = new QueryParameterIdentifier(parameterIdentifierOptions.Value.CalendarType);
        EpochCollection = new QueryParameterIdentifier(parameterIdentifierOptions.Value.EpochCollection);
        EpochCollectionFormat = new QueryParameterIdentifier(parameterIdentifierOptions.Value.EpochCollectionFormat);
        GenerateEphemeris = new QueryParameterIdentifier(parameterIdentifierOptions.Value.GenerateEphemeris);
        ObjectDataInclusion = new QueryParameterIdentifier(parameterIdentifierOptions.Value.ObjectDataInclusion);
        Origin = new QueryParameterIdentifier(parameterIdentifierOptions.Value.Origin);
        OriginCoordinate = new QueryParameterIdentifier(parameterIdentifierOptions.Value.OriginCoordinate);
        OriginCoordinateType = new QueryParameterIdentifier(parameterIdentifierOptions.Value.OriginCoordinateType);
        OutputFormat = new QueryParameterIdentifier(parameterIdentifierOptions.Value.OutputFormat);
        OutputUnits = new QueryParameterIdentifier(parameterIdentifierOptions.Value.OutputUnits);
        ReferencePlane = new QueryParameterIdentifier(parameterIdentifierOptions.Value.ReferencePlane);
        ReferenceSystem = new QueryParameterIdentifier(parameterIdentifierOptions.Value.ReferenceSystem);
        StartEpoch = new QueryParameterIdentifier(parameterIdentifierOptions.Value.StartEpoch);
        StepSize = new QueryParameterIdentifier(parameterIdentifierOptions.Value.StepSize);
        StopEpoch = new QueryParameterIdentifier(parameterIdentifierOptions.Value.StopEpoch);
        TimeDeltaInclusion = new QueryParameterIdentifier(parameterIdentifierOptions.Value.TimeDeltaInclusion);
        TimePrecision = new QueryParameterIdentifier(parameterIdentifierOptions.Value.TimePrecision);
        TimeSystem = new QueryParameterIdentifier(parameterIdentifierOptions.Value.TimeSystem);
        TimeZone = new QueryParameterIdentifier(parameterIdentifierOptions.Value.TimeZone);
        ValueSeparation = new QueryParameterIdentifier(parameterIdentifierOptions.Value.ValueSeparation);
        VectorCorrection = new QueryParameterIdentifier(parameterIdentifierOptions.Value.VectorCorrection);
        VectorLabels = new QueryParameterIdentifier(parameterIdentifierOptions.Value.VectorLabels);
        VectorTableContent = new QueryParameterIdentifier(parameterIdentifierOptions.Value.VectorTableContent);
    }
}
