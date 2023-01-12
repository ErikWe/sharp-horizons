namespace SharpHorizons.Query.Arguments;

using Microsoft.CodeAnalysis;

using System;
using System.Runtime.CompilerServices;

/// <inheritdoc cref="IQueryArgumentSetBuilder"/>
internal sealed class QueryArgumentSetBuilder : IQueryArgumentSetBuilder
{
    /// <summary>Indicates whether the most recently executed command was <see cref="IQueryArgumentSetBuilder.Build"/>.</summary>
    private bool BuildWasPreviousCommand { get; set; }

    /// <inheritdoc cref="MutableQueryArgumentSet"/>
    private MutableQueryArgumentSet ArgumentSet { get; set; }

    /// <inheritdoc cref="QueryArgumentSetBuilder"/>
    /// <param name="command"><inheritdoc cref="IQueryArgumentSet.Command" path="/summary"/></param>
    /// <exception cref="ArgumentNullException"/>
    public QueryArgumentSetBuilder(ICommandArgument command)
    {
        QueryArgument.Validate(command);

        ArgumentSet = new(command);
    }

    /// <summary>Constructs a <see cref="QueryArgumentSetBuilder"/>, handling incremental construction of <see cref="IQueryArgumentSet"/> - with an initial configuration <paramref name="argumentSet"/>.</summary>
    /// <param name="argumentSet">The initial configuration of the <see cref="QueryArgumentSetBuilder"/>. This instance is not modified.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public QueryArgumentSetBuilder(IQueryArgumentSet argumentSet)
    {
        ArgumentNullException.ThrowIfNull(argumentSet);

        try
        {
            QueryArgument.Validate(argumentSet.Command);
        }
        catch (ArgumentException e)
        {
            throw ArgumentExceptionFactory.InvalidState<IQueryArgumentSet>(nameof(argumentSet), e);
        }

        ArgumentSet = new(argumentSet);
    }

    /// <summary>Constructs a new <see cref="MutableQueryArgumentSet"/>, <see cref="ArgumentSet"/>, if necessary.</summary>
    private void ConstructNewInstanceIfNecessary()
    {
        if (BuildWasPreviousCommand is false)
        {
            return;
        }

        BuildWasPreviousCommand = false;

        ArgumentSet = new MutableQueryArgumentSet(ArgumentSet);
    }

    /// <summary>Modifies some property of <see cref="ArgumentSet"/>, and handles construction of new instances of <see cref="MutableQueryArgumentSet"/> when necessary.</summary>
    /// <param name="setter">Sets some property of <see cref="ArgumentSet"/>.</param>
    private IQueryArgumentSetBuilder Modify(Action<MutableQueryArgumentSet> setter)
    {
        ConstructNewInstanceIfNecessary();

        setter(ArgumentSet);

        return this;
    }

    /// <summary>Specifies some property of <see cref="ArgumentSet"/>, and handles construction of new instances of <see cref="MutableQueryArgumentSet"/> when necessary.</summary>
    /// <typeparam name="TArgument">The type of the property of <see cref="ArgumentSet"/> that is specified.</typeparam>
    /// <param name="argument">The value of the property of <see cref="ArgumentSet"/>.</param>
    /// <param name="setter">Sets some property of <see cref="ArgumentSet"/>.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="argument"/>.</param>
    private IQueryArgumentSetBuilder Specify<TArgument>(TArgument argument, Action<MutableQueryArgumentSet> setter, [CallerArgumentExpression(nameof(argument))] string? argumentExpression = null) where TArgument : IQueryArgument
    {
        QueryArgument.Validate(argument, argumentExpression);

        return Modify(setter);
    }

