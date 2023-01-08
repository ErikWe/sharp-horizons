namespace SharpHorizons.Tests.QueryCases.EpochCases.IUniformStepSizeFactoryCases;

using System.Collections;
using System.Collections.Generic;

internal static class Datasets
{
    public class OutOfRangeStepCounts : IEnumerable<object?[]>
    {
        public static IEnumerable<int> Items => new int[]
        {
            0,
            -1,
            int.MinValue
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class ValidStepCounts : IEnumerable<object?[]>
    {
        public static IEnumerable<int> Items => new int[]
        {
            1,
            int.MaxValue
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
