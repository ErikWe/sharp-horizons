namespace SharpHorizons.Tests.IdentityCases.ObservationSiteNameCases;

using System.Collections;
using System.Collections.Generic;

internal static class Datasets
{
    public class ValidObservationSiteNameStrings : IEnumerable<object?[]>
    {
        public static IEnumerable<string> Items => new string[]
        {
            "Arecibo",
            "Sardinia Radio Telescope (SRT 64-m)"
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class InvalidObservationSiteNameStrings : IEnumerable<object?[]>
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

    public class ValidObservationSiteNames : IEnumerable<object?[]>
    {
        public static IEnumerable<ObservationSiteName> Items
        {
            get
            {
                foreach (var name in ValidObservationSiteNameStrings.Items)
                {
                    yield return new(name);
                }
            }
        }

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