    /// <summary>Specifies some optional property of <see cref="ArgumentSet"/>, and handles construction of new instances of <see cref="MutableQueryArgumentSet"/> when necessary.</summary>
    /// <typeparam name="TArgument">The type of the optional property of <see cref="ArgumentSet"/> that is specified.</typeparam>
    /// <param name="argument">The value of the optional property of <see cref="ArgumentSet"/>.</param>
    /// <param name="setter">Sets some optional property of <see cref="ArgumentSet"/>.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="argument"/>.</param>
    private IQueryArgumentSetBuilder SpecifyOptional<TArgument>(TArgument argument, Action<MutableQueryArgumentSet, Optional<TArgument>> setter, [CallerArgumentExpression(nameof(argument))] string? argumentExpression = null) where TArgument : IQueryArgument
    {
        return Specify(argument, (argumentSet) => setter(argumentSet, new Optional<TArgument>(argument)), argumentExpression);
    }

    /// <summary>Unspecifies some optional property of <see cref="ArgumentSet"/>, and handles construction of new instances of <see cref="MutableQueryArgumentSet"/> when necessary.</summary>
    /// <typeparam name="TArgument">The type of the optional property of <see cref="ArgumentSet"/> that is unspecified.</typeparam>
    /// <param name="setter">Unsets some optional property of <see cref="ArgumentSet"/>.</param>
    private IQueryArgumentSetBuilder UnspecifyOptional<TArgument>(Action<MutableQueryArgumentSet, Optional<TArgument>> setter) where TArgument : IQueryArgument
    {
        return Modify((argumentSet) => setter(argumentSet, new Optional<TArgument>()));
    }

