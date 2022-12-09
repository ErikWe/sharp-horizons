namespace SharpHorizons.Tests.Epoch;

using NodaTime;

using SharpMeasures;

using System;
using System.Collections.Generic;
using System.Globalization;

using Xunit;

public class EpochMaths
{
    private static JulianCalendar JulianCalendar { get; } = new();
    private static GregorianCalendar GregorianCalendar { get; } = new();

    [Theory]
    [MemberData(nameof(InvalidTimes))]
    public void JulianDayInvalidTime(Time difference)
    {
        var initial = JulianDay.Epoch;

        Assert.Throws<ArgumentException>(() => initial.Add(difference));
        Assert.Throws<ArgumentException>(() => initial + difference);
        Assert.Throws<ArgumentException>(() => initial - difference);
    }

    [Theory]
    [MemberData(nameof(InvalidTimes))]
    public void ModifiedJulianDayInvalidTime(Time difference)
    {
        var initial = ModifiedJulianDay.Epoch;

        Assert.Throws<ArgumentException>(() => initial.Add(difference));
        Assert.Throws<ArgumentException>(() => initial + difference);
        Assert.Throws<ArgumentException>(() => initial - difference);
    }

    [Theory]
    [MemberData(nameof(InvalidTimes))]
    public void EpochInvalidTime(Time difference)
    {
        SharpHorizons.Epoch initial = new(Instant.FromJulianDate(0));

        Assert.Throws<ArgumentException>(() => initial.Add(difference));
        Assert.Throws<ArgumentException>(() => initial + difference);
        Assert.Throws<ArgumentException>(() => initial - difference);
    }

    [Theory]
    [MemberData(nameof(InvalidTimes))]
    public void DateTimeEpochInvalidTime(Time difference)
    {
        DateTimeEpoch initial = new(DateTimeOffset.UnixEpoch);

        Assert.Throws<ArgumentException>(() => initial.Add(difference));
        Assert.Throws<ArgumentException>(() => initial + difference);
        Assert.Throws<ArgumentException>(() => initial - difference);
    }

    [Fact]
    public void JulianDayOutOfBounds()
    {
        JulianDay initial = new(0);

        Time difference = new(double.MaxValue);

        Assert.Throws<EpochOutOfBoundsException>(() => initial.Add(difference));
        Assert.Throws<EpochOutOfBoundsException>(() => initial + difference);
        Assert.Throws<EpochOutOfBoundsException>(() => initial - difference);
    }

    [Fact]
    public void ModifiedJulianDayOutOfBounds()
    {
        ModifiedJulianDay initial = new(0);

        Time difference = new(double.MaxValue);

        Assert.Throws<EpochOutOfBoundsException>(() => initial.Add(difference));
        Assert.Throws<EpochOutOfBoundsException>(() => initial + difference);
        Assert.Throws<EpochOutOfBoundsException>(() => initial - difference);
    }

    [Fact]
    public void EpochOutOfBounds()
    {
        SharpHorizons.Epoch initial = new(Instant.FromJulianDate(0));

        Time difference = new(double.MaxValue);

        Assert.Throws<EpochOutOfBoundsException>(() => initial.Add(difference));
        Assert.Throws<EpochOutOfBoundsException>(() => initial + difference);
        Assert.Throws<EpochOutOfBoundsException>(() => initial - difference);
    }

    [Fact]
    public void DateTimeEpochOutOfBounds()
    {
        DateTimeEpoch initial = new(DateTimeOffset.UnixEpoch);

        Time difference = new(double.MaxValue);

        Assert.Throws<EpochOutOfBoundsException>(() => initial.Add(difference));
        Assert.Throws<EpochOutOfBoundsException>(() => initial + difference);
        Assert.Throws<EpochOutOfBoundsException>(() => initial - difference);
    }

    [Theory]
    [MemberData(nameof(JulianDayAddition))]
    public void JulianDayTimeAddition(double originalJulianDayNumber, Time difference, double expectedJulianDayNumber)
    {
        JulianDay expected = new(expectedJulianDayNumber);
        JulianDay original = new(originalJulianDayNumber);

        var operatorActual = original + difference;
        var methodActual = original.Add(difference);

        AssertApproximatelyEqual(expected, operatorActual);
        AssertApproximatelyEqual(expected, methodActual);
    }

