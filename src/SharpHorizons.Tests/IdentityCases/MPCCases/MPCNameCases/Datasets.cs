namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCNameCases;

using SharpHorizons.MPC;

using System.Collections;
using System.Collections.Generic;

internal static class Datasets
{
    public class ValidMPCNameStrings : IEnumerable<object?[]>
    {
        public static IEnumerable<string> Items => new string[]
        {
            "Ceres",
            "Vesta"
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class InvalidMPCNameStrings : IEnumerable<object?[]>
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

    public class ValidMPCNames : IEnumerable<object?[]>
    {
        public static IEnumerable<MPCName> Items
        {
            get
            {
                foreach (var name in ValidMPCNameStrings.Items)
                {
                    yield return new(name);
                }
            }
        }

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
