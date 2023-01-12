namespace SharpHorizons.Tests.QueryCases.ResultCases.QueryResultSignatureCases;

using SharpHorizons.Query.Result;

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

internal static class Datasets
{
    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class ValidQueryResultSignatureTuples : IEnumerable<object?[]>
    {
        public static IEnumerable<(string Source, string Version)> Items => new (string, string)[]
        {
            ("NASA/JPL Horizons API", "1.2"),
            ("NASA-JPL Horizons API", "1.3")
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class InvalidQueryResultSignatureTuples : IEnumerable<object?[]>
    {
        public static IEnumerable<(string Source, string Version)> Items => new (string, string)[]
        {
            (string.Empty, "1.2"),
            (string.Empty, string.Empty),
            (string.Empty, " "),
            (string.Empty, "  "),
            (" ", "1.2"),
            (" ", string.Empty),
            (" ", " "),
            (" ", "  "),
            ("  ", "1.2"),
            ("  ", string.Empty),
            ("  ", " "),
            ("  ", "  "),
            ("NASA/JPL Horizons API", string.Empty),
            ("NASA/JPL Horizons API", " "),
            ("NASA/JPL Horizons API", "  ")
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class ValidQueryResultSignatures : IEnumerable<object?[]>
    {
        public static IEnumerable<QueryResultSignature> Items
        {
            get
            {
                foreach (var (source, version) in ValidQueryResultSignatureTuples.Items)
                {
                    yield return new(source, version);
                }
            }
        }

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class InvalidQueryResultSignatures : IEnumerable<object?[]>
    {
        public static IEnumerable<QueryResultSignature> Items => new QueryResultSignature[]
        {
            default
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
