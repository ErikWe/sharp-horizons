namespace SharpHorizons.Tests;

using System.Collections.Generic;

public static class DatasetUtility
{

    public static IEnumerable<(T1, T2, T3)> Flatten<T1, T2, T3>(IEnumerable<((T1, T2), T3)> items)
    {
        foreach (var item in items)
        {
            yield return (item.Item1.Item1, item.Item1.Item2, item.Item2);
        }
    }

    public static IEnumerable<(T1, T2, T3)> Flatten<T1, T2, T3>(IEnumerable<(T1, (T2, T3))> items)
    {
        foreach (var item in items)
        {
            yield return (item.Item1, item.Item2.Item1, item.Item2.Item2);
        }
    }

    public static IEnumerable<(T1, T2)> Permutate<T1, T2>(IEnumerable<T1> firstItems, IEnumerable<T2> secondItems)
    {
        var firstEnumerator = firstItems.GetEnumerator();

        while (firstEnumerator.MoveNext())
        {
            var secondEnumerator = secondItems.GetEnumerator();

            while (secondEnumerator.MoveNext())
            {
                yield return (firstEnumerator.Current, secondEnumerator.Current);
            }
        }
    }

    public static IEnumerable<(T1, T2, T3)> Permutate<T1, T2, T3>(IEnumerable<T1> firstItems, IEnumerable<T2> secondItems, IEnumerable<T3> thirdItems)
    {
        var firstEnumerator = firstItems.GetEnumerator();

        while (firstEnumerator.MoveNext())
        {
            var secondEnumerator = secondItems.GetEnumerator();

            while (secondEnumerator.MoveNext())
            {
                var thirdEnumerator = thirdItems.GetEnumerator();

                while (thirdEnumerator.MoveNext())
                {
                    yield return (firstEnumerator.Current, secondEnumerator.Current, thirdEnumerator.Current);
                }
            }
        }
    }
}
