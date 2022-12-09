namespace SharpHorizons.Query.Vectors.Fluency;

using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.Vectors.Table;

/// <inheritdoc cref="IEpochStageFactory"/>
internal sealed class EpochStageFactory : IEpochStageFactory
{
    /// <inheritdoc cref="IVectorTableContentValidator"/>
    private IVectorTableContentValidator TableContentValidator { get; }

    /// <inheritdoc cref="IFixedEpochRangeFactory"/>
    private IFixedEpochRangeFactory FixedRangeFactory { get; }

    /// <inheritdoc cref="IUniformEpochRangeFactory"/>
    private IUniformEpochRangeFactory UniformRangeFactory { get; }

    /// <inheritdoc cref="ICalendarEpochRangeFactory"/>
    private ICalendarEpochRangeFactory CalendarRangeFactory { get; }

    /// <inheritdoc cref="IEpochCollectionFactory"/>
    private IEpochCollectionFactory CollectionFactory { get; }

    /// <inheritdoc cref="EpochStageFactory"/>
    /// <param name="tableContentValidator"><inheritdoc cref="TableContentValidator" path="/summary"/></param>
    /// <param name="fixedRangeFactory"><inheritdoc cref="FixedRangeFactory" path="/summary"/></param>
    /// <param name="uniformRangeFactory"><inheritdoc cref="UniformRangeFactory" path="/summary"/></param>
    /// <param name="calendarRangeFactory"><inheritdoc cref="CalendarRangeFactory" path="/summary"/></param>
    /// <param name="collectionFactory"><inheritdoc cref="CollectionFactory" path="/summary"/></param>
    public EpochStageFactory(IVectorTableContentValidator? tableContentValidator = null, IFixedEpochRangeFactory? fixedRangeFactory = null, IUniformEpochRangeFactory? uniformRangeFactory = null, ICalendarEpochRangeFactory? calendarRangeFactory = null, IEpochCollectionFactory? collectionFactory = null)
    {
        EpochRangeFactory? defaultEpochRangeFactory = null;

        if (fixedRangeFactory is null || uniformRangeFactory is null || calendarRangeFactory is null)
        {
            defaultEpochRangeFactory = new EpochRangeFactory();
        }

        TableContentValidator = tableContentValidator ?? new VectorTableContentValidator();

        FixedRangeFactory = fixedRangeFactory ?? defaultEpochRangeFactory!;
        UniformRangeFactory = uniformRangeFactory ?? defaultEpochRangeFactory!;
        CalendarRangeFactory = calendarRangeFactory ?? defaultEpochRangeFactory!;

        CollectionFactory = collectionFactory ?? new EpochCollectionFactory();
    }

    IEpochStage IEpochStageFactory.Create(ITarget target, IOrigin origin) => new EpochStage(target, origin, TableContentValidator, FixedRangeFactory, UniformRangeFactory, CalendarRangeFactory, CollectionFactory);
}
