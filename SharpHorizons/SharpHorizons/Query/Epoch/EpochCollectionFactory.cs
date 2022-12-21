namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;
using SharpHorizons.Query.Arguments.Composers.Epoch;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

/// <summary>Handles construction of <see cref="IEpochCollection"/>.</summary>
public sealed class EpochCollectionFactory : IEpochCollectionFactory
{
    /// <summary>Determines the default <see cref="EpochFormat"/>.</summary>
    private static EpochFormat DefaultFormat { get; } = EpochFormat.JulianDays;

    /// <summary>Composes <see cref="IEpochCollectionArgument"/> that describe <see cref="IEpochCollection"/>.</summary>
    private IEpochCollectionComposer<IEpochCollection> Composer { get; }

    /// <summary>Used to compose <see cref="IEpochCollectionFormatArgument"/> that describe the <see cref="EpochFormat"/> of <see cref="IEpochCollection"/>.</summary>
    private IEpochCollectionFormatComposer FormatComposer { get; }

    /// <inheritdoc cref="IEpochCalendarComposer"/>
    private IEpochCalendarComposer CalendarComposer { get; }

    /// <inheritdoc cref="ITimeSystemComposer"/>
    private ITimeSystemComposer TimeSystemComposer { get; }

    /// <inheritdoc cref="ITimeZoneComposer"/>
    private ITimeZoneComposer TimeZoneComposer { get; }

    /// <inheritdoc cref="EpochCollectionFactory"/>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    /// <param name="formatComposer"><inheritdoc cref="FormatComposer" path="/summary"/></param>
    /// <param name="calendarComposer"><inheritdoc cref="CalendarComposer" path="/summary"/></param>
    /// <param name="timeSystemComposer"><inheritdoc cref="TimeSystemComposer" path="/summary"/></param>
    /// <param name="timeZoneComposer"><inheritdoc cref="TimeZoneComposer" path="/summary"/></param>
    public EpochCollectionFactory(IEpochCollectionComposer<IEpochCollection>? composer = null, IEpochCollectionFormatComposer? formatComposer = null, IEpochCalendarComposer? calendarComposer = null, ITimeSystemComposer? timeSystemComposer = null, ITimeZoneComposer? timeZoneComposer = null)
    {
        Composer = composer ?? new EpochCollectionComposer();

        FormatComposer = formatComposer ?? new EpochCollectionFormatComposer();
        CalendarComposer = calendarComposer ?? new EpochCalendarComposer();
        TimeSystemComposer = timeSystemComposer ?? new TimeSystemComposer();
        TimeZoneComposer = timeZoneComposer ?? new TimeZoneComposer();
    }

    /// <inheritdoc/>
    public IEpochCollection Create(IEnumerable<IEpoch> epochs, EpochFormat format)
    {
        ArgumentNullException.ThrowIfNull(epochs);
        ValidateEpochFormat(format);

        return new EpochCollection(epochs, format, Composer, FormatComposer, CalendarComposer, TimeSystemComposer, TimeZoneComposer);
    }

    /// <inheritdoc/>
    public IEpochCollection Create(IEnumerable<IEpoch> epochs)
    {
        ArgumentNullException.ThrowIfNull(epochs);

        return Create(epochs, DefaultFormat);
    }

    /// <inheritdoc/>
    public IEpochCollection Create(EpochFormat format, params IEpoch[] epochs)
    {
        ValidateEpochFormat(format);
        ArgumentNullException.ThrowIfNull(epochs);

        return Create(epochs, format);
    }

    /// <inheritdoc/>
    public IEpochCollection Create(params IEpoch[] epochs)
    {
        ArgumentNullException.ThrowIfNull(epochs);

        return Create(DefaultFormat, epochs);
    }

    /// <summary>Validates the <see cref="EpochFormat"/> <paramref name="format"/>, and throws an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="format">This <see cref="EpochFormat"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="format"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    private static void ValidateEpochFormat(EpochFormat format, [CallerArgumentExpression(nameof(format))] string? argumentExpression = null)
    {
        InvalidEnumArgumentExceptionUtility.ThrowIfUnlisted(format);

        if (format is EpochFormat.Unknown)
        {
            throw ArgumentExceptionFactory.UnsupportedEnumValue(format, argumentExpression);
        }
    }
}
