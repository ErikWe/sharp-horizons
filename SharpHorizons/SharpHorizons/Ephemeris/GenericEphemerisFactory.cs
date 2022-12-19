namespace SharpHorizons.Ephemeris;

using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>Handles construction of <see cref="IEphemeris{TEntry}"/>.</summary>
internal static class GenericEphemerisFactory
{
    /// <summary>Constucts a <see cref="IEphemeris{TEntry}"/> representing <paramref name="entries"/>, which are already ordered by <see cref="IEpoch"/>.</summary>
    /// <param name="entries">The <typeparamref name="TEntry"/> of the <see cref="IEphemeris{TEntry}"/>, ordered by <see cref="IEpoch"/>.</param>
    public static IEphemeris<TEntry> FromOrdered<TEntry>(IReadOnlyList<TEntry> entries) where TEntry : IEphemerisEntry => new EphemerisImplementation<TEntry>(entries);

    /// <summary>Constucts a <see cref="IEphemeris{TEntry}"/> representing <paramref name="entries"/>.</summary>
    /// <param name="entries">The <typeparamref name="TEntry"/> of the <see cref="IEphemeris{TEntry}"/>.</param>
    public static IEphemeris<TEntry> FromUnordered<TEntry>(IReadOnlyList<TEntry> entries) where TEntry : IEphemerisEntry => FromOrdered(entries.OrderBy(static (entry) => entry.Epoch.ToJulianDay().Day).ToList());

    /// <summary>Represents an <see cref="IEphemeris{TEntry}"/> with <see cref="IEphemerisEntry"/> of type <typeparamref name="TEntry"/>.</summary>
    /// <typeparam name="TEntry">The type of the <see cref="IEphemerisEntry"/> of the <see cref="IEphemeris{TEntry}"/>.</typeparam>
    private sealed record class EphemerisImplementation<TEntry> : IEphemeris<TEntry> where TEntry : IEphemerisEntry
    {
        /// <summary>The <typeparamref name="TEntry"/> of the <see cref="IEphemeris{TEntry}"/>, ordered by <see cref="IEpoch"/>.</summary>
        private IReadOnlyList<TEntry> Ephemeris { get; }

        /// <inheritdoc cref="EphemerisImplementation{TEntry}"/>
        /// <param name="ephemeris"><inheritdoc cref="Ephemeris" path="/summary"/></param>
        public EphemerisImplementation(IReadOnlyList<TEntry> ephemeris)
        {
            Ephemeris = ephemeris;
        }

        TEntry IReadOnlyList<TEntry>.this[int index] => Ephemeris[index];
        int IReadOnlyCollection<TEntry>.Count => Ephemeris.Count;
        IEnumerator<TEntry> IEnumerable<TEntry>.GetEnumerator() => Ephemeris.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => Ephemeris.GetEnumerator();
    }
}
