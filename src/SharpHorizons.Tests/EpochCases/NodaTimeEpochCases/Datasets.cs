namespace SharpHorizons.Tests.EpochCases.NodaTimeEpochCases;

using NodaTime;

using System.Collections;
using System.Collections.Generic;

internal static class Datasets
{
    public class Instants : IEnumerable<object?[]>
    {
        public static IEnumerable<Instant> Items => new Instant[]
        {
            Instant.MaxValue,
            Instant.MinValue,
            Instant.FromJulianDate(0),
            Instant.FromJulianDate(double.Pi),
            Instant.FromJulianDate(-double.E),
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class Epochs : IEnumerable<object?[]>
    {
        public static IEnumerable<Epoch> Items
        {
            get
            {
                foreach (var instant in Instants.Items)
                {
                    yield return new(instant);
                }
            }
        }

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class TwoEpochs : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(DatasetWrappers.Permutate(Epochs.Items, Epochs.Items)).GetEnumerator();
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

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class UnconvertibleIEpochs : IEnumerable<object?[]>
    {
        public static IEnumerable<IEpoch> Items => new IEpoch[]
        {
            new ModifiedJulianDay(int.MaxValue)
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class EpochsAndConvertibleIEpochs : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(DatasetWrappers.Permutate(Epochs.Items, ConvertibleIEpochs.Items)).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class EpochsAndUnconvertibleIEpochs : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(DatasetWrappers.Permutate(Epochs.Items, UnconvertibleIEpochs.Items)).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class UnconvertibleJulianDays : IEnumerable<object?[]>
    {
        public static IEnumerable<JulianDay> Items => new JulianDay[]
        {
            new(int.MaxValue),
            new(int.MinValue)
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
