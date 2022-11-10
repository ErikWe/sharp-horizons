namespace SharpHorizons.Query.Vectors;

using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;

/// <inheritdoc cref="IVectorsQueryArgumentComposer"/>
internal sealed class VectorsQueryArgumentComposer : IVectorsQueryArgumentComposer
{
    /// <summary><inheritdoc cref="IQueryArgumentsBuilderFactory" path="/summary"/></summary>
    private IQueryArgumentsBuilderFactory BuilderFactory { get; }

    /// <summary><inheritdoc cref="IOutputFormatComposer" path="/summary"/></summary>
    private IOutputFormatComposer OutputFormatComposer { get; }

    /// <summary><inheritdoc cref="IObjectDataInclusionComposer" path="/summary"/></summary>
    private IObjectDataInclusionComposer ObjectDataInclusionComposer { get; }

    /// <summary><inheritdoc cref="IReferencePlaneComposer" path="/summary"/></summary>
    private IReferencePlaneComposer ReferencePlaneComposer { get; }

    /// <summary><inheritdoc cref="IReferenceSystemComposer" path="/summary"/></summary>
    private IReferenceSystemComposer ReferenceSystemComposer { get; }

    /// <summary><inheritdoc cref="ITimePrecisionComposer" path="/summary"/></summary>
    private ITimePrecisionComposer TimePrecisionComposer { get; }

    /// <summary><inheritdoc cref="IVectorCorrectionComposer" path="/summary"/></summary>
    private IVectorCorrectionComposer CorrectionComposer { get; }

    /// <summary><inheritdoc cref="ITimeDeltaInclusionComposer" path="/summary"/></summary>
    private ITimeDeltaInclusionComposer TimeDeltaInclusionComposer { get; }

    /// <summary><inheritdoc cref="IVectorTableContentComposer" path="/summary"/></summary>
    private IVectorTableContentComposer TableContentComposer { get; }

    /// <summary><inheritdoc cref="IOutputUnitsComposer" path="/summary"/></summary>
    private IOutputUnitsComposer OutputUnitsComposer { get; }

    /// <summary><inheritdoc cref="IVectorLabelsComposer" path="/summary"/></summary>
    private IVectorLabelsComposer OutputLabelsComposer { get; }

    /// <summary><inheritdoc cref="IValueSeparationComposer" path="/summary"/></summary>
    private IValueSeparationComposer ValueSeparationComposer { get; }

    /// <summary><inheritdoc cref="IEphemerisTypeArgument" path="/summary"/></summary>
    private IEphemerisTypeArgument EphemerisTypeArgument { get; }

