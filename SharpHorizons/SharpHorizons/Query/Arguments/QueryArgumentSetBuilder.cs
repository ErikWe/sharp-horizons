namespace SharpHorizons.Query.Arguments;

using System;

/// <inheritdoc cref="IQueryArgumentSetBuilder"/>
internal sealed class QueryArgumentSetBuilder : IQueryArgumentSetBuilder
{
    /// <inheritdoc cref="IQueryArgumentSet"/>
    private MutableQueryArgumentSet ArgumentSet { get; set; } = new();

    IQueryArgumentSet IQueryArgumentSetBuilder.Build()
    {
        if (ArgumentSet.Command is null)
        {
            throw new InvalidOperationException($"The {nameof(ICommandArgument)} of the {nameof(IQueryArgumentSet)} was never specified by the {nameof(IQueryArgumentSetBuilder)}.");
        }

        return ArgumentSet;
    }

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.Specify(ICommandArgument command)
    {
        QueryArgument.Validate(command);

        ArgumentSet.Command = command;

        return this;
    }

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.Specify(IEphemerisTypeArgument ephemerisType)
    {
        QueryArgument.Validate(ephemerisType);

        ArgumentSet.EphemerisType = OptionalQueryArgument.Construct(ephemerisType);

        return this;
    }

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.Specify(IGenerateEphemerisArgument generateEphemeris)
    {
        QueryArgument.Validate(generateEphemeris);

        ArgumentSet.GenerateEphemeris = OptionalQueryArgument.Construct(generateEphemeris);

        return this;
    }

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.Specify(IOutputFormatArgument outputFormat)
    {
        QueryArgument.Validate(outputFormat);

        ArgumentSet.OutputFormat = OptionalQueryArgument.Construct(outputFormat);

        return this;
    }

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.Specify(IObjectDataInclusionArgument objectDataInclusion)
    {
        QueryArgument.Validate(objectDataInclusion);

        ArgumentSet.ObjectDataInclusion = OptionalQueryArgument.Construct(objectDataInclusion);

        return this;
    }

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.Specify(IOriginArgument origin)
    {
        QueryArgument.Validate(origin);

        ArgumentSet.Origin = OptionalQueryArgument.Construct(origin);

        return this;
    }

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.Specify(IOriginCoordinateArgument originCoordinate)
    {
        QueryArgument.Validate(originCoordinate);

        ArgumentSet.OriginCoordinate = OptionalQueryArgument.Construct(originCoordinate);

        return this;
    }

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.Specify(IOriginCoordinateTypeArgument originCoordinateType)
    {
        QueryArgument.Validate(originCoordinateType);

        ArgumentSet.OriginCoordinateType = OptionalQueryArgument.Construct(originCoordinateType);

        return this;
    }

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.Specify(IEpochCollectionArgument epochCollection)
    {
        QueryArgument.Validate(epochCollection);

        ArgumentSet.EpochCollection = OptionalQueryArgument.Construct(epochCollection);

        return this;
    }

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.Specify(IEpochCollectionFormatArgument epochCollectionFormat)
    {
        QueryArgument.Validate(epochCollectionFormat);

        ArgumentSet.EpochCollectionFormat = OptionalQueryArgument.Construct(epochCollectionFormat);

        return this;
    }

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.Specify(ICalendarTypeArgument epochCalendar)
    {
        QueryArgument.Validate(epochCalendar);

        ArgumentSet.EpochCalendar = OptionalQueryArgument.Construct(epochCalendar);

        return this;
    }

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.Specify(ITimeSystemArgument timeSystem)
    {
        QueryArgument.Validate(timeSystem);

        ArgumentSet.TimeSystem = OptionalQueryArgument.Construct(timeSystem);

        return this;
    }

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.Specify(ITimeZoneArgument timeZone)
    {
        QueryArgument.Validate(timeZone);

        ArgumentSet.TimeZone = OptionalQueryArgument.Construct(timeZone);

        return this;
    }

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.Specify(IStartEpochArgument startEpoch)
    {
        QueryArgument.Validate(startEpoch);

        ArgumentSet.StartEpoch = OptionalQueryArgument.Construct(startEpoch);

        return this;
    }

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.Specify(IStopEpochArgument stopEpoch)
    {
        QueryArgument.Validate(stopEpoch);

        ArgumentSet.StopEpoch = OptionalQueryArgument.Construct(stopEpoch);

        return this;
    }

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.Specify(IStepSizeArgument stepSize)
    {
        QueryArgument.Validate(stepSize);

        ArgumentSet.StepSize = OptionalQueryArgument.Construct(stepSize);

        return this;
    }

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.Specify(IReferencePlaneArgument referencePlane)
    {
        QueryArgument.Validate(referencePlane);

        ArgumentSet.ReferencePlane = OptionalQueryArgument.Construct(referencePlane);

        return this;
    }

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.Specify(IReferenceSystemArgument referenceSystem)
    {
        QueryArgument.Validate(referenceSystem);

        ArgumentSet.ReferenceSystem = OptionalQueryArgument.Construct(referenceSystem);

        return this;
    }

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.Specify(ITimePrecisionArgument timePrecision)
    {
        QueryArgument.Validate(timePrecision);

        ArgumentSet.TimePrecision = OptionalQueryArgument.Construct(timePrecision);

        return this;
    }

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.Specify(IVectorCorrectionArgument vectorCorrection)
    {
        QueryArgument.Validate(vectorCorrection);

        ArgumentSet.VectorCorrection = OptionalQueryArgument.Construct(vectorCorrection);

        return this;
    }

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.Specify(ITimeDeltaInclusionArgument timeDeltaInclusion)
    {
        QueryArgument.Validate(timeDeltaInclusion);

        ArgumentSet.TimeDeltaInclusion = OptionalQueryArgument.Construct(timeDeltaInclusion);

        return this;
    }

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.Specify(IVectorTableContentArgument vectorTableContent)
    {
        QueryArgument.Validate(vectorTableContent);

        ArgumentSet.VectorTableContent = OptionalQueryArgument.Construct(vectorTableContent);

        return this;
    }

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.Specify(IOutputUnitsArgument outputUnits)
    {
        QueryArgument.Validate(outputUnits);

        ArgumentSet.OutputUnits = OptionalQueryArgument.Construct(outputUnits);

        return this;
    }

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.Specify(IVectorLabelsArgument vectorLabels)
    {
        QueryArgument.Validate(vectorLabels);

        ArgumentSet.VectorLabels = OptionalQueryArgument.Construct(vectorLabels);

        return this;
    }

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.Specify(IValueSeparationArgument valueSeparation)
    {
        QueryArgument.Validate(valueSeparation);

        ArgumentSet.ValueSeparation = OptionalQueryArgument.Construct(valueSeparation);

        return this;
    }

