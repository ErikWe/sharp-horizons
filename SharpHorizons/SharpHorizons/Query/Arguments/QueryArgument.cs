namespace SharpHorizons.Query.Arguments;

/// <inheritdoc cref="IQueryArgument"/>
internal sealed record class QueryArgument : IQueryArgument, ICommandArgument, IElementLabelsArgument, IEphemerisTypeArgument, IEpochCollectionArgument, IEpochCollectionFormatArgument, IGenerateEphemeridesArgument,
    IObjectDataInclusionArgument, IOriginArgument, IOriginCoordinateArgument, IOriginCoordinateTypeArgument, IOutputFormatArgument, IOutputUnitsArgument, IReferencePlaneArgument, IReferenceSystemArgument,
    IStartEpochArgument, IStepSizeArgument, IStopEpochArgument, ITargetArgument, ITimeDeltaInclusionArgument, ITimePrecisionArgument, IValueSeparationArgument, IVectorCorrectionArgument, IVectorLabelsArgument, IVectorTableContentArgument
{
    public string Value { get; }

    /// <summary><inheritdoc cref="QueryArgument" path="/summary"/></summary>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    public QueryArgument(string value)
    {
        Value = value;
    }
}