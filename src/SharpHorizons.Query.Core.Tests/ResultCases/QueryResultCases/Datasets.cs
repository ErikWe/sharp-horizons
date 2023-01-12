namespace SharpHorizons.Tests.QueryCases.ResultCases.QueryResultCases;

using SharpHorizons.Query.Result;

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

internal static class Datasets
{
    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class ValidQueryResultTuples : IEnumerable<object?[]>
    {
        public static IEnumerable<(QueryResultSignature Signature, string Content)> Items => new (QueryResultSignature, string)[]
        {
            (new("NASA/JPL Horizons API", "1.2"), "Data..."),
            (new("NASA/JPL Horizons API", "1.3"), string.Empty)
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class InvalidQueryResultTuples : IEnumerable<object?[]>
    {
        public static IEnumerable<(QueryResultSignature Signature, string Content)> Items => new (QueryResultSignature, string)[]
        {
            (default, "Data..."),
            (default, string.Empty)
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class ValidQueryResults : IEnumerable<object?[]>
    {
        public static IEnumerable<QueryResult> Items
        {
            get
            {
                foreach (var (signature, content) in ValidQueryResultTuples.Items)
                {
                    yield return new(signature, content);
                }
            }
        }

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class InvalidQueryResults : IEnumerable<object?[]>
    {
        public static IEnumerable<QueryResult> Items => new QueryResult[]
        {
            default
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
