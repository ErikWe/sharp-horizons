namespace SharpHorizons.Query.Parameters;

/// <inheritdoc cref="IQueryParameterIdentifier"/>
internal sealed class QueryParameterIdentifier : IQueryParameterIdentifier, ICommandParameterIdentifier, IEphemerisTypeParameterIdentifier, ICalendarTypeParameterIdentifier, IEpochCollectionFormatParameterIdentifier, IEpochCollectionParameterIdentifier,
    IGenerateEphemerisParameterIdentifier, IObjectDataInclusionParameterIdentifier, IOriginCoordinateParameterIdentifier, IOriginCoordinateTypeParameterIdentifier, IOriginParameterIdentifier, IOutputFormatParameterIdentifier, IOutputUnitsParameterIdentifier,
    IReferencePlaneParameterIdentifier, IReferenceSystemParameterIdentifier, IStartEpochParameterIdentifier, IStepSizeParameterIdentifier, IStopEpochParameterIdentifier, ITimeDeltaInclusionParameterIdentifier, ITimePrecisionParameterIdentifier,
    ITimeSystemParameterIdentifier, ITimeZoneParameterIdentifier, IValueSeparationParameterIdentifier, IVectorCorrectionParameterIdentifier, IVectorLabelsParameterIdentifier, IVectorTableContentParameterIdentifier
{
    /// <inheritdoc cref="IQueryParameterIdentifier.Identifier"/>
    private string Identifier { get; }

    string IQueryParameterIdentifier.Identifier => Identifier;

    /// <inheritdoc cref="QueryParameterIdentifier"/>
    /// <param name="identifier"><inheritdoc cref="Identifier" path="/summary"/></param>
    public QueryParameterIdentifier(string identifier)
    {
        Identifier = identifier;
    }
}
