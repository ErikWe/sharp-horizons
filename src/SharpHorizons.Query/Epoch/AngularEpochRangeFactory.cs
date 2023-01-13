namespace SharpHorizons.Query.Epoch;

using SharpHorizons;

using SharpMeasures;

/// <inheritdoc cref="IAngularEpochRangeFactory"/>
internal sealed class AngularEpochRangeFactory : IAngularEpochRangeFactory
{
    /// <inheritdoc cref="IAngularStepSizeFactory"/>
    private IAngularStepSizeFactory StepSizeFactory { get; }

    /// <inheritdoc cref="IEpochRangeFactory"/>
    private IEpochRangeFactory EpochRangeFactory { get; }

    /// <inheritdoc cref="AngularEpochRangeFactory"/>
    /// <param name="stepSizeFactory"><inheritdoc cref="StepSizeFactory" path="/summary"/></param>
    /// <param name="epochRangeFactory"><inheritdoc cref="EpochRangeFactory" path="/summary"/></param>
    public AngularEpochRangeFactory(IAngularStepSizeFactory? stepSizeFactory = null, IEpochRangeFactory? epochRangeFactory = null)
    {
        StepSizeFactory = stepSizeFactory ?? new AngularStepSizeFactory();

        EpochRangeFactory = epochRangeFactory ?? new SimpleEpochRangeFactory();
    }

    /// <inheritdoc cref="IEpochRangeFactory.Create(IEpoch, IEpoch, IStepSize)"/>
    private IEpochRange Create(IEpoch startEpoch, IEpoch stopEpoch, IStepSize stepSize) => EpochRangeFactory.Create(startEpoch, stopEpoch, stepSize);

    IEpochRange IEpochRangeFactory.Create(IEpoch startEpoch, IEpoch stopEpoch, IStepSize stepSize) => Create(startEpoch, stopEpoch, stepSize);
    IEpochRange IAngularEpochRangeFactory.Create(IEpoch startEpoch, IEpoch stopEpoch, Angle deltaAngle)
    {
        var stepSize = StepSizeFactory.Create(deltaAngle);

        return Create(startEpoch, stopEpoch, stepSize);
    }
}