    [Theory]
    [MemberData(nameof(JulianDayAddition))]
    public void JulianDayTimeSubtraction(double expectedJulianDayNumber, Time difference, double originalJulianDayNumber)
    {
        JulianDay expected = new(expectedJulianDayNumber);
        JulianDay original = new(originalJulianDayNumber);

        var operatorActual = original - difference;
        var methodActual = original.Add(-difference);

        AssertApproximatelyEqual(expected, operatorActual);
        AssertApproximatelyEqual(expected, methodActual);
    }

    [Theory]
    [MemberData(nameof(JulianDayAddition))]
    public void JulianDayDifference(double initialJulianDayNumber, Time expected, double finalJulianDayNumber)
    {
        JulianDay initial = new(initialJulianDayNumber);
        JulianDay final = new(finalJulianDayNumber);

        var operatorActual = final - initial;
        var methodActual = final.Difference(initial);

        AssertApproximatelyEqual(expected, operatorActual);
        AssertApproximatelyEqual(expected, methodActual);
    }

    [Theory]
    [MemberData(nameof(JulianDayAddition))]
    public void ModifiedJulianDayTimeAddition(double originalModifiedJulianDayNumber, Time difference, double expectedModifiedJulianDayNumber)
    {
        ModifiedJulianDay expected = new(expectedModifiedJulianDayNumber);
        ModifiedJulianDay original = new(originalModifiedJulianDayNumber);

        var operatorActual = original + difference;
        var methodActual = original.Add(difference);

        AssertApproximatelyEqual(expected, operatorActual);
        AssertApproximatelyEqual(expected, methodActual);
    }

    [Theory]
    [MemberData(nameof(JulianDayAddition))]
    public void ModifiedJulianDayTimeSubtraction(double expectedModifiedJulianDayNumber, Time difference, double originalModifiedJulianDayNumber)
    {
        ModifiedJulianDay expected = new(expectedModifiedJulianDayNumber);
        ModifiedJulianDay original = new(originalModifiedJulianDayNumber);

        var operatorActual = original - difference;
        var methodActual = original.Add(-difference);

        AssertApproximatelyEqual(expected, operatorActual);
        AssertApproximatelyEqual(expected, methodActual);
    }

    [Theory]
    [MemberData(nameof(JulianDayAddition))]
    public void ModifiedJulianDayDifference(double initialModifiedJulianDayNumber, Time expected, double finalModifiedJulianDayNumber)
    {
        ModifiedJulianDay initial = new(initialModifiedJulianDayNumber);
        ModifiedJulianDay final = new(finalModifiedJulianDayNumber);

        var operatorActual = final - initial;
        var methodActual = final.Difference(initial);

        AssertApproximatelyEqual(expected, operatorActual);
        AssertApproximatelyEqual(expected, methodActual);
    }

    [Theory]
    [MemberData(nameof(GregorianCalendarAddition))]
    public void GregorianCalendarTimeAddition(int originalYear, int originalMonth, int originalDay, int originalHour, int originalMinute, int originalSecond, int originalMillisecond, Time difference, int expectedYear, int expectedMonth, int expectedDay, int expectedHour, int expectedMinute, int expectedSecond, int expectedMillisecond)
    {
        var nodaOriginal = new SharpHorizons.Epoch(new LocalDateTime(originalYear, originalMonth, originalDay, originalHour, originalMinute, originalSecond, originalMillisecond, CalendarSystem.Gregorian).InUtc());
        var nodaExpected = new SharpHorizons.Epoch(new LocalDateTime(expectedYear, expectedMonth, expectedDay, expectedHour, expectedMinute, expectedSecond, expectedMillisecond, CalendarSystem.Gregorian).InUtc());

        var nodaOperatorActual = nodaOriginal + difference;
        var nodaMethodActual = nodaOriginal.Add(difference);

        AssertApproximatelyEqual(nodaExpected, nodaOperatorActual);
        AssertApproximatelyEqual(nodaExpected, nodaMethodActual);

        if (originalYear > 0)
        {
            var bclOriginal = new DateTimeEpoch(new DateTime(originalYear, originalMonth, originalDay, originalHour, originalMinute, originalSecond, originalMillisecond, GregorianCalendar), TimeSpan.Zero);
            var bclExpected = new DateTimeEpoch(new DateTime(expectedYear, expectedMonth, expectedDay, expectedHour, expectedMinute, expectedSecond, expectedMillisecond, GregorianCalendar), TimeSpan.Zero);

            var bclOperatorActual = bclOriginal + difference;
            var bclMethodActual = bclOriginal.Add(difference);

            AssertApproximatelyEqual(bclExpected, bclOperatorActual);
            AssertApproximatelyEqual(bclExpected, bclMethodActual);
        }
    }