    IQueryArgumentSet IQueryArgumentSetBuilder.Build()
    {
        BuildWasPreviousCommand = true;

        return ArgumentSet;
    }

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.SpecifyCommand(ICommandArgument command) => Specify(command, (argumentSet) => argumentSet.Command = command);

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.SpecifyEphemerisType(IEphemerisTypeArgument ephemerisType) => SpecifyOptional(ephemerisType, static (argumentSet, ephemerisType) => argumentSet.EphemerisType = ephemerisType);
    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.UnspecifyEphemerisType() => UnspecifyOptional<IEphemerisTypeArgument>((argumentSet, ephemerisType) => argumentSet.EphemerisType = ephemerisType);

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.SpecifyGenerateEphemeris(IGenerateEphemerisArgument generateEphemeris) => SpecifyOptional(generateEphemeris, static (argumentSet, generateEphemeris) => argumentSet.GenerateEphemeris = generateEphemeris);
    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.UnspecifyGenerateEphemeris() => UnspecifyOptional<IGenerateEphemerisArgument>((argumentSet, generateEphemeris) => argumentSet.GenerateEphemeris = generateEphemeris);

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.SpecifyOutputFormat(IOutputFormatArgument outputFormat) => SpecifyOptional(outputFormat, static (argumentSet, outputFormat) => argumentSet.OutputFormat = outputFormat);
    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.UnspecifyOutputFormat() => UnspecifyOptional<IOutputFormatArgument>((argumentSet, outputFormat) => argumentSet.OutputFormat = outputFormat);

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.SpecifyObjectDataInclusion(IObjectDataInclusionArgument objectDataInclusion) => SpecifyOptional(objectDataInclusion, static (argumentSet, objectDataInclusion) => argumentSet.ObjectDataInclusion = objectDataInclusion);
    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.UnspecifyObjectDataInclusion() => UnspecifyOptional<IObjectDataInclusionArgument>((argumentSet, objectDataInclusion) => argumentSet.ObjectDataInclusion = objectDataInclusion);

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.SpecifyOrigin(IOriginArgument origin) => SpecifyOptional(origin, static (argumentSet, origin) => argumentSet.Origin = origin);
    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.UnspecifyOrigin() => UnspecifyOptional<IOriginArgument>((argumentSet, origin) => argumentSet.Origin = origin);

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.SpecifyOriginCoordinate(IOriginCoordinateArgument originCoordinate) => SpecifyOptional(originCoordinate, static (argumentSet, originCoordinate) => argumentSet.OriginCoordinate = originCoordinate);
    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.UnspecifyOriginCoordinate() => UnspecifyOptional<IOriginCoordinateArgument>((argumentSet, originCoordinate) => argumentSet.OriginCoordinate = originCoordinate);

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.SpecifyOriginCoordinateType(IOriginCoordinateTypeArgument originCoordinateType) => SpecifyOptional(originCoordinateType, static (argumentSet, originCoordinateType) => argumentSet.OriginCoordinateType = originCoordinateType);
    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.UnspecifyOriginCoordinateType() => UnspecifyOptional<IOriginCoordinateTypeArgument>((argumentSet, originCoordinateType) => argumentSet.OriginCoordinateType = originCoordinateType);

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.SpecifyEpochCollection(IEpochCollectionArgument epochCollection) => SpecifyOptional(epochCollection, static (argumentSet, epochCollection) => argumentSet.EpochCollection = epochCollection);
    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.UnspecifyEpochCollection() => UnspecifyOptional<IEpochCollectionArgument>((argumentSet, epochCollection) => argumentSet.EpochCollection = epochCollection);

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.SpecifyEpochCollectionFormat(IEpochCollectionFormatArgument epochCollectionFormat) => SpecifyOptional(epochCollectionFormat, static (argumentSet, epochCollectionFormat) => argumentSet.EpochCollectionFormat = epochCollectionFormat);
    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.UnspecifyEpochCollectionFormat() => UnspecifyOptional<IEpochCollectionFormatArgument>((argumentSet, epochCollectionFormat) => argumentSet.EpochCollectionFormat = epochCollectionFormat);

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.SpecifyCalendarType(ICalendarTypeArgument calendarType) => SpecifyOptional(calendarType, static (argumentSet, calendarType) => argumentSet.CalendarType = calendarType);
    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.UnspecifyCalendarType() => UnspecifyOptional<ICalendarTypeArgument>((argumentSet, calendarType) => argumentSet.CalendarType = calendarType);

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.SpecifyTimeSystem(ITimeSystemArgument timeSystem) => SpecifyOptional(timeSystem, static (argumentSet, timeSystem) => argumentSet.TimeSystem = timeSystem);
    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.UnspecifyTimeSystem() => UnspecifyOptional<ITimeSystemArgument>((argumentSet, timeSystem) => argumentSet.TimeSystem = timeSystem);

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.SpecifyTimeZone(ITimeZoneArgument timeZone) => SpecifyOptional(timeZone, static (argumentSet, timeZone) => argumentSet.TimeZone = timeZone);
    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.UnspecifyTimeZone() => UnspecifyOptional<ITimeZoneArgument>((argumentSet, timeZone) => argumentSet.TimeZone = timeZone);

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.SpecifyStartEpoch(IStartEpochArgument startEpoch) => SpecifyOptional(startEpoch, static (argumentSet, startEpoch) => argumentSet.StartEpoch = startEpoch);
    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.UnspecifyStartEpoch() => UnspecifyOptional<IStartEpochArgument>((argumentSet, startEpoch) => argumentSet.StartEpoch = startEpoch);

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.SpecifyStopEpoch(IStopEpochArgument stopEpoch) => SpecifyOptional(stopEpoch, static (argumentSet, stopEpoch) => argumentSet.StopEpoch = stopEpoch);
    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.UnspecifyStopEpoch() => UnspecifyOptional<IStopEpochArgument>((argumentSet, stopEpoch) => argumentSet.StopEpoch = stopEpoch);

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.SpecifyStepSize(IStepSizeArgument stepSize) => SpecifyOptional(stepSize, static (argumentSet, stepSize) => argumentSet.StepSize = stepSize);
    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.UnspecifyStepSize() => UnspecifyOptional<IStepSizeArgument>((argumentSet, stepSize) => argumentSet.StepSize = stepSize);

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.SpecifyReferencePlane(IReferencePlaneArgument referencePlane) => SpecifyOptional(referencePlane, static (argumentSet, referencePlane) => argumentSet.ReferencePlane = referencePlane);
    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.UnspecifyRwferencePlane() => UnspecifyOptional<IReferencePlaneArgument>((argumentSet, referencePlane) => argumentSet.ReferencePlane = referencePlane);

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.SpecifyReferenceSystem(IReferenceSystemArgument referenceSystem) => SpecifyOptional(referenceSystem, static (argumentSet, referenceSystem) => argumentSet.ReferenceSystem = referenceSystem);
    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.UnspecifyReferenceSystem() => UnspecifyOptional<IReferenceSystemArgument>((argumentSet, referenceSystem) => argumentSet.ReferenceSystem = referenceSystem);

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.SpecifyTimePrecision(ITimePrecisionArgument timePrecision) => SpecifyOptional(timePrecision, static (argumentSet, timePrecision) => argumentSet.TimePrecision = timePrecision);
    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.UnspecifyTimePrecision() => UnspecifyOptional<ITimePrecisionArgument>((argumentSet, timePrecision) => argumentSet.TimePrecision = timePrecision);

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.SpecifyVectorCorrection(IVectorCorrectionArgument vectorCorrection) => SpecifyOptional(vectorCorrection, static (argumentSet, vectorCorrection) => argumentSet.VectorCorrection = vectorCorrection);
    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.UnspecifyVectorCorrection() => UnspecifyOptional<IVectorCorrectionArgument>((argumentSet, vectorCorrection) => argumentSet.VectorCorrection = vectorCorrection);

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.SpecifyTimeDeltaInclusion(ITimeDeltaInclusionArgument timeDeltaInclusion) => SpecifyOptional(timeDeltaInclusion, static (argumentSet, timeDeltaInclusion) => argumentSet.TimeDeltaInclusion = timeDeltaInclusion);
    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.UnspecifyTimeDeltaInclusion() => UnspecifyOptional<ITimeDeltaInclusionArgument>((argumentSet, timeDeltaInclusion) => argumentSet.TimeDeltaInclusion = timeDeltaInclusion);

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.SpecifyVectorTableContent(IVectorTableContentArgument vectorTableContent) => SpecifyOptional(vectorTableContent, static (argumentSet, vectorTableContent) => argumentSet.VectorTableContent = vectorTableContent);
    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.UnspecifyVectorTableContent() => UnspecifyOptional<IVectorTableContentArgument>((argumentSet, vectorTableContent) => argumentSet.VectorTableContent = vectorTableContent);

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.SpecifyOutputUnits(IOutputUnitsArgument outputUnits) => SpecifyOptional(outputUnits, static (argumentSet, outputUnits) => argumentSet.OutputUnits = outputUnits);
    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.UnspecifyOutputUnits() => UnspecifyOptional<IOutputUnitsArgument>((argumentSet, outputUnits) => argumentSet.OutputUnits = outputUnits);

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.SpecifyVectorLabels(IVectorLabelsArgument vectorLabels) => SpecifyOptional(vectorLabels, static (argumentSet, vectorLabels) => argumentSet.VectorLabels = vectorLabels);
    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.UnspecifyVectorLabels() => UnspecifyOptional<IVectorLabelsArgument>((argumentSet, vectorLabels) => argumentSet.VectorLabels = vectorLabels);

    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.SpecifyValueSeparation(IValueSeparationArgument valueSeparation) => SpecifyOptional(valueSeparation, static (argumentSet, valueSeparation) => argumentSet.ValueSeparation = valueSeparation);
    IQueryArgumentSetBuilder IQueryArgumentSetBuilder.UnspecifyValueSeparation() => UnspecifyOptional<IValueSeparationArgument>((argumentSet, valueSeparation) => argumentSet.ValueSeparation = valueSeparation);

