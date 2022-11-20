namespace SharpHorizons.Query.Parameters;

using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IQueryParameterIdentifier"/>
internal sealed class QueryParameterIdentifier : IQueryParameterIdentifier, ICommandParameterIdentifier, IElementLabelsParameterIdentifier, IEphemerisTypeParameterIdentifier, IEpochCollectionFormatParameterIdentifier, IEpochCollectionParameterIdentifier,
    IGenerateEphemeridesParameterIdentifier, IObjectDataInclusionParameterIdentifier, IOriginCoordinateParameterIdentifier, IOriginCoordinateTypeParameterIdentifier, IOriginParameterIdentifier, IOutputFormatParameterIdentifier, IOutputUnitsParameterIdentifier,
    IReferencePlaneParameterIdentifier, IReferenceSystemParameterIdentifier, IStartEpochParameterIdentifier, IStepSizeParameterIdentifier, IStopEpochParameterIdentifier, ITimeDeltaInclusionParameterIdentifier, ITimePrecisionParameterIdentifier, IValueSeparationParameterIdentifier,
    IVectorCorrectionParameterIdentifier, IVectorLabelsParameterIdentifier, IVectorTableContentParameterIdentifier
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
