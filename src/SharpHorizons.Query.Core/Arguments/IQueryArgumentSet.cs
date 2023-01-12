namespace SharpHorizons.Query.Arguments;

using Microsoft.CodeAnalysis;

using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.Vectors;

using SharpMeasures;

/// <summary>Represents the set of <see cref="IQueryArgument"/> that describes a query.</summary>
public interface IQueryArgumentSet
{
    /// <summary>The <see cref="ICommandArgument"/>, describing the <see cref="QueryCommand"/> or the <see cref="ITarget"/> for ephemeris generation.</summary>
    public abstract ICommandArgument Command { get; }

    /// <summary>The optional <see cref="IEphemerisTypeArgument"/>, describing the <see cref="Query.EphemerisType"/>.</summary>
    public abstract Optional<IEphemerisTypeArgument> EphemerisType { get; }

    /// <summary>The optional <see cref="IGenerateEphemerisArgument"/>, describing <see cref="Query.GenerateEphemeris"/>.</summary>
    public abstract Optional<IGenerateEphemerisArgument> GenerateEphemeris { get; }

    /// <summary>The optional <see cref="IOutputFormatArgument"/>, describing the <see cref="Query.OutputFormat"/>.</summary>
    public abstract Optional<IOutputFormatArgument> OutputFormat { get; }

    /// <summary>The optional <see cref="IObjectDataInclusionArgument"/>, describing the <see cref="Query.ObjectDataInclusion"/>.</summary>
    public abstract Optional<IObjectDataInclusionArgument> ObjectDataInclusion { get; }

    /// <summary>The optional <see cref="IOriginArgument"/>, describing the <see cref="IOrigin"/>.</summary>
    public abstract Optional<IOriginArgument> Origin { get; }

    /// <summary>The optional <see cref="IOriginCoordinateArgument"/>, describing the <see cref="IOriginCoordinate"/>.</summary>
    public abstract Optional<IOriginCoordinateArgument> OriginCoordinate { get; }

    /// <summary>The optional <see cref="IOriginCoordinateTypeArgument"/>, describing the type of the <see cref="IOriginCoordinate"/>.</summary>
    public abstract Optional<IOriginCoordinateTypeArgument> OriginCoordinateType { get; }

    /// <summary>The optional <see cref="IEpochCollectionArgument"/>, describing the <see cref="IEpochSelection"/> when using <see cref="EpochSelectionMode.Collection"/>.</summary>
    public abstract Optional<IEpochCollectionArgument> EpochCollection { get; }

    /// <summary>The optional <see cref="IEpochCollectionFormatArgument"/>, describing the <see cref="EpochFormat"/> of the individual <see cref="IEpoch"/> of the <see cref="EpochCollection"/>.</summary>
    public abstract Optional<IEpochCollectionFormatArgument> EpochCollectionFormat { get; }

    /// <summary>The optional <see cref="ICalendarTypeArgument"/>, describing the <see cref="Epoch.CalendarType"/>.</summary>
    public abstract Optional<ICalendarTypeArgument> CalendarType { get; }

    /// <summary>The optional <see cref="ITimeSystemArgument"/>, describing the <see cref="Epoch.TimeSystem"/>.</summary>
    public abstract Optional<ITimeSystemArgument> TimeSystem { get; }

    /// <summary>The optional <see cref="ITimeZoneArgument"/>, describing the <see cref="Time"/> offset to the <see cref="TimeSystem"/>.</summary>
    public abstract Optional<ITimeZoneArgument> TimeZone { get; }

    /// <summary>The optional <see cref="IStartEpochArgument"/>, describing the <see cref="IStartEpoch"/> when using <see cref="EpochSelectionMode.Range"/>.</summary>
    public abstract Optional<IStartEpochArgument> StartEpoch { get; }

    /// <summary>The optional <see cref="IStopEpochArgument"/>, describing the <see cref="IStopEpoch"/> when using <see cref="EpochSelectionMode.Range"/>.</summary>
    public abstract Optional<IStopEpochArgument> StopEpoch { get; }

    /// <summary>The optional <see cref="IStepSizeArgument"/>, describing the <see cref="IStepSize"/> when using <see cref="EpochSelectionMode.Range"/>.</summary>
    public abstract Optional<IStepSizeArgument> StepSize { get; }

    /// <summary>The optional <see cref="IReferencePlaneArgument"/>, describing the <see cref="Query.ReferencePlane"/>.</summary>
    public abstract Optional<IReferencePlaneArgument> ReferencePlane { get; }

    /// <summary>The optional <see cref="IReferenceSystemArgument"/>, describing the <see cref="Query.ReferenceSystem"/>.</summary>
    public abstract Optional<IReferenceSystemArgument> ReferenceSystem { get; }

    /// <summary>The optional <see cref="ITimePrecisionArgument"/>, describing the <see cref="Query.TimePrecision"/>.</summary>
    public abstract Optional<ITimePrecisionArgument> TimePrecision { get; }

    /// <summary>The optional <see cref="IOutputUnitsArgument"/>, describing the <see cref="Query.OutputUnits"/>.</summary>
    public abstract Optional<IOutputUnitsArgument> OutputUnits { get; }

    /// <summary>The optional <see cref="IVectorCorrectionArgument"/>, describing the <see cref="Vectors.VectorCorrection"/>.</summary>
    public abstract Optional<IVectorCorrectionArgument> VectorCorrection { get; }

    /// <summary>The optional <see cref="ITimeDeltaInclusionArgument"/>, describing the <see cref="Query.TimeDeltaInclusion"/>.</summary>
    public abstract Optional<ITimeDeltaInclusionArgument> TimeDeltaInclusion { get; }

    /// <summary>The optional <see cref="IVectorTableContentArgument"/>, describing the <see cref="Vectors.Table.VectorTableContent"/>.</summary>
    public abstract Optional<IVectorTableContentArgument> VectorTableContent { get; }

    /// <summary>The optional <see cref="IVectorLabelsArgument"/>, describing the <see cref="OutputLabels"/> in a <see cref="IVectorsQuery"/>.</summary>
    public abstract Optional<IVectorLabelsArgument> VectorLabels { get; }

    /// <summary>The optional <see cref="IValueSeparationArgument"/>, describing the <see cref="Query.ValueSeparation"/>.</summary>
    public abstract Optional<IValueSeparationArgument> ValueSeparation { get; }
}
