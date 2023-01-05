namespace SharpHorizons.Query.Vectors.Fluency;

using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;

using System;

/// <inheritdoc cref="IOriginStage"/>
internal sealed class OriginStage : IOriginStage
{
    /// <summary>The <see cref="ITarget"/> selected for the <see cref="IVectorsQuery"/>.</summary>
    private ITarget Target { get; }

    /// <inheritdoc cref="IOriginFactory"/>
    private IOriginFactory OriginFactory { get; }

    /// <inheritdoc cref="IEpochStageFactory"/>
    private IEpochStageFactory EpochStageFactory { get; }

    /// <inheritdoc cref="OriginStage"/>
    /// <param name="target"><inheritdoc cref="Target" path="/summary"/></param>
    /// <param name="originFactory"><inheritdoc cref="OriginFactory" path="/summary"/></param>
    /// <param name="epochStageFactory"><inheritdoc cref="EpochStageFactory" path="/summary"/></param>
    public OriginStage(ITarget target, IOriginFactory originFactory, IEpochStageFactory epochStageFactory)
    {
        Target = target;

        OriginFactory = originFactory;
        EpochStageFactory = epochStageFactory;
    }

    IEpochStage IOriginStage.WithOrigin(IOrigin origin)
    {
        ArgumentNullException.ThrowIfNull(origin);

        return CreateEpochStage(origin);
    }

    IEpochStage IOriginStage.WithOrigin(IOriginStage.DOriginFactory originFactoryDelegate)
    {
        ArgumentNullException.ThrowIfNull(originFactoryDelegate);

        var origin = InvokeOriginFactoryDelegate(originFactoryDelegate);

        try
        {
            return CreateEpochStage(origin);
        }
        catch (ArgumentNullException e)
        {
            throw new ArgumentException($"The {nameof(IOriginStage.DOriginFactory)} produced a null {nameof(IOrigin)}.", nameof(originFactoryDelegate), e);
        }
    }

    /// <summary>Invokes the <see cref="IOriginStage.DOriginFactory"/> <paramref name="originFactoryDelegate"/>, resulting in an <see cref="IOrigin"/>.</summary>
    /// <param name="originFactoryDelegate">This <see cref="IOriginStage.DOriginFactory"/> is invoked.</param>
    /// <exception cref="ArgumentException"/>
    private IOrigin InvokeOriginFactoryDelegate(IOriginStage.DOriginFactory originFactoryDelegate)
    {
        try
        {
            return originFactoryDelegate(OriginFactory);
        }
        catch (Exception e)
        {
            throw new ArgumentException($"The {nameof(IOriginStage.DOriginFactory)} encountered an error while producing an {nameof(IOrigin)}.", nameof(originFactoryDelegate), e);
        }
    }

    /// <summary>Selects <paramref name="origin"/> as the <see cref="IOrigin"/> in the <see cref="IVectorsQuery"/>, and proceeds to the <see cref="IEpochStage"/>.</summary>
    /// <param name="origin">The <see cref="IOrigin"/> in the <see cref="IVectorsQuery"/>.</param>
    private IEpochStage CreateEpochStage(IOrigin origin) => EpochStageFactory.Create(Target, origin);
}
