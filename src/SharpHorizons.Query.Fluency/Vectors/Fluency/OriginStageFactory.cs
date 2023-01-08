namespace SharpHorizons.Query.Vectors.Fluency;

using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;

using System;

/// <inheritdoc cref="IOriginStageFactory"/>
internal sealed class OriginStageFactory : IOriginStageFactory
{
    /// <inheritdoc cref="ITargetFactory"/>
    private IOriginFactory OriginFactory { get; }

    /// <inheritdoc cref="IEpochStageFactory"/>
    private IEpochStageFactory EpochStageFactory { get; }

    /// <inheritdoc cref="OriginStageFactory"/>
    /// <param name="originFactory"><inheritdoc cref="OriginFactory" path="/summary"/></param>
    /// <param name="epochStageFactory"><inheritdoc cref="EpochStageFactory" path="/summary"/></param>
    public OriginStageFactory(IOriginFactory? originFactory = null, IEpochStageFactory? epochStageFactory = null)
    {
        OriginFactory = originFactory ?? new OriginFactory();
        EpochStageFactory = epochStageFactory ?? new EpochStageFactory();
    }

    IOriginStage IOriginStageFactory.Create(ITarget target)
    {
        ArgumentNullException.ThrowIfNull(target);

        return new OriginStage(target, OriginFactory, EpochStageFactory);
    }
}