    /// <summary>A mutable <see cref="IQueryArgumentSet"/>.</summary>
    private sealed record class MutableQueryArgumentSet : IQueryArgumentSet
    {
        public ICommandArgument Command { get; set; }
        public Optional<IEphemerisTypeArgument> EphemerisType { get; set; }
        public Optional<IGenerateEphemerisArgument> GenerateEphemeris { get; set; }
        public Optional<IOutputFormatArgument> OutputFormat { get; set; }
        public Optional<IObjectDataInclusionArgument> ObjectDataInclusion { get; set; }
        public Optional<IOriginArgument> Origin { get; set; }
        public Optional<IOriginCoordinateArgument> OriginCoordinate { get; set; }
        public Optional<IOriginCoordinateTypeArgument> OriginCoordinateType { get; set; }
        public Optional<IEpochCollectionArgument> EpochCollection { get; set; }
        public Optional<IEpochCollectionFormatArgument> EpochCollectionFormat { get; set; }
        public Optional<ICalendarTypeArgument> CalendarType { get; set; }
        public Optional<ITimeSystemArgument> TimeSystem { get; set; }
        public Optional<ITimeZoneArgument> TimeZone { get; set; }
        public Optional<IStartEpochArgument> StartEpoch { get; set; }
        public Optional<IStopEpochArgument> StopEpoch { get; set; }
        public Optional<IStepSizeArgument> StepSize { get; set; }
        public Optional<IReferencePlaneArgument> ReferencePlane { get; set; }
        public Optional<IReferenceSystemArgument> ReferenceSystem { get; set; }
        public Optional<ITimePrecisionArgument> TimePrecision { get; set; }
        public Optional<IOutputUnitsArgument> OutputUnits { get; set; }
        public Optional<IVectorCorrectionArgument> VectorCorrection { get; set; }
        public Optional<ITimeDeltaInclusionArgument> TimeDeltaInclusion { get; set; }
        public Optional<IVectorTableContentArgument> VectorTableContent { get; set; }
        public Optional<IVectorLabelsArgument> VectorLabels { get; set; }
        public Optional<IValueSeparationArgument> ValueSeparation { get; set; }

