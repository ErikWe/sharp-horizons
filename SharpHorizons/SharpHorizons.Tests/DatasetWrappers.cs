namespace SharpHorizons.Tests;

using System.Collections.Generic;

internal static class DatasetWrappers
{
    public static IEnumerable<object?[]> Wrap<T>(IEnumerable<T> items)
    {
        return wrap();

        IEnumerable<object?[]> wrap()
        {
            foreach (var item in items)
            {
                yield return new object?[] { item };
            }
        }
    }

    public static IEnumerable<object?[]> SeparateAndWrap<T1, T2>(IEnumerable<(T1 A, T2 B)> items)
    {
        return wrap();

        IEnumerable<object?[]> wrap()
        {
            foreach (var (a, b) in items)
            {
                yield return new object?[] { a, b };
            }
        }
    }

    public static IEnumerable<object?[]> SeparateAndWrap<T1, T2, T3>(IEnumerable<(T1 A, T2 B, T3 C)> items)
    {
        return wrap();

        IEnumerable<object?[]> wrap()
        {
            foreach (var (a, b, c) in items)
            {
                yield return new object?[] { a, b, c };
            }
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
