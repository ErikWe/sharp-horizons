namespace SharpHorizons.Settings.Query.Parameters;

using Microsoft.Extensions.Configuration;

using SharpHorizons.Query.Parameters;

/// <summary>Allows the <see cref="IQueryParameterIdentifier"/> to be specified.</summary>
/// <remarks>Once specified, <see cref="IQueryParameterIdentifier"/> should be accessed through a <see cref="IQueryParameterIdentifierProvider"/>.</remarks>
internal sealed class ParameterIdentifierOptions
{
    /// <summary>The identifier of the <see cref="IConfigurationSection"/> associated with <see cref="ParameterIdentifierOptions"/>.</summary>
    internal static string Section { get; } = "Query:ParameterIdentifiers";

    /// <inheritdoc cref="ICommandParameterIdentifier"/>
    public string Command { get; set; } = null!;

    /// <inheritdoc cref="IEphemerisTypeParameterIdentifier"/>
    public string EphemerisType { get; set; } = null!;

    /// <inheritdoc cref="ICalendarTypeParameterIdentifier"/>
    public string CalendarType { get; set; } = null!;

    /// <inheritdoc cref="IEpochCollectionParameterIdentifier"/>
    public string EpochCollection { get; set; } = null!;

    /// <inheritdoc cref="IEpochCollectionFormatParameterIdentifier"/>
    public string EpochCollectionFormat { get; set; } = null!;

    /// <inheritdoc cref="IGenerateEphemerisParameterIdentifier"/>
    public string GenerateEphemeris { get; set; } = null!;

    /// <inheritdoc cref="IObjectDataInclusionParameterIdentifier"/>
    public string ObjectDataInclusion { get; set; } = null!;

    /// <inheritdoc cref="IOriginParameterIdentifier"/>
    public string Origin { get; set; } = null!;

    /// <inheritdoc cref="IOriginCoordinateParameterIdentifier"/>
    public string OriginCoordinate { get; set; } = null!;

    /// <inheritdoc cref="IOriginCoordinateTypeParameterIdentifier"/>
    public string OriginCoordinateType { get; set; } = null!;

    /// <inheritdoc cref="IOutputFormatParameterIdentifier"/>
    public string OutputFormat { get; set; } = null!;

    /// <inheritdoc cref="IOutputUnitsParameterIdentifier"/>
    public string OutputUnits { get; set; } = null!;

    /// <inheritdoc cref="IReferencePlaneParameterIdentifier"/>
    public string ReferencePlane { get; set; } = null!;

    /// <inheritdoc cref="IReferenceSystemParameterIdentifier"/>
    public string ReferenceSystem { get; set; } = null!;

    /// <inheritdoc cref="IStartEpochParameterIdentifier"/>
    public string StartEpoch { get; set; } = null!;

    /// <inheritdoc cref="IStepSizeParameterIdentifier"/>
    public string StepSize { get; set; } = null!;

    /// <inheritdoc cref="IStopEpochParameterIdentifier"/>
    public string StopEpoch { get; set; } = null!;

    /// <inheritdoc cref="ITimeDeltaInclusionParameterIdentifier"/>
    public string TimeDeltaInclusion { get; set; } = null!;

    /// <inheritdoc cref="ITimePrecisionParameterIdentifier"/>
    public string TimePrecision { get; set; } = null!;

    /// <inheritdoc cref="ITimeSystemParameterIdentifier"/>
    public string TimeSystem { get; set; } = null!;

    /// <inheritdoc cref="ITimeZoneParameterIdentifier"/>
    public string TimeZone { get; set; } = null!;

    /// <inheritdoc cref="IValueSeparationParameterIdentifier"/>
    public string ValueSeparation { get; set; } = null!;

    /// <inheritdoc cref="IVectorCorrectionParameterIdentifier"/>
    public string VectorCorrection { get; set; } = null!;

    /// <inheritdoc cref="IVectorLabelsParameterIdentifier"/>
    public string VectorLabels { get; set; } = null!;

    /// <inheritdoc cref="IVectorTableContentParameterIdentifier"/>
    public string VectorTableContent { get; set; } = null!;

    /// <summary>Applies the default values to the <see cref="ParameterIdentifierOptions"/> <paramref name="options"/>.</summary>
    /// <param name="options">The default values are applied to this <see cref="ParameterIdentifierOptions"/>.</param>
    public static void ApplyDefaults(ParameterIdentifierOptions options)
    {
        options.Command = DefaultParameterIdentifiers.Default.Command;
        options.EphemerisType = DefaultParameterIdentifiers.Default.EphemerisType;
        options.CalendarType = DefaultParameterIdentifiers.Default.CalendarType;
        options.EpochCollection = DefaultParameterIdentifiers.Default.EpochCollection;
        options.EpochCollectionFormat = DefaultParameterIdentifiers.Default.EpochCollectionFormat;
        options.GenerateEphemeris = DefaultParameterIdentifiers.Default.GenerateEphemeris;
        options.ObjectDataInclusion = DefaultParameterIdentifiers.Default.ObjectDataInclusion;
        options.Origin = DefaultParameterIdentifiers.Default.Origin;
        options.OriginCoordinate = DefaultParameterIdentifiers.Default.OriginCoordinate;
        options.OriginCoordinateType = DefaultParameterIdentifiers.Default.OriginCoordinateType;
        options.OutputFormat = DefaultParameterIdentifiers.Default.OutputFormat;
        options.OutputUnits = DefaultParameterIdentifiers.Default.OutputUnits;
        options.ReferencePlane = DefaultParameterIdentifiers.Default.ReferencePlane;
        options.ReferenceSystem = DefaultParameterIdentifiers.Default.ReferenceSystem;
        options.StartEpoch = DefaultParameterIdentifiers.Default.StartEpoch;
        options.StepSize = DefaultParameterIdentifiers.Default.StepSize;
        options.StopEpoch = DefaultParameterIdentifiers.Default.StopEpoch;
        options.TimeDeltaInclusion = DefaultParameterIdentifiers.Default.TimeDeltaInclusion;
        options.TimePrecision = DefaultParameterIdentifiers.Default.TimePrecision;
        options.TimeSystem = DefaultParameterIdentifiers.Default.TimeSystem;
        options.TimeZone = DefaultParameterIdentifiers.Default.TimeZone;
        options.ValueSeparation = DefaultParameterIdentifiers.Default.ValueSeparation;
        options.VectorCorrection = DefaultParameterIdentifiers.Default.VectorCorrection;
        options.VectorLabels = DefaultParameterIdentifiers.Default.VectorLabels;
        options.VectorTableContent = DefaultParameterIdentifiers.Default.VectorTableContent;
    }
}