        /// <inheritdoc cref="MutableQueryArgumentSet"/>
        /// <param name="command"><inheritdoc cref="Command" path="/summary"/></param>
        public MutableQueryArgumentSet(ICommandArgument command)
        {
            Command = command;
        }

        /// <summary>Constructs a new <see cref="MutableQueryArgumentSet"/>, with an initial configuration <paramref name="argumentSet"/>.</summary>
        /// <param name="argumentSet"> The initial configuration of the <see cref="MutableQueryArgumentSet"/>. This instance is not modified.</param>
        public MutableQueryArgumentSet(IQueryArgumentSet argumentSet)
        {
            Command = argumentSet.Command;
            EphemerisType = argumentSet.EphemerisType;
            GenerateEphemeris = argumentSet.GenerateEphemeris;
            OutputFormat = argumentSet.OutputFormat;
            ObjectDataInclusion = argumentSet.ObjectDataInclusion;
            Origin = argumentSet.Origin;
            OriginCoordinate = argumentSet.OriginCoordinate;
            OriginCoordinateType = argumentSet.OriginCoordinateType;
            EpochCollection = argumentSet.EpochCollection;
            EpochCollectionFormat = argumentSet.EpochCollectionFormat;
            CalendarType = argumentSet.CalendarType;
            TimeSystem = argumentSet.TimeSystem;
            TimeZone = argumentSet.TimeZone;
            StartEpoch = argumentSet.StartEpoch;
            StopEpoch = argumentSet.StopEpoch;
            StepSize = argumentSet.StepSize;
            ReferencePlane = argumentSet.ReferencePlane;
            ReferenceSystem = argumentSet.ReferenceSystem;
            TimePrecision = argumentSet.TimePrecision;
            OutputUnits = argumentSet.OutputUnits;
            VectorCorrection = argumentSet.VectorCorrection;
            TimeDeltaInclusion = argumentSet.TimeDeltaInclusion;
            VectorTableContent = argumentSet.VectorTableContent;
            VectorLabels = argumentSet.VectorLabels;
            ValueSeparation = argumentSet.ValueSeparation;
        }
    }
}
