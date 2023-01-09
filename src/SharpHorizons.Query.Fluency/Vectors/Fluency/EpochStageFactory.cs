namespace SharpHorizons.Query.Vectors.Fluency;

using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;

using System;

/// <inheritdoc cref="IEpochStageFactory"/>
internal sealed class EpochStageFactory : IEpochStageFactory
{
    /// <inheritdoc cref="IVectorsQueryFactory"/>
    private IVectorsQueryFactory VectorsQueryFactory { get; }

    /// <inheritdoc cref="IEpochRangeFactory"/>
    private IEpochRangeFactory EpochRangeFactory { get; }

    /// <inheritdoc cref="IEpochCollectionFactory"/>
    private IEpochCollectionFactory EpochCollectionFactory { get; }

    /// <inheritdoc cref="EpochStageFactory"/>
    /// <param name="vectorsQueryFactory"><inheritdoc cref="VectorsQueryFactory" path="/summary"/></param>
    /// <param name="epochRangeFactory"><inheritdoc cref="EpochRangeFactory" path="/summary"/></param>
    /// <param name="epochCollectionFactory"><inheritdoc cref="EpochCollectionFactory" path="/summary"/></param>
    public EpochStageFactory(IVectorsQueryFactory? vectorsQueryFactory = null, IEpochRangeFactory? epochRangeFactory = null, IEpochCollectionFactory? epochCollectionFactory = null)
    {
        VectorsQueryFactory = vectorsQueryFactory ?? new VectorsQueryFactory();

        EpochRangeFactory = epochRangeFactory ?? new EpochRangeFactory();
        EpochCollectionFactory = epochCollectionFactory ?? new EpochCollectionFactory();
    }

    IEpochStage IEpochStageFactory.Create(ITarget target, IOrigin origin)
    {
        ArgumentNullException.ThrowIfNull(target);
        ArgumentNullException.ThrowIfNull(origin);

        return new EpochStage(target, origin, VectorsQueryFactory, epochRangeFactory: EpochRangeFactory, epochCollectionFactory: EpochCollectionFactory);
    }
}
