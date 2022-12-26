namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCCometNameCases;

using SharpHorizons.MPC;

using System.Collections;
using System.Collections.Generic;

internal static class Datasets
{
    public class ValidMPCCometNameStrings : IEnumerable<object?[]>
    {
        public static IEnumerable<string> Items => new string[]
        {
            "Halley",
            "Hale-Bopp"
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class InvalidMPCCometNameStrings : IEnumerable<object?[]>
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

    public class ValidMPCCometNames : IEnumerable<object?[]>
    {
        public static IEnumerable<MPCCometName> Items
        {
            get
            {
                foreach (var name in ValidMPCCometNameStrings.Items)
                {
                    yield return new(name);
                }
            }
        }

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
