namespace SharpHorizons.Query.Parameters;

/// <summary>Handles iterative construction of <see cref="IQueryParameterSetBuilder"/>.</summary>
public interface IQueryParameterSetBuilder
{
    /// <summary>Constructs the <see cref="IQueryParameterSet"/>.</summary>
    public abstract IQueryParameterSet Build();

    /// <summary>Specifies the <see cref="ICommandParameter"/> of the <see cref="IQueryParameterSet"/>.</summary>
    /// <param name="command">The <see cref="ICommandParameter"/> of the <see cref="IQueryParameterSet"/>.</param>
    public abstract IQueryParameterSetBuilder Specify(ICommandParameter command);

    /// <summary>Specifies the <see cref="IEphemerisTypeParameter"/> of the <see cref="IQueryParameterSet"/>.</summary>
    /// <param name="ephemerisType">The <see cref="IEphemerisTypeParameter"/> of the <see cref="IQueryParameterSet"/>.</param>
    public abstract IQueryParameterSetBuilder Specify(IEphemerisTypeParameter ephemerisType);

    /// <summary>Specifies the <see cref="IGenerateEphemeridesParameter"/> of the <see cref="IQueryParameterSet"/>.</summary>
    /// <param name="generateEphemerides">The <see cref="IGenerateEphemeridesParameter"/> of the <see cref="IQueryParameterSet"/>.</param>
    public abstract IQueryParameterSetBuilder Specify(IGenerateEphemeridesParameter generateEphemerides);

    /// <summary>Specifies the <see cref="IOutputFormatParameter"/> of the <see cref="IQueryParameterSet"/>.</summary>
    /// <param name="outputFormat">The <see cref="IOutputFormatParameter"/> of the <see cref="IQueryParameterSet"/>.</param>
    public abstract IQueryParameterSetBuilder Specify(IOutputFormatParameter outputFormat);

    /// <summary>Specifies the <see cref="IObjectDataInclusionParameter"/> of the <see cref="IQueryParameterSet"/>.</summary>
    /// <param name="objectDataInclusion">The <see cref="IObjectDataInclusionParameter"/> of the <see cref="IQueryParameterSet"/>.</param>
    public abstract IQueryParameterSetBuilder Specify(IObjectDataInclusionParameter objectDataInclusion);

    /// <summary>Specifies the <see cref="IOriginParameter"/> of the <see cref="IQueryParameterSet"/>.</summary>
    /// <param name="origin">The <see cref="IOriginParameter"/> of the <see cref="IQueryParameterSet"/>.</param>
    public abstract IQueryParameterSetBuilder Specify(IOriginParameter origin);

    /// <summary>Specifies the <see cref="IOriginCoordinateParameter"/> of the <see cref="IQueryParameterSet"/>.</summary>
    /// <param name="originCoordinate">The <see cref="IOriginCoordinateParameter"/> of the <see cref="IQueryParameterSet"/>.</param>
    public abstract IQueryParameterSetBuilder Specify(IOriginCoordinateParameter originCoordinate);

    /// <summary>Specifies the <see cref="IOriginCoordinateTypeParameter"/> of the <see cref="IQueryParameterSet"/>.</summary>
    /// <param name="originCoordinateType">The <see cref="IOriginCoordinateTypeParameter"/> of the <see cref="IQueryParameterSet"/>.</param>
    public abstract IQueryParameterSetBuilder Specify(IOriginCoordinateTypeParameter originCoordinateType);

    /// <summary>Specifies the <see cref="IEpochCollectionParameter"/> of the <see cref="IQueryParameterSet"/>.</summary>
    /// <param name="epochCollection">The <see cref="IEpochCollectionParameter"/> of the <see cref="IQueryParameterSet"/>.</param>
    public abstract IQueryParameterSetBuilder Specify(IEpochCollectionParameter epochCollection);

    /// <summary>Specifies the <see cref="IEpochCollectionFormatParameter"/> of the <see cref="IQueryParameterSet"/>.</summary>
    /// <param name="epochCollectionFormat">The <see cref="IEpochCollectionFormatParameter"/> of the <see cref="IQueryParameterSet"/>.</param>
    public abstract IQueryParameterSetBuilder Specify(IEpochCollectionFormatParameter epochCollectionFormat);

    /// <summary>Specifies the <see cref="IStartEpochParameter"/> of the <see cref="IQueryParameterSet"/>.</summary>
    /// <param name="startEpoch">The <see cref="IStartEpochParameter"/> of the <see cref="IQueryParameterSet"/>.</param>
    public abstract IQueryParameterSetBuilder Specify(IStartEpochParameter startEpoch);

