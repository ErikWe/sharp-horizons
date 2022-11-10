namespace SharpHorizons.Query.Parameters;

using SharpHorizons.Calendars;
using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Elements;
using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.Vectors;

/// <summary>Represents the set of <see cref="IQueryParameter{TIdentifier, TArgument}"/> that comprise a query.</summary>
public interface IQueryParameterSet
{
    /// <summary>The <see cref="ICommandParameter"/>, describing the <see cref="QueryCommand"/> or the <see cref="ITarget"/> for ephemeris generation.</summary>
    public abstract ICommandParameter Command { get; }

    /// <summary>The optional <see cref="IEphemerisTypeParameter"/>, describing the <see cref="Query.EphemerisType"/>.</summary>
    public abstract OptionalQueryParameter<IEphemerisTypeParameter, IEphemerisTypeParameterIdentifier, IEphemerisTypeArgument> EphemerisType { get; }

    /// <summary>The optional <see cref="IGenerateEphemeridesParameter"/>, describing <see cref="Query.GenerateEphemerides"/>.</summary>
    public abstract OptionalQueryParameter<IGenerateEphemeridesParameter, IGenerateEphemeridesParameterIdentifier, IGenerateEphemeridesArgument> GenerateEphemerides { get; }

    /// <summary>The optional <see cref="IOutputFormatParameter"/>, describing the <see cref="Query.OutputFormat"/>.</summary>
    public abstract OptionalQueryParameter<IOutputFormatParameter, IOutputFormatParameterIdentifier, IOutputFormatArgument> OutputFormat { get; }

    /// <summary>The optional <see cref="IObjectDataInclusionParameter"/>, describing the <see cref="Query.ObjectDataInclusion"/>.</summary>
    public abstract OptionalQueryParameter<IObjectDataInclusionParameter, IObjectDataInclusionParameterIdentifier, IObjectDataInclusionArgument> ObjectDataInclusion { get; }

    /// <summary>The optional <see cref="IOriginParameter"/>, describing the <see cref="IOrigin"/>.</summary>
    public abstract OptionalQueryParameter<IOriginParameter, IOriginParameterIdentifier, IOriginArgument> Origin { get; }

    /// <summary>The optional <see cref="IOriginCoordinateParameter"/>, describing the <see cref="IOriginCoordinate"/>.</summary>
    public abstract OptionalQueryParameter<IOriginCoordinateParameter, IOriginCoordinateParameterIdentifier, IOriginCoordinateArgument> OriginCoordinate { get; }

    /// <summary>The optional <see cref="IOriginCoordinateTypeParameter"/>, describing the type of the <see cref="IOriginCoordinate"/>.</summary>
    public abstract OptionalQueryParameter<IOriginCoordinateTypeParameter, IOriginCoordinateTypeParameterIdentifier, IOriginCoordinateTypeArgument> OriginCoordinateType { get; }

    /// <summary>The optional <see cref="IEpochCollectionParameter"/>, describing the <see cref="IEpochSelection"/> when using <see cref="EpochSelectionMode.Collection"/>.</summary>
    public abstract OptionalQueryParameter<IEpochCollectionParameter, IEpochCollectionParameterIdentifier, IEpochCollectionArgument> EpochCollection { get; }

    /// <summary>The optional <see cref="IEpochCollectionFormatParameter"/>, describing the <see cref="Epoch.EpochCollectionFormat"/> of the individual <see cref="IEpoch"/> of <see cref="EpochCollection"/>.</summary>
    public abstract OptionalQueryParameter<IEpochCollectionFormatParameter, IEpochCollectionFormatParameterIdentifier, IEpochCollectionFormatArgument> EpochCollectionFormat { get; }

    /// <summary>The optional <see cref="IStartEpochParameter"/>, describing the <see cref="IStartEpoch"/> when using <see cref="EpochSelectionMode.Range"/>.</summary>
    public abstract OptionalQueryParameter<IStartEpochParameter, IStartEpochParameterIdentifier, IStartEpochArgument> StartEpoch { get; }

