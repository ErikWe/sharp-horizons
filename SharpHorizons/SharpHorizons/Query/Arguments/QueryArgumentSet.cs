namespace SharpHorizons.Query.Arguments;

/// <inheritdoc cref="IQueryArgumentSet"/>
internal sealed class QueryArgumentSet : IQueryArgumentSet
{
    public ICommandArgument Command { get; }
    public OptionalQueryArgument<IEphemerisTypeArgument> EphemerisType { get; init; }
    public OptionalQueryArgument<IGenerateEphemeridesArgument> GenerateEphemerides { get; init; }
    public OptionalQueryArgument<IOutputFormatArgument> OutputFormat { get; init; }
    public OptionalQueryArgument<IObjectDataInclusionArgument> ObjectDataInclusion { get; init; }
    public OptionalQueryArgument<IOriginArgument> Origin { get; init; }
    public OptionalQueryArgument<IOriginCoordinateArgument> OriginCoordinate { get; init; }
    public OptionalQueryArgument<IOriginCoordinateTypeArgument> OriginCoordinateType { get; init; }
    public OptionalQueryArgument<IEpochCollectionArgument> EpochCollection { get; init; }
    public OptionalQueryArgument<IEpochCollectionFormatArgument> EpochCollectionFormat { get; init; }
    public OptionalQueryArgument<IStartEpochArgument> StartEpoch { get; init; }
    public OptionalQueryArgument<IStopEpochArgument> StopEpoch { get; init; }
    public OptionalQueryArgument<IStepSizeArgument> StepSize { get; init; }
    public OptionalQueryArgument<IReferencePlaneArgument> ReferencePlane { get; init; }
    public OptionalQueryArgument<IReferenceSystemArgument> ReferenceSystem { get; init; }
    public OptionalQueryArgument<ITimePrecisionArgument> TimePrecision { get; init; }
    public OptionalQueryArgument<IOutputUnitsArgument> OutputUnits { get; init; }
    public OptionalQueryArgument<IVectorCorrectionArgument> VectorCorrection { get; init; }
    public OptionalQueryArgument<ITimeDeltaInclusionArgument> TimeDeltaInclusion { get; init; }
    public OptionalQueryArgument<IVectorTableContentArgument> VectorTableContent { get; init; }
    public OptionalQueryArgument<IElementLabelsArgument> ElementLabels { get; init; }
    public OptionalQueryArgument<IVectorLabelsArgument> VectorLabels { get; init; }
    public OptionalQueryArgument<IValueSeparationArgument> ValueSeparation { get; init; }

    /// <summary><inheritdoc cref="QueryArgumentSet" path="/summary"/></summary>
    /// <param name="command"><inheritdoc cref="Command" path="/summary"/></param>
    public QueryArgumentSet(ICommandArgument command)
    {
        Command = command;
    }
}
