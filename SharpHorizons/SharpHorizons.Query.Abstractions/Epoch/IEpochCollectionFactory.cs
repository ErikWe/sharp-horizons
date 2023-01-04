namespace SharpHorizons.Query.Epoch;

using System;
using System.Collections.Generic;

/// <summary>Handles construction of <see cref="IEpochCollection"/>.</summary>
public interface IEpochCollectionFactory
{
    /// <summary>Constructs a <see cref="IEpochCollection"/> containing <paramref name="epochs"/>.</summary>
    /// <param name="epochs"><inheritdoc cref="IEpochCollection.Epochs" path="/summary"/></param>
    /// <exception cref="ArgumentNullException"/>
    public abstract IEpochCollection Create(IEnumerable<IEpoch> epochs);

    /// <summary>Constructs a <see cref="IEpochCollection"/> containing <paramref name="epochs"/>.</summary>
    /// <param name="epochs"><inheritdoc cref="IEpochCollection.Epochs" path="/summary"/></param>
    /// <exception cref="ArgumentNullException"/>
    public abstract IEpochCollection Create(params IEpoch[] epochs);
}
