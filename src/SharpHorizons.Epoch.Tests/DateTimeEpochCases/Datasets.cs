namespace SharpHorizons.Tests.EpochCases.DateTimeEpochCases;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;

internal static class Datasets
{
    private static JulianCalendar JulianCalendar { get; } = new();
    private static GregorianCalendar GregorianCalendar { get; } = new();

    public static DateTime GetValidDateTime() => new(1555, 9, 8, 14, 15, 16, 17);
    public static DateTime GetNPTValidDateTime() => DateTimeValues.NPTValid.First();

    public static TimeSpan GetNPTOffset() => TimeSpan.FromHours(5.75);
    public static TimeSpan GetPDTOffset() => TimeSpan.FromHours(-7);
    public static TimeSpan GetPSTOffset() => TimeSpan.FromHours(-8);

    public static DateTimeEpoch GetNullDateTimeEpoch() => null!;
    public static DateTimeEpoch GetValidDateTimeEpoch() => DateTimeEpochValues.Valid.First();

    public static JulianDay GetNullJulianDay() => null!;
    public static JulianDay GetValidJulianDay() => JulianDayValues.SupportingDateTimeEpochConversion.First();

    public static IEpoch GetNullIEpoch() => null!;

    public static class DateTimeAndOffsetValues
    {
        public static IEnumerable<(DateTime, TimeSpan)> UTCInvalid => new[]
        {
            (new DateTime(1555, 3, 9, 15, 16, 17, 18, GregorianCalendar, DateTimeKind.Utc), TimeSpan.FromMinutes(5))
        };

        public static IEnumerable<(DateTime, TimeSpan)> GMTInvalid => new[]
        {
            (new DateTime(1555, 9, 8, 14, 15, 16, 17, GregorianCalendar, DateTimeKind.Local), TimeSpan.FromMinutes(5))
        };

        public static IEnumerable<(DateTime, TimeSpan)> NPTOutOfRange => new[]
        {
            (new DateTime(1, 1, 1, 0, 0, 0, 0, GregorianCalendar, DateTimeKind.Local), GetNPTOffset())
        };

        public static IEnumerable<(DateTime, TimeSpan)> PSTOutOfRange => new[]
        {
            (new DateTime(9999, 12, 31, 23, 59, 59, 999, GregorianCalendar, DateTimeKind.Local), GetPSTOffset())
        };
        public static IEnumerable<(DateTime, TimeSpan)> UTCValid => new[]
        {
            (new DateTime(1555, 3, 9, 15, 16, 17, 18, GregorianCalendar, DateTimeKind.Utc), TimeSpan.FromMinutes(0)),
            (new DateTime(1455, 3, 9, 15, 16, 17, 18, GregorianCalendar, DateTimeKind.Utc), TimeSpan.FromMinutes(0))
        };

        public static IEnumerable<(DateTime, TimeSpan)> NPTValid => new[]
        {
            (new DateTime(2022, 1, 1, 0, 0, 0, 0, JulianCalendar, DateTimeKind.Local), GetNPTOffset()),
            (new DateTime(2012, 1, 1, 0, 0, 0, 0, JulianCalendar, DateTimeKind.Local), GetNPTOffset())
        };

        public static IEnumerable<(DateTime, TimeSpan)> Valid => new[]
        {
            (new DateTime(1555, 3, 9, 15, 16, 17, 18, GregorianCalendar, DateTimeKind.Unspecified), TimeSpan.FromHours(4)),
            (new DateTime(2021, 1, 3, 4, 5, 6, 9, JulianCalendar, DateTimeKind.Unspecified), TimeSpan.FromHours(-1))
        };
    }

    public static class DateTimeValues
    {
        public static IEnumerable<DateTime> NPTValid
        {
            get
            {
                foreach (var (dateTime, _) in DateTimeAndOffsetValues.NPTValid)
                {
                    yield return dateTime;
                }
            }
        }

        public static IEnumerable<DateTime> NPTInvalid
        {
            get
            {
                yield return new DateTime(DateTime.MinValue.Ticks, DateTimeKind.Local);
            }
        }

        public static IEnumerable<DateTime> PSTInvalid
        {
            get
            {
                yield return new DateTime(DateTime.MaxValue.Ticks, DateTimeKind.Local);
            }
        }
    }

    public static class TimeSpanOffsetValues
    {
        public static IEnumerable<TimeSpan> Invalid => new[]
        {
            TimeSpan.FromSeconds(42)
        };

        public static IEnumerable<TimeSpan> OutOfRange => new[]
        {
            TimeSpan.FromHours(15),
            TimeSpan.FromHours(-15)
        };
    }

