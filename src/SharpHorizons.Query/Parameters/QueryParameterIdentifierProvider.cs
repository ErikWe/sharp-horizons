namespace SharpHorizons.Query.Parameters;

using Microsoft.Extensions.Options;

using SharpHorizons.Settings.Query.Parameters;

using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IQueryParameterIdentifierProvider"/>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class QueryParameterIdentifierProvider : IQueryParameterIdentifierProvider
{
    /// <inheritdoc cref="IQueryParameterIdentifierProvider.Command"/>
    private ICommandParameterIdentifier Command { get; }

    /// <inheritdoc cref="IQueryParameterIdentifierProvider.EphemerisType"/>
    private IEphemerisTypeParameterIdentifier EphemerisType { get; }

    /// <inheritdoc cref="IQueryParameterIdentifierProvider.CalendarType"/>
    private ICalendarTypeParameterIdentifier CalendarType { get; }

    /// <inheritdoc cref="IQueryParameterIdentifierProvider.EpochCollection"/>
    private IEpochCollectionParameterIdentifier EpochCollection { get; }

    /// <inheritdoc cref="IQueryParameterIdentifierProvider.EpochCollectionFormat"/>
    private IEpochCollectionFormatParameterIdentifier EpochCollectionFormat { get; }

    /// <inheritdoc cref="IQueryParameterIdentifierProvider.GenerateEphemeris"/>
    private IGenerateEphemerisParameterIdentifier GenerateEphemeris { get; }

    /// <inheritdoc cref="IQueryParameterIdentifierProvider.ObjectDataInclusion"/>
    private IObjectDataInclusionParameterIdentifier ObjectDataInclusion { get; }

    /// <inheritdoc cref="IQueryParameterIdentifierProvider.Origin"/>
    private IOriginParameterIdentifier Origin { get; }

    /// <inheritdoc cref="IQueryParameterIdentifierProvider.OriginCoordinate"/>
    private IOriginCoordinateParameterIdentifier OriginCoordinate { get; }

    /// <inheritdoc cref="IQueryParameterIdentifierProvider.OriginCoordinateType"/>
    private IOriginCoordinateTypeParameterIdentifier OriginCoordinateType { get; }

    /// <inheritdoc cref="IQueryParameterIdentifierProvider.OutputFormat"/>
    private IOutputFormatParameterIdentifier OutputFormat { get; }

    /// <inheritdoc cref="IQueryParameterIdentifierProvider.OutputUnits"/>
    private IOutputUnitsParameterIdentifier OutputUnits { get; }

    /// <inheritdoc cref="IQueryParameterIdentifierProvider.ReferencePlane"/>
    private IReferencePlaneParameterIdentifier ReferencePlane { get; }

    /// <inheritdoc cref="IQueryParameterIdentifierProvider.ReferenceSystem"/>
    private IReferenceSystemParameterIdentifier ReferenceSystem { get; }

    /// <inheritdoc cref="IQueryParameterIdentifierProvider.StartEpoch"/>
    private IStartEpochParameterIdentifier StartEpoch { get; }

    /// <inheritdoc cref="IQueryParameterIdentifierProvider.StepSize"/>
    private IStepSizeParameterIdentifier StepSize { get; }

    /// <inheritdoc cref="IQueryParameterIdentifierProvider.StopEpoch"/>
    private IStopEpochParameterIdentifier StopEpoch { get; }

    /// <inheritdoc cref="IQueryParameterIdentifierProvider.TimeDeltaInclusion"/>
    private ITimeDeltaInclusionParameterIdentifier TimeDeltaInclusion { get; }

    /// <inheritdoc cref="IQueryParameterIdentifierProvider.TimePrecision"/>
    private ITimePrecisionParameterIdentifier TimePrecision { get; }

    /// <inheritdoc cref="IQueryParameterIdentifierProvider.TimeSystem"/>
    private ITimeSystemParameterIdentifier TimeSystem { get; }

    /// <inheritdoc cref="IQueryParameterIdentifierProvider.TimeZone"/>
    private ITimeZoneParameterIdentifier TimeZone { get; }

    /// <inheritdoc cref="IQueryParameterIdentifierProvider.ValueSeparation"/>
    private IValueSeparationParameterIdentifier ValueSeparation { get; }

    /// <inheritdoc cref="IQueryParameterIdentifierProvider.VectorCorrection"/>
    private IVectorCorrectionParameterIdentifier VectorCorrection { get; }

    /// <inheritdoc cref="IQueryParameterIdentifierProvider.VectorLabels"/>
    private IVectorLabelsParameterIdentifier VectorLabels { get; }

    /// <inheritdoc cref="IQueryParameterIdentifierProvider.VectorTableContent"/>
    private IVectorTableContentParameterIdentifier VectorTableContent { get; }

    ICommandParameterIdentifier IQueryParameterIdentifierProvider.Command => Command;
    IEphemerisTypeParameterIdentifier IQueryParameterIdentifierProvider.EphemerisType => EphemerisType;
    ICalendarTypeParameterIdentifier IQueryParameterIdentifierProvider.CalendarType => CalendarType;
    IEpochCollectionParameterIdentifier IQueryParameterIdentifierProvider.EpochCollection => EpochCollection;
    IEpochCollectionFormatParameterIdentifier IQueryParameterIdentifierProvider.EpochCollectionFormat => EpochCollectionFormat;
    IGenerateEphemerisParameterIdentifier IQueryParameterIdentifierProvider.GenerateEphemeris => GenerateEphemeris;
    IObjectDataInclusionParameterIdentifier IQueryParameterIdentifierProvider.ObjectDataInclusion => ObjectDataInclusion;
    IOriginParameterIdentifier IQueryParameterIdentifierProvider.Origin => Origin;
    IOriginCoordinateParameterIdentifier IQueryParameterIdentifierProvider.OriginCoordinate => OriginCoordinate;
    IOriginCoordinateTypeParameterIdentifier IQueryParameterIdentifierProvider.OriginCoordinateType => OriginCoordinateType;
    IOutputFormatParameterIdentifier IQueryParameterIdentifierProvider.OutputFormat => OutputFormat;
    IOutputUnitsParameterIdentifier IQueryParameterIdentifierProvider.OutputUnits => OutputUnits;
    IReferencePlaneParameterIdentifier IQueryParameterIdentifierProvider.ReferencePlane => ReferencePlane;
    IReferenceSystemParameterIdentifier IQueryParameterIdentifierProvider.ReferenceSystem => ReferenceSystem;
    IStartEpochParameterIdentifier IQueryParameterIdentifierProvider.StartEpoch => StartEpoch;
    IStepSizeParameterIdentifier IQueryParameterIdentifierProvider.StepSize => StepSize;
    IStopEpochParameterIdentifier IQueryParameterIdentifierProvider.StopEpoch => StopEpoch;
    ITimeDeltaInclusionParameterIdentifier IQueryParameterIdentifierProvider.TimeDeltaInclusion => TimeDeltaInclusion;
    ITimePrecisionParameterIdentifier IQueryParameterIdentifierProvider.TimePrecision => TimePrecision;
    ITimeSystemParameterIdentifier IQueryParameterIdentifierProvider.TimeSystem => TimeSystem;
    ITimeZoneParameterIdentifier IQueryParameterIdentifierProvider.TimeZone => TimeZone;
    IValueSeparationParameterIdentifier IQueryParameterIdentifierProvider.ValueSeparation => ValueSeparation;
    IVectorCorrectionParameterIdentifier IQueryParameterIdentifierProvider.VectorCorrection => VectorCorrection;
    IVectorLabelsParameterIdentifier IQueryParameterIdentifierProvider.VectorLabels => VectorLabels;
    IVectorTableContentParameterIdentifier IQueryParameterIdentifierProvider.VectorTableContent => VectorTableContent;

    /// <inheritdoc cref="QueryParameterIdentifierProvider"/>
    /// <param name="parameterIdentifierOptions">Provides the <see cref="ParameterIdentifierOptions"/>.</param>
    public QueryParameterIdentifierProvider(IOptions<ParameterIdentifierOptions> parameterIdentifierOptions)
    {
        Command = new QueryParameterIdentifier(parameterIdentifierOptions.Value.Command);
        EphemerisType = new QueryParameterIdentifier(parameterIdentifierOptions.Value.EphemerisType);
        CalendarType = new QueryParameterIdentifier(parameterIdentifierOptions.Value.CalendarType);
        EpochCollection = new QueryParameterIdentifier(parameterIdentifierOptions.Value.EpochCollection);
        EpochCollectionFormat = new QueryParameterIdentifier(parameterIdentifierOptions.Value.EpochCollectionFormat);
        GenerateEphemeris = new QueryParameterIdentifier(parameterIdentifierOptions.Value.GenerateEphemeris);
        ObjectDataInclusion = new QueryParameterIdentifier(parameterIdentifierOptions.Value.ObjectDataInclusion);
        Origin = new QueryParameterIdentifier(parameterIdentifierOptions.Value.Origin);
        OriginCoordinate = new QueryParameterIdentifier(parameterIdentifierOptions.Value.OriginCoordinate);
        OriginCoordinateType = new QueryParameterIdentifier(parameterIdentifierOptions.Value.OriginCoordinateType);
        OutputFormat = new QueryParameterIdentifier(parameterIdentifierOptions.Value.OutputFormat);
        OutputUnits = new QueryParameterIdentifier(parameterIdentifierOptions.Value.OutputUnits);
        ReferencePlane = new QueryParameterIdentifier(parameterIdentifierOptions.Value.ReferencePlane);
        ReferenceSystem = new QueryParameterIdentifier(parameterIdentifierOptions.Value.ReferenceSystem);
        StartEpoch = new QueryParameterIdentifier(parameterIdentifierOptions.Value.StartEpoch);
        StepSize = new QueryParameterIdentifier(parameterIdentifierOptions.Value.StepSize);
        StopEpoch = new QueryParameterIdentifier(parameterIdentifierOptions.Value.StopEpoch);
        TimeDeltaInclusion = new QueryParameterIdentifier(parameterIdentifierOptions.Value.TimeDeltaInclusion);
        TimePrecision = new QueryParameterIdentifier(parameterIdentifierOptions.Value.TimePrecision);
        TimeSystem = new QueryParameterIdentifier(parameterIdentifierOptions.Value.TimeSystem);
        TimeZone = new QueryParameterIdentifier(parameterIdentifierOptions.Value.TimeZone);
        ValueSeparation = new QueryParameterIdentifier(parameterIdentifierOptions.Value.ValueSeparation);
        VectorCorrection = new QueryParameterIdentifier(parameterIdentifierOptions.Value.VectorCorrection);
        VectorLabels = new QueryParameterIdentifier(parameterIdentifierOptions.Value.VectorLabels);
        VectorTableContent = new QueryParameterIdentifier(parameterIdentifierOptions.Value.VectorTableContent);
    }
}
