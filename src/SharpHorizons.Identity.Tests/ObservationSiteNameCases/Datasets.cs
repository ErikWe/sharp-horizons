namespace SharpHorizons.Tests.IdentityCases.ObservationSiteNameCases;

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

internal static class Datasets
{
    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class ValidObservationSiteNameStrings : IEnumerable<object?[]>
    {
        public static IEnumerable<string> Items => new string[]
        {
            "Arecibo",
            "Sardinia Radio Telescope (SRT 64-m)"
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class InvalidObservationSiteNameStrings : IEnumerable<object?[]>
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

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class ValidObservationSiteNames : IEnumerable<object?[]>
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