    /// <summary>A mutable <see cref="IQueryArgumentSet"/>.</summary>
    internal sealed class MutableQueryArgumentSet : IQueryArgumentSet
    {
        public ICommandArgument Command { get; set; } = null!;
        public OptionalQueryArgument<IEphemerisTypeArgument> EphemerisType { get; set; }
        public OptionalQueryArgument<IGenerateEphemerisArgument> GenerateEphemeris { get; set; }
        public OptionalQueryArgument<IOutputFormatArgument> OutputFormat { get; set; }
        public OptionalQueryArgument<IObjectDataInclusionArgument> ObjectDataInclusion { get; set; }
        public OptionalQueryArgument<IOriginArgument> Origin { get; set; }
        public OptionalQueryArgument<IOriginCoordinateArgument> OriginCoordinate { get; set; }
        public OptionalQueryArgument<IOriginCoordinateTypeArgument> OriginCoordinateType { get; set; }
        public OptionalQueryArgument<IEpochCollectionArgument> EpochCollection { get; set; }
        public OptionalQueryArgument<IEpochCollectionFormatArgument> EpochCollectionFormat { get; set; }
        public OptionalQueryArgument<ICalendarTypeArgument> EpochCalendar { get; set; }
        public OptionalQueryArgument<ITimeSystemArgument> TimeSystem { get; set; }
        public OptionalQueryArgument<ITimeZoneArgument> TimeZone { get; set; }
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
        public OptionalQueryArgument<IVectorLabelsArgument> VectorLabels { get; set; }
        public OptionalQueryArgument<IValueSeparationArgument> ValueSeparation { get; set; }
    }
}
