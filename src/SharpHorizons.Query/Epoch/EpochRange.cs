﻿namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;

using SharpMeasures;

using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

/// <inheritdoc cref="IEpochRange"/>
internal sealed record class EpochRange : IEpochRange
{
    public required IStartEpoch StartEpoch { get; init; }
    public required IStopEpoch StopEpoch { get; init; }
    public required IStepSize StepSize { get; init; }

    public EpochFormat Format { get; init; } = EpochFormat.JulianDays;
    public CalendarType Calendar { get; init; } = CalendarType.Gregorian;
    public TimeSystem TimeSystem { get; init; } = TimeSystem.UT;
    public Time UTCOffset { get; init; } = Time.Zero;

    /// <summary>Used to compose <see cref="IStartEpochArgument"/> that describe <see cref="StartEpoch"/>.</summary>
    public required IStartEpochComposer<IEpochRange> StartEpochComposer { private get; init; }

    /// <summary>Used to compose <see cref="IStopEpochArgument"/> that describe <see cref="StopEpoch"/>.</summary>
    public required IStopEpochComposer<IEpochRange> StopEpochComposer { private get; init; }

    /// <summary>Used to compose <see cref="ICalendarTypeArgument"/> that describe <see cref="Calendar"/>.</summary>
    public required IEpochCalendarComposer CalendarComposer { private get; init; }

    /// <summary>Used to compose <see cref="ITimeSystemArgument"/> that describe <see cref="TimeSystem"/>.</summary>
    public required ITimeSystemComposer TimeSystemComposer { private get; init; }

    /// <summary>Used to compose <see cref="ITimeZoneArgument"/> that describe <see cref="UTCOffset"/>.</summary>
    public required ITimeZoneComposer TimeZoneComposer { private get; init; }

    /// <inheritdoc cref="EpochRange"/>
    public EpochRange() { }

    /// <inheritdoc cref="EpochRange"/>
    /// <param name="startEpoch"><inheritdoc cref="StartEpoch" path="/summary"/></param>
    /// <param name="stopEpoch"><inheritdoc cref="StopEpoch" path="/summary"/></param>
    /// <param name="stepSize"><inheritdoc cref="StepSize" path="/summary"/></param>
    /// <param name="startEpochComposer"><inheritdoc cref="StartEpochComposer" path="/summary"/></param>
    /// <param name="stopEpochComposer"><inheritdoc cref="StopEpochComposer" path="/summary"/></param>
    /// <param name="calendarComposer"><inheritdoc cref="CalendarComposer" path="/summary"/></param>
    /// <param name="timeSystemComposer"><inheritdoc cref="TimeSystemComposer" path="/summary"/></param>
    /// <param name="timeZoneComposer"><inheritdoc cref="TimeZoneComposer" path="/summary"/></param>
    [SetsRequiredMembers]
    public EpochRange(IStartEpoch startEpoch, IStopEpoch stopEpoch, IStepSize stepSize, IStartEpochComposer<IEpochRange> startEpochComposer, IStopEpochComposer<IEpochRange> stopEpochComposer, IEpochCalendarComposer calendarComposer, ITimeSystemComposer timeSystemComposer, ITimeZoneComposer timeZoneComposer)
    {
        StartEpoch = startEpoch;
        StopEpoch = stopEpoch;

        StepSize = stepSize;

        StartEpochComposer = startEpochComposer;
        StopEpochComposer = stopEpochComposer;
        CalendarComposer = calendarComposer;
        TimeSystemComposer = timeSystemComposer;
        TimeZoneComposer = timeZoneComposer;
    }

    public IEpochRange WithFormat(EpochFormat format)
    {
        ValidateEpochFormat(format);

        return this with { Format = format };
    }

    public IEpochRange WithCalendar(CalendarType calendar)
    {
        ValidateCalendarType(calendar);

        return this with { Calendar = calendar };
    }

    public IEpochRange WithTimeSystem(TimeSystem timeSystem)
    {
        ValidateTimeSystem(timeSystem);

        return this with { TimeSystem = timeSystem };
    }

    public IEpochRange WithUTCOffset(Time utcOffset)
    {
        ValidateUTCOffset(utcOffset);

        return this with { UTCOffset = utcOffset };
    }

    public IEpochRange WithConfiguration(EpochFormat? format, CalendarType? calendar, TimeSystem? timeSystem, Time? utcOffset)
    {
        if (format is not null)
        {
            ValidateEpochFormat(format.Value);
        }

        if (calendar is not null)
        {
            ValidateCalendarType(calendar.Value);
        }

        if (timeSystem is not null)
        {
            ValidateTimeSystem(timeSystem.Value);
        }

        if (utcOffset is not null)
        {
            ValidateUTCOffset(utcOffset.Value);
        }

        return this with
        {
            Format = format ?? Format,
            Calendar = calendar ?? Calendar,
            TimeSystem = timeSystem ?? TimeSystem,
            UTCOffset = utcOffset ?? UTCOffset
        };
    }