    [Theory]
    [MemberData(nameof(GregorianCalendarAddition))]
    public void GregorianCalendarTimeSubtraction(int expectedYear, int expectedMonth, int expectedDay, int expectedHour, int expectedMinute, int expectedSecond, int expectedMillisecond, Time difference, int originalYear, int originalMonth, int originalDay, int originalHour, int originalMinute, int originalSecond, int originalMillisecond)
    {
        var nodaOriginal = new SharpHorizons.Epoch(new LocalDateTime(originalYear, originalMonth, originalDay, originalHour, originalMinute, originalSecond, originalMillisecond, CalendarSystem.Gregorian).InUtc());
        var nodaExpected = new SharpHorizons.Epoch(new LocalDateTime(expectedYear, expectedMonth, expectedDay, expectedHour, expectedMinute, expectedSecond, expectedMillisecond, CalendarSystem.Gregorian).InUtc());

        var nodaOperatorActual = nodaOriginal - difference;
        var nodaMethodActual = nodaOriginal.Add(-difference);

        AssertApproximatelyEqual(nodaExpected, nodaOperatorActual);
        AssertApproximatelyEqual(nodaExpected, nodaMethodActual);

        if (expectedYear > 0)
        {
            var bclOriginal = new DateTimeEpoch(new DateTime(originalYear, originalMonth, originalDay, originalHour, originalMinute, originalSecond, originalMillisecond, GregorianCalendar), TimeSpan.Zero);
            var bclExpected = new DateTimeEpoch(new DateTime(expectedYear, expectedMonth, expectedDay, expectedHour, expectedMinute, expectedSecond, expectedMillisecond, GregorianCalendar), TimeSpan.Zero);

            var bclOperatorActual = bclOriginal - difference;
            var bclMethodActual = bclOriginal.Add(-difference);

            AssertApproximatelyEqual(bclExpected, bclOperatorActual);
            AssertApproximatelyEqual(bclExpected, bclMethodActual);
        }
    }

    [Theory]
    [MemberData(nameof(GregorianCalendarAddition))]
    public void GregorianCalendarTimeDifference(int initialYear, int initialMonth, int initialDay, int initialHour, int initialMinute, int initialSecond, int initialMillisecond, Time expected, int finalYear, int finalMonth, int finalDay, int finalHour, int finalMinute, int finalSecond, int finalMillisecond)
    {
        var nodaInitial = new SharpHorizons.Epoch(new LocalDateTime(initialYear, initialMonth, initialDay, initialHour, initialMinute, initialSecond, initialMillisecond, CalendarSystem.Gregorian).InUtc());
        var nodaFinal = new SharpHorizons.Epoch(new LocalDateTime(finalYear, finalMonth, finalDay, finalHour, finalMinute, finalSecond, finalMillisecond, CalendarSystem.Gregorian).InUtc());

        var nodaOperatorActual = nodaFinal - nodaInitial;
        var nodaMethodActual = nodaFinal.Difference(nodaInitial);

        AssertApproximatelyEqual(expected, nodaOperatorActual);
        AssertApproximatelyEqual(expected, nodaMethodActual);

        if (initialYear > 0)
        {
            var bclInitial = new DateTimeEpoch(new DateTime(initialYear, initialMonth, initialDay, initialHour, initialMinute, initialSecond, initialMillisecond, GregorianCalendar), TimeSpan.Zero);
            var bclFinal = new DateTimeEpoch(new DateTime(finalYear, finalMonth, finalDay, finalHour, finalMinute, finalSecond, finalMillisecond, GregorianCalendar), TimeSpan.Zero);

            var bclOperatorActual = bclFinal - bclInitial;
            var bclMethodActual = bclFinal.Difference(bclInitial);

            AssertApproximatelyEqual(expected, bclOperatorActual);
            AssertApproximatelyEqual(expected, bclMethodActual);
        }
    }

