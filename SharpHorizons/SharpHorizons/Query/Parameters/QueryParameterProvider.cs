namespace SharpHorizons.Query.Parameters;

using Microsoft.Extensions.Options;

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
