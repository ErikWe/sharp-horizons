namespace SharpHorizons.Ephemeris;

using System;
using System.Collections.Generic;

/// <summary>Represents an ephemeris of an object, with each <see cref="IEphemerisEntry"/> described as an instance of <typeparamref name="TEntry"/>. This is a list of <typeparamref name="TEntry"/>, ordered by their <see cref="IEphemerisEntry.Epoch"/> (earliest first).</summary>
/// <typeparam name="TEntry">The <see cref="IEphemeris{TEntry}"/> uses instances of this type to describe the properties of an object at different <see cref="IEpoch"/>.</typeparam>
public interface IEphemeris<TEntry> : IReadOnlyList<TEntry> where TEntry : IEphemerisEntry
{
    /// <summary>Retrieves the <typeparamref name="TEntry"/> that describes the <see cref="IEpoch"/> closest to <paramref name="epoch"/>.</summary>
    /// <param name="epoch">The <typeparamref name="TEntry"/> that describes the <see cref="IEpoch"/> closest to this <see cref="IEpoch"/> is retrieved.</param>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="EmptyEphemerisSearchException"/>
    public virtual TEntry GetClosest(IEpoch epoch)
    {
        ArgumentNullException.ThrowIfNull(epoch);

        return EphemerisSearch.GetClosest(this, epoch);
    }

    /// <summary>Retrieves the <typeparamref name="TEntry"/> that describes the <see cref="IEpoch"/> closest to, but before, <paramref name="epoch"/>.</summary>
    /// <param name="epoch">The <typeparamref name="TEntry"/> that describes the <see cref="IEpoch"/> closest to, but before, this <see cref="IEpoch"/> is retrieved.</param>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="EmptyEphemerisSearchException"/>
    /// <exception cref="UnboundedEphemerisSearchException"/>
    public virtual TEntry GetClosestBefore(IEpoch epoch)
    {
        ArgumentNullException.ThrowIfNull(epoch);

        return EphemerisSearch.GetClosestBefore(this, epoch);
    }

    /// <summary>Retrieves the <typeparamref name="TEntry"/> that describes the <see cref="IEpoch"/> closest to, but after, <paramref name="epoch"/>.</summary>
    /// <param name="epoch">The <typeparamref name="TEntry"/> that describes the <see cref="IEpoch"/> closest to, but after, this <see cref="IEpoch"/> is retrieved.</param>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="EmptyEphemerisSearchException"/>
    /// <exception cref="UnboundedEphemerisSearchException"/>
    public virtual TEntry GetClosestAfter(IEpoch epoch)
    {
        ArgumentNullException.ThrowIfNull(epoch);

        return EphemerisSearch.GetClosestAfter(this, epoch);
    }
}