    IEpochSelection IEpochSelection.WithFormat(EpochFormat format) => WithFormat(format);
    IEpochSelection IEpochSelection.WithCalendar(CalendarType calendar) => WithCalendar(calendar);
    IEpochSelection IEpochSelection.WithTimeSystem(TimeSystem timeSystem) => WithTimeSystem(timeSystem);
    IEpochSelection IEpochSelection.WithUTCOffset(Time utcOffset) => WithUTCOffset(utcOffset);
    IEpochSelection IEpochSelection.WithConfiguration(EpochFormat? format, CalendarType? calendar, TimeSystem? timeSystem, Time? utcOffset) => WithConfiguration(format, calendar, timeSystem, utcOffset);

    EpochSelectionMode IEpochSelection.SelectionMode => EpochSelectionMode.Range;
    IEpochCollectionArgument IEpochSelection.ComposeCollectionArgument() => throw UnsupportedEpochSelectionModeException.EpochSelectionNotCollection();
    IEpochCollectionFormatArgument IEpochSelection.ComposeCollectionFormatArgument() => throw UnsupportedEpochSelectionModeException.EpochSelectionNotCollection();
    ICalendarTypeArgument IEpochSelection.ComposeEpochCalendarArgument() => CalendarComposer.Compose(Calendar);
    ITimeSystemArgument IEpochSelection.ComposeTimeSystemArgument() => TimeSystemComposer.Compose(TimeSystem);
    ITimeZoneArgument IEpochSelection.ComposeTimeZoneArgument() => TimeZoneComposer.Compose(UTCOffset);
    IStartEpochArgument IEpochSelection.ComposeStartEpochArgument() => StartEpochComposer.Compose(this);
    IStopEpochArgument IEpochSelection.ComposeStopEpochArgument() => StopEpochComposer.Compose(this);
    IStepSizeArgument IEpochSelection.ComposeStepSizeArgument() => StepSize.ComposeArgument();

    /// <summary>Validates the <see cref="EpochFormat"/> <paramref name="format"/>, throwing an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="format">This <see cref="EpochFormat"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="format"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    private static void ValidateEpochFormat(EpochFormat format, [CallerArgumentExpression(nameof(format))] string? argumentExpression = null)
    {
        InvalidEnumArgumentExceptionUtility.ThrowIfUnlisted(format, argumentExpression);

        if (format is EpochFormat.Unknown)
        {
            throw ArgumentExceptionFactory.UnsupportedEnumValue(format, argumentExpression);
        }
    }

    /// <summary>Validates the <see cref="CalendarType"/> <paramref name="calendar"/>, throwing an <see cref="InvalidEnumArgumentException"/> if invalid.</summary>
    /// <param name="calendar">This <see cref="CalendarType"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="calendar"/>.</param>
    /// <exception cref="InvalidEnumArgumentException"/>
    private static void ValidateCalendarType(CalendarType calendar, [CallerArgumentExpression(nameof(calendar))] string? argumentExpression = null)
    {
        InvalidEnumArgumentExceptionUtility.ThrowIfUnlisted(calendar, argumentExpression);

        if (calendar is CalendarType.Unknown)
        {
            throw ArgumentExceptionFactory.UnsupportedEnumValue(calendar, argumentExpression);
        }
    }

    /// <summary>Validates the <see cref="Epoch.TimeSystem"/> <paramref name="timeSystem"/>, throwing an <see cref="InvalidEnumArgumentException"/> if invalid.</summary>
    /// <param name="timeSystem">This <see cref="Epoch.TimeSystem"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="timeSystem"/>.</param>
    /// <exception cref="InvalidEnumArgumentException"/>
    private static void ValidateTimeSystem(TimeSystem timeSystem, [CallerArgumentExpression(nameof(timeSystem))] string? argumentExpression = null)
    {
        InvalidEnumArgumentExceptionUtility.ThrowIfUnlisted(timeSystem, argumentExpression);

        if (timeSystem is TimeSystem.Unknown)
        {
            throw ArgumentExceptionFactory.UnsupportedEnumValue(timeSystem, argumentExpression);
        }
    }

    /// <summary>Validates the <see cref="Time"/> <paramref name="utcOffset"/>, throwing an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="utcOffset">This <see cref="Time"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="utcOffset"/>.</param>
    /// <exception cref="ArgumentException"/>
    private static void ValidateUTCOffset(Time utcOffset, [CallerArgumentExpression(nameof(utcOffset))] string? argumentExpression = null)
    {
        SharpMeasuresValidation.Validate(utcOffset, argumentExpression);
    }
}
