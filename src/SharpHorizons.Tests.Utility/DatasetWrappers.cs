namespace SharpHorizons.Tests;

using System.Collections.Generic;

public static class DatasetWrappers
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
}
