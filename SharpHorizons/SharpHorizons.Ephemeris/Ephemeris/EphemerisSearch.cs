namespace SharpHorizons.Ephemeris;

using System.ComponentModel;

internal static class EphemerisSearch
{
    /// <summary>Retrieves the <typeparamref name="TEntry"/> of <paramref name="ephemeris"/> that describes the <see cref="IEpoch"/> closest to <paramref name="epoch"/>.</summary>
    /// <typeparam name="TEntry">The type of the <see cref="IEphemerisEntry"/> of <paramref name="ephemeris"/>.</typeparam>
    /// <param name="ephemeris">The <see cref="IEphemeris{TEntry}"/> from which an <typeparamref name="TEntry"/> is retrieved.</param>
    /// <param name="epoch">The <typeparamref name="TEntry"/> of <paramref name="ephemeris"/> that describes the <see cref="IEpoch"/> closest to this <see cref="IEpoch"/> is retrieved.</param>
    /// <exception cref="EmptyEphemerisSearchException"/>
    public static TEntry GetClosest<TEntry>(IEphemeris<TEntry> ephemeris, IEpoch epoch) where TEntry : IEphemerisEntry
    {
        if (ephemeris.Count is 0)
        {
            throw new EmptyEphemerisSearchException();
        }

        var target = epoch.ToJulianDay();

        var predecessor = BinarySearchPredecessor(ephemeris, target);

        if (predecessor is -1)
        {
            return ephemeris[0];
        }

        var successor = BinarySearchSuccessor(ephemeris, target);

        if (successor == ephemeris.Count)
        {
            return ephemeris[^1];
        }

        var differenceBefore = target - ephemeris[predecessor].Epoch.ToJulianDay();
        var differenceAfter = ephemeris[successor].Epoch.ToJulianDay() - target;

        if (differenceBefore < differenceAfter)
        {
            return ephemeris[predecessor];
        }

        return ephemeris[successor];
    }

    /// <summary>Retrieves the <typeparamref name="TEntry"/> of <paramref name="ephemeris"/> that describes the <see cref="IEpoch"/> closest to, but before, <paramref name="epoch"/>.</summary>
    /// <typeparam name="TEntry">The type of the <see cref="IEphemerisEntry"/> of <paramref name="ephemeris"/>.</typeparam>
    /// <param name="ephemeris">The <see cref="IEphemeris{TEntry}"/> from which an <typeparamref name="TEntry"/> is retrieved.</param>
    /// <param name="epoch">The <typeparamref name="TEntry"/> of <paramref name="ephemeris"/> that describes the <see cref="IEpoch"/> closest to, but before, this <see cref="IEpoch"/> is retrieved.</param>
    /// <exception cref="EmptyEphemerisSearchException"/>
    /// <exception cref="UnboundedEphemerisSearchException"/>
    public static TEntry GetClosestBefore<TEntry>(IEphemeris<TEntry> ephemeris, IEpoch epoch) where TEntry : IEphemerisEntry
    {
        if (ephemeris.Count is 0)
        {
            throw new EmptyEphemerisSearchException();
        }

        var index = BinarySearchPredecessor(ephemeris, epoch.ToJulianDay());

        if (index == -1)
        {
            throw UnboundedEphemerisSearchException.Earliest();
        }

        return ephemeris[index];
    }

    /// <summary>Retrieves the <typeparamref name="TEntry"/> of <paramref name="ephemeris"/> that describes the <see cref="IEpoch"/> closest to, but after, <paramref name="epoch"/>.</summary>
    /// <typeparam name="TEntry">The type of the <see cref="IEphemerisEntry"/> of <paramref name="ephemeris"/>.</typeparam>
    /// <param name="ephemeris">The <see cref="IEphemeris{TEntry}"/> from which an <typeparamref name="TEntry"/> is retrieved.</param>
    /// <param name="epoch">The <typeparamref name="TEntry"/> of <paramref name="ephemeris"/> that describes the <see cref="IEpoch"/> closest to, but after, this <see cref="IEpoch"/> is retrieved.</param>
    /// <exception cref="EmptyEphemerisSearchException"/>
    /// <exception cref="UnboundedEphemerisSearchException"/>
    public static TEntry GetClosestAfter<TEntry>(IEphemeris<TEntry> ephemeris, IEpoch epoch)  where TEntry : IEphemerisEntry
    {
        if (ephemeris.Count is 0)
        {
            throw new EmptyEphemerisSearchException();
        }

        var index = BinarySearchSuccessor(ephemeris, epoch.ToJulianDay());

        if (index == ephemeris.Count)
        {
            throw UnboundedEphemerisSearchException.Latest();
        }

        return ephemeris[index];
    }

