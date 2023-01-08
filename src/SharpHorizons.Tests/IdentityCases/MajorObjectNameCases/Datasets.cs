namespace SharpHorizons.Tests.IdentityCases.MajorObjectNameCases;

using System.Collections;
using System.Collections.Generic;

internal static class Datasets
{
    public class ValidMajorObjectNameStrings : IEnumerable<object?[]>
    {
        public static IEnumerable<string> Items => new string[]
        {
            "Earth",
            "Voyager 1 (spacecraft)"
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class InvalidMajorObjectNameStrings : IEnumerable<object?[]>
    {
        public static IEnumerable<string> Items => new string[]
        {
            string.Empty,
            " ",
            "  "
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class ValidMajorObjectNames : IEnumerable<object?[]>
    {
        public static IEnumerable<MajorObjectName> Items
        {
            get
            {
                foreach (var name in ValidMajorObjectNameStrings.Items)
                {
                    yield return new(name);
                }
            }
        }

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
