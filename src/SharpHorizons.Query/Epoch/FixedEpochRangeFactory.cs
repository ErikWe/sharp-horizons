namespace SharpHorizons.Query.Epoch;

using SharpHorizons;

using SharpMeasures;

/// <inheritdoc cref="IFixedEpochRangeFactory"/>
internal sealed class FixedEpochRangeFactory : IFixedEpochRangeFactory
{
    /// <inheritdoc cref="IFixedStepSizeFactory"/>
    private IFixedStepSizeFactory StepSizeFactory { get; }

    /// <inheritdoc cref="IEpochRangeFactory"/>
    private IEpochRangeFactory EpochRangeFactory { get; }

    /// <inheritdoc cref="FixedEpochRangeFactory"/>
    /// <param name="stepSizeFactory"><inheritdoc cref="StepSizeFactory" path="/summary"/></param>
    /// <param name="epochRangeFactory"><inheritdoc cref="EpochRangeFactory" path="/summary"/></param>
    public FixedEpochRangeFactory(IFixedStepSizeFactory? stepSizeFactory = null, IEpochRangeFactory? epochRangeFactory = null)
    {
        StepSizeFactory = stepSizeFactory ?? new FixedStepSizeFactory();

        EpochRangeFactory = epochRangeFactory ?? new SimpleEpochRangeFactory();
    }

    /// <inheritdoc cref="IEpochRangeFactory.Create(IEpoch, IEpoch, IStepSize)"/>
    private IEpochRange Create(IEpoch startEpoch, IEpoch stopEpoch, IStepSize stepSize) => EpochRangeFactory.Create(startEpoch, stopEpoch, stepSize);

    IEpochRange IEpochRangeFactory.Create(IEpoch startEpoch, IEpoch stopEpoch, IStepSize stepSize) => Create(startEpoch, stopEpoch, stepSize);
    IEpochRange IFixedEpochRangeFactory.Create(IEpoch startEpoch, IEpoch stopEpoch, Time deltaTime)
    {
        var stepSize = StepSizeFactory.Create(deltaTime);

        return Create(startEpoch, stopEpoch, stepSize);
    }
}
