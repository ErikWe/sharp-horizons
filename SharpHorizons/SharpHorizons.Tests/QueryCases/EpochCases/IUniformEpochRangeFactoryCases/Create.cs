namespace SharpHorizons.Tests.QueryCases.EpochCases.IUniformEpochRangeFactoryCases;

using SharpHorizons.Query.Epoch;

using SharpMeasures;

using System;

using Xunit;

public class Create
{
    [Fact]
    public void NullStartEpoch_ArgumentNullException()
    {
        var startEpoch = GetInvalidEpoch();
        var stopEpoch = GetValidStopEpoch();
        var stepCount = GetValidStepCount();

        AnyError_TException<ArgumentNullException>(startEpoch, stopEpoch, stepCount);
    }

    [Fact]
    public void NullStopEpoch_ArgumentNullException()
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetInvalidEpoch();
        var stepCount = GetValidStepCount();

        AnyError_TException<ArgumentNullException>(startEpoch, stopEpoch, stepCount);
    }

    [Fact]
    public void NullStartAndStopEpochs_ArgumentNullException()
    {
        var startEpoch = GetInvalidEpoch();
        var stopEpoch = GetInvalidEpoch();
        var stepCount = GetValidStepCount();

        AnyError_TException<ArgumentNullException>(startEpoch, stopEpoch, stepCount);
    }

    [Fact]
    public void StopEpochEarlierThanStartEpoch_ArgumentException()
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetEarlierStopEpoch();
        var stepCount = GetValidStepCount();

        AnyError_TException<ArgumentException>(startEpoch, stopEpoch, stepCount);
    }

    [Fact]
    public void StopEpochSameAsStartEpoch_ArgumentException()
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = startEpoch;
        var stepCount = GetValidStepCount();

        AnyError_TException<ArgumentException>(startEpoch, stopEpoch, stepCount);
    }

    [Theory]
    [ClassData(typeof(Datasets.OutOfRangeStepCounts))]
    public void OutOfRangeStepCount_ArgumentOutOfRangeException(int stepCount)
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetValidStopEpoch();

        AnyError_TException<ArgumentOutOfRangeException>(startEpoch, stopEpoch, stepCount);
    }

    [Fact]
    public void NullStartAndStopEpochsAndOutOfRangeStepCount_ArgumentOutOfRangeException()
    {
        var startEpoch = GetInvalidEpoch();
        var stopEpoch = GetInvalidEpoch();
        var stepCount = GetOutOfRangeStepCount();

        AnyError_TException<ArgumentOutOfRangeException>(startEpoch, stopEpoch, stepCount);
    }

    private static void AnyError_TException<TException>(IEpoch startEpoch, IEpoch stopEpoch, int stepCount) where TException : Exception
    {
        var factory = GetService();

        var exception = Record.Exception(() => factory.Create(startEpoch, stopEpoch, stepCount));

        Assert.IsType<TException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidStepCounts))]
    public void Valid_ExactMatch(int stepCount)
    {
        var factory = GetService();

        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetValidStopEpoch();

        var actual = factory.Create(startEpoch, stopEpoch, stepCount);

        Assert.Equal(startEpoch, actual.StartEpoch.Epoch);
        Assert.Equal(stopEpoch, actual.StopEpoch.Epoch);

        Assert.Equal(EpochSelectionMode.Range, actual.Selection);
        Assert.Equal(EpochFormat.JulianDays, actual.Format);
        Assert.Equal(CalendarType.Gregorian, actual.Calendar);
        Assert.Equal(TimeSystem.UT, actual.TimeSystem);
        Assert.Equal(Time.Zero, actual.Offset);
    }

    private static IUniformEpochRangeFactory GetService() => DependencyInjection.GetRequiredService<IUniformEpochRangeFactory>();

    private static int GetOutOfRangeStepCount() => 0;
    private static int GetValidStepCount() => 1;

    private static IEpoch GetInvalidEpoch() => null!;
    private static IEpoch GetValidStartEpoch() => new JulianDay(0);
    private static IEpoch GetValidStopEpoch() => new JulianDay(1);
    private static IEpoch GetEarlierStopEpoch() => new JulianDay(-1);
}
