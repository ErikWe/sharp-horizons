namespace SharpHorizons.Settings.Query.Parameters;

using Microsoft.Extensions.Configuration;

using SharpHorizons.Query.Parameters;

using System.Diagnostics.CodeAnalysis;

/// <summary>Allows the <see cref="IQueryParameterIdentifier"/> to be specified.</summary>
/// <remarks>Once specified, a <see cref="IQueryParameterIdentifierProvider"/> should be used to access the <see cref="IQueryParameterIdentifier"/>.</remarks>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class ParameterIdentifierOptions
{
    /// <summary>The identifier of the <see cref="IConfigurationSection"/> associated with <see cref="ParameterIdentifierOptions"/>.</summary>
    internal static string Section { get; } = "Query:ParameterIdentifiers";

    /// <inheritdoc cref="IQueryParameterIdentifierProvider.Command"/>
    public string Command { get; set; } = null!;

    /// <inheritdoc cref="IQueryParameterIdentifierProvider.EphemerisType"/>
    public string EphemerisType { get; set; } = null!;

    /// <inheritdoc cref="IQueryParameterIdentifierProvider.CalendarType"/>
    public string CalendarType { get; set; } = null!;

    /// <inheritdoc cref="IQueryParameterIdentifierProvider.EpochCollection"/>
    public string EpochCollection { get; set; } = null!;

    /// <inheritdoc cref="IQueryParameterIdentifierProvider.EpochCollectionFormat"/>
    public string EpochCollectionFormat { get; set; } = null!;

    /// <inheritdoc cref="IQueryParameterIdentifierProvider.GenerateEphemeris"/>
    public string GenerateEphemeris { get; set; } = null!;

    /// <inheritdoc cref="IQueryParameterIdentifierProvider.ObjectDataInclusion"/>
    public string ObjectDataInclusion { get; set; } = null!;

    /// <inheritdoc cref="IQueryParameterIdentifierProvider.Origin"/>
    public string Origin { get; set; } = null!;

    /// <inheritdoc cref="IQueryParameterIdentifierProvider.OriginCoordinate"/>
    public string OriginCoordinate { get; set; } = null!;

    /// <inheritdoc cref="IQueryParameterIdentifierProvider.OriginCoordinateType"/>
    public string OriginCoordinateType { get; set; } = null!;

    /// <inheritdoc cref="IQueryParameterIdentifierProvider.OutputFormat"/>
    public string OutputFormat { get; set; } = null!;

    /// <inheritdoc cref="IQueryParameterIdentifierProvider.OutputUnits"/>
    public string OutputUnits { get; set; } = null!;

    /// <inheritdoc cref="IQueryParameterIdentifierProvider.ReferencePlane"/>
    public string ReferencePlane { get; set; } = null!;

    /// <inheritdoc cref="IQueryParameterIdentifierProvider.ReferenceSystem"/>
    public string ReferenceSystem { get; set; } = null!;

    /// <inheritdoc cref="IQueryParameterIdentifierProvider.StartEpoch"/>
    public string StartEpoch { get; set; } = null!;

    /// <inheritdoc cref="IQueryParameterIdentifierProvider.StepSize"/>
    public string StepSize { get; set; } = null!;

    /// <inheritdoc cref="IQueryParameterIdentifierProvider.StopEpoch"/>
    public string StopEpoch { get; set; } = null!;

    /// <inheritdoc cref="IQueryParameterIdentifierProvider.TimeDeltaInclusion"/>
    public string TimeDeltaInclusion { get; set; } = null!;

    /// <inheritdoc cref="IQueryParameterIdentifierProvider.TimePrecision"/>
    public string TimePrecision { get; set; } = null!;

    /// <inheritdoc cref="IQueryParameterIdentifierProvider.TimeSystem"/>
    public string TimeSystem { get; set; } = null!;

    /// <inheritdoc cref="IQueryParameterIdentifierProvider.TimeZone"/>
    public string TimeZone { get; set; } = null!;

    /// <inheritdoc cref="IQueryParameterIdentifierProvider.ValueSeparation"/>
    public string ValueSeparation { get; set; } = null!;

    /// <inheritdoc cref="IQueryParameterIdentifierProvider.VectorCorrection"/>
    public string VectorCorrection { get; set; } = null!;

    /// <inheritdoc cref="IQueryParameterIdentifierProvider.VectorLabels"/>
    public string VectorLabels { get; set; } = null!;

    /// <inheritdoc cref="IQueryParameterIdentifierProvider.VectorTableContent"/>
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
