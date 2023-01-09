namespace SharpHorizons.Tests.QueryCases.EpochCases.IFixedStepSizeFactoryCases;

using SharpMeasures;

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

internal static class Datasets
{
    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class InvalidDeltaTimes : IEnumerable<object?[]>
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

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class OutOfRangeDeltaTimes : IEnumerable<object?[]>
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

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class ValidDeltaTimes : IEnumerable<object?[]>
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
