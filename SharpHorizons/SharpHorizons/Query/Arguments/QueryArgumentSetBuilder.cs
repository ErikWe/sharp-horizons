namespace SharpHorizons.Query.Arguments;

/// <inheritdoc cref="IQueryArgumentSetBuilder"/>
internal sealed class QueryArgumentSetBuilder : IQueryArgumentSetBuilder
{
    /// <summary><inheritdoc cref="QueryArgumentSet" path="/summary"/></summary>
    private MutableQueryArgumentSet ArgumentSet { get; set; } = new();

    IQueryArgumentSet IQueryArgumentSetBuilder.Build()
    {
        if (ArgumentSet.Command is null)
        {
            throw new QueryArgumentRequireCommandException();
        }

        return new QueryArgumentSet(ArgumentSet.Command)
        {
            EphemerisType = ArgumentSet.EphemerisType,
            GenerateEphemerides = ArgumentSet.GenerateEphemerides,
            OutputFormat = ArgumentSet.OutputFormat,
            ObjectDataInclusion = ArgumentSet.ObjectDataInclusion,
            Origin = ArgumentSet.Origin,
            OriginCoordinate = ArgumentSet.OriginCoordinate,
            OriginCoordinateType = ArgumentSet.OriginCoordinateType,
            EpochCollection = ArgumentSet.EpochCollection,
            EpochCollectionFormat = ArgumentSet.EpochCollectionFormat,
            StartEpoch = ArgumentSet.StartEpoch,
            StopEpoch = ArgumentSet.StopEpoch,
            StepSize = ArgumentSet.StepSize,
            ReferencePlane = ArgumentSet.ReferencePlane,
            ReferenceSystem = ArgumentSet.ReferenceSystem,
            TimePrecision = ArgumentSet.TimePrecision,
            VectorCorrection = ArgumentSet.VectorCorrection,
            TimeDeltaInclusion = ArgumentSet.TimeDeltaInclusion,
            VectorTableContent = ArgumentSet.VectorTableContent,
            OutputUnits = ArgumentSet.OutputUnits,
            ElementLabels = ArgumentSet.ElementLabels,
            VectorLabels = ArgumentSet.VectorLabels,
            ValueSeparation = ArgumentSet.ValueSeparation
        };
    }

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.Specify(ICommandArgument command)
    {
        ArgumentSet.Command = command;

        return this;
    }

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.Specify(IEphemerisTypeArgument ephemerisType)
    {
        ArgumentSet.EphemerisType = OptionalQueryArgument.Construct(ephemerisType);

        return this;
    }

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.Specify(IGenerateEphemeridesArgument generateEphemerides)
    {
        ArgumentSet.GenerateEphemerides = OptionalQueryArgument.Construct(generateEphemerides);

        return this;
    }

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.Specify(IOutputFormatArgument outputFormat)
    {
        ArgumentSet.OutputFormat = OptionalQueryArgument.Construct(outputFormat);

        return this;
    }

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.Specify(IObjectDataInclusionArgument objectDataInclusion)
    {
        ArgumentSet.ObjectDataInclusion = OptionalQueryArgument.Construct(objectDataInclusion);

        return this;
    }

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.Specify(IOriginArgument origin)
    {
        ArgumentSet.Origin = OptionalQueryArgument.Construct(origin);

        return this;
    }

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.Specify(IOriginCoordinateArgument originCoordinate)
    {
        ArgumentSet.OriginCoordinate = OptionalQueryArgument.Construct(originCoordinate);

        return this;
    }

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.Specify(IOriginCoordinateTypeArgument originCoordinateType)
    {
        ArgumentSet.OriginCoordinateType = OptionalQueryArgument.Construct(originCoordinateType);

        return this;
    }

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.Specify(IEpochCollectionArgument epochCollection)
    {
        ArgumentSet.EpochCollection = OptionalQueryArgument.Construct(epochCollection);

        return this;
    }

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.Specify(IEpochCollectionFormatArgument epochCollectionFormat)
    {
        ArgumentSet.EpochCollectionFormat = OptionalQueryArgument.Construct(epochCollectionFormat);

        return this;
    }

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.Specify(IStartEpochArgument startEpoch)
    {
        ArgumentSet.StartEpoch = OptionalQueryArgument.Construct(startEpoch);

        return this;
    }

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.Specify(IStopEpochArgument stopEpoch)
    {
        ArgumentSet.StopEpoch = OptionalQueryArgument.Construct(stopEpoch);

        return this;
    }

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.Specify(IStepSizeArgument stepSize)
    {
        ArgumentSet.StepSize = OptionalQueryArgument.Construct(stepSize);

        return this;
    }

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.Specify(IReferencePlaneArgument referencePlane)
    {
        ArgumentSet.ReferencePlane = OptionalQueryArgument.Construct(referencePlane);

        return this;
    }

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.Specify(IReferenceSystemArgument referenceSystem)
    {
        ArgumentSet.ReferenceSystem = OptionalQueryArgument.Construct(referenceSystem);

        return this;
    }

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.Specify(ITimePrecisionArgument timePrecision)
    {
        ArgumentSet.TimePrecision = OptionalQueryArgument.Construct(timePrecision);

        return this;
    }

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.Specify(IVectorCorrectionArgument vectorCorrection)
    {
        ArgumentSet.VectorCorrection = OptionalQueryArgument.Construct(vectorCorrection);

        return this;
    }

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.Specify(ITimeDeltaInclusionArgument timeDeltaInclusion)
    {
        ArgumentSet.TimeDeltaInclusion = OptionalQueryArgument.Construct(timeDeltaInclusion);

        return this;
    }

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.Specify(IVectorTableContentArgument vectorTableContent)
    {
        ArgumentSet.VectorTableContent = OptionalQueryArgument.Construct(vectorTableContent);

        return this;
    }

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.Specify(IOutputUnitsArgument outputUnits)
    {
        ArgumentSet.OutputUnits = OptionalQueryArgument.Construct(outputUnits);

        return this;
    }

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.Specify(IElementLabelsArgument elementLabels)
    {
        ArgumentSet.ElementLabels = OptionalQueryArgument.Construct(elementLabels);

        return this;
    }

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.Specify(IVectorLabelsArgument vectorLabels)
    {
        ArgumentSet.VectorLabels = OptionalQueryArgument.Construct(vectorLabels);

        return this;
    }

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.Specify(IValueSeparationArgument valueSeparation)
    {
        ArgumentSet.ValueSeparation = OptionalQueryArgument.Construct(valueSeparation);

        return this;
    }

