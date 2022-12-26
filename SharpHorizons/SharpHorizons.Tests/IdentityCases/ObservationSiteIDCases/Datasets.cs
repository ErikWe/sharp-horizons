namespace SharpHorizons.Tests.IdentityCases.ObservationSiteIDCases;

using System.Collections;
using System.Collections.Generic;

internal static class Datasets
{
    public class ValidObservationSiteIDStrings : IEnumerable<object?[]>
    {
        public static IEnumerable<string> Items => new string[]
        {
            "000",
            "0",
            "001",
            "1",
            "999",
            "-1",
            "-99",
            "B0",
            "B00",
            "B2",
            "B02",
            "Z99"
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class InvalidObservationSiteIDStrings : IEnumerable<object?[]>
    {
        public static IEnumerable<string> Items => new string[]
        {
            string.Empty,
            " ",
            "  ",
            "_",
            "-100",
            "1000",
            "B100",
            "-A02",
            "B"
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class ValidObservationSiteIDInts : IEnumerable<object?[]>
    {
        public static IEnumerable<int> Items => new int[]
        {
            0,
            1,
            99,
            999,
            -1,
            -99
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class InvalidObservationSiteIDInts : IEnumerable<object?[]>
    {
        public static IEnumerable<int> Items => new int[]
        {
            -100,
            1000,
            int.MinValue,
            int.MaxValue
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class ValidObservationSiteIDs : IEnumerable<object?[]>
    {
        public static IEnumerable<ObservationSiteID> Items
        {
            get
            {
                foreach (var id in ValidObservationSiteIDStrings.Items)
                {
                    yield return new(id);
                }

                foreach (var id in ValidObservationSiteIDInts.Items)
                {
                    yield return new(id);
                }
            }
        }

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