    /// <summary>Specifies the <see cref="IStopEpochParameter"/> of the <see cref="IQueryParameterSet"/>.</summary>
    /// <param name="stopEpoch">The <see cref="IStopEpochParameter"/> of the <see cref="IQueryParameterSet"/>.</param>
    public abstract IQueryParameterSetBuilder Specify(IStopEpochParameter stopEpoch);

    /// <summary>Specifies the <see cref="IStepSizeParameter"/> of the <see cref="IQueryParameterSet"/>.</summary>
    /// <param name="stepSize">The <see cref="IStepSizeParameter"/> of the <see cref="IQueryParameterSet"/>.</param>
    public abstract IQueryParameterSetBuilder Specify(IStepSizeParameter stepSize);

    /// <summary>Specifies the <see cref="IReferencePlaneParameter"/> of the <see cref="IQueryParameterSet"/>.</summary>
    /// <param name="referencePlane">The <see cref="IReferencePlaneParameter"/> of the <see cref="IQueryParameterSet"/>.</param>
    public abstract IQueryParameterSetBuilder Specify(IReferencePlaneParameter referencePlane);

    /// <summary>Specifies the <see cref="IReferenceSystemParameter"/> of the <see cref="IQueryParameterSet"/>.</summary>
    /// <param name="referenceSystem">The <see cref="IReferenceSystemParameter"/> of the <see cref="IQueryParameterSet"/>.</param>
    public abstract IQueryParameterSetBuilder Specify(IReferenceSystemParameter referenceSystem);

    /// <summary>Specifies the <see cref="ITimePrecisionParameter"/> of the <see cref="IQueryParameterSet"/>.</summary>
    /// <param name="timePrecision">The <see cref="ITimePrecisionParameter"/> of the <see cref="IQueryParameterSet"/>.</param>
    public abstract IQueryParameterSetBuilder Specify(ITimePrecisionParameter timePrecision);

    /// <summary>Specifies the <see cref="IVectorCorrectionParameter"/> of the <see cref="IQueryParameterSet"/>.</summary>
    /// <param name="vectorCorrection">The <see cref="IVectorCorrectionParameter"/> of the <see cref="IQueryParameterSet"/>.</param>
    public abstract IQueryParameterSetBuilder Specify(IVectorCorrectionParameter vectorCorrection);

    /// <summary>Specifies the <see cref="ITimeDeltaInclusionParameter"/> of the <see cref="IQueryParameterSet"/>.</summary>
    /// <param name="timeDeltaInclusion">The <see cref="ITimeDeltaInclusionParameter"/> of the <see cref="IQueryParameterSet"/>.</param>
    public abstract IQueryParameterSetBuilder Specify(ITimeDeltaInclusionParameter timeDeltaInclusion);

    /// <summary>Specifies the <see cref="IVectorTableContentParameter"/> of the <see cref="IQueryParameterSet"/>.</summary>
    /// <param name="vectorTableContent">The <see cref="IVectorTableContentParameter"/> of the <see cref="IQueryParameterSet"/>.</param>
    public abstract IQueryParameterSetBuilder Specify(IVectorTableContentParameter vectorTableContent);

    /// <summary>Specifies the <see cref="IOutputUnitsParameter"/> of the <see cref="IQueryParameterSet"/>.</summary>
    /// <param name="outputUnits">The <see cref="IOutputUnitsParameter"/> of the <see cref="IQueryParameterSet"/>.</param>
    public abstract IQueryParameterSetBuilder Specify(IOutputUnitsParameter outputUnits);

    /// <summary>Specifies the <see cref="IElementLabelsParameter"/> of the <see cref="IQueryParameterSet"/>.</summary>
    /// <param name="elementLabels">The <see cref="IElementLabelsParameter"/> of the <see cref="IQueryParameterSet"/>.</param>
    public abstract IQueryParameterSetBuilder Specify(IElementLabelsParameter elementLabels);

    /// <summary>Specifies the <see cref="IVectorLabelsParameter"/> of the <see cref="IQueryParameterSet"/>.</summary>
    /// <param name="vectorLabels">The <see cref="IVectorLabelsParameter"/> of the <see cref="IQueryParameterSet"/>.</param>
    public abstract IQueryParameterSetBuilder Specify(IVectorLabelsParameter vectorLabels);

    /// <summary>Specifies the <see cref="IValueSeparationParameter"/> of the <see cref="IQueryParameterSet"/>.</summary>
    /// <param name="valueSeparation">The <see cref="IValueSeparationParameter"/> of the <see cref="IQueryParameterSet"/>.</param>
    public abstract IQueryParameterSetBuilder Specify(IValueSeparationParameter valueSeparation);
}
