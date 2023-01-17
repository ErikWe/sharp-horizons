namespace SharpHorizons.Query.Vectors;

using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;

using System;
using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IVectorsQueryArgumentComposer"/>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class VectorsQueryArgumentComposer : IVectorsQueryArgumentComposer
{
    /// <inheritdoc cref="IQueryArgumentSetFactory"/>
    private IQueryArgumentSetFactory BuilderFactory { get; }

    /// <inheritdoc cref="IOutputFormatComposer"/>
    private IOutputFormatComposer OutputFormatComposer { get; }

    /// <inheritdoc cref="IObjectDataInclusionComposer"/>
    private IObjectDataInclusionComposer ObjectDataInclusionComposer { get; }

    /// <inheritdoc cref="IReferencePlaneComposer"/>
    private IReferencePlaneComposer ReferencePlaneComposer { get; }

    /// <inheritdoc cref="IReferenceSystemComposer"/>
    private IReferenceSystemComposer ReferenceSystemComposer { get; }

    /// <inheritdoc cref="ITimePrecisionComposer"/>
    private ITimePrecisionComposer TimePrecisionComposer { get; }

    /// <inheritdoc cref="IVectorCorrectionComposer"/>
    private IVectorCorrectionComposer CorrectionComposer { get; }

    /// <inheritdoc cref="ITimeDeltaInclusionComposer"/>
    private ITimeDeltaInclusionComposer TimeDeltaInclusionComposer { get; }

    /// <inheritdoc cref="IVectorTableContentComposer"/>
    private IVectorTableContentComposer TableContentComposer { get; }

    /// <inheritdoc cref="IOutputUnitsComposer"/>
    private IOutputUnitsComposer OutputUnitsComposer { get; }

    /// <inheritdoc cref="IVectorLabelsComposer"/>
    private IVectorLabelsComposer OutputLabelsComposer { get; }

    /// <inheritdoc cref="IValueSeparationComposer"/>
    private IValueSeparationComposer ValueSeparationComposer { get; }

    /// <inheritdoc cref="IEphemerisTypeArgument"/>
    private IEphemerisTypeArgument EphemerisTypeArgument { get; }

    /// <inheritdoc cref="VectorsQueryArgumentComposer"/>
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
    public VectorsQueryArgumentComposer(IQueryArgumentSetFactory builderFactory, IEphemerisTypeComposer ephemerisTypeComposer, IOutputFormatComposer outputFormatComposer, IObjectDataInclusionComposer objectDataInclusionComposer, IReferencePlaneComposer referencePlaneComposer, IReferenceSystemComposer referenceSystemComposer,
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
        ArgumentNullException.ThrowIfNull(query);

        var builder = BuilderFactory.CreateBuilder(query.Target.ComposeArgument());

        builder.SpecifyEphemerisType(EphemerisTypeArgument);
        builder.SpecifyOutputFormat(OutputFormatComposer.Compose(query.OutputFormat));
        builder.SpecifyObjectDataInclusion(ObjectDataInclusionComposer.Compose(query.ObjectDataInclusion));

        builder.SpecifyOrigin(query.Origin.ComposeArgument());

        if (query.Origin.UsesCoordinate)
        {
            builder.SpecifyOriginCoordinate(query.Origin.ComposeCoordinateArgument());
            builder.SpecifyOriginCoordinateType(query.Origin.ComposeCoordinateTypeArgument());
        }

        if (query.EpochSelection.SelectionMode is Epoch.EpochSelectionMode.Collection)
        {
            builder.SpecifyEpochCollection(query.EpochSelection.ComposeCollectionArgument());
            builder.SpecifyEpochCollectionFormat(query.EpochSelection.ComposeCollectionFormatArgument());
        }

        if (query.EpochSelection.SelectionMode is Epoch.EpochSelectionMode.Range)
        {
            builder.SpecifyStartEpoch(query.EpochSelection.ComposeStartEpochArgument());
            builder.SpecifyStopEpoch(query.EpochSelection.ComposeStopEpochArgument());
            builder.SpecifyStepSize(query.EpochSelection.ComposeStepSizeArgument());
        }

        builder.SpecifyReferencePlane(ReferencePlaneComposer.Compose(query.ReferencePlane));
        builder.SpecifyReferenceSystem(ReferenceSystemComposer.Compose(query.ReferenceSystem));

        builder.SpecifyTimePrecision(TimePrecisionComposer.Compose(query.TimePrecision));
        builder.SpecifyVectorCorrection(CorrectionComposer.Compose(query.Correction));
        builder.SpecifyTimeDeltaInclusion(TimeDeltaInclusionComposer.Compose(query.TimeDeltaInclusion));
        builder.SpecifyVectorTableContent(TableContentComposer.Compose(query.TableContent));
        builder.SpecifyOutputUnits(OutputUnitsComposer.Compose(query.OutputUnits));
        builder.SpecifyVectorLabels(OutputLabelsComposer.Compose(query.OutputLabels));
        builder.SpecifyValueSeparation(ValueSeparationComposer.Compose(query.ValueSeparation));

        return builder.Build();
    }
}
