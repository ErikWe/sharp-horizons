namespace SharpHorizons.Query.Vectors.Fluency;

using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;

/// <inheritdoc cref="IEpochStageFactory"/>
internal sealed class EpochStageFactory : IEpochStageFactory
{
    /// <inheritdoc cref="Vectors.VectorsQueryInstantiation"/>
    private VectorsQueryInstantiation VectorsQueryInstantiation { get; }

    /// <summary><inheritdoc cref="IFixedEpochRangeFactory" path="/summary"/></summary>
    private IFixedEpochRangeFactory FixedRangeFactory { get; }

    /// <summary><inheritdoc cref="IUniformEpochRangeFactory" path="/summary"/></summary>
    private IUniformEpochRangeFactory UniformRangeFactory { get; }

    /// <summary><inheritdoc cref="ICalendarEpochRangeFactory" path="/summary"/></summary>
    private ICalendarEpochRangeFactory CalendarRangeFactory { get; }

    /// <summary><inheritdoc cref="IEpochCollectionFactory" path="/summary"/></summary>
    private IEpochCollectionFactory CollectionFactory { get; }

    /// <summary><inheritdoc cref="EpochStageFactory" path="/summary"/></summary>
    /// <param name="vectorsQueryInstantiation"><inheritdoc cref="VectorsQueryInstantiation" path="/summary"/></param>
    /// <param name="fixedRangeFactory"><inheritdoc cref="FixedRangeFactory" path="/summary"/></param>
    /// <param name="uniformRangeFactory"><inheritdoc cref="UniformRangeFactory" path="/summary"/></param>
    /// <param name="calendarRangeFactory"><inheritdoc cref="CalendarRangeFactory" path="/summary"/></param>
    /// <param name="collectionFactory"><inheritdoc cref="CollectionFactory" path="/summary"/></param>
    public EpochStageFactory(VectorsQueryInstantiation? vectorsQueryInstantiation = null, IFixedEpochRangeFactory? fixedRangeFactory = null, IUniformEpochRangeFactory? uniformRangeFactory = null, ICalendarEpochRangeFactory? calendarRangeFactory = null, IEpochCollectionFactory? collectionFactory = null)
    {
        EpochRangeFactory? defaultEpochRangeFactory = null;

        if (fixedRangeFactory is null || uniformRangeFactory is null || calendarRangeFactory is null)
        {
            defaultEpochRangeFactory = new EpochRangeFactory();
        }

        VectorsQueryInstantiation = vectorsQueryInstantiation ?? VectorsQuery.Instantiation;

        FixedRangeFactory = fixedRangeFactory ?? defaultEpochRangeFactory!;
        UniformRangeFactory = uniformRangeFactory ?? defaultEpochRangeFactory!;
        CalendarRangeFactory = calendarRangeFactory ?? defaultEpochRangeFactory!;

        CollectionFactory = collectionFactory ?? new EpochCollectionFactory();
    }

    IEpochStage IEpochStageFactory.Create(ITarget target, IOrigin origin) => new EpochStage(target, origin, VectorsQueryInstantiation, FixedRangeFactory, UniformRangeFactory, CalendarRangeFactory, CollectionFactory);
}
