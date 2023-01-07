namespace SharpHorizons.Query.Vectors.Fluency;

using SharpHorizons.Query.Epoch;

using System;

/// <summary>Provides means of selecting the <see cref="IEpoch"/> of a <see cref="IVectorsQuery"/>.</summary>
public interface IEpochStage
{
    /// <summary>Uses a <see cref="IEpochRangeFactory"/> to produce the <see cref="IEpochSelection"/> in the <see cref="IVectorsQuery"/>.</summary>
    /// <param name="epochRangeFactory">This <see cref="IEpochRangeFactory"/> is used to produce the <see cref="IEpochSelection"/> in the <see cref="IVectorsQuery"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public delegate IEpochRange DEpochRangeFactory(IEpochRangeFactory epochRangeFactory);

    /// <summary>Uses a <see cref="IEpochCollectionFactory"/> to produce the <see cref="IEpochSelection"/> in the <see cref="IVectorsQuery"/>.</summary>
    /// <param name="epochCollectionFactory">This <see cref="IEpochCollectionFactory"/> is used to produce the <see cref="IEpochSelection"/> in the <see cref="IVectorsQuery"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public delegate IEpochCollection DEpochCollectionFactory(IEpochCollectionFactory epochCollectionFactory);

    /// <summary>Uses <paramref name="epochSelection"/> as the <see cref="IEpochSelection"/> in the <see cref="IVectorsQuery"/>.</summary>
    /// <param name="epochSelection">The <see cref="IEpochSelection"/> in the <see cref="IVectorsQuery"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    public abstract IVectorsQueryBuilder WithEpochSelection(IEpochSelection epochSelection);

    /// <summary>Uses <paramref name="epochRange"/> as the <see cref="IEpochSelection"/> in the <see cref="IVectorsQuery"/>.</summary>
    /// <param name="epochRange">This <see cref="IEpochRange"/> is used as the <see cref="IEpochSelection"/> in the <see cref="IVectorsQuery"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    public virtual IVectorsQueryBuilder WithEpochRange(IEpochRange epochRange) => WithEpochSelection(epochRange);

    /// <summary>Delegates the production of an <see cref="IEpochSelection"/> to an <see cref="IEpochRangeFactory"/>, and constructs the <see cref="IVectorsQuery"/>.</summary>
    /// <param name="epochRangeFactoryDelegate"><inheritdoc cref="DEpochRangeFactory" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract IVectorsQueryBuilder WithEpochRange(DEpochRangeFactory epochRangeFactoryDelegate);

    /// <summary>Uses <paramref name="epochCollection"/> as the <see cref="IEpochSelection"/> in the <see cref="IVectorsQuery"/>.</summary>
    /// <param name="epochCollection">This <see cref="IEpochCollection"/> is used as the <see cref="IEpochSelection"/> in the <see cref="IVectorsQuery"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    public virtual IVectorsQueryBuilder WithEpochCollection(IEpochCollection epochCollection) => WithEpochSelection(epochCollection);

    /// <summary>Delegates the production of an <see cref="IEpochSelection"/> to an <see cref="IEpochCollectionFactory"/>, and constructs the <see cref="IVectorsQuery"/>.</summary>
    /// <param name="epochCollectionFactoryDelegate"><inheritdoc cref="DEpochCollectionFactory" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract IVectorsQueryBuilder WithEpochCollection(DEpochCollectionFactory epochCollectionFactoryDelegate);
}
