namespace SharpHorizons.Query.Vectors.Fluency;

using SharpHorizons.Query.Target;

using System;

/// <inheritdoc cref="ITargetStage"/>
internal sealed class TargetStage : ITargetStage
{
    /// <inheritdoc cref="ITargetFactory"/>
    private ITargetFactory TargetFactory { get; }

    /// <inheritdoc cref="IOriginStageFactory"/>
    private IOriginStageFactory OriginStageFactory { get; }

    /// <inheritdoc cref="TargetStage"/>
    /// <param name="targetFactory"><inheritdoc cref="TargetFactory" path="/summary"/></param>
    /// <param name="originStageFactory"><inheritdoc cref="OriginStageFactory" path="/summary"/></param>
    public TargetStage(ITargetFactory targetFactory, IOriginStageFactory originStageFactory)
    {
        TargetFactory = targetFactory;
        OriginStageFactory = originStageFactory;
    }

    IOriginStage ITargetStage.WithTarget(ITarget target)
    {
        ArgumentNullException.ThrowIfNull(target);

        return CreateOriginStage(target);
    }

    IOriginStage ITargetStage.WithTarget(ITargetStage.DTargetFactory targetFactoryDelegate)
    {
        ArgumentNullException.ThrowIfNull(targetFactoryDelegate);

        var target = InvokeTargetFactoryDelegate(targetFactoryDelegate);

        try
        {
            return CreateOriginStage(target);
        }
        catch (ArgumentNullException e)
        {
            throw new ArgumentException($"The provided {nameof(ITargetStage.DTargetFactory)} produced a null {nameof(ITarget)}.", nameof(targetFactoryDelegate), e);
        }
    }

    /// <summary>Invokes the <see cref="ITargetStage.DTargetFactory"/> <paramref name="targetFactoryDelegate"/>, resulting in a <see cref="ITarget"/>.</summary>
    /// <param name="targetFactoryDelegate">This <see cref="ITargetStage.DTargetFactory"/> is invoked.</param>
    /// <exception cref="ArgumentException"/>
    private ITarget InvokeTargetFactoryDelegate(ITargetStage.DTargetFactory targetFactoryDelegate)
    {
        try
        {
            return targetFactoryDelegate(TargetFactory);
        }
        catch (InvalidOperationException e)
        {
            throw new ArgumentException($"The provided {nameof(ITargetStage.DTargetFactory)} encountered an error while producing a {nameof(ITarget)}.", nameof(targetFactoryDelegate), e);
        }
    }

    /// <summary>Selects <paramref name="target"/> as the <see cref="ITarget"/> in the <see cref="IVectorsQuery"/>, and proceeds to the <see cref="IOriginStage"/>.</summary>
    /// <param name="target">The <see cref="ITarget"/> in the <see cref="IVectorsQuery"/>.</param>
    private IOriginStage CreateOriginStage(ITarget target) => OriginStageFactory.Create(target);
}
