namespace SharpHorizons.Query.Vectors.Fluency;

using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;

using System;

/// <inheritdoc cref="IEpochStage"/>
internal sealed class EpochStage : IEpochStage
{
    /// <summary>The <see cref="ITarget"/> selected for the <see cref="IVectorsQuery"/>.</summary>
    private ITarget Target { get; }

    /// <summary>The <see cref="IOrigin"/> selected for the <see cref="IVectorsQuery"/>.</summary>
    private IOrigin Origin { get; }

    /// <inheritdoc cref="IVectorsQueryValidator"/>
    private IVectorsQueryValidator VectorsQueryValidator { get; }

    /// <inheritdoc cref="IEpochRangeFactory"/>
    private IEpochRangeFactory EpochRangeFactory { get; }

    /// <inheritdoc cref="IEpochCollectionFactory"/>
    private IEpochCollectionFactory EpochCollectionFactory { get; }

    /// <inheritdoc cref="EpochStage"/>
    /// <param name="target"><inheritdoc cref="Target" path="/summary"/></param>
    /// <param name="origin"><inheritdoc cref="Origin" path="/summary"/></param>
    /// <param name="vectorsQueryValidator"><inheritdoc cref="VectorsQueryValidator" path="/summary"/></param>
    /// <param name="epochRangeFactory"><inheritdoc cref="EpochRangeFactory" path="/summary"/></param>
    /// <param name="epochCollectionFactory"><inheritdoc cref="EpochCollectionFactory" path="/summary"/></param>
    public EpochStage(ITarget target, IOrigin origin, IVectorsQueryValidator vectorsQueryValidator, IEpochRangeFactory epochRangeFactory, IEpochCollectionFactory epochCollectionFactory)
    {
        Target = target;
        Origin = origin;

        VectorsQueryValidator = vectorsQueryValidator;

        EpochRangeFactory = epochRangeFactory;

        EpochCollectionFactory = epochCollectionFactory;
    }

    IVectorsQueryBuilder IEpochStage.WithEpochSelection(IEpochSelection epochSelection)
    {
        ArgumentNullException.ThrowIfNull(epochSelection);

        return CreateVectorsQueryBuilder(epochSelection);
    }

    IVectorsQueryBuilder IEpochStage.WithEpochRange(IEpochStage.DEpochRangeFactory epochRangeFactoryDelegate)
    {
        ArgumentNullException.ThrowIfNull(epochRangeFactoryDelegate);

        var epochSelection = InvokeEpochRangeFactoryDelegate(epochRangeFactoryDelegate);

        try
        {
            return CreateVectorsQueryBuilder(epochSelection);
        }
        catch (ArgumentNullException e)
        {
            throw new ArgumentException($"The {nameof(IEpochStage.DEpochRangeFactory)} produced a null {nameof(IEpochSelection)}.", nameof(epochRangeFactoryDelegate), e);
        }
    }

    IVectorsQueryBuilder IEpochStage.WithEpochCollection(IEpochStage.DEpochCollectionFactory epochCollectionFactoryDelegate)
    {
        ArgumentNullException.ThrowIfNull(epochCollectionFactoryDelegate);

        var epochSelection = InvokeEpochCollectionFactoryDelegate(epochCollectionFactoryDelegate);

        try
        {
            return CreateVectorsQueryBuilder(epochSelection);
        }
        catch (ArgumentNullException e)
        {
            throw new ArgumentException($"The {nameof(IEpochStage.DEpochCollectionFactory)} produced a null {nameof(IEpochSelection)}.", nameof(epochCollectionFactoryDelegate), e);
        }
    }

    /// <summary>Invokes the <see cref="IEpochStage.DEpochRangeFactory"/> <paramref name="epochCollectionFactoryDelegate"/>, resulting in an <see cref="IEpochSelection"/>.</summary>
    /// <param name="epochCollectionFactoryDelegate">This <see cref="IEpochStage.DEpochRangeFactory"/> is invoked.</param>
    /// <exception cref="ArgumentException"/>
    private IEpochSelection InvokeEpochRangeFactoryDelegate(IEpochStage.DEpochRangeFactory epochCollectionFactoryDelegate)
    {
        try
        {
            return epochCollectionFactoryDelegate(EpochRangeFactory);
        }
        catch (Exception e)
        {
            throw new ArgumentException($"The {nameof(IEpochStage.DEpochRangeFactory)} encountered an error while producing an {nameof(IEpochSelection)}.", nameof(epochCollectionFactoryDelegate), e);
        }
    }

    /// <summary>Invokes the <see cref="IEpochStage.DEpochCollectionFactory"/> <paramref name="epochCollectionFactoryDelegate"/>, resulting in an <see cref="IEpochSelection"/>.</summary>
    /// <param name="epochCollectionFactoryDelegate">This <see cref="IEpochStage.DEpochCollectionFactory"/> is invoked.</param>
    /// <exception cref="ArgumentException"/>
    private IEpochSelection InvokeEpochCollectionFactoryDelegate(IEpochStage.DEpochCollectionFactory epochCollectionFactoryDelegate)
    {
        try
        {
            return epochCollectionFactoryDelegate(EpochCollectionFactory);
        }
        catch (Exception e)
        {
            throw new ArgumentException($"The {nameof(IEpochStage.DEpochCollectionFactory)} encountered an error while producing an {nameof(IEpochSelection)}.", nameof(epochCollectionFactoryDelegate), e);
        }
    }

    /// <summary>Uses <paramref name="epochSelection"/> as the <see cref="IEpochSelection"/> in the <see cref="IVectorsQuery"/>, and constructs the <see cref="IVectorsQuery"/>.</summary>
    /// <param name="epochSelection">The <see cref="IEpochSelection"/> in the <see cref="IVectorsQuery"/>.</param>
    private IVectorsQueryBuilder CreateVectorsQueryBuilder(IEpochSelection epochSelection) => new VectorsQueryBuilder(VectorsQueryValidator, Target, Origin, epochSelection);
}
