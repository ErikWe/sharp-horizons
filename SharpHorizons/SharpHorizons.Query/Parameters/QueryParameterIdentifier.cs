namespace SharpHorizons.Query.Parameters;

using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IQueryParameterIdentifier"/>
internal sealed class QueryParameterIdentifier : IQueryParameterIdentifier, ICommandParameterIdentifier, IEphemerisTypeParameterIdentifier, ICalendarTypeParameterIdentifier, IEpochCollectionFormatParameterIdentifier, IEpochCollectionParameterIdentifier,
    IGenerateEphemerisParameterIdentifier, IObjectDataInclusionParameterIdentifier, IOriginCoordinateParameterIdentifier, IOriginCoordinateTypeParameterIdentifier, IOriginParameterIdentifier, IOutputFormatParameterIdentifier, IOutputUnitsParameterIdentifier,
    IReferencePlaneParameterIdentifier, IReferenceSystemParameterIdentifier, IStartEpochParameterIdentifier, IStepSizeParameterIdentifier, IStopEpochParameterIdentifier, ITimeDeltaInclusionParameterIdentifier, ITimePrecisionParameterIdentifier,
    ITimeSystemParameterIdentifier, ITimeZoneParameterIdentifier, IValueSeparationParameterIdentifier, IVectorCorrectionParameterIdentifier, IVectorLabelsParameterIdentifier, IVectorTableContentParameterIdentifier
{
    public required string Identifier { get; init; }

    /// <inheritdoc cref="QueryParameterIdentifier"/>
    public QueryParameterIdentifier() { }

    /// <inheritdoc cref="QueryParameterIdentifier"/>
    /// <param name="identifier"><inheritdoc cref="Identifier" path="/summary"/></param>
    [SetsRequiredMembers]
    public QueryParameterIdentifier(string identifier)
    {
        Identifier = identifier;
    }
}
