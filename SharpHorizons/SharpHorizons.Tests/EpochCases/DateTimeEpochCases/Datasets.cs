namespace SharpHorizons.Tests.EpochCases.DateTimeEpochCases;

using SharpHorizons.Tests;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

internal static class Datasets
{
    public static DateTimeEpoch SimpleDateTimeEpoch { get; } = DateTimeEpoch.FromJulianDay(new JulianDay(2400000));

    private static JulianCalendar JulianCalendar { get; } = new();
    private static GregorianCalendar GregorianCalendar { get; } = new();

    public class DateTimeOffsets : IEnumerable<object?[]>
    {
        public static IEnumerable<DateTimeOffset> Items => new DateTimeOffset[]
        {
            new DateTimeOffset(new DateTime(5, 1, 1, 0, 0, 0, 0, JulianCalendar), TimeSpan.Zero),
            new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 0, 0, JulianCalendar), TimeSpan.Zero),
            new DateTimeOffset(new DateTime(9999, 1, 1, 0, 0, 0, 0, JulianCalendar), TimeSpan.Zero),
            new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, GregorianCalendar), TimeSpan.Zero),
            new DateTimeOffset(new DateTime(2022, 1, 1, 0, 0, 0, 0, GregorianCalendar), TimeSpan.Zero),
            new DateTimeOffset(new DateTime(9999, 1, 1, 0, 0, 0, 0, GregorianCalendar), TimeSpan.Zero),
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class DateTimeEpochs : IEnumerable<object?[]>
    {
        public static IEnumerable<DateTimeEpoch> Items
        {
            get
            {
                foreach (var offset in DateTimeOffsets.Items)
                {
                    yield return new DateTimeEpoch(offset);
                }
            }
        }

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class TwoDateTimeEpochs : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.DoublePermutate(DateTimeEpochs.Items);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class ConvertibleIEpochs : IEnumerable<object?[]>
    {
        public static IEnumerable<IEpoch> Items => new IEpoch[]
        {
            new ModifiedJulianDay(0),
            new ModifiedJulianDay(int.MinValue),
            new ModifiedJulianDay(double.Pi)
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class UnconvertibleIEpochs : IEnumerable<object?[]>
    {
        public static IEnumerable<IEpoch> Items => new IEpoch[]
        {
            new ModifiedJulianDay(int.MaxValue)
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class DateTimeEpochsAndConvertibleIEpochs : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Permutate(DateTimeEpochs.Items, ConvertibleIEpochs.Items);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class DateTimeEpochsAndUnconvertibleIEpochs : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Permutate(DateTimeEpochs.Items, UnconvertibleIEpochs.Items);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class UnconvertibleJulianDays : IEnumerable<object?[]>
    {
        public static IEnumerable<JulianDay> Items => new JulianDay[]
        {
            new JulianDay(int.MaxValue),
            new JulianDay(int.MinValue)
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