    /// <summary>Locates the <typeparamref name="TEntry"/>, in <paramref name="ephemeris"/>, which is the predecessor to <paramref name="target"/>.</summary>
    /// <typeparam name="TEntry">The type of the <see cref="IEphemerisEntry"/> of <paramref name="ephemeris"/>.</typeparam>
    /// <param name="ephemeris">The <see cref="IEphemeris{TEntry}"/> from which an <typeparamref name="TEntry"/> is retrieved.</param>
    /// <param name="target">The <typeparamref name="TEntry"/> which is the predecessor to this <see cref="JulianDay"/> is selected.</param>
    /// <returns>The index of the <typeparamref name="TEntry"/> in <paramref name="ephemeris"/>.</returns>
    private static int BinarySearchPredecessor<TEntry>(IEphemeris<TEntry> ephemeris, JulianDay target) where TEntry : IEphemerisEntry => BinarySearch(ephemeris, target, SearchRelation.Predecessor);

    /// <summary>Locates the <typeparamref name="TEntry"/>, in <paramref name="ephemeris"/>, which is the sucecssor to <paramref name="target"/>.</summary>
    /// <typeparam name="TEntry">The type of the <see cref="IEphemerisEntry"/> of <paramref name="ephemeris"/>.</typeparam>
    /// <param name="ephemeris">The <see cref="IEphemeris{TEntry}"/> from which an <typeparamref name="TEntry"/> is retrieved.</param>
    /// <param name="target">The <typeparamref name="TEntry"/> which is the successor to this <see cref="JulianDay"/> is selected.</param>
    /// <returns>The index of the <typeparamref name="TEntry"/> in <paramref name="ephemeris"/>.</returns>
    private static int BinarySearchSuccessor<TEntry>(IEphemeris<TEntry> ephemeris, JulianDay target) where TEntry : IEphemerisEntry => BinarySearch(ephemeris, target, SearchRelation.Successor);

    /// <summary>Locates the <typeparamref name="TEntry"/>, in <paramref name="ephemeris"/>, with some <paramref name="relation"/> to <paramref name="target"/>.</summary>
    /// <typeparam name="TEntry">The type of the <see cref="IEphemerisEntry"/> of <paramref name="ephemeris"/>.</typeparam>
    /// <param name="ephemeris">The <see cref="IEphemeris{TEntry}"/> from which an <typeparamref name="TEntry"/> is retrieved.</param>
    /// <param name="target">The <typeparamref name="TEntry"/> with some <paramref name="relation"/> to this <see cref="JulianDay"/> is selected.</param>
    /// <param name="relation">Describes the relation between the selection of the search and the <paramref name="target"/>.</param>
    /// <returns>The index of the <typeparamref name="TEntry"/> in <paramref name="ephemeris"/>.</returns>
    /// <exception cref="InvalidEnumArgumentException"/>
    private static int BinarySearch<TEntry>(IEphemeris<TEntry> ephemeris, JulianDay target, SearchRelation relation) where TEntry : IEphemerisEntry
    {
        int left = 0;
        int right = ephemeris.Count;

        while (left < right)
        {
            int mid = (left + right) / 2;

            if (inLeftHalf(mid, target))
            {
                left = mid + 1;

                continue;
            }

            right = mid;
        }

        if (left is 0)
        {
            throw UnboundedEphemerisSearchException.Earliest();
        }

        return resultTransform(left, right);

        bool inLeftHalf(double mid, JulianDay target) => relation switch
        {
            SearchRelation.Predecessor => mid < target.Day,
            SearchRelation.Successor => mid <= target.Day,
            _ => throw InvalidEnumArgumentExceptionFactory.Create(relation)
        };

        int resultTransform(int left, int right) => relation switch
        {
            SearchRelation.Predecessor => left - 1,
            SearchRelation.Successor => right,
            _ => throw InvalidEnumArgumentExceptionFactory.Create(relation)
        };
    }

    /// <summary>Describes the relation between the target and the selection of a search.</summary>
    private enum SearchRelation
    {
        /// <summary>The selection is the predecessor to the target.</summary>
        Predecessor,
        /// <summary>The selection is the successor to the target.</summary>
        Successor
    }
}