    /// <summary>A mutable <see cref="IQueryArgumentSet"/>.</summary>
    internal sealed class MutableQueryArgumentSet
    {
        /// <inheritdoc cref="IQueryArgumentSet.Command"/>
        public ICommandArgument? Command { get; set; }

        /// <inheritdoc cref="IQueryArgumentSet.EphemerisType"/>
        public OptionalQueryArgument<IEphemerisTypeArgument> EphemerisType { get; set; }

        /// <inheritdoc cref="IQueryArgumentSet.GenerateEphemerides"/>
        public OptionalQueryArgument<IGenerateEphemeridesArgument> GenerateEphemerides { get; set; }

        /// <inheritdoc cref="IQueryArgumentSet.OutputFormat"/>
        public OptionalQueryArgument<IOutputFormatArgument> OutputFormat { get; set; }

        /// <inheritdoc cref="IQueryArgumentSet.ObjectDataInclusion"/>
        public OptionalQueryArgument<IObjectDataInclusionArgument> ObjectDataInclusion { get; set; }

        /// <inheritdoc cref="IQueryArgumentSet.Origin"/>
        public OptionalQueryArgument<IOriginArgument> Origin { get; set; }

        /// <inheritdoc cref="IQueryArgumentSet.OriginCoordinate"/>
        public OptionalQueryArgument<IOriginCoordinateArgument> OriginCoordinate { get; set; }

        /// <inheritdoc cref="IQueryArgumentSet.OriginCoordinateType"/>
        public OptionalQueryArgument<IOriginCoordinateTypeArgument> OriginCoordinateType { get; set; }

        /// <inheritdoc cref="IQueryArgumentSet.EpochCollection"/>
        public OptionalQueryArgument<IEpochCollectionArgument> EpochCollection { get; set; }

        /// <inheritdoc cref="IQueryArgumentSet.EpochCollectionFormat"/>
        public OptionalQueryArgument<IEpochCollectionFormatArgument> EpochCollectionFormat { get; set; }

        /// <inheritdoc cref="IQueryArgumentSet.StartEpoch"/>
        public OptionalQueryArgument<IStartEpochArgument> StartEpoch { get; set; }

        /// <inheritdoc cref="IQueryArgumentSet.StopEpoch"/>
        public OptionalQueryArgument<IStopEpochArgument> StopEpoch { get; set; }

        /// <inheritdoc cref="IQueryArgumentSet.StepSize"/>
        public OptionalQueryArgument<IStepSizeArgument> StepSize { get; set; }

        /// <inheritdoc cref="IQueryArgumentSet.ReferencePlane"/>
        public OptionalQueryArgument<IReferencePlaneArgument> ReferencePlane { get; set; }

        /// <inheritdoc cref="IQueryArgumentSet.ReferenceSystem"/>
        public OptionalQueryArgument<IReferenceSystemArgument> ReferenceSystem { get; set; }

        /// <inheritdoc cref="IQueryArgumentSet.TimePrecision"/>
        public OptionalQueryArgument<ITimePrecisionArgument> TimePrecision { get; set; }

        /// <inheritdoc cref="IQueryArgumentSet.OutputUnits"/>
        public OptionalQueryArgument<IOutputUnitsArgument> OutputUnits { get; set; }

        /// <inheritdoc cref="IQueryArgumentSet.VectorCorrection"/>
        public OptionalQueryArgument<IVectorCorrectionArgument> VectorCorrection { get; set; }

        /// <inheritdoc cref="IQueryArgumentSet.TimeDeltaInclusion"/>
        public OptionalQueryArgument<ITimeDeltaInclusionArgument> TimeDeltaInclusion { get; set; }

        /// <inheritdoc cref="IQueryArgumentSet.VectorTableContent"/>
        public OptionalQueryArgument<IVectorTableContentArgument> VectorTableContent { get; set; }

        /// <inheritdoc cref="IQueryArgumentSet.ElementLabels"/>
        public OptionalQueryArgument<IElementLabelsArgument> ElementLabels { get; set; }

        /// <inheritdoc cref="IQueryArgumentSet.VectorLabels"/>
        public OptionalQueryArgument<IVectorLabelsArgument> VectorLabels { get; set; }

        /// <inheritdoc cref="IQueryArgumentSet.ValueSeparation"/>
        public OptionalQueryArgument<IValueSeparationArgument> ValueSeparation { get; set; }
    }
}
