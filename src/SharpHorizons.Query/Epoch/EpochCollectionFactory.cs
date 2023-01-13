namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;
using SharpHorizons.Query.Arguments.Composers.Epoch;

using System;
using System.Collections.Generic;

/// <summary>Handles construction of <see cref="IEpochCollection"/>.</summary>
public sealed class EpochCollectionFactory : IEpochCollectionFactory
{
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
    public IEpochCollection Create(IEnumerable<IEpoch> epochs)
    {
        ArgumentNullException.ThrowIfNull(epochs);

        return new EpochCollection(epochs, Composer, FormatComposer, CalendarComposer, TimeSystemComposer, TimeZoneComposer);
    }

    /// <inheritdoc/>
    public IEpochCollection Create(params IEpoch[] epochs)
    {
        ArgumentNullException.ThrowIfNull(epochs);

        return Create(epochs as IEnumerable<IEpoch>);
    }
}
