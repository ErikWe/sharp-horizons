namespace SharpHorizons.Tests.EpochCases.NodaTimeEpochCases;

using NodaTime;

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

internal static class Datasets
{
    public static Epoch GetNullEpoch() => null!;
    public static Epoch GetValidEpoch() => EpochValues.Valid.First();

    public static JulianDay GetNullJulianDay() => null!;
    public static JulianDay GetValidJulianDay() => JulianDayValues.SupportingEpochConversion.First();

    public static IEpoch GetNullIEpoch() => null!;

    public static class InstantValues
    {
        public static IEnumerable<Instant> Valid => new[]
        {
            Instant.FromJulianDate(0),
            Instant.FromJulianDate(double.Pi),
            Instant.FromJulianDate(-double.E),
            Instant.MaxValue,
            Instant.MinValue
        };
    }

    public static class ZonedDateTimeValues
    {
        public static IEnumerable<ZonedDateTime> Valid => new[]
        {
            new ZonedDateTime(Instant.MinValue, DateTimeZone.Utc),
            new ZonedDateTime(Instant.FromJulianDate(105), DateTimeZone.Utc)
        };
    }

    public static class EpochValues
    {
        public static IEnumerable<Epoch> Valid
        {
            get
            {
                foreach (var instant in InstantValues.Valid)
                {
                    yield return new(instant);
                }
            }
        }
    }

    public static class JulianDayDoubleValues
    {
        public static IEnumerable<double> SupportingEpochConversion => new double[]
        {
            0,
            1,
            -1
        };

        public static IEnumerable<double> NotSupportingEpochConversion => new double[]
        {
            int.MaxValue,
            int.MinValue
        };
    }

    public static class JulianDayValues
    {
        public static IEnumerable<JulianDay> SupportingEpochConversion
        {
            get
            {
                foreach (var number in JulianDayDoubleValues.SupportingEpochConversion)
                {
                    yield return new(number);
                }
            }
        }

        public static IEnumerable<JulianDay> NotSupportingEpochConversion
        {
            get
            {
                foreach (var number in JulianDayDoubleValues.NotSupportingEpochConversion)
                {
                    yield return new(number);
                }
            }
        }
    }

    public static class IEpochValues
    {
        public static IEnumerable<IEpoch> SupportingJulianDayOrEpochConversion
        {
            get
            {
                foreach (var epoch in JulianDayCases.Datasets.JulianDayValues.Valid)
                {
                    yield return epoch;
                }

                foreach (var epoch in ModifiedJulianDayCases.Datasets.ModifiedJulianDayValues.SupportingJulianDayConversion)
                {
                    yield return epoch;
                }

                foreach (var epoch in DateTimeEpochCases.Datasets.DateTimeEpochValues.Valid)
                {
                    yield return epoch;
                }
            }
        }

        public static IEnumerable<IEpoch> NotSupportingJulianDayOrEpochConversion
        {
            get
            {
                foreach (var epoch in ModifiedJulianDayCases.Datasets.ModifiedJulianDayValues.NotSupportingJulianDayConversion)
                {
                    yield return epoch;
                }
            }
        }
    }

    public static IEnumerable<(Epoch, JulianDay)> EpochAndEquivalentJulianDayValues => new[]
    {
        (new Epoch(Instant.FromJulianDate(105)), new JulianDay(105)),
        (new Epoch(Instant.FromJulianDate(2289079.1363078705)), new JulianDay(2289079.1363078705))
    };

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class ValidInstant : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(InstantValues.Valid).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class ValidZonedDateTime : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(ZonedDateTimeValues.Valid).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class ValidEpoch : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(EpochValues.Valid).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class ValidEpoch_ValidEpoch : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(DatasetUtility.Permutate(EpochValues.Valid, EpochValues.Valid)).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class UnconvertibleJulianDay : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(JulianDayValues.NotSupportingEpochConversion).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class ConvertibleJulianDay : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(JulianDayValues.SupportingEpochConversion).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class ConvertibleIEpoch : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(IEpochValues.SupportingJulianDayOrEpochConversion).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class UnconvertibleIEpoch : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(IEpochValues.NotSupportingJulianDayOrEpochConversion).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class ValidEpoch_UnconvertibleIEpoch : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(DatasetUtility.Permutate(EpochValues.Valid, IEpochValues.NotSupportingJulianDayOrEpochConversion)).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class ValidEpoch_ConvertibleIEpoch : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(DatasetUtility.Permutate(EpochValues.Valid, IEpochValues.SupportingJulianDayOrEpochConversion)).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class EpochAndEquivalentJulianDay : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(EpochAndEquivalentJulianDayValues).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