    [Theory]
    [MemberData(nameof(JulianCalendarAddition))]
    public void JulianCalendarTimeAddition(int originalYear, int originalMonth, int originalDay, int originalHour, int originalMinute, int originalSecond, int originalMillisecond, Time difference, int expectedYear, int expectedMonth, int expectedDay, int expectedHour, int expectedMinute, int expectedSecond, int expectedMillisecond)
    {
        var nodaOriginal = new SharpHorizons.Epoch(new LocalDateTime(originalYear + (originalYear > 0 ? 0 : 1), originalMonth, originalDay, originalHour, originalMinute, originalSecond, originalMillisecond, CalendarSystem.Julian).InUtc());
        var nodaExpected = new SharpHorizons.Epoch(new LocalDateTime(expectedYear + (expectedYear > 0 ? 0 : 1), expectedMonth, expectedDay, expectedHour, expectedMinute, expectedSecond, expectedMillisecond, CalendarSystem.Julian).InUtc());

        var nodaOperatorActual = nodaOriginal + difference;
        var nodaMethodActual = nodaOriginal.Add(difference);

        AssertApproximatelyEqual(nodaExpected, nodaOperatorActual);
        AssertApproximatelyEqual(nodaExpected, nodaMethodActual);

        if (originalYear > 0)
        {
            var bclOriginal = new DateTimeEpoch(new DateTime(originalYear, originalMonth, originalDay, originalHour, originalMinute, originalSecond, originalMillisecond, JulianCalendar), TimeSpan.Zero);
            var bclExpected = new DateTimeEpoch(new DateTime(expectedYear, expectedMonth, expectedDay, expectedHour, expectedMinute, expectedSecond, expectedMillisecond, JulianCalendar), TimeSpan.Zero);

            var bclOperatorActual = bclOriginal + difference;
            var bclMethodActual = bclOriginal.Add(difference);

            AssertApproximatelyEqual(bclExpected, bclOperatorActual);
            AssertApproximatelyEqual(bclExpected, bclMethodActual);
        }
    }

    [Theory]
    [MemberData(nameof(JulianCalendarAddition))]
    public void JulianCalendarTimeSubtraction(int expectedYear, int expectedMonth, int expectedDay, int expectedHour, int expectedMinute, int expectedSecond, int expectedMillisecond, Time difference, int originalYear, int originalMonth, int originalDay, int originalHour, int originalMinute, int originalSecond, int originalMillisecond)
    {
        var nodaOriginal = new SharpHorizons.Epoch(new LocalDateTime(originalYear + (originalYear > 0 ? 0 : 1), originalMonth, originalDay, originalHour, originalMinute, originalSecond, originalMillisecond, CalendarSystem.Julian).InUtc());
        var nodaExpected = new SharpHorizons.Epoch(new LocalDateTime(expectedYear + (expectedYear > 0 ? 0 : 1), expectedMonth, expectedDay, expectedHour, expectedMinute, expectedSecond, expectedMillisecond, CalendarSystem.Julian).InUtc());

        var nodaOperatorActual = nodaOriginal - difference;
        var nodaMethodActual = nodaOriginal.Add(-difference);

        AssertApproximatelyEqual(nodaExpected, nodaOperatorActual);
        AssertApproximatelyEqual(nodaExpected, nodaMethodActual);

        if (expectedYear > 0)
        {
            var bclOriginal = new DateTimeEpoch(new DateTime(originalYear, originalMonth, originalDay, originalHour, originalMinute, originalSecond, originalMillisecond, JulianCalendar), TimeSpan.Zero);
            var bclExpected = new DateTimeEpoch(new DateTime(expectedYear, expectedMonth, expectedDay, expectedHour, expectedMinute, expectedSecond, expectedMillisecond, JulianCalendar), TimeSpan.Zero);

            var bclOperatorActual = bclOriginal - difference;
            var bclMethodActual = bclOriginal.Add(-difference);

            AssertApproximatelyEqual(bclExpected, bclOperatorActual);
            AssertApproximatelyEqual(bclExpected, bclMethodActual);
        }
    }

