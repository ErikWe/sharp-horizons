namespace SharpHorizons.Tests.QueryCases.EpochCases.IAngularStepSizeFactoryCases;

using SharpMeasures;

using System.Collections;
using System.Collections.Generic;

internal static class Datasets
{
    public class InvalidDeltaAngles : IEnumerable<object?[]>
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

    public class OutOfRangeDeltaAngles : IEnumerable<object?[]>
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

    public class ValidDeltaAngles : IEnumerable<object?[]>
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
