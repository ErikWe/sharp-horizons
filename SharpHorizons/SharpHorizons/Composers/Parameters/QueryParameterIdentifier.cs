namespace SharpHorizons.Composers.Parameters;

/// <inheritdoc cref="IQueryParameterIdentifier"/>
internal sealed record class QueryParameterIdentifier : IQueryParameterIdentifier, IElementLabelsParameterIdentifier, IEphemerisTypeParameterIdentifier, IEpochCollectionParameterIdentifier, IEpochCollectionFormatParameterIdentifier, IGenerateEphemeridesParameterIdentifier, IObjectDataInclusionParameterIdentifier,
    IOriginParameterIdentifier, IOriginCoordinateParameterIdentifier, IOriginCoordinateTypeParameterIdentifier, IOutputFormatParameterIdentifier, IOutputUnitsParameterIdentifier, IReferencePlaneParameterIdentifier, IReferenceSystemParameterIdentifier, IStartEpochParameterIdentifier, IStepSizeParameterIdentifier,
    IStopEpochParameterIdentifier, ITargetParameterIdentifier, ITimeDeltaInclusionParameterIdentifier, ITimePrecisionParameterIdentifier, IValueSeparationParameterIdentifier, IVectorCorrectionParameterIdentifier, IVectorLabelsParameterIdentifier, IVectorTableContentParameterIdentifier
{
    /// <inheritdoc/>
    public string Identifier { get; }

    /// <summary>Uses { <paramref name="identifier"/> } to describe the identifier of the parameter in a query.</summary>
    /// <param name="identifier"><inheritdoc cref="Identifier" path="/summary"/></param>
    public QueryParameterIdentifier(string identifier)
    {
        Identifier = identifier;
    }
}
