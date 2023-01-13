namespace SharpHorizons.Tests.QueryCases.EpochCases.IUniformEpochRangeFactoryCases;

using SharpHorizons.Query.Epoch;

using SharpMeasures;

using System;

using Xunit;

public class Create_IEpochRangeFactory
{
    [Fact]
    public void NullStartEpoch_ArgumentNullException()
    {
        var startEpoch = GetNullEpoch();
        var stopEpoch = GetValidStopEpoch();
        var stepSize = GetValidStepSize();

        AnyError_TException<ArgumentNullException>(startEpoch, stopEpoch, stepSize);
    }

    [Fact]
    public void NullStopEpoch_ArgumentNullException()
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetNullEpoch();
        var stepSize = GetValidStepSize();

        AnyError_TException<ArgumentNullException>(startEpoch, stopEpoch, stepSize);
    }

    [Fact]
    public void NullStepSize_ArgumentNullException()
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetValidStopEpoch();
        var stepSize = GetNullStepSize();

        AnyError_TException<ArgumentNullException>(startEpoch, stopEpoch, stepSize);
    }

    [Fact]
    public void StopEpochEarlierThanStartEpochAndNullStepSize_ArgumentNullException()
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetEarlierStopEpoch();
        var stepSize = GetNullStepSize();

        AnyError_TException<ArgumentNullException>(startEpoch, stopEpoch, stepSize);
    }

    [Fact]
    public void StopEpochEarlierThanStartEpoch_ArgumentException()
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetEarlierStopEpoch();
        var stepSize = GetValidStepSize();

        AnyError_TException<ArgumentException>(startEpoch, stopEpoch, stepSize);
    }

    [Fact]
    public void StopEpochSameAsStartEpoch_ArgumentException()
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = startEpoch;
        var stepSize = GetValidStepSize();

        AnyError_TException<ArgumentException>(startEpoch, stopEpoch, stepSize);
    }

    private static void AnyError_TException<TException>(IEpoch startEpoch, IEpoch stopEpoch, IStepSize stepSize) where TException : Exception
    {
        var factory = GetService();

        var exception = Record.Exception(() => factory.Create(startEpoch, stopEpoch, stepSize));

        Assert.IsType<TException>(exception);
    }

    [Fact]
    public void Valid_ExactMatch()
    {
        var factory = GetService();

        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetValidStopEpoch();
        var stepSize = GetValidStepSize();

        var actual = factory.Create(startEpoch, stopEpoch, stepSize);

        Assert.Equal(startEpoch, actual.StartEpoch.Epoch);
        Assert.Equal(stopEpoch, actual.StopEpoch.Epoch);

        Assert.Equal(EpochSelectionMode.Range, actual.Selection);
        Assert.Equal(EpochFormat.JulianDays, actual.Format);
        Assert.Equal(CalendarType.Gregorian, actual.Calendar);
        Assert.Equal(TimeSystem.UT, actual.TimeSystem);
        Assert.Equal(Time.Zero, actual.Offset);
    }

    private static IUniformEpochRangeFactory GetService() => DependencyInjection.GetRequiredService<IUniformEpochRangeFactory>();

    private static IEpoch GetNullEpoch() => null!;
    private static IEpoch GetValidStartEpoch() => new JulianDay(0);
    private static IEpoch GetValidStopEpoch() => new JulianDay(1);
    private static IEpoch GetEarlierStopEpoch() => new JulianDay(-1);

    private static IStepSize GetNullStepSize() => null!;
    private static IStepSize GetValidStepSize()
    {
        var factory = DependencyInjection.GetRequiredService<IUniformStepSizeFactory>();

        return factory.Create(1);
    }
}
