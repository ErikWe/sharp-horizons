namespace SharpHorizons.Query.Vectors.Fluency;

using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;

using System;

/// <inheritdoc cref="IEpochStageFactory"/>
internal sealed class EpochStageFactory : IEpochStageFactory
{
    /// <inheritdoc cref="IVectorsQueryValidator"/>
    private IVectorsQueryValidator VectorsQueryValidator { get; }

    /// <inheritdoc cref="IEpochRangeFactory"/>
    private IEpochRangeFactory EpochRangeFactory { get; }

    /// <inheritdoc cref="IEpochCollectionFactory"/>
    private IEpochCollectionFactory EpochCollectionFactory { get; }

    /// <inheritdoc cref="EpochStageFactory"/>
    /// <param name="vectorsQueryValidator"><inheritdoc cref="VectorsQueryValidator" path="/summary"/></param>
    /// <param name="epochRangeFactory"><inheritdoc cref="EpochRangeFactory" path="/summary"/></param>
    /// <param name="epochCollectionFactory"><inheritdoc cref="EpochCollectionFactory" path="/summary"/></param>
    public EpochStageFactory(IVectorsQueryValidator? vectorsQueryValidator = null, IEpochRangeFactory? epochRangeFactory = null, IEpochCollectionFactory? epochCollectionFactory = null)
    {
        VectorsQueryValidator = vectorsQueryValidator ?? new VectorsQueryValidator();

        EpochRangeFactory = epochRangeFactory ?? new EpochRangeFactory();
        EpochCollectionFactory = epochCollectionFactory ?? new EpochCollectionFactory();
    }

    IEpochStage IEpochStageFactory.Create(ITarget target, IOrigin origin)
    {
        ArgumentNullException.ThrowIfNull(target);
        ArgumentNullException.ThrowIfNull(origin);

        return new EpochStage(target, origin, VectorsQueryValidator, EpochRangeFactory, EpochCollectionFactory);
    }
}