    /// <summary>The optional <see cref="IStopEpochParameter"/>, describing the <see cref="IStopEpoch"/> when using <see cref="EpochSelectionMode.Range"/>.</summary>
    public abstract OptionalQueryParameter<IStopEpochParameter, IStopEpochParameterIdentifier, IStopEpochArgument> StopEpoch { get; }

    /// <summary>The optional <see cref="IStepSizeParameter"/>, describing the <see cref="IStepSize"/> when using <see cref="EpochSelectionMode.Range"/>.</summary>
    public abstract OptionalQueryParameter<IStepSizeParameter, IStepSizeParameterIdentifier, IStepSizeArgument> StepSize { get; }

    /// <summary>The optional <see cref="IReferencePlaneParameter"/>, describing the <see cref="Query.ReferencePlane"/>.</summary>
    public abstract OptionalQueryParameter<IReferencePlaneParameter, IReferencePlaneParameterIdentifier, IReferencePlaneArgument> ReferencePlane { get; }

    /// <summary>The optional <see cref="IReferenceSystemParameter"/>, describing the <see cref="Query.ReferenceSystem"/>.</summary>
    public abstract OptionalQueryParameter<IReferenceSystemParameter, IReferenceSystemParameterIdentifier, IReferenceSystemArgument> ReferenceSystem { get; }

    /// <summary>The optional <see cref="ITimePrecisionParameter"/>, describing the <see cref="Query.TimePrecision"/>.</summary>
    public abstract OptionalQueryParameter<ITimePrecisionParameter, ITimePrecisionParameterIdentifier, ITimePrecisionArgument> TimePrecision { get; }

    /// <summary>The optional <see cref="IOutputUnitsParameter"/>, describing the <see cref="Query.OutputUnits"/>.</summary>
    public abstract OptionalQueryParameter<IOutputUnitsParameter, IOutputUnitsParameterIdentifier, IOutputUnitsArgument> OutputUnits { get; }

    /// <summary>The optional <see cref="IVectorCorrectionParameter"/>, describing the <see cref="Query.VectorCorrection"/>.</summary>
    public abstract OptionalQueryParameter<IVectorCorrectionParameter, IVectorCorrectionParameterIdentifier, IVectorCorrectionArgument> VectorCorrection { get; }

    /// <summary>The optional <see cref="ITimeDeltaInclusionParameter"/>, describing the <see cref="Query.TimeDeltaInclusion"/>.</summary>
    public abstract OptionalQueryParameter<ITimeDeltaInclusionParameter, ITimeDeltaInclusionParameterIdentifier, ITimeDeltaInclusionArgument> TimeDeltaInclusion { get; }

    /// <summary>The optional <see cref="IVectorTableContentParameter"/>, describing the <see cref="VectorTable.VectorTableContent"/>.</summary>
    public abstract OptionalQueryParameter<IVectorTableContentParameter, IVectorTableContentParameterIdentifier, IVectorTableContentArgument> VectorTableContent { get; }

    /// <summary>The optional <see cref="IElementLabelsParameter"/>, describing the <see cref="OutputLabels"/> in an <see cref="IElementsQuery"/>.</summary>
    public abstract OptionalQueryParameter<IElementLabelsParameter, IElementLabelsParameterIdentifier, IElementLabelsArgument> ElementLabels { get; }

    /// <summary>The optional <see cref="IVectorLabelsParameter"/>, describing the <see cref="OutputLabels"/> in a <see cref="IVectorsQuery"/>.</summary>
    public abstract OptionalQueryParameter<IVectorLabelsParameter, IVectorLabelsParameterIdentifier, IVectorLabelsArgument> VectorLabels { get; }

    /// <summary>The optional <see cref="IValueSeparationParameter"/>, describing the <see cref="Query.ValueSeparation"/>.</summary>
    public abstract OptionalQueryParameter<IValueSeparationParameter, IValueSeparationParameterIdentifier, IValueSeparationArgument> ValueSeparation { get; }
}
