namespace SharpHorizons.Tests.QueryCases.EpochCases.IFixedEpochRangeFactoryCases;

using SharpHorizons.Query.Epoch;

using SharpMeasures;

using System;

using Xunit;

public class Create
{
    [Fact]
    public void NullStartEpoch_ArgumentNullException()
    {
        var startEpoch = GetNullEpoch();
        var stopEpoch = GetValidStopEpoch();
        var deltaTime = GetValidTime();

        AnyError_TException<ArgumentNullException>(startEpoch, stopEpoch, deltaTime);
    }

    [Fact]
    public void NullStopEpoch_ArgumentNullException()
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetNullEpoch();
        var deltaTime = GetValidTime();

        AnyError_TException<ArgumentNullException>(startEpoch, stopEpoch, deltaTime);
    }

    [Fact]
    public void NullStartAndStopEpochs_ArgumentNullException()
    {
        var startEpoch = GetNullEpoch();
        var stopEpoch = GetNullEpoch();
        var deltaTime = GetValidTime();

        AnyError_TException<ArgumentNullException>(startEpoch, stopEpoch, deltaTime);
    }

    [Fact]
    public void StopEpochEarlierThanStartEpoch_ArgumentException()
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetEarlierStopEpoch();
        var deltaTime = GetValidTime();

        AnyError_TException<ArgumentException>(startEpoch, stopEpoch, deltaTime);
    }

    [Fact]
    public void StopEpochSameAsStartEpoch_ArgumentException()
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = startEpoch;
        var deltaTime = GetValidTime();

        AnyError_TException<ArgumentException>(startEpoch, stopEpoch, deltaTime);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidDeltaTimes))]
    public void InvalidDeltaTime_ArgumentException(Time deltaTime)
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetValidStopEpoch();

        AnyError_TException<ArgumentException>(startEpoch, stopEpoch, deltaTime);
    }

    [Theory]
    [ClassData(typeof(Datasets.OutOfRangeDeltaTimes))]
    public void OutOfRangeDeltaTime_ArgumentOutOfRangeException(Time deltaTime)
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetValidStopEpoch();

        AnyError_TException<ArgumentOutOfRangeException>(startEpoch, stopEpoch, deltaTime);
    }

    [Fact]
    public void NullStartAndStopEpochsAndInvalidDeltaTime_ArgumentException()
    {
        var startEpoch = GetNullEpoch();
        var stopEpoch = GetNullEpoch();
        var deltaTime = GetInvalidTime();

        AnyError_TException<ArgumentException>(startEpoch, stopEpoch, deltaTime);
    }

    private static void AnyError_TException<TException>(IEpoch startEpoch, IEpoch stopEpoch, Time deltaTime) where TException : Exception
    {
        var factory = GetService();

        var exception = Record.Exception(() => factory.Create(startEpoch, stopEpoch, deltaTime));

        Assert.IsType<TException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidDeltaTimes))]
    public void Valid_ExactMatch(Time deltaTime)
    {
        var factory = GetService();

        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetValidStopEpoch();

        var actual = factory.Create(startEpoch, stopEpoch, deltaTime);

        Assert.Equal(startEpoch, actual.StartEpoch.Epoch);
        Assert.Equal(stopEpoch, actual.StopEpoch.Epoch);

        Assert.Equal(EpochSelectionMode.Range, actual.Selection);
        Assert.Equal(EpochFormat.JulianDays, actual.Format);
        Assert.Equal(CalendarType.Gregorian, actual.Calendar);
        Assert.Equal(TimeSystem.UT, actual.TimeSystem);
        Assert.Equal(Time.Zero, actual.Offset);
    }

    private static IFixedEpochRangeFactory GetService() => DependencyInjection.GetRequiredService<IFixedEpochRangeFactory>();

    private static Time GetInvalidTime() => new(double.NaN);
    private static Time GetValidTime() => new(1);

    private static IEpoch GetNullEpoch() => null!;
    private static IEpoch GetValidStartEpoch() => new JulianDay(0);
    private static IEpoch GetValidStopEpoch() => new JulianDay(1);
    private static IEpoch GetEarlierStopEpoch() => new JulianDay(-1);
}
