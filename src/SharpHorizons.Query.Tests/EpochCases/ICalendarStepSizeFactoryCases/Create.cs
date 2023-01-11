namespace SharpHorizons.Tests.QueryCases.EpochCases.ICalendarStepSizeFactoryCases;

using SharpHorizons.Query.Epoch;

using System;
using System.ComponentModel;

using Xunit;

public class Create
{
    [Theory]
    [ClassData(typeof(Datasets.OutOfRangeCountCombinations))]
    public void OutOfRangeCount_ArgumentOutOfRangeException(int count, CalendarStepSizeUnit unit)
    {
        AnyError_TException<ArgumentOutOfRangeException>(count, unit);
    }

    [Theory]
    [ClassData(typeof(Datasets.ForbiddenUnitCombinations))]
    public void ForbiddenUnit_ArgumentException(int count, CalendarStepSizeUnit unit)
    {
        AnyError_TException<ArgumentException>(count, unit);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidUnitCombinations))]
    public void InvalidUnit_InvalidEnumArgumentException(int count, CalendarStepSizeUnit unit)
    {
        AnyError_TException<InvalidEnumArgumentException>(count, unit);
    }

    private static void AnyError_TException<TException>(int count, CalendarStepSizeUnit unit) where TException : Exception
    {
        var factory = GetService();

        var exception = Record.Exception(() => factory.Create(count, unit));

        Assert.IsType<TException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidCombinations))]
    public void Valid_ExactMatch(int count, CalendarStepSizeUnit unit)
    {
        var factory = GetService();

        var actual = factory.Create(count, unit);

        Assert.Equal(count, actual.Count);
        Assert.Equal(unit, actual.Unit);
    }

    private static ICalendarStepSizeFactory GetService() => DependencyInjection.GetRequiredService<ICalendarStepSizeFactory>();
}
