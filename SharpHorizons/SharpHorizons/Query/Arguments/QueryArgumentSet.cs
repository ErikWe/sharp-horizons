namespace SharpHorizons.Query.Arguments;

/// <inheritdoc cref="IQueryArgumentSet"/>
internal sealed class QueryArgumentSet : IQueryArgumentSet
{
    /// <inheritdoc/>
    public ICommandArgument Command { get; }

    /// <inheritdoc/>
    public OptionalQueryArgument<IEphemerisTypeArgument> EphemerisType { get; init; }

    /// <inheritdoc/>
    public OptionalQueryArgument<IGenerateEphemeridesArgument> GenerateEphemerides { get; init; }

    /// <inheritdoc/>
    public OptionalQueryArgument<IOutputFormatArgument> OutputFormat { get; init; }

    /// <inheritdoc/>
    public OptionalQueryArgument<IObjectDataInclusionArgument> ObjectDataInclusion { get; init; }

    /// <inheritdoc/>
    public OptionalQueryArgument<IOriginArgument> Origin { get; init; }

    /// <inheritdoc/>
    public OptionalQueryArgument<IOriginCoordinateArgument> OriginCoordinate { get; init; }

    /// <inheritdoc/>
    public OptionalQueryArgument<IOriginCoordinateTypeArgument> OriginCoordinateType { get; init; }

    /// <inheritdoc/>
    public OptionalQueryArgument<IEpochCollectionArgument> EpochCollection { get; init; }

    /// <inheritdoc/>
    public OptionalQueryArgument<IEpochCollectionFormatArgument> EpochCollectionFormat { get; init; }

    /// <inheritdoc/>
    public OptionalQueryArgument<IStartEpochArgument> StartEpoch { get; init; }

    /// <inheritdoc/>
    public OptionalQueryArgument<IStopEpochArgument> StopEpoch { get; init; }

    /// <inheritdoc/>
    public OptionalQueryArgument<IStepSizeArgument> StepSize { get; init; }

    /// <inheritdoc/>
    public OptionalQueryArgument<IReferencePlaneArgument> ReferencePlane { get; init; }

    /// <inheritdoc/>
    public OptionalQueryArgument<IReferenceSystemArgument> ReferenceSystem { get; init; }

    /// <inheritdoc/>
    public OptionalQueryArgument<ITimePrecisionArgument> TimePrecision { get; init; }

    /// <inheritdoc/>
    public OptionalQueryArgument<IOutputUnitsArgument> OutputUnits { get; init; }

    /// <inheritdoc/>
    public OptionalQueryArgument<IVectorCorrectionArgument> VectorCorrection { get; init; }

    /// <inheritdoc/>
    public OptionalQueryArgument<ITimeDeltaInclusionArgument> TimeDeltaInclusion { get; init; }

    /// <inheritdoc/>
    public OptionalQueryArgument<IVectorTableContentArgument> VectorTableContent { get; init; }

    /// <inheritdoc/>
    public OptionalQueryArgument<IElementLabelsArgument> ElementLabels { get; init; }

    /// <inheritdoc/>
    public OptionalQueryArgument<IVectorLabelsArgument> VectorLabels { get; init; }

    /// <inheritdoc/>
    public OptionalQueryArgument<IValueSeparationArgument> ValueSeparation { get; init; }

    /// <summary><inheritdoc cref="QueryArgumentSet" path="/summary"/></summary>
    /// <param name="command"><inheritdoc cref="Command" path="/summary"/></param>
    public QueryArgumentSet(ICommandArgument command)
    {
        Command = command;
    }
}
