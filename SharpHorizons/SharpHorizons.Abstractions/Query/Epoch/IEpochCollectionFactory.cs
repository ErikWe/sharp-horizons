namespace SharpHorizons.Query.Epoch;

using System;
using System.Collections.Generic;
using System.ComponentModel;

/// <summary>Handles construction of <see cref="IEpochCollection"/>.</summary>
public interface IEpochCollectionFactory
{
    /// <summary>Constructs a <see cref="IEpochCollection"/> containing <paramref name="epochs"/>, formatted according to <paramref name="format"/>.</summary>
    /// <param name="epochs"><inheritdoc cref="IEpochCollection.Epochs" path="/summary"/></param>
    /// <param name="format"><inheritdoc cref="IEpochSelection.Format" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract IEpochCollection Create(IEnumerable<IEpoch> epochs, EpochFormat format);

    /// <summary>Constructs a <see cref="IEpochCollection"/> containing <paramref name="epochs"/>.</summary>
    /// <param name="epochs"><inheritdoc cref="IEpochCollection.Epochs" path="/summary"/></param>
    /// <exception cref="ArgumentNullException"/>
    public abstract IEpochCollection Create(IEnumerable<IEpoch> epochs);

    /// <summary>Constructs a <see cref="IEpochCollection"/> containing <paramref name="epochs"/>, formatted according to <paramref name="format"/>.</summary>
    /// <param name="format"><inheritdoc cref="IEpochSelection.Format" path="/summary"/></param>
    /// <param name="epochs"><inheritdoc cref="IEpochCollection.Epochs" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract IEpochCollection Create(EpochFormat format, params IEpoch[] epochs);

    /// <summary>Constructs a <see cref="IEpochCollection"/> containing <paramref name="epochs"/>.</summary>
    /// <param name="epochs"><inheritdoc cref="IEpochCollection.Epochs" path="/summary"/></param>
    /// <exception cref="ArgumentNullException"/>
    public abstract IEpochCollection Create(params IEpoch[] epochs);
}
