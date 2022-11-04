namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Calendars;

using System;
using System.Collections.Generic;

/// <summary>Handles construction of <see cref="IEpochCollection"/>.</summary>
public interface IEpochCollectionFactory
{
    /// <summary>Constructs a <see cref="IEpochCollection"/> containing <paramref name="epochs"/>, formatted according to <paramref name="format"/>.</summary>
    /// <param name="epochs"><inheritdoc cref="IEpochCollection.Epochs" path="/summary"/></param>
    /// <param name="format"><inheritdoc cref="IEpochCollection.Format" path="/summary"/></param>
    /// <exception cref="ArgumentNullException"/>
    public abstract IEpochCollection Create(IEnumerable<IEpoch> epochs, EpochCollectionFormat format);

    /// <summary>Constructs a <see cref="IEpochCollection"/> containing <paramref name="epochs"/>.</summary>
    /// <param name="epochs"><inheritdoc cref="IEpochCollection.Epochs" path="/summary"/></param>
    /// <exception cref="ArgumentNullException"/>
    public abstract IEpochCollection Create(IEnumerable<IEpoch> epochs);

    /// <summary>Constructs a <see cref="IEpochCollection"/> containing <paramref name="epochs"/>, formatted according to <paramref name="format"/>.</summary>
    /// <param name="format"><inheritdoc cref="IEpochCollection.Format" path="/summary"/></param>
    /// <param name="epochs"><inheritdoc cref="IEpochCollection.Epochs" path="/summary"/></param>
    /// <exception cref="ArgumentNullException"/>
    public abstract IEpochCollection Create(EpochCollectionFormat format, params IEpoch[] epochs);

    /// <summary>Constructs a <see cref="IEpochCollection"/> containing <paramref name="epochs"/>.</summary>
    /// <param name="epochs"><inheritdoc cref="IEpochCollection.Epochs" path="/summary"/></param>
    /// <exception cref="ArgumentNullException"/>
    public abstract IEpochCollection Create(params IEpoch[] epochs);

    /// <summary>Constructs an empty <see cref="IEpochCollection"/>.</summary>
    /// <param name="format"><inheritdoc cref="IEpochCollection.Format" path="/summary"/></param>
    public abstract IEpochCollection Create(EpochCollectionFormat format);

    /// <summary>Constructs an empty <see cref="IEpochCollection"/>.</summary>
    public abstract IEpochCollection Create();
}
