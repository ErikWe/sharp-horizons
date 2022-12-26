namespace SharpHorizons.Tests.EpochCases.JulianDayCases;

using SharpHorizons.Tests;

using System.Collections;
using System.Collections.Generic;

internal static class Datasets
{
    public class ValidJulianDayNumbers : IEnumerable<object?[]>
    {
        public static IEnumerable<double> Items => new double[]
        {
            int.MaxValue + 0.99,
            int.MinValue,
            double.Pi,
            -double.E,
            0
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class ValidIntegralAndFractionalDays : IEnumerable<object?[]>
    {
        public static IEnumerable<(int, float)> Items => new (int, float)[]
        {
            (int.MaxValue, 0.99f),
            (int.MinValue, 0.01f),
            (3, 0.142f),
            (-2, 0.718f),
            (0, 0)
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class OutOfRangeJulianDayNumbers : IEnumerable<object?[]>
    {
        public static IEnumerable<double> Items => new double[]
        {
            double.PositiveInfinity,
            double.NegativeInfinity,
            int.MaxValue + 1.01,
            int.MinValue - 0.01
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class OutOfRangeIntegralAndFractionalDays : IEnumerable<object?[]>
    {
        public static IEnumerable<(int, float)> Items => new (int, float)[]
        {
            (0, float.PositiveInfinity),
            (0, float.NegativeInfinity),
            (0, -0.314f),
            (0, 1.718f)
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class JulianDays : IEnumerable<object?[]>
    {
        public static IEnumerable<JulianDay> Items
        {
            get
            {
                foreach (var julianDayNumber in ValidJulianDayNumbers.Items)
                {
                    yield return new(julianDayNumber);
                }
            }
        }

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class TwoJulianDays : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.DoublePermutate(JulianDays.Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
