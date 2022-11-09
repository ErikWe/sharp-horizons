namespace SharpHorizons.Query.Vectors.Fluency;

using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;

/// <inheritdoc cref="IOriginStageFactory"/>
internal sealed class OriginStageFactory : IOriginStageFactory
{
    /// <summary><inheritdoc cref="ITargetFactory" path="/summary"/></summary>
    private IOriginFactory OriginFactory { get; }

    /// <summary><inheritdoc cref="IEpochStageFactory" path="/summary"/></summary>
    private IEpochStageFactory EpochStageFactory { get; }

    /// <summary><inheritdoc cref="TargetStageFactory" path="/summary"/></summary>
    /// <param name="originFactory"><inheritdoc cref="OriginFactory" path="/summary"/></param>
    /// <param name="epochStageFactory"><inheritdoc cref="EpochStageFactory" path="/summary"/></param>
    public OriginStageFactory(IOriginFactory? originFactory = null, IEpochStageFactory? epochStageFactory = null)
    {
        OriginFactory = originFactory ?? new OriginFactory();
        EpochStageFactory = epochStageFactory ?? new EpochStageFactory();
    }

    IOriginStage IOriginStageFactory.Create(ITarget target) => new OriginStage(target, OriginFactory, EpochStageFactory);
}
