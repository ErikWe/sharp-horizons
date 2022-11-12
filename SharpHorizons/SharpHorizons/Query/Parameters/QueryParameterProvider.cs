namespace SharpHorizons.Query.Parameters;

using Microsoft.Extensions.Options;

/// <summary><inheritdoc cref="IQueryParameterProvider" path="/summary"/></summary>
internal sealed class QueryParameterProvider : IQueryParameterProvider
{
    public ICommandParameterIdentifier Command { get; }
    public IElementLabelsParameterIdentifier ElementLabels { get; }
    public IEphemerisTypeParameterIdentifier EphemerisType { get; }
    public IEpochCollectionParameterIdentifier EpochCollection { get; }
    public IEpochCollectionFormatParameterIdentifier EpochCollectionFormat { get; }
    public IGenerateEphemeridesParameterIdentifier GenerateEphemerides { get; }
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
    public IValueSeparationParameterIdentifier ValueSeparation { get; }
    public IVectorCorrectionParameterIdentifier VectorCorrection { get; }
    public IVectorLabelsParameterIdentifier VectorLabels { get; }
    public IVectorTableContentParameterIdentifier VectorTableContent { get; }

    /// <summary><inheritdoc cref="QueryParameterProvider" path="/summary"/></summary>
    /// <param name="parameterIdentifierOptions">Provides the <see cref="ParameterIdentifierOptions"/>.</param>
    public QueryParameterProvider(IOptions<ParameterIdentifierOptions> parameterIdentifierOptions)
    {
        Command = new QueryParameterIdentifier(parameterIdentifierOptions.Value.Command);
        ElementLabels = new QueryParameterIdentifier(parameterIdentifierOptions.Value.ElementLabels);
        EphemerisType = new QueryParameterIdentifier(parameterIdentifierOptions.Value.EphemerisType);
        EpochCollection = new QueryParameterIdentifier(parameterIdentifierOptions.Value.EpochCollection);
        EpochCollectionFormat = new QueryParameterIdentifier(parameterIdentifierOptions.Value.EpochCollectionFormat);
        GenerateEphemerides = new QueryParameterIdentifier(parameterIdentifierOptions.Value.GenerateEphemerides);
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
        ValueSeparation = new QueryParameterIdentifier(parameterIdentifierOptions.Value.ValueSeparation);
        VectorCorrection = new QueryParameterIdentifier(parameterIdentifierOptions.Value.VectorCorrection);
        VectorLabels = new QueryParameterIdentifier(parameterIdentifierOptions.Value.VectorLabels);
        VectorTableContent = new QueryParameterIdentifier(parameterIdentifierOptions.Value.VectorTableContent);
    }
}
