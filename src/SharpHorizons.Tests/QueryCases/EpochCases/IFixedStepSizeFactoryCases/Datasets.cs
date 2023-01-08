namespace SharpHorizons.Tests.QueryCases.EpochCases.IFixedStepSizeFactoryCases;

using SharpMeasures;

using System.Collections;
using System.Collections.Generic;

internal static class Datasets
{
    public class InvalidDeltaTimes : IEnumerable<object?[]>
    {
        public static IEnumerable<Time> Items => new Time[]
        {
            new Time(double.NaN),
            new Time(double.NegativeInfinity),
            new Time(double.PositiveInfinity)
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class OutOfRangeDeltaTimes : IEnumerable<object?[]>
    {
        public static IEnumerable<Time> Items => new Time[]
        {
            new Time(0),
            new Time(-1),
            new Time(double.MinValue)
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class ValidDeltaTimes : IEnumerable<object?[]>
    {
        public static IEnumerable<Time> Items => new Time[]
        {
            new Time(1),
            new Time(double.MaxValue)
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
