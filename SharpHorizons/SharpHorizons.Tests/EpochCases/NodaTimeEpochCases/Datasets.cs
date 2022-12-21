namespace SharpHorizons.Tests.EpochCases.NodaTimeEpochCases;

using NodaTime;

using SharpHorizons.Tests;

using System.Collections;
using System.Collections.Generic;

internal static class Datasets
{
    internal class Instants : IEnumerable<object?[]>
    {
        public static IEnumerable<Instant> Items => new Instant[]
        {
            Instant.MaxValue,
            Instant.MinValue,
            Instant.FromJulianDate(0),
            Instant.FromJulianDate(double.Pi),
            Instant.FromJulianDate(-double.E),
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    internal class Epochs : IEnumerable<object?[]>
    {
        public static IEnumerable<Epoch> Items
        {
            get
            {
                foreach (var instant in Instants.Items)
                {
                    yield return new Epoch(instant);
                }
            }
        }

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    internal class TwoEpochs : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.DoublePermutate(Epochs.Items);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    internal class ConvertibleIEpochs : IEnumerable<object?[]>
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

    internal class UnconvertibleIEpochs : IEnumerable<object?[]>
    {
        public static IEnumerable<IEpoch> Items => new IEpoch[]
        {
            new ModifiedJulianDay(int.MaxValue)
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    internal class EpochsAndConvertibleIEpochs : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Permutate(Epochs.Items, ConvertibleIEpochs.Items);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    internal class EpochsAndUnconvertibleIEpochs : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Permutate(Epochs.Items, UnconvertibleIEpochs.Items);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    internal class UnconvertibleJulianDays : IEnumerable<object?[]>
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
