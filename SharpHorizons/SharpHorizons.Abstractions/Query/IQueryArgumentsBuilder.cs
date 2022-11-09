namespace SharpHorizons.Query;

/// <summary>Handles iterative construction of <see cref="IQueryArgumentSet"/>.</summary>
public interface IQueryArgumentsBuilder
{
    /// <summary>Constructs the <see cref="IQueryArgumentSet"/> of the <see cref="IQueryArgumentSet"/>.</summary>
    public abstract IQueryArgumentSet Build();

    /// <summary>Specifies the <see cref="ICommandArgument"/> of the <see cref="IQueryArgumentSet"/>.</summary>
    /// <param name="command">The <see cref="ICommandArgument"/> of the <see cref="IQueryArgumentSet"/>.</param>
    public abstract IQueryArgumentsBuilder Specify(ICommandArgument command);

    /// <summary>Specifies the <see cref="IEphemerisTypeArgument"/> of the <see cref="IQueryArgumentSet"/>.</summary>
    /// <param name="ephemerisType">The <see cref="IEphemerisTypeArgument"/> of the <see cref="IQueryArgumentSet"/>.</param>
    public abstract IQueryArgumentsBuilder Specify(IEphemerisTypeArgument ephemerisType);

    /// <summary>Specifies the <see cref="IGenerateEphemeridesArgument"/> of the <see cref="IQueryArgumentSet"/>.</summary>
    /// <param name="generateEphemerides">The <see cref="IGenerateEphemeridesArgument"/> of the <see cref="IQueryArgumentSet"/>.</param>
    public abstract IQueryArgumentsBuilder Specify(IGenerateEphemeridesArgument generateEphemerides);

    /// <summary>Specifies the <see cref="IOutputFormatArgument"/> of the <see cref="IQueryArgumentSet"/>.</summary>
    /// <param name="outputFormat">The <see cref="IOutputFormatArgument"/> of the <see cref="IQueryArgumentSet"/>.</param>
    public abstract IQueryArgumentsBuilder Specify(IOutputFormatArgument outputFormat);

    /// <summary>Specifies the <see cref="IObjectDataInclusionArgument"/> of the <see cref="IQueryArgumentSet"/>.</summary>
    /// <param name="objectDataInclusion">The <see cref="IObjectDataInclusionArgument"/> of the <see cref="IQueryArgumentSet"/>.</param>
    public abstract IQueryArgumentsBuilder Specify(IObjectDataInclusionArgument objectDataInclusion);

    /// <summary>Specifies the <see cref="IOriginArgument"/> of the <see cref="IQueryArgumentSet"/>.</summary>
    /// <param name="origin">The <see cref="IOriginArgument"/> of the <see cref="IQueryArgumentSet"/>.</param>
    public abstract IQueryArgumentsBuilder Specify(IOriginArgument origin);

    /// <summary>Specifies the <see cref="IOriginCoordinateArgument"/> of the <see cref="IQueryArgumentSet"/>.</summary>
    /// <param name="originCoordinate">The <see cref="IOriginCoordinateArgument"/> of the <see cref="IQueryArgumentSet"/>.</param>
    public abstract IQueryArgumentsBuilder Specify(IOriginCoordinateArgument originCoordinate);

    /// <summary>Specifies the <see cref="IOriginCoordinateTypeArgument"/> of the <see cref="IQueryArgumentSet"/>.</summary>
    /// <param name="originCoordinateType">The <see cref="IOriginCoordinateTypeArgument"/> of the <see cref="IQueryArgumentSet"/>.</param>
    public abstract IQueryArgumentsBuilder Specify(IOriginCoordinateTypeArgument originCoordinateType);

    /// <summary>Specifies the <see cref="IEpochCollectionArgument"/> of the <see cref="IQueryArgumentSet"/>.</summary>
    /// <param name="epochCollection">The <see cref="IEpochCollectionArgument"/> of the <see cref="IQueryArgumentSet"/>.</param>
    public abstract IQueryArgumentsBuilder Specify(IEpochCollectionArgument epochCollection);

    /// <summary>Specifies the <see cref="IEpochCollectionFormatArgument"/> of the <see cref="IQueryArgumentSet"/>.</summary>
    /// <param name="epochCollectionFormat">The <see cref="IEpochCollectionFormatArgument"/> of the <see cref="IQueryArgumentSet"/>.</param>
    public abstract IQueryArgumentsBuilder Specify(IEpochCollectionFormatArgument epochCollectionFormat);

    /// <summary>Specifies the <see cref="IStartEpochArgument"/> of the <see cref="IQueryArgumentSet"/>.</summary>
    /// <param name="startEpoch">The <see cref="IStartEpochArgument"/> of the <see cref="IQueryArgumentSet"/>.</param>
    public abstract IQueryArgumentsBuilder Specify(IStartEpochArgument startEpoch);

