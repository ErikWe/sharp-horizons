namespace SharpHorizons.Query.Arguments;

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
    public abstract OptionalQueryArgument<IEphemerisTypeArgument> EphemerisType { get; }

    /// <summary>The optional <see cref="IGenerateEphemerisArgument"/>, describing <see cref="Query.GenerateEphemeris"/>.</summary>
    public abstract OptionalQueryArgument<IGenerateEphemerisArgument> GenerateEphemeris { get; }

    /// <summary>The optional <see cref="IOutputFormatArgument"/>, describing the <see cref="Query.OutputFormat"/>.</summary>
    public abstract OptionalQueryArgument<IOutputFormatArgument> OutputFormat { get; }

    /// <summary>The optional <see cref="IObjectDataInclusionArgument"/>, describing the <see cref="Query.ObjectDataInclusion"/>.</summary>
    public abstract OptionalQueryArgument<IObjectDataInclusionArgument> ObjectDataInclusion { get; }

    /// <summary>The optional <see cref="IOriginArgument"/>, describing the <see cref="IOrigin"/>.</summary>
    public abstract OptionalQueryArgument<IOriginArgument> Origin { get; }

    /// <summary>The optional <see cref="IOriginCoordinateArgument"/>, describing the <see cref="IOriginCoordinate"/>.</summary>
    public abstract OptionalQueryArgument<IOriginCoordinateArgument> OriginCoordinate { get; }

    /// <summary>The optional <see cref="IOriginCoordinateTypeArgument"/>, describing the type of the <see cref="IOriginCoordinate"/>.</summary>
    public abstract OptionalQueryArgument<IOriginCoordinateTypeArgument> OriginCoordinateType { get; }

    /// <summary>The optional <see cref="IEpochCollectionArgument"/>, describing the <see cref="IEpochSelection"/> when using <see cref="EpochSelectionMode.Collection"/>.</summary>
    public abstract OptionalQueryArgument<IEpochCollectionArgument> EpochCollection { get; }

    /// <summary>The optional <see cref="IEpochCollectionFormatArgument"/>, describing the <see cref="EpochFormat"/> of the individual <see cref="IEpoch"/> of the <see cref="EpochCollection"/>.</summary>
    public abstract OptionalQueryArgument<IEpochCollectionFormatArgument> EpochCollectionFormat { get; }

    /// <summary>The optional <see cref="ICalendarTypeArgument"/>, describing the <see cref="Epoch.CalendarType"/>.</summary>
    public abstract OptionalQueryArgument<ICalendarTypeArgument> CalendarType { get; }

    /// <summary>The optional <see cref="ITimeSystemArgument"/>, describing the <see cref="Epoch.TimeSystem"/>.</summary>
    public abstract OptionalQueryArgument<ITimeSystemArgument> TimeSystem { get; }

    /// <summary>The optional <see cref="ITimeZoneArgument"/>, describing the <see cref="Time"/> offset to the <see cref="TimeSystem"/>.</summary>
    public abstract OptionalQueryArgument<ITimeZoneArgument> TimeZone { get; }

    /// <summary>The optional <see cref="IStartEpochArgument"/>, describing the <see cref="IStartEpoch"/> when using <see cref="EpochSelectionMode.Range"/>.</summary>
    public abstract OptionalQueryArgument<IStartEpochArgument> StartEpoch { get; }

    /// <summary>The optional <see cref="IStopEpochArgument"/>, describing the <see cref="IStopEpoch"/> when using <see cref="EpochSelectionMode.Range"/>.</summary>
    public abstract OptionalQueryArgument<IStopEpochArgument> StopEpoch { get; }

    /// <summary>The optional <see cref="IStepSizeArgument"/>, describing the <see cref="IStepSize"/> when using <see cref="EpochSelectionMode.Range"/>.</summary>
    public abstract OptionalQueryArgument<IStepSizeArgument> StepSize { get; }

    /// <summary>The optional <see cref="IReferencePlaneArgument"/>, describing the <see cref="Query.ReferencePlane"/>.</summary>
    public abstract OptionalQueryArgument<IReferencePlaneArgument> ReferencePlane { get; }

    /// <summary>The optional <see cref="IReferenceSystemArgument"/>, describing the <see cref="Query.ReferenceSystem"/>.</summary>
    public abstract OptionalQueryArgument<IReferenceSystemArgument> ReferenceSystem { get; }

    /// <summary>The optional <see cref="ITimePrecisionArgument"/>, describing the <see cref="Query.TimePrecision"/>.</summary>
    public abstract OptionalQueryArgument<ITimePrecisionArgument> TimePrecision { get; }

    /// <summary>The optional <see cref="IOutputUnitsArgument"/>, describing the <see cref="Query.OutputUnits"/>.</summary>
    public abstract OptionalQueryArgument<IOutputUnitsArgument> OutputUnits { get; }

    /// <summary>The optional <see cref="IVectorCorrectionArgument"/>, describing the <see cref="Vectors.VectorCorrection"/>.</summary>
    public abstract OptionalQueryArgument<IVectorCorrectionArgument> VectorCorrection { get; }

    /// <summary>The optional <see cref="ITimeDeltaInclusionArgument"/>, describing the <see cref="Query.TimeDeltaInclusion"/>.</summary>
    public abstract OptionalQueryArgument<ITimeDeltaInclusionArgument> TimeDeltaInclusion { get; }

    /// <summary>The optional <see cref="IVectorTableContentArgument"/>, describing the <see cref="Vectors.Table.VectorTableContent"/>.</summary>
    public abstract OptionalQueryArgument<IVectorTableContentArgument> VectorTableContent { get; }

    /// <summary>The optional <see cref="IVectorLabelsArgument"/>, describing the <see cref="OutputLabels"/> in a <see cref="IVectorsQuery"/>.</summary>
    public abstract OptionalQueryArgument<IVectorLabelsArgument> VectorLabels { get; }

    /// <summary>The optional <see cref="IValueSeparationArgument"/>, describing the <see cref="Query.ValueSeparation"/>.</summary>
    public abstract OptionalQueryArgument<IValueSeparationArgument> ValueSeparation { get; }
}
