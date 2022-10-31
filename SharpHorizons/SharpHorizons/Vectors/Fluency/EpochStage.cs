namespace SharpHorizons.Vectors.Fluency;

using SharpHorizons.Calendars;
using SharpHorizons.Query;

using SharpMeasures;

using System;
using System.Collections.Generic;

/// <inheritdoc cref="IEpochStage"/>
internal sealed class EpochStage : IEpochStage
{
    /// <summary>The <see cref="ITarget"/> selected for the <see cref="IVectorsQuery"/>.</summary>
    private ITarget Target { get; }

    /// <summary>The <see cref="IOrigin"/> selected for the <see cref="IVectorsQuery"/>.</summary>
    private IOrigin Origin { get; }

    /// <summary>Uses <paramref name="target"/> and <paramref name="origin"/> as the <see cref="ITarget"/> and <see cref="IOrigin"/> in the <see cref="IVectorsQuery"/>, and provides means of selecting the <see cref="IEpoch"/>.</summary>
    /// <param name="target"><inheritdoc cref="Target" path="/summary"/></param>
    /// <param name="origin"><inheritdoc cref="Origin" path="/summary"/></param>
    public EpochStage(ITarget target, IOrigin origin)
    {
        Target = target;
        Origin = origin;
    }

    IVectorsQuery IEpochStage.WithEpochs(IEpochSelection epochs)
    {
        ArgumentNullException.ThrowIfNull(epochs);

        return new VectorsQuery(Target, Origin, epochs);
    }

    IVectorsQuery IEpochStage.WithEpochs(params IEpoch[] epochs)
    {
        ArgumentNullException.ThrowIfNull(epochs);

        return new VectorsQuery(Target, Origin, new EpochCollection(epochs));
    }

    IVectorsQuery IEpochStage.WithEpochs(IEnumerable<IEpoch> epochs)
    {
        ArgumentNullException.ThrowIfNull(epochs);

        return new VectorsQuery(Target, Origin, new EpochCollection(epochs));
    }

    IVectorsQuery IEpochStage.WithFixedEpochRange(IEpoch startEpoch, IEpoch stopEpoch, Time deltaTime)
    {
        ArgumentNullException.ThrowIfNull(startEpoch);
        ArgumentNullException.ThrowIfNull(stopEpoch);

        return new VectorsQuery(Target, Origin, EpochRange.Fixed(startEpoch, stopEpoch, deltaTime));
    }

    IVectorsQuery IEpochStage.WithUniformEpochRange(IEpoch startEpoch, IEpoch stopEpoch, int stepCount)
    {
        ArgumentNullException.ThrowIfNull(startEpoch);
        ArgumentNullException.ThrowIfNull(stopEpoch);

        return new VectorsQuery(Target, Origin, EpochRange.Uniform(startEpoch, stopEpoch, stepCount));
    }

    IVectorsQuery IEpochStage.WithCalendarEpochRange(IEpoch startEpoch, IEpoch stopEpoch, int count, CalendarStepSizeUnit unit)
    {
        ArgumentNullException.ThrowIfNull(startEpoch);
        ArgumentNullException.ThrowIfNull(stopEpoch);

        return new VectorsQuery(Target, Origin, EpochRange.Calendar(startEpoch, stopEpoch, count, unit));
    }
}