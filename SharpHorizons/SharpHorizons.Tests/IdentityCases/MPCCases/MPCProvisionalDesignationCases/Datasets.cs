namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCPrevisionalDesignationCases;

using SharpHorizons.MPC;

using System.Collections;
using System.Collections.Generic;

internal static class Datasets
{
    public class ValidMPCProvisionalDesignationStrings : IEnumerable<object?[]>
    {
        public static IEnumerable<string> Items => new string[]
        {
            "A801 AA",
            "A807 FA",
            "A923 YO13",
            "1925 BD",
            "1933 FF1",
            "4010 P-L",
            "2402 T-1",
            "2402 T-2",
            "2402 T-3",
            "2000 WP157",
            "2000 WP1571237123"
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class InvalidMPCProvisionalDesignationStrings : IEnumerable<object?[]>
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

    public class ValidMPCProvisionalDesignations : IEnumerable<object?[]>
    {
        public static IEnumerable<MPCProvisionalDesignation> Items
        {
            get
            {
                foreach (var designation in ValidMPCProvisionalDesignationStrings.Items)
                {
                    yield return new(designation);
                }
            }
        }

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
