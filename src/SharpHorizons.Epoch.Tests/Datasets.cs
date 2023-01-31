namespace SharpHorizons.Tests.EpochCases;

using SharpMeasures;

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

internal static class Datasets
{
    public static Time GetOutOfBoundsTime() => new(double.MaxValue);

    public static class TimeValues
    {
        public static IEnumerable<Time> Invalid => new[]
        {
            new Time(double.NaN),
            new Time(double.PositiveInfinity),
            new Time(double.NegativeInfinity)
        };

        public static IEnumerable<Time> Valid => new[]
        {
            2.5 * Time.OneDay,
            0.314 * Time.OneDay
        };
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class InvalidTimes : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(TimeValues.Invalid).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class ValidTimes : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(TimeValues.Valid).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
