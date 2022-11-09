namespace SharpHorizons.Query;

/// <inheritdoc cref="IQueryArgument"/>
internal sealed record class QueryArgument : IQueryArgument, ICommandArgument, IElementLabelsArgument, IEphemerisTypeArgument, IEpochCollectionArgument, IEpochCollectionFormatArgument, IGenerateEphemeridesArgument,
    IObjectDataInclusionArgument, IOriginArgument, IOriginCoordinateArgument, IOriginCoordinateTypeArgument, IOutputFormatArgument, IOutputUnitsArgument, IReferencePlaneArgument, IReferenceSystemArgument,
    IStartEpochArgument, IStepSizeArgument, IStopEpochArgument, ITimeDeltaInclusionArgument, ITimePrecisionArgument, IValueSeparationArgument, IVectorCorrectionArgument, IVectorLabelsArgument, IVectorTableContentArgument
{
    /// <inheritdoc/>
    public string Value { get; }

    /// <summary>Uses { <paramref name="value"/> } to describe the value of the parameter in a query.</summary>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    public QueryArgument(string value)
    {
        Value = value;
    }
}