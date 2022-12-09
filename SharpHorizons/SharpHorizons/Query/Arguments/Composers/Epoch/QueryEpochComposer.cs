namespace SharpHorizons.Query.Arguments.Composers.Epoch;

using NodaTime;

using SharpHorizons.Query.Epoch;

using SharpMeasures;

using System;
using System.Globalization;
using System.Runtime.CompilerServices;

/// <inheritdoc cref="IQueryEpochComposer"/>
internal class QueryEpochComposer : IQueryEpochComposer
{
    /// <summary>The <see cref="JulianDay"/> of the change from the Julian calendar to the Gregorian calendar in Horizons.</summary>
    private static JulianDay CalendarChangeJulianDay { get; } = new(2299160.5);

    /// <inheritdoc cref="ITimeSystemOffsetProvider"/>
    private ITimeSystemOffsetProvider TimeSystemOffsetProvider { get; }

    /// <inheritdoc cref="QueryEpochComposer"/>
    /// <param name="timeSystemOffsetProvider"><inheritdoc cref="TimeSystemOffsetProvider" path="/summary"/></param>
    public QueryEpochComposer(ITimeSystemOffsetProvider? timeSystemOffsetProvider = null)
    {
        TimeSystemOffsetProvider = timeSystemOffsetProvider ?? new ZeroTimeSystemOffsetProvider();
    }

    string IQueryEpochComposer.Compose(QueryEpoch queryEpoch)
    {
        Validate(queryEpoch);

        var julianDay = ExpressEpoch(queryEpoch.Epoch, queryEpoch.TimeSystem, queryEpoch.Offset);

        return queryEpoch.Format switch
        {
            EpochFormat.CalendarDates => ComposeAsDate(julianDay, queryEpoch.Calendar),
            EpochFormat.JulianDays => ComposeAsDayNumbers(julianDay.Day),
            EpochFormat.ModifiedJulianDays => ComposeAsDayNumbers(ModifiedJulianDay.FromJulianDay(julianDay).Day),
            _ => throw ArgumentExceptionFactory.InvalidState<QueryEpoch>(nameof(queryEpoch))
        };
    }

    /// <summary>Composes a <see cref="string"/> describing <paramref name="dayNumber"/>.</summary>
    /// <param name="dayNumber">The composed <see cref="string"/> describes this day number.</param>
    private static string ComposeAsDayNumbers(double dayNumber) => dayNumber.ToString("F9", CultureInfo.InvariantCulture);

    /// <summary>Composes a <see cref="string"/> describing <paramref name="julianDay"/>, expressed as a date in <paramref name="calendar"/>.</summary>
    /// <param name="julianDay">The composed <see cref="string"/> describes this <see cref="JulianDay"/>, expressed as a date in <paramref name="calendar"/>.</param>
    /// <param name="calendar">The <paramref name="julianDay"/> is expressed as a date in this <see cref="CalendarType"/>.</param>
    private static string ComposeAsDate(JulianDay julianDay, CalendarType calendar)
    {
        var (year, month, day, hour, minute, second) = ToDate(ToCalendar(julianDay, calendar));

        var era = year < 0 ? "BC" : "AD";
        var yearText = Math.Abs(year).ToString(CultureInfo.InvariantCulture);
        var monthText = month.ToString(CultureInfo.InvariantCulture);
        var dayText = day.ToString(CultureInfo.InvariantCulture);
        var hourText = hour.ToString(CultureInfo.InvariantCulture);
        var minuteText = minute.ToString(CultureInfo.InvariantCulture);
        var secondText = second.ToString("00.###", CultureInfo.InvariantCulture);

        return $"{yearText}{era}-{monthText}-{dayText} {hourText}:{minuteText}:{secondText}";
    }

    /// <summary>Extracts the components of <paramref name="date"/>.</summary>
    /// <param name="date">The components of this <see cref="ZonedDateTime"/> are extracted.</param>
    private static (int Year, int Month, int Day, int Hour, int Minute, double Second) ToDate(ZonedDateTime date) => (date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second + date.Millisecond / 1000d);

