namespace SharpHorizons.Query.Epoch;

using System;
using System.Collections.Generic;

/// <summary>Uses a collection of individual <see cref="IEpoch"/> to describe the <see cref="IEpochSelection"/> in a query.</summary>
public interface IEpochCollection : IEnumerable<IEpoch>, IEpochSelection
{
    /// <summary>The selected <see cref="IEpoch"/>.</summary>
    public abstract IEnumerable<IEpoch> Epochs { get; }

    /// <summary>Constructs a new <see cref="IEpochCollection"/>, with <paramref name="epochs"/> added to the collection.</summary>
    /// <param name="epochs">These <see cref="IEpoch"/> are added to the <see cref="IEpochCollection"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    public abstract IEpochCollection Concat(IEnumerable<IEpoch> epochs);
}
