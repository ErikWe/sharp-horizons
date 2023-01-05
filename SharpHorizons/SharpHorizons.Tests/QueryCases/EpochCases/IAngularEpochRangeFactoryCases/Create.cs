namespace SharpHorizons.Tests.QueryCases.EpochCases.IAngularEpochRangeFactoryCases;

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
        var deltaAngle = GetValidAngle();

        AnyError_TException<ArgumentNullException>(startEpoch, stopEpoch, deltaAngle);
    }

    [Fact]
    public void NullStopEpoch_ArgumentNullException()
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetNullEpoch();
        var deltaAngle = GetValidAngle();

        AnyError_TException<ArgumentNullException>(startEpoch, stopEpoch, deltaAngle);
    }

    [Fact]
    public void NullStartAndStopEpochs_ArgumentNullException()
    {
        var startEpoch = GetNullEpoch();
        var stopEpoch = GetNullEpoch();
        var deltaAngle = GetValidAngle();

        AnyError_TException<ArgumentNullException>(startEpoch, stopEpoch, deltaAngle);
    }

    [Fact]
    public void StopEpochEarlierThanStartEpoch_ArgumentException()
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetEarlierStopEpoch();
        var deltaAngle = GetValidAngle();

        AnyError_TException<ArgumentException>(startEpoch, stopEpoch, deltaAngle);
    }

    [Fact]
    public void StopEpochSameAsStartEpoch_ArgumentException()
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = startEpoch;
        var deltaAngle = GetValidAngle();

        AnyError_TException<ArgumentException>(startEpoch, stopEpoch, deltaAngle);
    }

    [Theory]
    [ClassData(typeof(Datasets.InvalidDeltaAngles))]
    public void InvalidDeltaAngle_ArgumentException(Angle deltaAngle)
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetValidStopEpoch();

        AnyError_TException<ArgumentException>(startEpoch, stopEpoch, deltaAngle);
    }

    [Theory]
    [ClassData(typeof(Datasets.OutOfRangeDeltaAngles))]
    public void OutOfRangeDeltaAngle_ArgumentOutOfRangeException(Angle deltaAngle)
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetValidStopEpoch();

        AnyError_TException<ArgumentOutOfRangeException>(startEpoch, stopEpoch, deltaAngle);
    }

    [Fact]
    public void NullStartAndStopEpochsAndInvalidDeltaAngle_ArgumentException()
    {
        var startEpoch = GetNullEpoch();
        var stopEpoch = GetNullEpoch();
        var deltaAngle = GetInvalidAngle();

        AnyError_TException<ArgumentException>(startEpoch, stopEpoch, deltaAngle);
    }

    private static void AnyError_TException<TException>(IEpoch startEpoch, IEpoch stopEpoch, Angle deltaAngle) where TException : Exception
    {
        var factory = GetService();

        var exception = Record.Exception(() => factory.Create(startEpoch, stopEpoch, deltaAngle));

        Assert.IsType<TException>(exception);
    }

    [Theory]
    [ClassData(typeof(Datasets.ValidDeltaAngles))]
    public void Valid_ExactMatch(Angle deltaAngle)
    {
        var factory = GetService();

        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetValidStopEpoch();

        var actual = factory.Create(startEpoch, stopEpoch, deltaAngle);

        Assert.Equal(startEpoch, actual.StartEpoch.Epoch);
        Assert.Equal(stopEpoch, actual.StopEpoch.Epoch);

        Assert.Equal(EpochSelectionMode.Range, actual.Selection);
        Assert.Equal(EpochFormat.JulianDays, actual.Format);
        Assert.Equal(CalendarType.Gregorian, actual.Calendar);
        Assert.Equal(TimeSystem.UT, actual.TimeSystem);
        Assert.Equal(Time.Zero, actual.Offset);
    }

    private static IAngularEpochRangeFactory GetService() => DependencyInjection.GetRequiredService<IAngularEpochRangeFactory>();

    private static Angle GetInvalidAngle() => new(double.NaN);
    private static Angle GetValidAngle() => new(1);

    private static IEpoch GetNullEpoch() => null!;
    private static IEpoch GetValidStartEpoch() => new JulianDay(0);
    private static IEpoch GetValidStopEpoch() => new JulianDay(1);
    private static IEpoch GetEarlierStopEpoch() => new JulianDay(-1);
}
