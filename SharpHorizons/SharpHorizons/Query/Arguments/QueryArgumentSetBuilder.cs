namespace SharpHorizons.Query.Arguments;

/// <inheritdoc cref="IQueryArgumentSetBuilder"/>
internal sealed class QueryArgumentSetBuilder : IQueryArgumentSetBuilder
{
    /// <summary><inheritdoc cref="IQueryArgumentSet" path="/summary"/></summary>
    private MutableQueryArgumentSet ArgumentSet { get; set; } = new();

    IQueryArgumentSet IQueryArgumentSetBuilder.Build()
    {
        if (ArgumentSet.Command is null)
        {
            throw new QueryArgumentRequireCommandException();
        }

        return ArgumentSet;
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
    internal sealed class MutableQueryArgumentSet : IQueryArgumentSet
    {
        public ICommandArgument Command { get; set; } = null!;
        public OptionalQueryArgument<IEphemerisTypeArgument> EphemerisType { get; set; }
        public OptionalQueryArgument<IGenerateEphemeridesArgument> GenerateEphemerides { get; set; }
        public OptionalQueryArgument<IOutputFormatArgument> OutputFormat { get; set; }
        public OptionalQueryArgument<IObjectDataInclusionArgument> ObjectDataInclusion { get; set; }
        public OptionalQueryArgument<IOriginArgument> Origin { get; set; }
        public OptionalQueryArgument<IOriginCoordinateArgument> OriginCoordinate { get; set; }
        public OptionalQueryArgument<IOriginCoordinateTypeArgument> OriginCoordinateType { get; set; }
        public OptionalQueryArgument<IEpochCollectionArgument> EpochCollection { get; set; }
        public OptionalQueryArgument<IEpochCollectionFormatArgument> EpochCollectionFormat { get; set; }
        public OptionalQueryArgument<IStartEpochArgument> StartEpoch { get; set; }
        public OptionalQueryArgument<IStopEpochArgument> StopEpoch { get; set; }
        public OptionalQueryArgument<IStepSizeArgument> StepSize { get; set; }
        public OptionalQueryArgument<IReferencePlaneArgument> ReferencePlane { get; set; }
        public OptionalQueryArgument<IReferenceSystemArgument> ReferenceSystem { get; set; }
        public OptionalQueryArgument<ITimePrecisionArgument> TimePrecision { get; set; }
        public OptionalQueryArgument<IOutputUnitsArgument> OutputUnits { get; set; }
        public OptionalQueryArgument<IVectorCorrectionArgument> VectorCorrection { get; set; }
        public OptionalQueryArgument<ITimeDeltaInclusionArgument> TimeDeltaInclusion { get; set; }
        public OptionalQueryArgument<IVectorTableContentArgument> VectorTableContent { get; set; }
        public OptionalQueryArgument<IElementLabelsArgument> ElementLabels { get; set; }
        public OptionalQueryArgument<IVectorLabelsArgument> VectorLabels { get; set; }
        public OptionalQueryArgument<IValueSeparationArgument> ValueSeparation { get; set; }
    }
}
