namespace SharpHorizons.Query.Parameters;

/// <inheritdoc cref="IQueryParameterIdentifier"/>
internal sealed class QueryParameterIdentifier : IQueryParameterIdentifier, ICommandParameterIdentifier, IElementLabelsParameterIdentifier, IEphemerisTypeParameterIdentifier, IEpochCollectionFormatParameterIdentifier, IEpochCollectionParameterIdentifier,
    IGenerateEphemeridesParameterIdentifier, IObjectDataInclusionParameterIdentifier, IOriginCoordinateParameterIdentifier, IOriginCoordinateTypeParameterIdentifier, IOriginParameterIdentifier, IOutputFormatParameterIdentifier, IOutputUnitsParameterIdentifier,
    IReferencePlaneParameterIdentifier, IReferenceSystemParameterIdentifier, IStartEpochParameterIdentifier, IStepSizeParameterIdentifier, IStopEpochParameterIdentifier, ITimeDeltaInclusionParameterIdentifier, ITimePrecisionParameterIdentifier, IValueSeparationParameterIdentifier,
    IVectorCorrectionParameterIdentifier, IVectorLabelsParameterIdentifier, IVectorTableContentParameterIdentifier
{
    /// <inheritdoc/>
    public string Identifier { get; }

    /// <summary><inheritdoc cref="QueryParameterIdentifier" path="/summary"/></summary>
    /// <param name="identifier"><inheritdoc cref="Identifier" path="/summary"/></param>
    public QueryParameterIdentifier(string identifier)
    {
        Identifier = identifier;
    }
}
