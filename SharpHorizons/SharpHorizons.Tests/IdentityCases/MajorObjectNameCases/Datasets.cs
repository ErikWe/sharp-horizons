namespace SharpHorizons.Tests.IdentityCases.MajorObjectNameCases;

using System.Collections;
using System.Collections.Generic;

internal static class Datasets
{
    internal class ValidMajorObjectNameStrings : IEnumerable<object?[]>
    {
        public static IEnumerable<string> Items => new string[]
        {
            "Earth",
            "Earth Barycenter",
            "*-0a +?!&%"
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    internal class InvalidMajorObjectNameStrings : IEnumerable<object?[]>
    {
        public static IEnumerable<string> Items => new string[]
        {
            string.Empty,
            " ",
            "  "
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    internal class ValidMajorObjectNames : IEnumerable<object?[]>
    {
        public static IEnumerable<MajorObjectName> Items
        {
            get
            {
                foreach (var name in ValidMajorObjectNameStrings.Items)
                {
                    yield return new MajorObjectName(name);
                }
            }
        }

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    internal class InvalidMajorObjectNames : IEnumerable<object?[]>
    {
        public static IEnumerable<MajorObjectName> Items
        {
            get
            {
                foreach (var name in InvalidMajorObjectNameStrings.Items)
                {
                    yield return new MajorObjectName(name);
                }
            }
        }

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
