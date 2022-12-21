namespace SharpHorizons.Tests;

using System.Collections.Generic;

internal static class DatasetWrappers
{
    public static IEnumerator<object?[]> Wrap<T>(IEnumerable<T> items)
    {
        return wrap().GetEnumerator();

        IEnumerable<object?[]> wrap()
        {
            foreach (var item in items)
            {
                yield return new object?[] { item };
            }
        }
    }

    public static IEnumerator<object?[]> SeparateAndWrap<T1, T2>(IEnumerable<(T1 A, T2 B)> items)
    {
        return wrap().GetEnumerator();

        IEnumerable<object?[]> wrap()
        {
            foreach (var (a, b) in items)
            {
                yield return new object?[] { a, b };
            }
        }
    }

    public static IEnumerator<object?[]> DoublePermutate<T>(IEnumerable<T> items)
    {
        return SeparateAndWrap(wrap());

        IEnumerable<(T, T)> wrap()
        {
            var firstEnumerator = items.GetEnumerator();

            while (firstEnumerator.MoveNext())
            {
                var secondEnumerator = items.GetEnumerator();

                while (secondEnumerator.MoveNext())
                {
                    yield return (firstEnumerator.Current, secondEnumerator.Current);
                }
            }
        }
    }

    public static IEnumerator<object?[]> Permutate<T1, T2>(IEnumerable<T1> firstItems, IEnumerable<T2> secondItems)
    {
        return SeparateAndWrap(wrap());

        IEnumerable<(T1, T2)> wrap()
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
    }
}
