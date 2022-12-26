namespace SharpHorizons.Tests.IdentityCases.MPCCases.MPCSequentialNumberCases;

using SharpHorizons.MPC;

using System.Collections;
using System.Collections.Generic;

internal static class Datasets
{
    public class ValidMPCSequentialNumberInts : IEnumerable<object?[]>
    {
        public static IEnumerable<int> Items => new int[]
        {
            int.MaxValue,
            1
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class InvalidMPCSequentialNumberInts : IEnumerable<object?[]>
    {
        public static IEnumerable<int> Items => new int[]
        {
            int.MinValue,
            0,
            -1
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class MPCSequentialNumbers : IEnumerable<object?[]>
    {
        public static IEnumerable<MPCSequentialNumber> Items
        {
            get
            {
                foreach (var number in ValidMPCSequentialNumberInts.Items)
                {
                    yield return new(number);
                }
            }
        }

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
