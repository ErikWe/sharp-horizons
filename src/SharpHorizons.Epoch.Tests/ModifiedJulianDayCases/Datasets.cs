namespace SharpHorizons.Tests.EpochCases.ModifiedJulianDayCases;

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

internal static class Datasets
{
    public static ModifiedJulianDay GetNullModifiedJulianDay() => null!;
    public static ModifiedJulianDay GetConvertibleModifiedJulianDay() => ModifiedJulianDayValues.SupportingJulianDayConversion.First();

    public static JulianDay GetNullJulianDay() => null!;
    public static JulianDay GetValidJulianDay() => JulianDayValues.SupportingModifiedJulianDayConversion.First();

    public static IEpoch GetNullIEpoch() => null!;

    public static class ModifiedJulianDayDoubleValues
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

        public static IEnumerable<double> SupportingJulianDayConversion => new[]
        {
            0,
            int.MinValue,
            double.Pi,
            -double.E
        };

        public static IEnumerable<double> NotSupportingJulianDayConversion => new[]
        {
            int.MaxValue + 0.99999,
            int.MaxValue - 2000000
        };
    }

    public static class JulianDayDoubleValues
    {
        public static IEnumerable<double> SupportingModifiedJulianDayConversion => new[]
        {
            0,
            int.MaxValue,
            int.MinValue + 2400001,
            double.Pi,
            -double.E
        };

        public static IEnumerable<double> NotSupportingModifiedJulianDayConversion => new double[]
        {
            int.MinValue,
            int.MinValue + 2000000
        };
    }

    public static class ModifiedJulianDayIntegralDayInt32Values
    {
        public static IEnumerable<int> SupportingJulianDayConversion => new[]
        {
            0,
            3,
            -2,
            int.MinValue,
            int.MaxValue - 2400001
        };

        public static IEnumerable<int> NotSupportingJulianDayConversion => new[]
        {
            int.MaxValue,
            int.MaxValue - 2000000
        };
    }

    public static class ModifiedJulianDayFractionalDayFloatValues
    {
        public static IEnumerable<float> Invalid => JulianDayCases.Datasets.JulianDayFractionalDayFloatValues.Invalid;
        public static IEnumerable<float> OutOfRange => JulianDayCases.Datasets.JulianDayFractionalDayFloatValues.OutOfRange;
        public static IEnumerable<float> Valid => JulianDayCases.Datasets.JulianDayFractionalDayFloatValues.Valid;
    }

    public static class ModifiedJulianDayValues
    {
        public static IEnumerable<ModifiedJulianDay> SupportingJulianDayConversion
        {
            get
            {
                foreach (var number in ModifiedJulianDayDoubleValues.SupportingJulianDayConversion)
                {
                    yield return new(number);
                }
            }
        }

        public static IEnumerable<ModifiedJulianDay> NotSupportingJulianDayConversion
        {
            get
            {
                foreach (var number in ModifiedJulianDayDoubleValues.NotSupportingJulianDayConversion)
                {
                    yield return new(number);
                }
            }
        }
    }

    public static class JulianDayValues
    {
        public static IEnumerable<JulianDay> SupportingModifiedJulianDayConversion
        {
            get
            {
                foreach (var number in JulianDayDoubleValues.SupportingModifiedJulianDayConversion)
                {
                    yield return new(number);
                }
            }
        }

        public static IEnumerable<JulianDay> NotSupportingModifiedJulianDayConversion
        {
            get
            {
                foreach (var number in JulianDayDoubleValues.NotSupportingModifiedJulianDayConversion)
                {
                    yield return new(number);
                }
            }
        }
    }

    public static class IEpochValues
    {
        public static IEnumerable<IEpoch> SupportingJulianDayOrModifiedJulianDayConversion
        {
            get
            {
                foreach (var epoch in JulianDayValues.SupportingModifiedJulianDayConversion)
                {
                    yield return epoch;
                }

                foreach (var epoch in JulianDayValues.NotSupportingModifiedJulianDayConversion)
                {
                    yield return epoch;
                }

                foreach (var epoch in ModifiedJulianDayValues.SupportingJulianDayConversion)
                {
                    yield return epoch;
                }

                foreach (var epoch in ModifiedJulianDayValues.NotSupportingJulianDayConversion)
                {
                    yield return epoch;
                }
            }
        }

        public static IEnumerable<IEpoch> NotSupportingJulianDayOrModifiedJulianDayConversion
        {
            get
            {
                yield return SloppyEpoch.GetExceptionThrowingSloppyEpoch();
            }
        }
    }

    public static IEnumerable<(ModifiedJulianDay, JulianDay)> ModifiedJulianDayAndEquivalentJulianDayValues => new[]
    {
        (new ModifiedJulianDay(-2400000.5), JulianDay.Epoch),
        (ModifiedJulianDay.Epoch, new JulianDay(2400000.5)),
        (new ModifiedJulianDay(-10005.329 - 2400000.5), new JulianDay(-10005.329)),
        (new ModifiedJulianDay(10005.329 - 2400000.5), new JulianDay(10005.329)),
        (new ModifiedJulianDay(10005.329), new JulianDay(10005.329 + 2400000.5)),
        (new ModifiedJulianDay(-10005.329), new JulianDay(-10005.329 + 2400000.5)),
        (new ModifiedJulianDay(int.MinValue + 0.789), new JulianDay(int.MinValue + 0.789 + 2400000.5)),
        (new ModifiedJulianDay(int.MaxValue - 0.789 - 2400000.5), new JulianDay(int.MaxValue - 0.789))
    };

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class InvalidModifiedJulianDayDouble : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(ModifiedJulianDayDoubleValues.Invalid).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class OutOfRangeModifiedJulianDayDouble : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(ModifiedJulianDayDoubleValues.OutOfRange).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class ConvertibleModifiedJulianDayDouble : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(ModifiedJulianDayDoubleValues.SupportingJulianDayConversion).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class UnconvertibleModifiedJulianDayDouble : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(ModifiedJulianDayDoubleValues.NotSupportingJulianDayConversion).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class ConvertibleModifiedJulianDayIntegralDayInt32_InvalidModifiedJulianDayFractionalDayFloat : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(DatasetUtility.Permutate(ModifiedJulianDayIntegralDayInt32Values.SupportingJulianDayConversion, ModifiedJulianDayFractionalDayFloatValues.Invalid)).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class UnconvertibleModifiedJulianDayIntegralDayInt32_InvalidModifiedJulianDayFractionalDayFloat : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(DatasetUtility.Permutate(ModifiedJulianDayIntegralDayInt32Values.NotSupportingJulianDayConversion, ModifiedJulianDayFractionalDayFloatValues.Invalid)).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class ConvertibleModifiedJulianDayIntegralDayInt32_OutOfRangeModifiedJulianDayFractionalDayFloat : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(DatasetUtility.Permutate(ModifiedJulianDayIntegralDayInt32Values.SupportingJulianDayConversion, ModifiedJulianDayFractionalDayFloatValues.OutOfRange)).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class UnconvertibleModifiedJulianDayIntegralDayInt32_OutOfRangeModifiedJulianDayFractionalDayFloat : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(DatasetUtility.Permutate(ModifiedJulianDayIntegralDayInt32Values.NotSupportingJulianDayConversion, ModifiedJulianDayFractionalDayFloatValues.OutOfRange)).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class ConvertibleModifiedJulianDayIntegralDayInt32_ValidModifiedJulianDayFractionalDayFloat : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(DatasetUtility.Permutate(ModifiedJulianDayIntegralDayInt32Values.SupportingJulianDayConversion, ModifiedJulianDayFractionalDayFloatValues.Valid)).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class UnconvertibleModifiedJulianDayIntegralDayInt32_ValidModifiedJulianDayFractionalDayFloat : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(DatasetUtility.Permutate(ModifiedJulianDayIntegralDayInt32Values.NotSupportingJulianDayConversion, ModifiedJulianDayFractionalDayFloatValues.Valid)).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class ConvertibleModifiedJulianDayIntegralDayInt32 : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(ModifiedJulianDayIntegralDayInt32Values.SupportingJulianDayConversion).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class UnconvertibleModifiedJulianDayIntegralDayInt32 : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(ModifiedJulianDayIntegralDayInt32Values.NotSupportingJulianDayConversion).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class InvalidModifiedJulianDayFractionalDayFloat : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(ModifiedJulianDayFractionalDayFloatValues.Invalid).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class OutOfRangeModifiedJulianDayFractionalDayFloat : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(ModifiedJulianDayFractionalDayFloatValues.OutOfRange).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class ValidModifiedJulianDayFractionalDayFloat : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(ModifiedJulianDayFractionalDayFloatValues.Valid).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class ConvertibleModifiedJulianDay : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(ModifiedJulianDayValues.SupportingJulianDayConversion).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class UnconvertibleModifiedJulianDay : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(ModifiedJulianDayValues.NotSupportingJulianDayConversion).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class ConvertibleModifiedJulianDay_ConvertibleModifiedJulianDay : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(DatasetUtility.Permutate(ModifiedJulianDayValues.SupportingJulianDayConversion, ModifiedJulianDayValues.SupportingJulianDayConversion)).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class ConvertibleModifiedJulianDay_UnconvertibleModifiedJulianDay : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(DatasetUtility.Permutate(ModifiedJulianDayValues.SupportingJulianDayConversion, ModifiedJulianDayValues.NotSupportingJulianDayConversion)).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class ConvertibleModifiedJulianDay_ConvertibleIEpoch : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(DatasetUtility.Permutate(ModifiedJulianDayValues.SupportingJulianDayConversion, IEpochValues.SupportingJulianDayOrModifiedJulianDayConversion)).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class ConvertibleModifiedJulianDay_UnconvertibleIEpoch : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(DatasetUtility.Permutate(ModifiedJulianDayValues.SupportingJulianDayConversion, IEpochValues.NotSupportingJulianDayOrModifiedJulianDayConversion)).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class UnconvertibleModifiedJulianDay_ConvertibleModifiedJulianDay : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(DatasetUtility.Permutate(ModifiedJulianDayValues.NotSupportingJulianDayConversion, ModifiedJulianDayValues.SupportingJulianDayConversion)).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class UnconvertibleModifiedJulianDay_UnconvertibleModifiedJulianDay : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(DatasetUtility.Permutate(ModifiedJulianDayValues.NotSupportingJulianDayConversion, ModifiedJulianDayValues.NotSupportingJulianDayConversion)).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class UnconvertibleModifiedJulianDay_ConvertibleIEpoch : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(DatasetUtility.Permutate(ModifiedJulianDayValues.NotSupportingJulianDayConversion, IEpochValues.SupportingJulianDayOrModifiedJulianDayConversion)).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class UnconvertibleModifiedJulianDay_UnconvertibleIEpoch : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(DatasetUtility.Permutate(ModifiedJulianDayValues.NotSupportingJulianDayConversion, IEpochValues.NotSupportingJulianDayOrModifiedJulianDayConversion)).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class ConvertibleJulianDay : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(JulianDayValues.SupportingModifiedJulianDayConversion).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class UnconvertibleJulianDay : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(JulianDayValues.NotSupportingModifiedJulianDayConversion).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class ConvertibleIEpoch : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(IEpochValues.SupportingJulianDayOrModifiedJulianDayConversion).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class UnconvertibleIEpoch : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(IEpochValues.NotSupportingJulianDayOrModifiedJulianDayConversion).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used as test input.")]
    public sealed class ModifiedJulianDayAndEquivalentJulianDay : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(ModifiedJulianDayAndEquivalentJulianDayValues).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
