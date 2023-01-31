namespace SharpHorizons.Query.Epoch;

using System.Collections.Generic;

/// <summary>Uses a collection of individual <see cref="IEpoch"/> to describe the <see cref="IEpochSelection"/> in a query.</summary>
public interface IEpochCollection : IEnumerable<IEpoch>, IEpochSelection
{
    /// <summary>The selected <see cref="IEpoch"/>.</summary>
    public abstract IEnumerable<IEpoch> Epochs { get; }
}
