namespace SharpHorizons.Query.Vectors.Fluency;

using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.Vectors.Table;

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

    /// <inheritdoc cref="IVectorTableContentValidator"/>
    public required IVectorTableContentValidator TableContentValidator { private get; init; }

    /// <inheritdoc cref="IFixedEpochRangeFactory"/>
    public required IFixedEpochRangeFactory FixedRangeFactory { private get; init; }

    /// <inheritdoc cref="IUniformEpochRangeFactory"/>
    public required IUniformEpochRangeFactory UniformRangeFactory { private get; init; }

    /// <inheritdoc cref="ICalendarEpochRangeFactory"/>
    public required ICalendarEpochRangeFactory CalendarRangeFactory { private get; init; }

    /// <inheritdoc cref="IEpochCollectionFactory"/>
    public required IEpochCollectionFactory CollectionFactory { private get; init; }

    /// <inheritdoc cref="EpochStage"/>
    public EpochStage() { }

    /// <inheritdoc cref="EpochStage"/>
    /// <param name="target"><inheritdoc cref="Target" path="/summary"/></param>
    /// <param name="origin"><inheritdoc cref="Origin" path="/summary"/></param>
    /// <param name="tableContentValidator"><inheritdoc cref="TableContentValidator" path="/summary"/></param>
    /// <param name="fixedRangeFactory"><inheritdoc cref="FixedRangeFactory" path="/summary"/></param>
    /// <param name="uniformRangeFactory"><inheritdoc cref="UniformRangeFactory" path="/summary"/></param>
    /// <param name="calendarRangeFactory"><inheritdoc cref="CalendarRangeFactory" path="/summary"/></param>
    /// <param name="collectionFactory"><inheritdoc cref="CollectionFactory" path="/summary"/></param>
    [SetsRequiredMembers]
    public EpochStage(ITarget target, IOrigin origin, IVectorTableContentValidator tableContentValidator, IFixedEpochRangeFactory fixedRangeFactory, IUniformEpochRangeFactory uniformRangeFactory, ICalendarEpochRangeFactory calendarRangeFactory, IEpochCollectionFactory collectionFactory)
    {
        Target = target;
        Origin = origin;

        TableContentValidator = tableContentValidator;

        FixedRangeFactory = fixedRangeFactory;
        UniformRangeFactory = uniformRangeFactory;
        CalendarRangeFactory = calendarRangeFactory;

        CollectionFactory = collectionFactory;
    }

    IVectorsQuery IEpochStage.WithEpochs(IEpochSelection epochSelection)
    {
        ArgumentNullException.ThrowIfNull(epochSelection);

        return Create(epochSelection);
    }

    IVectorsQuery IEpochStage.WithEpochs(IEnumerable<IEpoch> epochs, EpochFormat format) => Create(CollectionFactory.Create(epochs, format));
    IVectorsQuery IEpochStage.WithEpochs(IEnumerable<IEpoch> epochs) => Create(CollectionFactory.Create(epochs));

    IVectorsQuery IEpochStage.WithEpochs(EpochFormat format, params IEpoch[] epochs) => Create(CollectionFactory.Create(format, epochs));
    IVectorsQuery IEpochStage.WithEpochs(params IEpoch[] epochs) => Create(CollectionFactory.Create(epochs));

    IVectorsQuery IEpochStage.WithFixedEpochRange(IEpoch startEpoch, IEpoch stopEpoch, Time deltaTime) => Create(FixedRangeFactory.Create(startEpoch, stopEpoch, deltaTime));
    IVectorsQuery IEpochStage.WithUniformEpochRange(IEpoch startEpoch, IEpoch stopEpoch, int stepCount) => Create(UniformRangeFactory.Create(startEpoch, stopEpoch, stepCount));
    IVectorsQuery IEpochStage.WithCalendarEpochRange(IEpoch startEpoch, IEpoch stopEpoch, int count, CalendarStepSizeUnit unit) => Create(CalendarRangeFactory.Create(startEpoch, stopEpoch, count, unit));

    /// <summary>Uses <paramref name="epochSelection"/> as the <see cref="IEpochSelection"/> in the <see cref="IVectorsQuery"/>.</summary>
    /// <param name="epochSelection">The <see cref="IEpochSelection"/> in the <see cref="IVectorsQuery"/>.</param>
    private IVectorsQuery Create(IEpochSelection epochSelection) => new VectorsQuery(TableContentValidator, Target, Origin, epochSelection);
}