    /// <summary><inheritdoc cref="VectorsQueryArgumentComposer" path="/summary"/></summary>
    /// <param name="builderFactory"><inheritdoc cref="BuilderFactory" path="/summary"/></param>
    /// <param name="ephemerisTypeComposer"><inheritdoc cref="IEphemerisTypeComposer" path="/summary"/></param>
    /// <param name="outputFormatComposer"><inheritdoc cref="OutputFormatComposer" path="/summary"/></param>
    /// <param name="objectDataInclusionComposer"><inheritdoc cref="ObjectDataInclusionComposer" path="/summary"/></param>
    /// <param name="referencePlaneComposer"><inheritdoc cref="ReferencePlaneComposer" path="/summary"/></param>
    /// <param name="referenceSystemComposer"><inheritdoc cref="ReferenceSystemComposer" path="/summary"/></param>
    /// <param name="timePrecisionComposer"><inheritdoc cref="TimePrecisionComposer" path="/summary"/></param>
    /// <param name="correctionComposer"><inheritdoc cref="CorrectionComposer" path="/summary"/></param>
    /// <param name="timeDeltaInclusionComposer"><inheritdoc cref="TimeDeltaInclusionComposer" path="/summary"/></param>
    /// <param name="tableContentComposer"><inheritdoc cref="TableContentComposer" path="/summary"/></param>
    /// <param name="outputUnitsComposer"><inheritdoc cref="OutputUnitsComposer" path="/summary"/></param>
    /// <param name="outputLabelsComposer"><inheritdoc cref="OutputLabelsComposer" path="/summary"/></param>
    /// <param name="valueSeparationComposer"><inheritdoc cref="ValueSeparationComposer" path="/summary"/></param>
    public VectorsQueryArgumentComposer(IQueryArgumentsBuilderFactory builderFactory, IEphemerisTypeComposer ephemerisTypeComposer, IOutputFormatComposer outputFormatComposer, IObjectDataInclusionComposer objectDataInclusionComposer, IReferencePlaneComposer referencePlaneComposer, IReferenceSystemComposer referenceSystemComposer,
        ITimePrecisionComposer timePrecisionComposer, IVectorCorrectionComposer correctionComposer, ITimeDeltaInclusionComposer timeDeltaInclusionComposer, IVectorTableContentComposer tableContentComposer, IOutputUnitsComposer outputUnitsComposer, IVectorLabelsComposer outputLabelsComposer, IValueSeparationComposer valueSeparationComposer)
    {
        BuilderFactory = builderFactory;

        OutputFormatComposer = outputFormatComposer;
        ObjectDataInclusionComposer = objectDataInclusionComposer;
        ReferencePlaneComposer = referencePlaneComposer;
        ReferenceSystemComposer = referenceSystemComposer;
        TimePrecisionComposer = timePrecisionComposer;
        CorrectionComposer = correctionComposer;
        TimeDeltaInclusionComposer = timeDeltaInclusionComposer;
        TableContentComposer = tableContentComposer;
        OutputUnitsComposer = outputUnitsComposer;
        OutputLabelsComposer = outputLabelsComposer;
        ValueSeparationComposer = valueSeparationComposer;

        EphemerisTypeArgument = ephemerisTypeComposer.Compose(EphemerisType.Vectors);
    }

    IQueryArgumentSet IVectorsQueryArgumentComposer.Compose(IVectorsQuery query)
    {
        var builder = BuilderFactory.Create();

        builder.Specify(EphemerisTypeArgument);
        builder.Specify(OutputFormatComposer.Compose(query.OutputFormat));
        builder.Specify(ObjectDataInclusionComposer.Compose(query.ObjectDataInclusion));

        builder.Specify(query.Target.ComposeArgument());
        builder.Specify(query.Origin.ComposeArgument());
        builder.Specify(query.Origin.ComposeCoordinateArgument());
        builder.Specify(query.Origin.ComposeCoordinateTypeArgument());

        if (query.Epochs.Selection is Epoch.EpochSelectionMode.Collection)
        {
            builder.Specify(query.Epochs.ComposeCollectionArgument());
            builder.Specify(query.Epochs.ComposeCollectionFormatArgument());
        }

        if (query.Epochs.Selection is Epoch.EpochSelectionMode.Range)
        {
            builder.Specify(query.Epochs.ComposeStartTimeArgument());
            builder.Specify(query.Epochs.ComposeStopTimeArgument());
            builder.Specify(query.Epochs.ComposeStepSizeArgument());
        }

        builder.Specify(ReferencePlaneComposer.Compose(query.ReferencePlane));
        builder.Specify(ReferenceSystemComposer.Compose(query.ReferenceSystem));

        builder.Specify(TimePrecisionComposer.Compose(query.TimePrecision));
        builder.Specify(CorrectionComposer.Compose(query.Correction));
        builder.Specify(TimeDeltaInclusionComposer.Compose(query.TimeDeltaInclusion));
        builder.Specify(TableContentComposer.Compose(query.TableContent));
        builder.Specify(OutputUnitsComposer.Compose(query.OutputUnits));
        builder.Specify(OutputLabelsComposer.Compose(query.OutputLabels));
        builder.Specify(ValueSeparationComposer.Compose(query.ValueSeparation));

        return builder.Build();
    }
}
