namespace SharpHorizons.Tests.QueryCases.EpochCases.IAngularEpochRangeFactoryCases;

using SharpHorizons.Query.Epoch;

using SharpMeasures;

using System;

using Xunit;

internal static class Executor_Create
{
    public static void NullStartEpoch_ArgumentNullException(IAngularEpochRangeFactory factory) => NullStartEpoch_ArgumentNullException(factory.Create);
    public static void NullStartEpoch_ArgumentNullException(Func<IEpoch, IEpoch, Angle, IEpochRange> factory)
    {
        var startEpoch = GetNullEpoch();
        var stopEpoch = GetValidStopEpoch();
        var deltaAngle = GetValidAngle();

        AnyError_TException<ArgumentNullException>(factory, startEpoch, stopEpoch, deltaAngle);
    }

    public static void NullStopEpoch_ArgumentNullException(IAngularEpochRangeFactory factory) => NullStopEpoch_ArgumentNullException(factory.Create);
    public static void NullStopEpoch_ArgumentNullException(Func<IEpoch, IEpoch, Angle, IEpochRange> factory)
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetNullEpoch();
        var deltaAngle = GetValidAngle();

        AnyError_TException<ArgumentNullException>(factory, startEpoch, stopEpoch, deltaAngle);
    }

    public static void NullStartAndStopEpochs_ArgumentNullException(IAngularEpochRangeFactory factory) => NullStartAndStopEpochs_ArgumentNullException(factory.Create);
    public static void NullStartAndStopEpochs_ArgumentNullException(Func<IEpoch, IEpoch, Angle, IEpochRange> factory)
    {
        var startEpoch = GetNullEpoch();
        var stopEpoch = GetNullEpoch();
        var deltaAngle = GetValidAngle();

        AnyError_TException<ArgumentNullException>(factory, startEpoch, stopEpoch, deltaAngle);
    }

    public static void StopEpochEarlierThanStartEpoch_ArgumentException(IAngularEpochRangeFactory factory) => StopEpochEarlierThanStartEpoch_ArgumentException(factory.Create);
    public static void StopEpochEarlierThanStartEpoch_ArgumentException(Func<IEpoch, IEpoch, Angle, IEpochRange> factory)
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetEarlierStopEpoch();
        var deltaAngle = GetValidAngle();

        AnyError_TException<ArgumentException>(factory, startEpoch, stopEpoch, deltaAngle);
    }

    public static void StopEpochSameAsStartEpoch_ArgumentException(IAngularEpochRangeFactory factory) => StopEpochSameAsStartEpoch_ArgumentException(factory.Create);
    public static void StopEpochSameAsStartEpoch_ArgumentException(Func<IEpoch, IEpoch, Angle, IEpochRange> factory)
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = startEpoch;
        var deltaAngle = GetValidAngle();

        AnyError_TException<ArgumentException>(factory, startEpoch, stopEpoch, deltaAngle);
    }

    public static void InvalidDeltaAngle_ArgumentException(IAngularEpochRangeFactory factory, Angle deltaAngle) => InvalidDeltaAngle_ArgumentException(factory.Create, deltaAngle);
    public static void InvalidDeltaAngle_ArgumentException(Func<IEpoch, IEpoch, Angle, IEpochRange> factory, Angle deltaAngle)
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetValidStopEpoch();

        AnyError_TException<ArgumentException>(factory, startEpoch, stopEpoch, deltaAngle);
    }

    public static void OutOfRangeDeltaAngle_ArgumentOutOfRangeException(IAngularEpochRangeFactory factory, Angle deltaAngle) => OutOfRangeDeltaAngle_ArgumentOutOfRangeException(factory.Create, deltaAngle);
    public static void OutOfRangeDeltaAngle_ArgumentOutOfRangeException(Func<IEpoch, IEpoch, Angle, IEpochRange> factory, Angle deltaAngle)
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetValidStopEpoch();

        AnyError_TException<ArgumentOutOfRangeException>(factory, startEpoch, stopEpoch, deltaAngle);
    }

    public static void NullStartAndStopEpochsAndInvalidDeltaAngle_ArgumentException(IAngularEpochRangeFactory factory) => NullStartAndStopEpochsAndInvalidDeltaAngle_ArgumentException(factory.Create);
    public static void NullStartAndStopEpochsAndInvalidDeltaAngle_ArgumentException(Func<IEpoch, IEpoch, Angle, IEpochRange> factory)
    {
        var startEpoch = GetNullEpoch();
        var stopEpoch = GetNullEpoch();
        var deltaAngle = GetInvalidAngle();

        AnyError_TException<ArgumentException>(factory, startEpoch, stopEpoch, deltaAngle);
    }

    private static void AnyError_TException<TException>(Func<IEpoch, IEpoch, Angle, IEpochRange> factory, IEpoch startEpoch, IEpoch stopEpoch, Angle deltaAngle) where TException : Exception
    {
        var exception = Record.Exception(() => factory(startEpoch, stopEpoch, deltaAngle));

        Assert.IsType<TException>(exception);
    }

    public static void Valid_ExactMatch(IAngularEpochRangeFactory factory, Angle deltaAngle) => Valid_ExactMatch(factory.Create, deltaAngle);
    public static void Valid_ExactMatch(Func<IEpoch, IEpoch, Angle, IEpochRange> factory, Angle deltaAngle)
    {
        var startEpoch = GetValidStartEpoch();
        var stopEpoch = GetValidStopEpoch();

        var actual = factory(startEpoch, stopEpoch, deltaAngle);

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
