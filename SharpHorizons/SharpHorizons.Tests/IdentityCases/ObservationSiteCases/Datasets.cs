namespace SharpHorizons.Tests.IdentityCases.ObservationSiteCases;

using System.Collections;
using System.Collections.Generic;

internal static class Datasets
{
    public class ValidObservationSiteIDs : IEnumerable<object?[]>
    {
        public static IEnumerable<ObservationSiteID> Items => new ObservationSiteID[]
        {
            new(1),
            new("1"),
            new("A1"),
            new("Z99")
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class ValidObservationSiteNames : IEnumerable<object?[]>
    {
        public static IEnumerable<ObservationSiteName> Items => new ObservationSiteName[]
        {
            new("Arecibo"),
            new("Sardinia Radio Telescope (SRT 64-m)")
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class InvalidObservationSiteNames : IEnumerable<object?[]>
    {
        public static IEnumerable<ObservationSiteName> Items => new ObservationSiteName[]
        {
            default
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class ValidCombinations : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Permutate(ValidObservationSiteIDs.Items, ValidObservationSiteNames.Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class InvalidCombinations : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Permutate(ValidObservationSiteIDs.Items, InvalidObservationSiteNames.Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
