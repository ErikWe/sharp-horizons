namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;
using SharpHorizons.Query.Arguments.Composers.Epoch;

using SharpMeasures;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

/// <summary>Handles construction of <see cref="IEpochCollection"/>.</summary>
public sealed class EpochCollectionFactory : IEpochCollectionFactory
{
    /// <summary>Composes <see cref="IEpochCollectionArgument"/> that describe <see cref="IEpochCollection"/>.</summary>
    private IEpochCollectionComposer<IEpochCollection> Composer { get; }

    /// <summary>The <see cref="EpochFormat"/> of the constructed <see cref="IEpochCollection"/>.</summary>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public EpochFormat DefaultFormat
    {
        get => defaultFormatField;
        set
        {
            ValidateFormat(value);

            defaultFormatField = value;
        }
    }

    /// <summary>The <see cref="CalendarType"/> of the constructed <see cref="IEpochCollection"/>.</summary>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public CalendarType DefaultCalendar
    {
        get => defaultCalendarField;
        set
        {
            ValidateCalendar(value);

            defaultCalendarField = value;
        }
    }

    /// <summary>The <see cref="DefaultTimeSystem"/> of the constructed <see cref="IEpochCollection"/>.</summary>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public TimeSystem DefaultTimeSystem
    {
        get => defaultTimeSystemField;
        set
        {
            ValidateTimeSystem(value);

            defaultTimeSystemField = value;
        }
    }

    /// <summary>The <see cref="Time"/> offset to UTC of the constructed <see cref="IEpochCollection"/>.</summary>
    /// <exception cref="ArgumentException"/>
    public Time DefaultUTCOffset
    {
        get => defaultUTCOffsetField;
        set
        {
            ValidateUTCOffset(value);

            defaultUTCOffsetField = value;
        }
    }

    /// <inheritdoc cref="EpochCollectionFactory"/>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    public EpochCollectionFactory(IEpochCollectionComposer<IEpochCollection>? composer = null)
    {
        Composer = composer ?? new EpochCollectionComposer();
    }

    /// <inheritdoc/>
    public IEpochCollection Create(IEnumerable<IEpoch> epochs)
    {
        ArgumentNullException.ThrowIfNull(epochs);

        return new EpochCollection(epochs, Composer)
        {
            Format = DefaultFormat,
            Calendar = DefaultCalendar,
            TimeSystem = DefaultTimeSystem,
            UTCOffset = DefaultUTCOffset
        };
    }

    /// <inheritdoc/>
    public IEpochCollection Create(params IEpoch[] epochs)
    {
        ArgumentNullException.ThrowIfNull(epochs);

        return Create(epochs as IEnumerable<IEpoch>);
    }

    IEpochCollectionFactory IEpochCollectionFactory.WithFormat(EpochFormat format)
    {
        DefaultFormat = format;

        return this;
    }

    IEpochCollectionFactory IEpochCollectionFactory.WithCalendar(CalendarType calendar)
    {
        DefaultCalendar = calendar;

        return this;
    }

    IEpochCollectionFactory IEpochCollectionFactory.WithTimeSystem(TimeSystem timeSystem)
    {
        DefaultTimeSystem = timeSystem;

        return this;
    }

    IEpochCollectionFactory IEpochCollectionFactory.WithUTCOffset(Time utcOffset)
    {
        DefaultUTCOffset = utcOffset;

        return this;
    }

    /// <summary>Backing field for <see cref="DefaultFormat"/>. Should not be used elsewhere.</summary>
    private EpochFormat defaultFormatField = EpochFormat.JulianDays;
    /// <summary>Backing field for <see cref="DefaultCalendar"/>. Should not be used elsewhere.</summary>
    private CalendarType defaultCalendarField = CalendarType.Gregorian;
    /// <summary>Backing field for <see cref="DefaultTimeSystem"/>. Should not be used elsewhere.</summary>
    private TimeSystem defaultTimeSystemField = TimeSystem.UniversalTime;
    /// <summary>Backing field for <see cref="DefaultUTCOffset"/>. Should not be used elsewhere.</summary>
    private Time defaultUTCOffsetField = Time.Zero;

    /// <summary>Validates the <see cref="EpochFormat"/> <paramref name="format"/>, throwing an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="format">This <see cref="EpochFormat"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="format"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    private static void ValidateFormat(EpochFormat format, [CallerArgumentExpression(nameof(format))] string? argumentExpression = null)
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
    private static void ValidateCalendar(CalendarType calendar, [CallerArgumentExpression(nameof(calendar))] string? argumentExpression = null)
    {
        InvalidEnumArgumentExceptionUtility.ThrowIfUnlisted(calendar, argumentExpression);

        if (calendar is CalendarType.Unknown)
        {
            throw ArgumentExceptionFactory.UnsupportedEnumValue(calendar, argumentExpression);
        }
    }

    /// <summary>Validates the <see cref="TimeSystem"/> <paramref name="timeSystem"/>, throwing an <see cref="InvalidEnumArgumentException"/> if invalid.</summary>
    /// <param name="timeSystem">This <see cref="TimeSystem"/> is validated.</param>
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
