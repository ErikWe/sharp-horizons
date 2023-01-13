namespace SharpHorizons.Tests.QueryCases.EpochCases.IAngularEpochRangeFactoryCases;

using SharpHorizons.Query.Epoch;

using SharpMeasures;

using System;

using Xunit;

internal static class Executor_Create
{
    public static void NullStartEpoch_ArgumentNullException(IAngularEpochRangeFactory factory)
    {
        var startEpoch = GetNullEpoch();
        var stopEpoch = GetValidStopEpoch();
        var deltaAngle = GetValidAngle();

        AnyError_TException<ArgumentNullException>(factory, startEpoch, stopEpoch, deltaAngle);
    }

    public static void NullStopEpoch_ArgumentNullException(IAngularEpochRangeFactory factory)
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetNullEpoch();
        var deltaAngle = GetValidAngle();

        AnyError_TException<ArgumentNullException>(factory, startEpoch, stopEpoch, deltaAngle);
    }

    public static void NullStartAndStopEpochs_ArgumentNullException(IAngularEpochRangeFactory factory)
    {
        var startEpoch = GetNullEpoch();
        var stopEpoch = GetNullEpoch();
        var deltaAngle = GetValidAngle();

        AnyError_TException<ArgumentNullException>(factory, startEpoch, stopEpoch, deltaAngle);
    }

    public static void StopEpochEarlierThanStartEpoch_ArgumentException(IAngularEpochRangeFactory factory)
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetEarlierStopEpoch();
        var deltaAngle = GetValidAngle();

        AnyError_TException<ArgumentException>(factory, startEpoch, stopEpoch, deltaAngle);
    }

    public static void StopEpochSameAsStartEpoch_ArgumentException(IAngularEpochRangeFactory factory)
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = startEpoch;
        var deltaAngle = GetValidAngle();

        AnyError_TException<ArgumentException>(factory, startEpoch, stopEpoch, deltaAngle);
    }

    public static void InvalidDeltaAngle_ArgumentException(IAngularEpochRangeFactory factory, Angle deltaAngle)
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetValidStopEpoch();

        AnyError_TException<ArgumentException>(factory, startEpoch, stopEpoch, deltaAngle);
    }

    public static void OutOfRangeDeltaAngle_ArgumentOutOfRangeException(IAngularEpochRangeFactory factory, Angle deltaAngle)
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetValidStopEpoch();

        AnyError_TException<ArgumentOutOfRangeException>(factory, startEpoch, stopEpoch, deltaAngle);
    }

    public static void NullStartAndStopEpochsAndInvalidDeltaAngle_ArgumentException(IAngularEpochRangeFactory factory)
    {
        var startEpoch = GetNullEpoch();
        var stopEpoch = GetNullEpoch();
        var deltaAngle = GetInvalidAngle();

        AnyError_TException<ArgumentException>(factory, startEpoch, stopEpoch, deltaAngle);
    }

    private static void AnyError_TException<TException>(IAngularEpochRangeFactory factory, IEpoch startEpoch, IEpoch stopEpoch, Angle deltaAngle) where TException : Exception
    {
        var exception = Record.Exception(() => factory.Create(startEpoch, stopEpoch, deltaAngle));

        Assert.IsType<TException>(exception);
    }

    public static void Valid_ExactMatch(IAngularEpochRangeFactory factory, Angle deltaAngle)
    {
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

    private static Angle GetInvalidAngle() => new(double.NaN);
    private static Angle GetValidAngle() => new(1);

    private static IEpoch GetNullEpoch() => null!;
    private static IEpoch GetValidStartEpoch() => new JulianDay(0);
    private static IEpoch GetValidStopEpoch() => new JulianDay(1);
    private static IEpoch GetEarlierStopEpoch() => new JulianDay(-1);
}
