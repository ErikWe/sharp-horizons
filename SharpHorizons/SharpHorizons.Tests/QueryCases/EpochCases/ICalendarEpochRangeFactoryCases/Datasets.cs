namespace SharpHorizons.Tests.QueryCases.EpochCases.ICalendarEpochRangeFactoryCases;

using SharpHorizons.Query.Epoch;

using System.Collections;
using System.Collections.Generic;

internal static class Datasets
{
    public class ValidCounts : IEnumerable<object?[]>
    {
        public static IEnumerable<int> Items => new int[]
        {
            1,
            int.MaxValue
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class OutOfRangeCounts : IEnumerable<object?[]>
    {
        public static IEnumerable<int> Items => new int[]
        {
            0,
            -1,
            int.MinValue
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class ValidUnits : IEnumerable<object?[]>
    {
        public static IEnumerable<CalendarStepSizeUnit> Items => new CalendarStepSizeUnit[]
        {
            CalendarStepSizeUnit.Month,
            CalendarStepSizeUnit.Year
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class ForbiddenUnits : IEnumerable<object?[]>
    {
        public static IEnumerable<CalendarStepSizeUnit> Items => new CalendarStepSizeUnit[]
        {
            CalendarStepSizeUnit.Unknown
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class InvalidUnits : IEnumerable<object?[]>
    {
        public static IEnumerable<CalendarStepSizeUnit> Items => new CalendarStepSizeUnit[]
        {
            (CalendarStepSizeUnit)(-1),
            (CalendarStepSizeUnit)3
        };

        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.Wrap(Items).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class ValidCombinations : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(DatasetWrappers.Permutate(ValidCounts.Items, ValidUnits.Items)).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class OutOfRangeCountCombinations : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(DatasetWrappers.Permutate(OutOfRangeCounts.Items, ValidUnits.Items)).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class ForbiddenUnitCombinations : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(DatasetWrappers.Permutate(ValidCounts.Items, ForbiddenUnits.Items)).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class InvalidUnitCombinations : IEnumerable<object?[]>
    {
        public IEnumerator<object?[]> GetEnumerator() => DatasetWrappers.SeparateAndWrap(DatasetWrappers.Permutate(ValidCounts.Items, InvalidUnits.Items)).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
