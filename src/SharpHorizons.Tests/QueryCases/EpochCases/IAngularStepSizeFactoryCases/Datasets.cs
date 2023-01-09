namespace SharpHorizons.Tests.QueryCases.EpochCases.IAngularStepSizeFactoryCases;

using SharpMeasures;

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

internal static class Datasets
{
    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class InvalidDeltaAngles : IEnumerable<object?[]>
    {
        public static IEnumerable<Angle> Items => new Angle[]
        {
            new Angle(double.NaN),
            new Angle(double.NegativeInfinity),
            new Angle(double.PositiveInfinity)
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class OutOfRangeDeltaAngles : IEnumerable<object?[]>
    {
        public static IEnumerable<Angle> Items => new Angle[]
        {
            new Angle(0),
            new Angle(-1),
            new Angle(double.MinValue)
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class ValidDeltaAngles : IEnumerable<object?[]>
    {
        public static IEnumerable<Angle> Items => new Angle[]
        {
            new Angle(1),
            new Angle(double.MaxValue)
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