    /// <summary>Converts <paramref name="epoch"/> to a <see cref="ZonedDateTime"/> representing the same <see cref="IEpoch"/>.</summary>
    /// <param name="epoch">The <see cref="IEpoch"/> which is converted to a <see cref="ZonedDateTime"/>.</param>
    /// <param name="calendar">The constructed instance of <see cref="ZonedDateTime"/> uses this <see cref="CalendarType"/>.</param>
    private static ZonedDateTime ToCalendar(IEpoch epoch, CalendarType calendar)
    {
        var julianDay = epoch.ToJulianDay();

        var zonedDateTime = Instant.FromJulianDate(julianDay.Day).InUtc();

        if (calendar is CalendarType.Mixed && julianDay.Day < CalendarChangeJulianDay.Day)
        {
            return zonedDateTime.WithCalendar(CalendarSystem.Julian);
        }

        return zonedDateTime.WithCalendar(CalendarSystem.Gregorian);
    }

    /// <summary>Expresses <paramref name="epoch"/> in <paramref name="timeSystem"/> with an <paramref name="offset"/>.</summary>
    /// <param name="epoch">The original <see cref="IEpoch"/>.</param>
    /// <param name="timeSystem">The <see cref="TimeSystem"/> in which the new <see cref="IEpoch"/> is expressed in, with some <paramref name="offset"/>.</param>
    /// <param name="offset">The <see cref="Time"/> offset from <paramref name="timeSystem"/> of the new <see cref="IEpoch"/>.</param>
    private JulianDay ExpressEpoch(IEpoch epoch, TimeSystem timeSystem, Time offset)
    {
        var timeSystemOffset = TimeSystemOffsetProvider.Offset(epoch, TimeSystem.UT, timeSystem);

        try
        {
            SharpMeasuresValidation.Validate(timeSystemOffset);
        }
        catch (ArgumentException e)
        {
            throw new InvalidOperationException($"The {nameof(ITimeSystemOffsetProvider)} provided an invalid {nameof(Time)}.", e);
        }

        return new(epoch.ToJulianDay().Day - offset.Days + timeSystemOffset.Days);
    }

    /// <summary>Validates the <see cref="QueryEpoch"/> <paramref name="queryEpoch"/>, and throws an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="queryEpoch">This <see cref="QueryEpoch"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="queryEpoch"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    private static void Validate(QueryEpoch queryEpoch, [CallerArgumentExpression(nameof(queryEpoch))] string? argumentExpression = null)
    {
        ArgumentNullException.ThrowIfNull(queryEpoch, argumentExpression);

        try
        {
            Validate(queryEpoch.Format);

            if (queryEpoch.Format is EpochFormat.CalendarDates)
            {
                Validate(queryEpoch.Calendar);
            }

            Validate(queryEpoch.TimeSystem);
        }
        catch (ArgumentException e)
        {
            throw ArgumentExceptionFactory.InvalidState<QueryEpoch>(argumentExpression, e);
        }
    }

    /// <summary>Validates the <see cref="EpochFormat"/> <paramref name="format"/>, and throws an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="format">This <see cref="EpochFormat"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="format"/>.</param>
    /// <exception cref="ArgumentException"/>
    private static void Validate(EpochFormat format, [CallerArgumentExpression(nameof(format))] string? argumentExpression = null)
    {
        if (format is EpochFormat.Unknown)
        {
            throw ArgumentExceptionFactory.UnsupportedEnumValue(format, argumentExpression);
        }
    }

    /// <summary>Validates the <see cref="CalendarType"/> <paramref name="calendar"/>, and throws an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="calendar">This <see cref="CalendarType"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="calendar"/>.</param>
    /// <exception cref="ArgumentException"/>
    private static void Validate(CalendarType calendar, [CallerArgumentExpression(nameof(calendar))] string? argumentExpression = null)
    {
        if (calendar is CalendarType.Unknown)
        {
            throw ArgumentExceptionFactory.UnsupportedEnumValue(calendar, argumentExpression);
        }
    }

    /// <summary>Validates the <see cref="TimeSystem"/> <paramref name="timeSystem"/>, and throws an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="timeSystem">This <see cref="TimeSystem"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="timeSystem"/>.</param>
    /// <exception cref="ArgumentException"/>
    private static void Validate(TimeSystem timeSystem, [CallerArgumentExpression(nameof(timeSystem))] string? argumentExpression = null)
    {
        if (timeSystem is TimeSystem.Unknown)
        {
            throw ArgumentExceptionFactory.UnsupportedEnumValue(timeSystem, argumentExpression);
        }
    }
}
