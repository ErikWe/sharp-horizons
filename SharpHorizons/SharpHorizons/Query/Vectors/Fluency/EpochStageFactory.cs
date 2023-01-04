namespace SharpHorizons.Query.Vectors.Fluency;

using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.Vectors.Table;

using System;

/// <inheritdoc cref="IEpochStageFactory"/>
internal sealed class EpochStageFactory : IEpochStageFactory
{
    /// <inheritdoc cref="IVectorTableContentValidator"/>
    private IVectorTableContentValidator TableContentValidator { get; }

    /// <inheritdoc cref="IEpochRangeFactory"/>
    private IEpochRangeFactory EpochRangeFactory { get; }

    /// <inheritdoc cref="IEpochCollectionFactory"/>
    private IEpochCollectionFactory EpochCollectionFactory { get; }

    /// <inheritdoc cref="EpochStageFactory"/>
    /// <param name="tableContentValidator"><inheritdoc cref="TableContentValidator" path="/summary"/></param>
    /// <param name="epochRangeFactory"><inheritdoc cref="EpochRangeFactory" path="/summary"/></param>
    /// <param name="epochCollectionFactory"><inheritdoc cref="EpochCollectionFactory" path="/summary"/></param>
    public EpochStageFactory(IVectorTableContentValidator? tableContentValidator = null, IEpochRangeFactory? epochRangeFactory = null, IEpochCollectionFactory? epochCollectionFactory = null)
    {
        TableContentValidator = tableContentValidator ?? new VectorTableContentValidator();

        EpochRangeFactory = epochRangeFactory ?? new EpochRangeFactory();
        EpochCollectionFactory = epochCollectionFactory ?? new EpochCollectionFactory();
    }

    IEpochStage IEpochStageFactory.Create(ITarget target, IOrigin origin)
    {
        ArgumentNullException.ThrowIfNull(target);
        ArgumentNullException.ThrowIfNull(origin);

        return new EpochStage(target, origin, TableContentValidator, EpochRangeFactory, EpochCollectionFactory);
    }
}
