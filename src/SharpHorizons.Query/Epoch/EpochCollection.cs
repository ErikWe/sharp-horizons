namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;

using SharpMeasures;

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;

/// <inheritdoc cref="IEpochCollection"/>
internal sealed record class EpochCollection : IEpochCollection
{
    public required IEnumerable<IEpoch> Epochs { get; init; }

    public EpochFormat Format { get; init; } = EpochFormat.JulianDays;
    public CalendarType Calendar { get; init; } = CalendarType.Gregorian;
    public TimeSystem TimeSystem { get; init; } = TimeSystem.UT;
    public Time Offset { get; init; } = Time.Zero;

    /// <summary>Used to compose <see cref="IEpochCollectionArgument"/> that describe <see langword="this"/>.</summary>
    public required IEpochCollectionComposer<IEpochCollection> Composer { private get; init; }

    /// <summary>Used to compose <see cref="IEpochCollectionFormatArgument"/> that describe <see cref="Format"/>.</summary>
    public required IEpochCollectionFormatComposer FormatComposer { private get; init; }

    /// <summary>Used to compose <see cref="ICalendarTypeArgument"/> that describe <see cref="Calendar"/>.</summary>
    public required IEpochCalendarComposer CalendarComposer { private get; init; }

    /// <summary>Used to compose <see cref="ITimeSystemArgument"/> that describe <see cref="TimeSystem"/>.</summary>
    public required ITimeSystemComposer TimeSystemComposer { private get; init; }

    /// <summary>Used to compose <see cref="ITimeZoneArgument"/> that describe <see cref="Offset"/>.</summary>
    public required ITimeZoneComposer TimeZoneComposer { private get; init; }

    /// <inheritdoc cref="EpochCollection"/>
    public EpochCollection() { }

    /// <inheritdoc cref="EpochCollection"/>
    /// <param name="epochs"><inheritdoc cref="Epochs" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    /// <param name="formatComposer"><inheritdoc cref="FormatComposer" path="/summary"/></param>
    /// <param name="calendarComposer"><inheritdoc cref="CalendarComposer" path="/summary"/></param>
    /// <param name="timeSystemComposer"><inheritdoc cref="TimeSystemComposer" path="/summary"/></param>
    /// <param name="timeZoneComposer"><inheritdoc cref="TimeZoneComposer" path="/summary"/></param>
    [SetsRequiredMembers]
    public EpochCollection(IEnumerable<IEpoch> epochs, IEpochCollectionComposer<IEpochCollection> composer, IEpochCollectionFormatComposer formatComposer, IEpochCalendarComposer calendarComposer, ITimeSystemComposer timeSystemComposer, ITimeZoneComposer timeZoneComposer)
    {
        Epochs = epochs;

        Composer = composer;
        FormatComposer = formatComposer;
        CalendarComposer = calendarComposer;
        TimeSystemComposer = timeSystemComposer;
        TimeZoneComposer = timeZoneComposer;
    }

    EpochSelectionMode IEpochSelection.Selection => EpochSelectionMode.Collection;

    IEpochCollectionArgument IEpochSelection.ComposeCollectionArgument() => Composer.Compose(this);
    IEpochCollectionFormatArgument IEpochSelection.ComposeCollectionFormatArgument() => FormatComposer.Compose(Format);
    ICalendarTypeArgument IEpochSelection.ComposeEpochCalendarArgument() => CalendarComposer.Compose(Calendar);
    ITimeSystemArgument IEpochSelection.ComposeTimeSystemArgument() => TimeSystemComposer.Compose(TimeSystem);
    ITimeZoneArgument IEpochSelection.ComposeTimeZoneArgument() => TimeZoneComposer.Compose(Offset);
    IStartEpochArgument IEpochSelection.ComposeStartTimeArgument() => throw UnsupportedEpochSelectionModeException.EpochSelectionNotRange();
    IStopEpochArgument IEpochSelection.ComposeStopTimeArgument() => throw UnsupportedEpochSelectionModeException.EpochSelectionNotRange();
    IStepSizeArgument IEpochSelection.ComposeStepSizeArgument() => throw UnsupportedEpochSelectionModeException.EpochSelectionNotRange();

    public IEpochCollection Concat(IEnumerable<IEpoch> epochs)
    {
        ArgumentNullException.ThrowIfNull(epochs);

        return this with { Epochs = Epochs.Concat(epochs) };
    }

    public IEpochCollection WithConfiguration(EpochFormat format)
    {
        ValidateEpochFormat(format);

        return this with { Format = format };
    }

    public IEpochCollection WithConfiguration(CalendarType calendar)
    {
        ValidateCalendarType(calendar);

        return this with { Calendar = calendar };
    }

    public IEpochCollection WithConfiguration(TimeSystem timeSystem)
    {
        ValidateTimeSystem(timeSystem);

        return this with { TimeSystem = timeSystem };
    }

    public IEpochCollection WithConfiguration(Time offset)
    {
        ValidateOffset(offset);

        return this with { Offset = offset };
    }

    public IEpochCollection WithConfiguration(EpochFormat? format, CalendarType? calendar, TimeSystem? timeSystem, Time? offset)
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

        if (offset is not null)
        {
            ValidateOffset(offset.Value);
        }

        return this with
        {
            Format = format ?? Format,
            Calendar = calendar ?? Calendar,
            TimeSystem = timeSystem ?? TimeSystem,
            Offset = offset ?? Offset
        };
    }

    IEpochSelection IEpochSelection.WithConfiguration(EpochFormat format) => WithConfiguration(format);
    IEpochSelection IEpochSelection.WithConfiguration(CalendarType calendar) => WithConfiguration(calendar);
    IEpochSelection IEpochSelection.WithConfiguration(TimeSystem timeSystem) => WithConfiguration(timeSystem);
    IEpochSelection IEpochSelection.WithConfiguration(Time offset) => WithConfiguration(offset);
    IEpochSelection IEpochSelection.WithConfiguration(EpochFormat? format, CalendarType? calendar, TimeSystem? timeSystem, Time? offset) => WithConfiguration(format, calendar, timeSystem, offset);

    public IEnumerator<IEpoch> GetEnumerator() => Epochs.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

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

    /// <summary>Validates the <see cref="Time"/> <paramref name="offset"/>, throwing an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="offset">This <see cref="Time"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="offset"/>.</param>
    /// <exception cref="ArgumentException"/>
    private static void ValidateOffset(Time offset, [CallerArgumentExpression(nameof(offset))] string? argumentExpression = null)
    {
        SharpMeasuresValidation.Validate(offset, argumentExpression);
    }
}
