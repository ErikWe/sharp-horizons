namespace SharpHorizons.Settings.Query.Parameters;

using Microsoft.Extensions.Configuration;

using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Parameters;

/// <summary>Specifies the identifiers associated with the available parameters.</summary>
/// <remarks><see cref="IQueryParameterIdentifierProvider"/> should be used to access the identifiers once specified.</remarks>
internal sealed class ParameterIdentifierOptions
{
    /// <summary>Describes the name of the <see cref="IConfigurationSection"/> which describes <see cref="ParameterIdentifierOptions"/>.</summary>
    internal static string Section { get; } = "Query:ParameterIdentifiers";

    /// <summary>The identifier associated with the <see cref="ICommandArgument"/>.</summary>
    public string Command { get; set; } = null!;

    /// <summary>The identifier associated with the <see cref="IEphemerisTypeArgument"/>.</summary>
    public string EphemerisType { get; set; } = null!;

    /// <summary>The identifier associated with the <see cref="ICalendarTypeArgument"/>.</summary>
    public string EpochCalendar { get; set; } = null!;

    /// <summary>The identifier associated with the <see cref="IEpochCollectionArgument"/>.</summary>
    public string EpochCollection { get; set; } = null!;

    /// <summary>The identifier associated with the <see cref="IEpochCollectionFormatArgument"/>.</summary>
    public string EpochCollectionFormat { get; set; } = null!;

    /// <summary>The identifier associated with the <see cref="IGenerateEphemerisArgument"/>.</summary>
    public string GenerateEphemeris { get; set; } = null!;

    /// <summary>The identifier associated with the <see cref="IObjectDataInclusionArgument"/>.</summary>
    public string ObjectDataInclusion { get; set; } = null!;

    /// <summary>The identifier associated with the <see cref="IOriginArgument"/>.</summary>
    public string Origin { get; set; } = null!;

    /// <summary>The identifier associated with the <see cref="IOriginCoordinateArgument"/>.</summary>
    public string OriginCoordinate { get; set; } = null!;

    /// <summary>The identifier associated with the <see cref="IOriginCoordinateTypeArgument"/>.</summary>
    public string OriginCoordinateType { get; set; } = null!;

    /// <summary>The identifier associated with the <see cref="IOutputFormatArgument"/>.</summary>
    public string OutputFormat { get; set; } = null!;

    /// <summary>The identifier associated with the <see cref="IOutputUnitsArgument"/>.</summary>
    public string OutputUnits { get; set; } = null!;

    /// <summary>The identifier associated with the <see cref="IReferencePlaneArgument"/>.</summary>
    public string ReferencePlane { get; set; } = null!;

    /// <summary>The identifier associated with the <see cref="IReferenceSystemArgument"/>.</summary>
    public string ReferenceSystem { get; set; } = null!;

    /// <summary>The identifier associated with the <see cref="IStartEpochArgument"/>.</summary>
    public string StartEpoch { get; set; } = null!;

    /// <summary>The identifier associated with the <see cref="IStepSizeArgument"/>.</summary>
    public string StepSize { get; set; } = null!;

    /// <summary>The identifier associated with the <see cref="IStopEpochArgument"/>.</summary>
    public string StopEpoch { get; set; } = null!;

    /// <summary>The identifier associated with the <see cref="ITimeDeltaInclusionArgument"/>.</summary>
    public string TimeDeltaInclusion { get; set; } = null!;

    /// <summary>The identifier associated with the <see cref="ITimePrecisionArgument"/>.</summary>
    public string TimePrecision { get; set; } = null!;

    /// <summary>The identifier associated with the <see cref="ITimeSystemArgument"/>.</summary>
    public string TimeSystem { get; set; } = null!;

    /// <summary>The identifier associated with the <see cref="ITimeZoneArgument"/>.</summary>
    public string TimeZone { get; set; } = null!;

    /// <summary>The identifier associated with the <see cref="IValueSeparationArgument"/>.</summary>
    public string ValueSeparation { get; set; } = null!;

    /// <summary>The identifier associated with the <see cref="IVectorCorrectionArgument"/>.</summary>
    public string VectorCorrection { get; set; } = null!;

    /// <summary>The identifier associated with the <see cref="IVectorLabelsArgument"/>.</summary>
    public string VectorLabels { get; set; } = null!;

    /// <summary>The identifier associated with the <see cref="IVectorTableContentArgument"/>.</summary>
    public string VectorTableContent { get; set; } = null!;

    /// <summary>Applies the default values to <paramref name="options"/>.</summary>
    /// <param name="options">The default values are applied to these <see cref="ParameterIdentifierOptions"/>.</param>
    public static void ApplyDefaults(ParameterIdentifierOptions options)
    {
        options.Command = DefaultParameterIdentifiers.Default.Command;
        options.EphemerisType = DefaultParameterIdentifiers.Default.EphemerisType;
        options.EpochCalendar = DefaultParameterIdentifiers.Default.EpochCalendar;
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
