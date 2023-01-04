namespace SharpHorizons.Query.Vectors.Fluency;

using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.Vectors.Table;

using System;
using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IEpochStage"/>
internal sealed class EpochStage : IEpochStage
{
    /// <summary>The <see cref="ITarget"/> selected for the <see cref="IVectorsQuery"/>.</summary>
    public required ITarget Target { private get; init; }

    /// <summary>The <see cref="IOrigin"/> selected for the <see cref="IVectorsQuery"/>.</summary>
    public required IOrigin Origin { private get; init; }

    /// <inheritdoc cref="IVectorTableContentValidator"/>
    public required IVectorTableContentValidator TableContentValidator { private get; init; }

    /// <inheritdoc cref="IEpochRangeFactory"/>
    public required IEpochRangeFactory EpochRangeFactory { private get; init; }

    /// <inheritdoc cref="IEpochCollectionFactory"/>
    public required IEpochCollectionFactory EpochCollectionFactory { private get; init; }

    /// <inheritdoc cref="EpochStage"/>
    public EpochStage() { }

    /// <inheritdoc cref="EpochStage"/>
    /// <param name="target"><inheritdoc cref="Target" path="/summary"/></param>
    /// <param name="origin"><inheritdoc cref="Origin" path="/summary"/></param>
    /// <param name="tableContentValidator"><inheritdoc cref="TableContentValidator" path="/summary"/></param>
    /// <param name="epochRangeFactory"><inheritdoc cref="EpochRangeFactory" path="/summary"/></param>
    /// <param name="epochCollectionFactory"><inheritdoc cref="EpochCollectionFactory" path="/summary"/></param>
    [SetsRequiredMembers]
    public EpochStage(ITarget target, IOrigin origin, IVectorTableContentValidator tableContentValidator, IEpochRangeFactory epochRangeFactory, IEpochCollectionFactory epochCollectionFactory)
    {
        Target = target;
        Origin = origin;

        TableContentValidator = tableContentValidator;

        EpochRangeFactory = epochRangeFactory;

        EpochCollectionFactory = epochCollectionFactory;
    }

    IVectorsQuery IEpochStage.WithEpochSelection(IEpochSelection epochSelection)
    {
        ArgumentNullException.ThrowIfNull(epochSelection);

        return CreateVectorsQuery(epochSelection);
    }

    IVectorsQuery IEpochStage.WithEpochRange(IEpochStage.DEpochRangeFactory epochRangeFactoryDelegate)
    {
        ArgumentNullException.ThrowIfNull(epochRangeFactoryDelegate);

        var epochSelection = InvokeEpochRangeFactoryDelegate(epochRangeFactoryDelegate);

        try
        {
            return CreateVectorsQuery(epochSelection);
        }
        catch (ArgumentNullException e)
        {
            throw new ArgumentException($"The {nameof(IEpochStage.DEpochRangeFactory)} produced a null {nameof(IEpochSelection)}.", nameof(epochRangeFactoryDelegate), e);
        }
    }

    IVectorsQuery IEpochStage.WithEpochCollection(IEpochStage.DEpochCollectionFactory epochCollectionFactoryDelegate)
    {
        ArgumentNullException.ThrowIfNull(epochCollectionFactoryDelegate);

        var epochSelection = InvokeEpochCollectionFactoryDelegate(epochCollectionFactoryDelegate);

        try
        {
            return CreateVectorsQuery(epochSelection);
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
    private IVectorsQuery CreateVectorsQuery(IEpochSelection epochSelection) => new VectorsQuery(TableContentValidator, Target, Origin, epochSelection);
}
