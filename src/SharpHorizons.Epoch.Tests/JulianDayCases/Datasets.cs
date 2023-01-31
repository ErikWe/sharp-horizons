namespace SharpHorizons.Tests.EpochCases.JulianDayCases;

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

internal static class Datasets
{
    public static JulianDay GetNullJulianDay() => null!;
    public static JulianDay GetValidJulianDay() => JulianDayValues.Valid.First();

    public static IEpoch GetNullIEpoch() => null!;

    public static class JulianDayDoubleValues
    {
        public static IEnumerable<double> Invalid => new[]
        {
            double.NaN
        };

        public static IEnumerable<double> OutOfRange => new[]
        {
            double.PositiveInfinity,
            double.NegativeInfinity,
            int.MaxValue + 1d,
            int.MinValue - 0.00001
        };

        public static IEnumerable<double> Valid => new[]
        {
            0,
            1,
            -1,
            int.MaxValue + 0.99999,
            int.MinValue,
            double.Pi,
            -double.E
        };
    }

    public static class JulianDayIntegralDayInt32Values
    {
        public static IEnumerable<int> Valid => new[]
        {
            0,
            1,
            -1,
            int.MaxValue,
            int.MinValue
        };
    }

    public static class JulianDayFractionalDayFloatValues
    {
        public static IEnumerable<float> Invalid => new[]
        {
            float.NaN
        };

        public static IEnumerable<float> OutOfRange => new[]
        {
            1,
            1.718f,
            -0.00001f,
            float.PositiveInfinity,
            float.NegativeInfinity
        };

        public static IEnumerable<float> Valid => new[]
        {
            0,
            0.5f,
            0.00001f,
            0.99999f
        };
    }

    public static class JulianDayValues
    {
        public static IEnumerable<JulianDay> Valid
        {
            get
            {
                foreach (var number in JulianDayDoubleValues.Valid)
                {
                    yield return new(number);
                }
            }
        }
    }

    public static class IEpochValues
    {
        public static IEnumerable<IEpoch> SupportingJulianDayConversion
        {
            get
            {
                foreach (var epoch in ModifiedJulianDayCases.Datasets.ModifiedJulianDayValues.SupportingJulianDayConversion)
                {
                    yield return epoch;
                }

                foreach (var epoch in DateTimeEpochCases.Datasets.DateTimeEpochValues.Valid)
                {
                    yield return epoch;
                }

                // TODO
            }
        }

        public static IEnumerable<IEpoch> NotSupportingJulianDayConversion
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

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class InvalidJulianDayDouble : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(JulianDayDoubleValues.Invalid).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class OutOfRangeJulianDayDouble : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(JulianDayDoubleValues.OutOfRange).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class ValidJulianDayDouble : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(JulianDayDoubleValues.Valid).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class ValidJulianDayIntegralDayInt32_InvalidJulianDayFractionalDayFloat : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(DatasetUtility.Permutate(JulianDayIntegralDayInt32Values.Valid, JulianDayFractionalDayFloatValues.Invalid)).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class ValidJulianDayIntegralDayInt32_OutOfRangeJulianDayFractionalDayFloat : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(DatasetUtility.Permutate(JulianDayIntegralDayInt32Values.Valid, JulianDayFractionalDayFloatValues.OutOfRange)).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class ValidJulianDayIntegralDayInt32_ValidJulianDayFractionalDayFloat : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(DatasetUtility.Permutate(JulianDayIntegralDayInt32Values.Valid, JulianDayFractionalDayFloatValues.Valid)).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class ValidJulianDayIntegralDayInt32 : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(JulianDayIntegralDayInt32Values.Valid).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class InvalidJulianDayFractionalDayFloat : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(JulianDayFractionalDayFloatValues.Invalid).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class OutOfRangeJulianDayFractionalDayFloat : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(JulianDayFractionalDayFloatValues.OutOfRange).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class ValidJulianDayFractionalDayFloat : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(JulianDayFractionalDayFloatValues.Valid).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class ValidJulianDay_ValidJulianDay : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(DatasetUtility.Permutate(JulianDayValues.Valid, JulianDayValues.Valid)).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class ValidJulianDay_ConvertibleIEpoch : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(DatasetUtility.Permutate(JulianDayValues.Valid, IEpochValues.SupportingJulianDayConversion)).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class ValidJulianDay_UnconvertibleIEpoch : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(DatasetUtility.Permutate(JulianDayValues.Valid, IEpochValues.NotSupportingJulianDayConversion)).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class ValidJulianDay : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(JulianDayValues.Valid).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class ConvertibleIEpoch : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(IEpochValues.SupportingJulianDayConversion).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class UnconvertibleIEpoch : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(IEpochValues.NotSupportingJulianDayConversion).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