    [Theory]
    [MemberData(nameof(JulianCalendarAddition))]
    public void JulianCalendarTimeDifference(int initialYear, int initialMonth, int initialDay, int initialHour, int initialMinute, int initialSecond, int initialMillisecond, Time expected, int finalYear, int finalMonth, int finalDay, int finalHour, int finalMinute, int finalSecond, int finalMillisecond)
    {
        var nodaInitial = new SharpHorizons.Epoch(new LocalDateTime(initialYear + (initialYear > 0 ? 0 : 1), initialMonth, initialDay, initialHour, initialMinute, initialSecond, initialMillisecond, CalendarSystem.Julian).InUtc());
        var nodaFinal = new SharpHorizons.Epoch(new LocalDateTime(finalYear + (finalYear > 0 ? 0 : 1), finalMonth, finalDay, finalHour, finalMinute, finalSecond, finalMillisecond, CalendarSystem.Julian).InUtc());

        var nodaOperatorActual = nodaFinal - nodaInitial;
        var nodaMethodActual = nodaFinal.Difference(nodaInitial);

        AssertApproximatelyEqual(expected, nodaOperatorActual);
        AssertApproximatelyEqual(expected, nodaMethodActual);

        if (initialYear > 0)
        {
            var bclInitial = new DateTimeEpoch(new DateTime(initialYear, initialMonth, initialDay, initialHour, initialMinute, initialSecond, initialMillisecond, JulianCalendar), TimeSpan.Zero);
            var bclFinal = new DateTimeEpoch(new DateTime(finalYear, finalMonth, finalDay, finalHour, finalMinute, finalSecond, finalMillisecond, JulianCalendar), TimeSpan.Zero);

            var bclOperatorActual = bclFinal - bclInitial;
            var bclMethodActual = bclFinal.Difference(bclInitial);

            AssertApproximatelyEqual(expected, bclOperatorActual);
            AssertApproximatelyEqual(expected, bclMethodActual);
        }
    }

    private static void AssertApproximatelyEqual(JulianDay expected, JulianDay actual)
    {
        Assert.Equal(expected.Day, actual.Day, 3);
    }

    private static void AssertApproximatelyEqual(ModifiedJulianDay expected, ModifiedJulianDay actual)
    {
        Assert.Equal(expected.Day, actual.Day, 3);
    }

    private static void AssertApproximatelyEqual(SharpHorizons.Epoch expected, SharpHorizons.Epoch actual)
    {
        Assert.Equal(expected.Instant.ToJulianDate(), actual.Instant.ToJulianDate(), 3);
    }

    private static void AssertApproximatelyEqual(DateTimeEpoch expected, DateTimeEpoch actual)
    {
        Assert.Equal(expected.Offset, actual.Offset);

        Assert.True(expected.DateTime.Ticks * 1.001 > actual.DateTime.Ticks);
        Assert.True(expected.DateTime.Ticks * 0.999 < actual.DateTime.Ticks);
    }

    private static void AssertApproximatelyEqual(Time expected, Time actual)
    {
        Assert.Equal(expected.Days, actual.Days, 3);
    }

    public static IEnumerable<object[]> JulianDayAddition() => new object[][]
    {
        new object[] { 2, Time.OneHour * 6, 2.25 },
        new object[] { 0, Time.OneHour * 12, 0.5 },
        new object[] { -2, Time.OneDay * 2.5, 0.5 }
    };

    public static IEnumerable<object[]> GregorianCalendarAddition() => new object[][]
    {
        new object[] { 2020, 2, 28, 12, 0, 0, 0, Time.OneDay, 2020, 2, 29, 12, 0, 0, 0 },
        new object[] { 2021, 2, 28, 12, 0, 0, 0, Time.OneDay, 2021, 3, 1, 12, 0, 0, 0 },
        new object[] { -1, 12, 31, 12, 0, 0, 0, Time.OneDay, 0, 1, 1, 12, 0, 0, 0 },
        new object[] { 0, 12, 31, 12, 0, 0, 0, Time.OneDay, 1, 1, 1, 12, 0, 0, 0 }
    };

    public static IEnumerable<object[]> JulianCalendarAddition() => new object[][]
    {
        new object[] { 2020, 2, 28, 12, 0, 0, 0, Time.OneDay, 2020, 2, 29, 12, 0, 0, 0 },
        new object[] { 2021, 2, 28, 12, 0, 0, 0, Time.OneDay, 2021, 3, 1, 12, 0, 0, 0 },
        new object[] { -1, 12, 31, 12, 0, 0, 0, Time.OneDay, 1, 1, 1, 12, 0, 0, 0 }
    };

    public static IEnumerable<object[]> InvalidTimes() => new object[][]
    {
        new object[] { new Time(double.NaN) },
        new object[] { new Time(double.NegativeInfinity) },
        new object[] { new Time(double.PositiveInfinity) }
    };
}
