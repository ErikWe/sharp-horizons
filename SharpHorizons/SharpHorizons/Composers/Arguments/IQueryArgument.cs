namespace SharpHorizons.Composers.Arguments;

using SharpHorizons.Calendars;
using SharpHorizons.Query;
using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.VectorTable;

/// <summary>Represents the value of a parameter in a query.</summary>
public interface IQueryArgument
{
    /// <summary>The value of the parameter in a query.</summary>
    public abstract string Value { get; }
}

/// <summary>A <see cref="IQueryArgument"/> describing the <see cref="EphemerisType"/>.</summary>
public interface IEphemerisTypeArgument : IQueryArgument { }

/// <summary>A <see cref="IQueryArgument"/> describing the <see cref="IEpochSelection"/> as a collection of <see cref="IEpoch"/> when using <see cref="EpochSelectionMode.Collection"/>.</summary>
public interface IEpochCollectionArgument : IQueryArgument { }

/// <summary>A <see cref="IQueryArgument"/> describing the <see cref="EpochCollectionFormat"/> of the individual <see cref="IEpoch"/> in the <see cref="IEpochCollectionArgument"/>.</summary>
public interface IEpochCollectionFormatArgument : IQueryArgument { }

/// <summary>A <see cref="IQueryArgument"/> describing <see cref="GenerateEphemerides"/>.</summary>
public interface IGenerateEphemeridesArgument : IQueryArgument { }

/// <summary>A <see cref="IQueryArgument"/> describing <see cref="ObjectDataInclusion"/></summary>
public interface IObjectDataInclusionArgument : IQueryArgument { }

/// <summary>A <see cref="IQueryArgument"/> describing the <see cref="IOrigin"/>.</summary>
public interface IOriginArgument : IQueryArgument { }

/// <summary>A <see cref="IQueryArgument"/> describing the <see cref="IOriginCoordinate"/>.</summary>
public interface IOriginCoordinateArgument : IQueryArgument { }

/// <summary>A <see cref="IQueryArgument"/> describing the type of the <see cref="IOriginCoordinate"/>.</summary>
public interface IOriginCoordinateTypeArgument : IQueryArgument { }

/// <summary>A <see cref="IQueryArgument"/> describing <see cref="OutputLabels"/>.</summary>
public interface IOutputLabelsArgument : IQueryArgument { }

/// <summary>A <see cref="IQueryArgument"/> describing the <see cref="OutputUnits"/>.</summary>
public interface IOutputUnitsArgument : IQueryArgument { }

/// <summary>A <see cref="IQueryArgument"/> describing the <see cref="ReferencePlane"/>.</summary>
public interface IReferencePlaneArgument : IQueryArgument { }

/// <summary>A <see cref="IQueryArgument"/> describing the <see cref="ReferenceSystem"/>.</summary>
public interface IReferenceSystemArgument : IQueryArgument { }

/// <summary>A <see cref="IQueryArgument"/> describing the <see cref="IStartEpoch"/> when using <see cref="EpochSelectionMode.Range"/>.</summary>
public interface IStartEpochArgument : IQueryArgument { }

/// <summary>A <see cref="IQueryArgument"/> describing the <see cref="IStepSize"/> when using <see cref="EpochSelectionMode.Range"/>.</summary>
public interface IStepSizeArgument : IQueryArgument { }

/// <summary>A <see cref="IQueryArgument"/> describing the <see cref="IStopEpoch"/> when using <see cref="EpochSelectionMode.Range"/>.</summary>
public interface IStopEpochArgument : IQueryArgument { }

/// <summary>A <see cref="IQueryArgument"/> describing the <see cref="ITarget"/>.</summary>
public interface ITargetArgument : IQueryArgument { }

/// <summary>A <see cref="IQueryArgument"/> describing <see cref="TimeDeltaInclusion"/>.</summary>
public interface ITimeDeltaInclusionArgument : IQueryArgument { }

/// <summary>A <see cref="IQueryArgument"/> describing the <see cref="TimePrecision"/>.</summary>
public interface ITimePrecisionArgument : IQueryArgument { }

/// <summary>A <see cref="IQueryArgument"/> describing the <see cref="ValueSeparation"/>.</summary>
public interface IValueSeparationArgument : IQueryArgument { }

/// <summary>A <see cref="IQueryArgument"/> describing the <see cref="VectorCorrection"/>.</summary>
public interface IVectorCorrectionArgument : IQueryArgument { }

/// <summary>A <see cref="IQueryArgument"/> describing the <see cref="VectorTableContent"/>.</summary>
public interface IVectorTableContentArgument : IQueryArgument { }
