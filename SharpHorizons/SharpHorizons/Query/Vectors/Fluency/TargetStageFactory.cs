namespace SharpHorizons.Query.Vectors.Fluency;

using SharpHorizons.Query.Target;

/// <inheritdoc cref="ITargetStageFactory"/>
internal sealed class TargetStageFactory : ITargetStageFactory
{
    /// <summary><inheritdoc cref="ITargetFactory" path="/summary"/></summary>
    private ITargetFactory TargetFactory { get; }

    /// <summary><inheritdoc cref="IOriginStageFactory" path="/summary"/></summary>
    private IOriginStageFactory OriginStageFactory { get; }

    /// <summary><inheritdoc cref="TargetStageFactory" path="/summary"/></summary>
    /// <param name="targetFactory"><inheritdoc cref="TargetFactory" path="/summary"/></param>
    /// <param name="originStageFactory"><inheritdoc cref="OriginStageFactory" path="/summary"/></param>
    public TargetStageFactory(ITargetFactory? targetFactory = null, IOriginStageFactory? originStageFactory = null)
    {
        TargetFactory = targetFactory ?? new TargetFactory();
        OriginStageFactory = originStageFactory ?? new OriginStageFactory();
    }

    ITargetStage ITargetStageFactory.Create() => new TargetStage(TargetFactory, OriginStageFactory);
}
