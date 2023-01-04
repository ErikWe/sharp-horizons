namespace SharpHorizons.Tests.EpochCases.ModifiedJulianDayCases;

using System.Collections;
using System.Collections.Generic;

internal static class Datasets
{
    public class ConvertibleModifiedJulianDayNumbers : IEnumerable<object?[]>
    {
        public static IEnumerable<double> Items => new double[]
        {
            int.MinValue,
            double.Pi,
            -double.E,
            0
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class ConvertibleIntegralAndFractionalDays : IEnumerable<object?[]>
    {
        public static IEnumerable<(int, float)> Items => new (int, float)[]
        {
            (int.MinValue, 0.01f),
            (3, 0.142f),
            (-2, 0.718f),
            (0, 0)
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class UnconvertibleModifiedJulianDayNumbers : IEnumerable<object?[]>
    {
        public static IEnumerable<double> Items => new double[]
        {
            int.MaxValue + 0.99,
            int.MaxValue - 2
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class UnconvertibleIntegralAndFractionalDays : IEnumerable<object?[]>
    {
        public static IEnumerable<(int, float)> Items => new (int, float)[]
        {
            (int.MaxValue, 0.99f),
            (int.MaxValue - 2, 0)
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class OutOfRangeModifiedJulianDayNumbers : IEnumerable<object?[]>
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

    public class ConvertibleModifiedJulianDays : IEnumerable<object?[]>
    {
        public static IEnumerable<ModifiedJulianDay> Items
        {
            get
            {
                foreach (var modifiedJulianDayNumber in ConvertibleModifiedJulianDayNumbers.Items)
                {
                    yield return new(modifiedJulianDayNumber);
                }
            }
        }

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class UnconvertibleModifiedJulianDays : IEnumerable<object?[]>
    {
        public static IEnumerable<ModifiedJulianDay> Items
        {
            get
            {
                foreach (var modifiedJulianDayNumber in UnconvertibleModifiedJulianDayNumbers.Items)
                {
                    yield return new(modifiedJulianDayNumber);
                }
            }
        }

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class TwoConvertibleModifiedJulianDays : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(DatasetWrappers.Permutate(ConvertibleModifiedJulianDays.Items, ConvertibleModifiedJulianDays.Items)).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class TwoUnconvertibleModifiedJulianDays : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(DatasetWrappers.Permutate(UnconvertibleModifiedJulianDays.Items, UnconvertibleModifiedJulianDays.Items)).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class ConvertibleModifiedJulianDaysAndIEpochs : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(DatasetWrappers.Permutate(ConvertibleModifiedJulianDays.Items, ConvertibleJulianDays.Items)).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class UnconvertibleModifiedJulianDaysAndConvertibleIEpochs : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(DatasetWrappers.Permutate(UnconvertibleModifiedJulianDays.Items, ConvertibleJulianDays.Items)).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class ConvertibleJulianDays : IEnumerable<object?[]>
    {
        public static IEnumerable<JulianDay> Items => new JulianDay[]
        {
            new(int.MaxValue),
            new(0),
            new(double.Pi),
            new(-double.E)
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class UnconvertibleJulianDays : IEnumerable<object?[]>
    {
        public static IEnumerable<JulianDay> Items => new JulianDay[]
        {
            new(int.MinValue)
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class ConvertibleIEpochs : IEnumerable<object?[]>
    {
        public static IEnumerable<IEpoch> Items => new IEpoch[]
        {
            Epoch.FromJulianDay(new JulianDay(0))
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
