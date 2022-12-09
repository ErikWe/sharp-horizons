namespace SharpHorizons.Query.Vectors.Fluency;

using SharpHorizons.Query.Target;

/// <inheritdoc cref="ITargetStageFactory"/>
internal sealed class TargetStageFactory : ITargetStageFactory
{
    /// <inheritdoc cref="ITargetFactory"/>
    private ITargetFactory TargetFactory { get; }

    /// <inheritdoc cref="IOriginStageFactory"/>
    private IOriginStageFactory OriginStageFactory { get; }

    /// <inheritdoc cref="TargetStageFactory"/>
    /// <param name="targetFactory"><inheritdoc cref="TargetFactory" path="/summary"/></param>
    /// <param name="originStageFactory"><inheritdoc cref="OriginStageFactory" path="/summary"/></param>
    public TargetStageFactory(ITargetFactory? targetFactory = null, IOriginStageFactory? originStageFactory = null)
    {
        TargetFactory = targetFactory ?? new TargetFactory();
        OriginStageFactory = originStageFactory ?? new OriginStageFactory();
    }

    ITargetStage ITargetStageFactory.Create() => new TargetStage(TargetFactory, OriginStageFactory);
}
