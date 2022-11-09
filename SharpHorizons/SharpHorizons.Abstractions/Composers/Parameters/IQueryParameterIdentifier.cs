namespace SharpHorizons.Composers.Parameters;

using SharpHorizons.Query;
using SharpHorizons.Query.Elements;
using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.Vectors;
using SharpHorizons.Query.VectorTable;

/// <summary>Represents the identifier of a parameter in a query.</summary>
public interface IQueryParameterIdentifier
{
    /// <summary>The identifier of the parameter in a query.</summary>
    public abstract string Identifier { get; }
}

/// <summary>The <see cref="IQueryParameterIdentifier"/> representing <see cref="OutputLabels"/> in an <see cref="IElementsQuery"/>.</summary>
public interface IElementLabelsParameterIdentifier : IQueryParameterIdentifier { }

/// <summary>The <see cref="IQueryParameterIdentifier"/> representing <see cref="EphemerisType"/>.</summary>
public interface IEphemerisTypeParameterIdentifier : IQueryParameterIdentifier { }

/// <summary>The <see cref="IQueryParameterIdentifier"/> representing <see cref="IEpochSelection"/> when using <see cref="EpochSelectionMode.Collection"/>.</summary>
public interface IEpochCollectionParameterIdentifier : IQueryParameterIdentifier { }

/// <summary>The <see cref="IQueryParameterIdentifier"/> representing <see cref="EpochCollectionFormat"/>.</summary>
public interface IEpochCollectionFormatParameterIdentifier : IQueryParameterIdentifier { }

/// <summary>The <see cref="IQueryParameterIdentifier"/> representing <see cref="GenerateEphemerides"/>.</summary>
public interface IGenerateEphemeridesParameterIdentifier : IQueryParameterIdentifier { }

/// <summary>The <see cref="IQueryParameterIdentifier"/> representing <see cref="ObjectDataInclusion"/></summary>
public interface IObjectDataInclusionParameterIdentifier : IQueryParameterIdentifier { }

/// <summary>The <see cref="IQueryParameterIdentifier"/> representing <see cref="IOrigin"/>.</summary>
public interface IOriginParameterIdentifier : IQueryParameterIdentifier { }

/// <summary>The <see cref="IQueryParameterIdentifier"/> representing <see cref="IOriginCoordinate"/>.</summary>
public interface IOriginCoordinateParameterIdentifier : IQueryParameterIdentifier { }

/// <summary>The <see cref="IQueryParameterIdentifier"/> representing the type of the <see cref="IOriginCoordinate"/>.</summary>
public interface IOriginCoordinateTypeParameterIdentifier : IQueryParameterIdentifier { }

/// <summary>The <see cref="IQueryParameterIdentifier"/> representing <see cref="OutputFormat"/>.</summary>
public interface IOutputFormatParameterIdentifier : IQueryParameterIdentifier { }

/// <summary>The <see cref="IQueryParameterIdentifier"/> representing <see cref="OutputUnits"/>.</summary>
public interface IOutputUnitsParameterIdentifier : IQueryParameterIdentifier { }

/// <summary>The <see cref="IQueryParameterIdentifier"/> representing <see cref="ReferencePlane"/>.</summary>
public interface IReferencePlaneParameterIdentifier : IQueryParameterIdentifier { }

/// <summary>The <see cref="IQueryParameterIdentifier"/> representing <see cref="ReferenceSystem"/>.</summary>
public interface IReferenceSystemParameterIdentifier : IQueryParameterIdentifier { }

/// <summary>The <see cref="IQueryParameterIdentifier"/> representing <see cref="IStartEpoch"/> when using <see cref="EpochSelectionMode.Range"/>.</summary>
public interface IStartEpochParameterIdentifier : IQueryParameterIdentifier { }

/// <summary>The <see cref="IQueryParameterIdentifier"/> representing <see cref="IStepSize"/> when using <see cref="EpochSelectionMode.Range"/>.</summary>
public interface IStepSizeParameterIdentifier : IQueryParameterIdentifier { }

/// <summary>The <see cref="IQueryParameterIdentifier"/> representing <see cref="IStopEpoch"/> when using <see cref="EpochSelectionMode.Range"/>.</summary>
public interface IStopEpochParameterIdentifier : IQueryParameterIdentifier { }

/// <summary>The <see cref="IQueryParameterIdentifier"/> representing <see cref="ITarget"/>.</summary>
public interface ITargetParameterIdentifier : IQueryParameterIdentifier { }

/// <summary>The <see cref="IQueryParameterIdentifier"/> representing <see cref="TimeDeltaInclusion"/>.</summary>
public interface ITimeDeltaInclusionParameterIdentifier : IQueryParameterIdentifier { }

/// <summary>The <see cref="IQueryParameterIdentifier"/> representing <see cref="TimePrecision"/>.</summary>
public interface ITimePrecisionParameterIdentifier : IQueryParameterIdentifier { }

/// <summary>The <see cref="IQueryParameterIdentifier"/> representing <see cref="ValueSeparation"/>.</summary>
public interface IValueSeparationParameterIdentifier : IQueryParameterIdentifier { }

/// <summary>The <see cref="IQueryParameterIdentifier"/> representing <see cref="VectorCorrection"/>.</summary>
public interface IVectorCorrectionParameterIdentifier : IQueryParameterIdentifier { }

/// <summary>The <see cref="IQueryParameterIdentifier"/> representing <see cref="OutputLabels"/> in a <see cref="IVectorsQuery"/>.</summary>
public interface IVectorLabelsParameterIdentifier : IQueryParameterIdentifier { }

/// <summary>The <see cref="IQueryParameterIdentifier"/> representing <see cref="VectorTableContent"/>.</summary>
public interface IVectorTableContentParameterIdentifier : IQueryParameterIdentifier { }