    /// <summary>Specifies the <see cref="IStopEpochArgument"/> of the <see cref="IQueryArgumentSet"/>.</summary>
    /// <param name="stopEpoch">The <see cref="IStopEpochArgument"/> of the <see cref="IQueryArgumentSet"/>.</param>
    public abstract IQueryArgumentsBuilder Specify(IStopEpochArgument stopEpoch);

    /// <summary>Specifies the <see cref="IStepSizeArgument"/> of the <see cref="IQueryArgumentSet"/>.</summary>
    /// <param name="stepSize">The <see cref="IStepSizeArgument"/> of the <see cref="IQueryArgumentSet"/>.</param>
    public abstract IQueryArgumentsBuilder Specify(IStepSizeArgument stepSize);

    /// <summary>Specifies the <see cref="IReferencePlaneArgument"/> of the <see cref="IQueryArgumentSet"/>.</summary>
    /// <param name="referencePlane">The <see cref="IReferencePlaneArgument"/> of the <see cref="IQueryArgumentSet"/>.</param>
    public abstract IQueryArgumentsBuilder Specify(IReferencePlaneArgument referencePlane);

    /// <summary>Specifies the <see cref="IReferenceSystemArgument"/> of the <see cref="IQueryArgumentSet"/>.</summary>
    /// <param name="referenceSystem">The <see cref="IReferenceSystemArgument"/> of the <see cref="IQueryArgumentSet"/>.</param>
    public abstract IQueryArgumentsBuilder Specify(IReferenceSystemArgument referenceSystem);

    /// <summary>Specifies the <see cref="ITimePrecisionArgument"/> of the <see cref="IQueryArgumentSet"/>.</summary>
    /// <param name="timePrecision">The <see cref="ITimePrecisionArgument"/> of the <see cref="IQueryArgumentSet"/>.</param>
    public abstract IQueryArgumentsBuilder Specify(ITimePrecisionArgument timePrecision);

    /// <summary>Specifies the <see cref="IVectorCorrectionArgument"/> of the <see cref="IQueryArgumentSet"/>.</summary>
    /// <param name="vectorCorrection">The <see cref="IVectorCorrectionArgument"/> of the <see cref="IQueryArgumentSet"/>.</param>
    public abstract IQueryArgumentsBuilder Specify(IVectorCorrectionArgument vectorCorrection);

    /// <summary>Specifies the <see cref="ITimeDeltaInclusionArgument"/> of the <see cref="IQueryArgumentSet"/>.</summary>
    /// <param name="timeDeltaInclusion">The <see cref="ITimeDeltaInclusionArgument"/> of the <see cref="IQueryArgumentSet"/>.</param>
    public abstract IQueryArgumentsBuilder Specify(ITimeDeltaInclusionArgument timeDeltaInclusion);

    /// <summary>Specifies the <see cref="IVectorTableContentArgument"/> of the <see cref="IQueryArgumentSet"/>.</summary>
    /// <param name="vectorTableContent">The <see cref="IVectorTableContentArgument"/> of the <see cref="IQueryArgumentSet"/>.</param>
    public abstract IQueryArgumentsBuilder Specify(IVectorTableContentArgument vectorTableContent);

    /// <summary>Specifies the <see cref="IOutputUnitsArgument"/> of the <see cref="IQueryArgumentSet"/>.</summary>
    /// <param name="outputUnits">The <see cref="IOutputUnitsArgument"/> of the <see cref="IQueryArgumentSet"/>.</param>
    public abstract IQueryArgumentsBuilder Specify(IOutputUnitsArgument outputUnits);

    /// <summary>Specifies the <see cref="IElementLabelsArgument"/> of the <see cref="IQueryArgumentSet"/>.</summary>
    /// <param name="elementLabels">The <see cref="IElementLabelsArgument"/> of the <see cref="IQueryArgumentSet"/>.</param>
    public abstract IQueryArgumentsBuilder Specify(IElementLabelsArgument elementLabels);

    /// <summary>Specifies the <see cref="IVectorLabelsArgument"/> of the <see cref="IQueryArgumentSet"/>.</summary>
    /// <param name="vectorLabels">The <see cref="IVectorLabelsArgument"/> of the <see cref="IQueryArgumentSet"/>.</param>
    public abstract IQueryArgumentsBuilder Specify(IVectorLabelsArgument vectorLabels);

    /// <summary>Specifies the <see cref="IValueSeparationArgument"/> of the <see cref="IQueryArgumentSet"/>.</summary>
    /// <param name="valueSeparation">The <see cref="IValueSeparationArgument"/> of the <see cref="IQueryArgumentSet"/>.</param>
    public abstract IQueryArgumentsBuilder Specify(IValueSeparationArgument valueSeparation);
}
