namespace SharpHorizons.Ephemeris;

using SharpHorizons.Epoch;

using System;
using System.Collections.Generic;

/// <summary>Represents an ephemeris of an object, with each <see cref="IEphemerisEntry"/> described as an instance of <typeparamref name="TEntry"/>.</summary>
/// <typeparam name="TEntry">Describes properties of an object at some <see cref="IEpoch"/>.</typeparam>
public interface IEphemeris<TEntry> : IReadOnlyList<TEntry> where TEntry : IEphemerisEntry
{
    /// <summary>The <see cref="IEphemerisEntry"/> of the <see cref="IEphemeris{TEntry}"/>.</summary>
    protected abstract IReadOnlyList<TEntry> Entries { get; }

    /// <summary>Retrieves the <typeparamref name="TEntry"/> that describes the <see cref="IEpoch"/> closest to <paramref name="epoch"/>.</summary>
    /// <param name="epoch">The <typeparamref name="TEntry"/> that describes the <see cref="IEpoch"/> closest to this <see cref="IEpoch"/> is retrieved.</param>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="EmptyEphemerisException"/>
    public virtual TEntry GetClosest(IEpoch epoch)
    {
        ArgumentNullException.ThrowIfNull(epoch);

        return EphemerisSearch.GetClosest(Entries, epoch);
    }

    /// <summary>Retrieves the <typeparamref name="TEntry"/> that describes the <see cref="IEpoch"/> closest to, but before, <paramref name="epoch"/>.</summary>
    /// <param name="epoch">The <typeparamref name="TEntry"/> that describes the <see cref="IEpoch"/> closest to, but before, this <see cref="IEpoch"/> is retrieved.</param>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="EmptyEphemerisException"/>
    /// <exception cref="UnboundedEphemerisEntryException"/>
    public virtual TEntry GetClosestBefore(IEpoch epoch)
    {
        ArgumentNullException.ThrowIfNull(epoch);

        return EphemerisSearch.GetClosestBefore(Entries, epoch);
    }

    /// <summary>Retrieves the <typeparamref name="TEntry"/> that describes the <see cref="IEpoch"/> closest to, but after, <paramref name="epoch"/>.</summary>
    /// <param name="epoch">The <typeparamref name="TEntry"/> that describes the <see cref="IEpoch"/> closest to, but after, this <see cref="IEpoch"/> is retrieved.</param>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="EmptyEphemerisException"/>
    /// <exception cref="UnboundedEphemerisEntryException"/>
    public virtual TEntry GetClosestAfter(IEpoch epoch)
    {
        ArgumentNullException.ThrowIfNull(epoch);

        return EphemerisSearch.GetClosestAfter(Entries, epoch);
    }
}