    public static class DateTimeOffsetValues
    {
        public static IEnumerable<DateTimeOffset> Valid
        {
            get
            {
                foreach (var (dateTime, offset) in DateTimeAndOffsetValues.Valid)
                {
                    yield return new(dateTime, offset);
                }
            }
        }
    }

    public static class DateTimeEpochValues
    {
        public static IEnumerable<DateTimeEpoch> Valid
        {
            get
            {
                foreach (var offset in DateTimeOffsetValues.Valid)
                {
                    yield return new(offset);
                }
            }
        }
    }

    public static class JulianDayDoubleValues
    {
        public static IEnumerable<double> SupportingDateTimeEpochConversion => new[]
        {
            2400000.5
        };

        public static IEnumerable<double> NotSupportingDateTimeEpochConversion => new double[]
        {
            0,
            1,
            -1,
            int.MaxValue,
            int.MinValue
        };
    }

    public static class JulianDayValues
    {
        public static IEnumerable<JulianDay> SupportingDateTimeEpochConversion
        {
            get
            {
                foreach (var number in JulianDayDoubleValues.SupportingDateTimeEpochConversion)
                {
                    yield return new(number);
                }
            }
        }

        public static IEnumerable<JulianDay> NotSupportingDateTimeEpochConversion
        {
            get
            {
                foreach (var number in JulianDayDoubleValues.NotSupportingDateTimeEpochConversion)
                {
                    yield return new(number);
                }
            }
        }
    }

    public static class IEpochValues
    {
        public static IEnumerable<IEpoch> SupportingJulianDayOrDateTimeEpochConversion
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
            }
        }

        public static IEnumerable<IEpoch> NotSupportingJulianDayOrDateTimeEpochConversion
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

    public static IEnumerable<(DateTimeEpoch, JulianDay)> DateTimeEpochAndEquivalentJulianDayValues => new[]
    {
        (new DateTimeEpoch(new DateTime(1555, 3, 9, 15, 16, 17, 18, GregorianCalendar, DateTimeKind.Utc)), new JulianDay(2289079.1363078705))
    };

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class NPTInvalidDateTime : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(DateTimeValues.NPTInvalid).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class NPTValidDateTime : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(DateTimeValues.NPTValid).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class PSTInvalidDateTime : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(DateTimeValues.PSTInvalid).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class InvalidOffset : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(TimeSpanOffsetValues.Invalid).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class OutOfRangeOffset : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(TimeSpanOffsetValues.OutOfRange).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class UTCInvalidCombination_DateTime_Offset : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(DateTimeAndOffsetValues.UTCInvalid).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class UTCValidCombination_DateTime_Offset : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(DateTimeAndOffsetValues.UTCValid).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class GMTInvalidCombination_DateTime_Offset : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(DateTimeAndOffsetValues.GMTInvalid).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class PSTOutOfRangeCombination_DateTime_Offset : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(DateTimeAndOffsetValues.PSTOutOfRange).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class NPTOutOfRangeCombination_DateTime_Offset : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(DateTimeAndOffsetValues.NPTOutOfRange).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class NPT_ValidDateTime_ValidOffset : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(DateTimeAndOffsetValues.NPTValid).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class ValidDateTimeOffset : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(DateTimeOffsetValues.Valid).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class ValidDateTimeEpoch : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(DateTimeEpochValues.Valid).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class ValidDateTimeEpoch_ValidDateTimeEpoch : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(DatasetUtility.Permutate(DateTimeEpochValues.Valid, DateTimeEpochValues.Valid)).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class UnconvertibleJulianDay : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(JulianDayValues.NotSupportingDateTimeEpochConversion).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class ConvertibleJulianDay : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(JulianDayValues.SupportingDateTimeEpochConversion).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class ConvertibleIEpoch : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(IEpochValues.SupportingJulianDayOrDateTimeEpochConversion).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class UnconvertibleIEpoch : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(IEpochValues.NotSupportingJulianDayOrDateTimeEpochConversion).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class ValidDateTimeEpoch_ConvertibleIEpoch : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(DatasetUtility.Permutate(DateTimeEpochValues.Valid, IEpochValues.SupportingJulianDayOrDateTimeEpochConversion)).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class ValidDateTimeEpoch_UnconvertibleIEpoch : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(DatasetUtility.Permutate(DateTimeEpochValues.Valid, IEpochValues.NotSupportingJulianDayOrDateTimeEpochConversion)).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class DateTimeEpochAndEquivalentJulianDay : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(DateTimeEpochAndEquivalentJulianDayValues).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
