namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;

using SharpMeasures;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

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
    /// <param name="format"><inheritdoc cref="Format" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    /// <param name="formatComposer"><inheritdoc cref="FormatComposer" path="/summary"/></param>
    /// <param name="calendarComposer"><inheritdoc cref="CalendarComposer" path="/summary"/></param>
    /// <param name="timeSystemComposer"><inheritdoc cref="TimeSystemComposer" path="/summary"/></param>
    /// <param name="timeZoneComposer"><inheritdoc cref="TimeZoneComposer" path="/summary"/></param>
    [SetsRequiredMembers]
    public EpochCollection(IEnumerable<IEpoch> epochs, EpochFormat format, IEpochCollectionComposer<IEpochCollection> composer, IEpochCollectionFormatComposer formatComposer, IEpochCalendarComposer calendarComposer, ITimeSystemComposer timeSystemComposer, ITimeZoneComposer timeZoneComposer)
    {
        Epochs = epochs;

        Format = format;

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

        return new EpochCollection(Epochs.Concat(epochs), Format, Composer, FormatComposer, CalendarComposer, TimeSystemComposer, TimeZoneComposer);
    }

    public IEnumerator<IEpoch> GetEnumerator() => Epochs.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}