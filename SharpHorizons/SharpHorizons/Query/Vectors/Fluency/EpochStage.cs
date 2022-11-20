namespace SharpHorizons.Query.Vectors.Fluency;

using SharpHorizons.Epoch;
using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;

using SharpMeasures;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IEpochStage"/>
internal sealed class EpochStage : IEpochStage
{
    /// <summary>The <see cref="ITarget"/> selected for the <see cref="IVectorsQuery"/>.</summary>
    public required ITarget Target { private get; init; }

    /// <summary>The <see cref="IOrigin"/> selected for the <see cref="IVectorsQuery"/>.</summary>
    public required IOrigin Origin { private get; init; }

    /// <inheritdoc cref="Vectors.VectorsQueryInstantiation"/>
    public required VectorsQueryInstantiation VectorsQueryInstantiation { private get; init; }

    /// <summary><inheritdoc cref="IFixedEpochRangeFactory" path="/summary"/></summary>
    public required IFixedEpochRangeFactory FixedRangeFactory { private get; init; }

    /// <summary><inheritdoc cref="IUniformEpochRangeFactory" path="/summary"/></summary>
    public required IUniformEpochRangeFactory UniformRangeFactory { private get; init; }

    /// <summary><inheritdoc cref="ICalendarEpochRangeFactory" path="/summary"/></summary>
    public required ICalendarEpochRangeFactory CalendarRangeFactory { private get; init; }

    /// <summary><inheritdoc cref="IEpochCollectionFactory" path="/summary"/></summary>
    public required IEpochCollectionFactory CollectionFactory { private get; init; }

    /// <inheritdoc cref="EpochStage"/>
    public EpochStage() { }

    /// <inheritdoc cref="EpochStage"/>
    /// <param name="target"><inheritdoc cref="Target" path="/summary"/></param>
    /// <param name="origin"><inheritdoc cref="Origin" path="/summary"/></param>
    /// <param name="vectorsQueryInstantiation"><inheritdoc cref="VectorsQueryInstantiation" path="/summary"/></param>
    /// <param name="fixedRangeFactory"><inheritdoc cref="FixedRangeFactory" path="/summary"/></param>
    /// <param name="uniformRangeFactory"><inheritdoc cref="UniformRangeFactory" path="/summary"/></param>
    /// <param name="calendarRangeFactory"><inheritdoc cref="CalendarRangeFactory" path="/summary"/></param>
    /// <param name="collectionFactory"><inheritdoc cref="CollectionFactory" path="/summary"/></param>
    [SetsRequiredMembers]
    public EpochStage(ITarget target, IOrigin origin, VectorsQueryInstantiation vectorsQueryInstantiation, IFixedEpochRangeFactory fixedRangeFactory, IUniformEpochRangeFactory uniformRangeFactory, ICalendarEpochRangeFactory calendarRangeFactory, IEpochCollectionFactory collectionFactory)
    {
        Target = target;
        Origin = origin;

        VectorsQueryInstantiation = vectorsQueryInstantiation;

        FixedRangeFactory = fixedRangeFactory;
        UniformRangeFactory = uniformRangeFactory;
        CalendarRangeFactory = calendarRangeFactory;

        CollectionFactory = collectionFactory;
    }

    IVectorsQuery IEpochStage.WithEpochs(IEpochSelection epochs)
    {
        ArgumentNullException.ThrowIfNull(epochs);

        return VectorsQueryInstantiation(Target, Origin, epochs);
    }

    IVectorsQuery IEpochStage.WithEpochs(params IEpoch[] epochs)
    {
        ArgumentNullException.ThrowIfNull(epochs);

        return VectorsQueryInstantiation(Target, Origin, CollectionFactory.Create(epochs));
    }

    IVectorsQuery IEpochStage.WithEpochs(IEnumerable<IEpoch> epochs)
    {
        ArgumentNullException.ThrowIfNull(epochs);

        return VectorsQueryInstantiation(Target, Origin, CollectionFactory.Create(epochs));
    }

    IVectorsQuery IEpochStage.WithFixedEpochRange(IEpoch startEpoch, IEpoch stopEpoch, Time deltaTime)
    {
        ArgumentNullException.ThrowIfNull(startEpoch);
        ArgumentNullException.ThrowIfNull(stopEpoch);

        return VectorsQueryInstantiation(Target, Origin, FixedRangeFactory.Create(startEpoch, stopEpoch, deltaTime));
    }

    IVectorsQuery IEpochStage.WithUniformEpochRange(IEpoch startEpoch, IEpoch stopEpoch, int stepCount)
    {
        ArgumentNullException.ThrowIfNull(startEpoch);
        ArgumentNullException.ThrowIfNull(stopEpoch);

        return VectorsQueryInstantiation(Target, Origin, UniformRangeFactory.Create(startEpoch, stopEpoch, stepCount));
    }

    IVectorsQuery IEpochStage.WithCalendarEpochRange(IEpoch startEpoch, IEpoch stopEpoch, int count, CalendarStepSizeUnit unit)
    {
        ArgumentNullException.ThrowIfNull(startEpoch);
        ArgumentNullException.ThrowIfNull(stopEpoch);

        return VectorsQueryInstantiation(Target, Origin, CalendarRangeFactory.Create(startEpoch, stopEpoch, count, unit));
    }
}