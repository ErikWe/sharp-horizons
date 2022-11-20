namespace SharpHorizons.Ephemeris;

using SharpHorizons.Epoch;

using System.Collections.Generic;
using System.ComponentModel;

internal static class EphemerisSearch
{
    /// <summary>Retrieves the <typeparamref name="TEntry"/> that describes the <see cref="IEpoch"/> closest to <paramref name="epoch"/>.</summary>
    /// <typeparam name="TEntry">The type of the <see cref="IEphemerisEntry"/> of <paramref name="entries"/>.</typeparam>
    /// <param name="entries">The ordered list of <typeparamref name="TEntry"/>.</param>
    /// <param name="epoch">The <typeparamref name="TEntry"/> that describes the <see cref="IEpoch"/> closest to this <see cref="IEpoch"/> is retrieved.</param>
    /// <exception cref="EmptyEphemerisException"/>
    public static TEntry GetClosest<TEntry>(IReadOnlyList<TEntry> entries, IEpoch epoch) where TEntry : IEphemerisEntry
    {
        if (entries.Count is 0)
        {
            throw new EmptyEphemerisException();
        }

        var target = epoch.ToJulianDay();

        var predecessor = BinarySearchPredecessor(entries, target);

        if (predecessor is -1)
        {
            return entries[0];
        }

        var successor = BinarySearchSuccessor(entries, target);

        if (successor == entries.Count)
        {
            return entries[^1];
        }

        var differenceBefore = target - entries[predecessor].Epoch.ToJulianDay();
        var differenceAfter = entries[successor].Epoch.ToJulianDay() - target;

        if (differenceBefore < differenceAfter)
        {
            return entries[predecessor];
        }

        return entries[successor];
    }

    /// <summary>Retrieves the <typeparamref name="TEntry"/> that describes the <see cref="IEpoch"/> closest to, but before, <paramref name="epoch"/>.</summary>
    /// <typeparam name="TEntry">The type of the <see cref="IEphemerisEntry"/> of <paramref name="entries"/>.</typeparam>
    /// <param name="entries">The ordered list of <typeparamref name="TEntry"/>.</param>
    /// <param name="epoch">The <typeparamref name="TEntry"/> that describes the <see cref="IEpoch"/> closest to, but before, this <see cref="IEpoch"/> is retrieved.</param>
    /// <exception cref="EmptyEphemerisException"/>
    /// <exception cref="UnboundedEphemerisEntryException"/>
    public static TEntry GetClosestBefore<TEntry>(IReadOnlyList<TEntry> entries, IEpoch epoch) where TEntry : IEphemerisEntry
    {
        if (entries.Count is 0)
        {
            throw new EmptyEphemerisException();
        }

        var index = BinarySearchPredecessor(entries, epoch.ToJulianDay());

        if (index == -1)
        {
            throw UnboundedEphemerisEntryException.Earliest;
        }

        return entries[index];
    }

    /// <summary>Retrieves the <typeparamref name="TEntry"/> that describes the <see cref="IEpoch"/> closest to, but after, <paramref name="epoch"/>.</summary>
    /// <typeparam name="TEntry">The type of the <see cref="IEphemerisEntry"/> of <paramref name="entries"/>.</typeparam>
    /// <param name="entries">The ordered list of <typeparamref name="TEntry"/>.</param>
    /// <param name="epoch">The <typeparamref name="TEntry"/> that describes the <see cref="IEpoch"/> closest to, but after, this <see cref="IEpoch"/> is retrieved.</param>
    /// <exception cref="EmptyEphemerisException"/>
    /// <exception cref="UnboundedEphemerisEntryException"/>
    public static TEntry GetClosestAfter<TEntry>(IReadOnlyList<TEntry> entries, IEpoch epoch)  where TEntry : IEphemerisEntry
    {
        if (entries.Count is 0)
        {
            throw new EmptyEphemerisException();
        }

        var index = BinarySearchSuccessor(entries, epoch.ToJulianDay());

        if (index == entries.Count)
        {
            throw UnboundedEphemerisEntryException.Latest;
        }

        return entries[index];
    }

    /// <summary>Performs a binary search for the index of the <typeparamref name="TEntry"/> of <paramref name="entries"/> which is the predecessor to <paramref name="target"/>.</summary>
    /// <typeparam name="TEntry">The type of <see cref="IEphemerisEntry"/> of <paramref name="entries"/>.</typeparam>
    /// <param name="entries">The ordered list of <typeparamref name="TEntry"/>.</param>
    /// <param name="target">The <typeparamref name="TEntry"/> which is the predecessor to this <see cref="JulianDay"/> is selected.</param>
    private static int BinarySearchPredecessor<TEntry>(IReadOnlyList<TEntry> entries, JulianDay target) where TEntry : IEphemerisEntry => BinarySearch(entries, target, SearchRelation.Predecessor);

    /// <summary>Performs a binary search for the index of the <typeparamref name="TEntry"/> of <paramref name="entries"/> which is the sucecssor to <paramref name="target"/>.</summary>
    /// <typeparam name="TEntry">The type of <see cref="IEphemerisEntry"/> of <paramref name="entries"/>.</typeparam>
    /// <param name="entries">The ordered list of <typeparamref name="TEntry"/>.</param>
    /// <param name="target">The <typeparamref name="TEntry"/> which is the successor to this <see cref="JulianDay"/> is selected.</param>
    private static int BinarySearchSuccessor<TEntry>(IReadOnlyList<TEntry> entries, JulianDay target) where TEntry : IEphemerisEntry => BinarySearch(entries, target, SearchRelation.Successor);

    /// <summary>Performs a binary search for the index of the <typeparamref name="TEntry"/> of <paramref name="entries"/> related to <paramref name="target"/> according to some <paramref name="relation"/>.</summary>
    /// <typeparam name="TEntry">The type of <see cref="IEphemerisEntry"/> of <paramref name="entries"/>.</typeparam>
    /// <param name="entries">The ordered list of <typeparamref name="TEntry"/>.</param>
    /// <param name="target">An <typeparamref name="TEntry"/> related to this <see cref="JulianDay"/> is selected.</param>
    /// <param name="relation">Describes the relation between the selection of the search and the <paramref name="target"/>.</param>
    /// <exception cref="InvalidEnumArgumentException"/>
    private static int BinarySearch<TEntry>(IReadOnlyList<TEntry> entries, JulianDay target, SearchRelation relation) where TEntry : IEphemerisEntry
    {
        int left = 0;
        int right = entries.Count;

        while (left < right)
        {
            int mid = (left + right) / 2;

            if (inLeftHalf(mid, target.Day))
            {
                left = mid + 1;

                continue;
            }

            right = mid;
        }

        if (left is 0)
        {
            throw UnboundedEphemerisEntryException.Earliest;
        }

        return resultTransform(left, right);

        bool inLeftHalf(double mid, double target) => relation switch
        {
            SearchRelation.Predecessor => mid < target,
            SearchRelation.Successor => mid <= target,
            _ => throw new InvalidEnumArgumentException(nameof(relation), (int)relation, typeof(SearchRelation))
        };

        int resultTransform(int left, int right) => relation switch
        {
            SearchRelation.Predecessor => left - 1,
            SearchRelation.Successor => right,
            _ => throw new InvalidEnumArgumentException(nameof(relation), (int)relation, typeof(SearchRelation))
        };
    }

    /// <summary>Describes the relation between the target and the selection of a search.</summary>
    private enum SearchRelation
    {
        /// <summary>The selection is the predecessor of the target.</summary>
        Predecessor,
        /// <summary>The selection is the successor of the target.</summary>
        Successor
    }
}
