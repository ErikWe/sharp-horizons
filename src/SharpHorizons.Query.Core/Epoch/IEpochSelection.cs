﻿namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Query.Arguments;

using SharpMeasures;

using System;
using System.ComponentModel;

/// <summary>Represents the selection of <see cref="IEpoch"/> in a query.</summary>
public interface IEpochSelection
{
    /// <inheritdoc cref="EpochSelectionMode"/>
    public abstract EpochSelectionMode SelectionMode { get; }

    /// <inheritdoc cref="EpochFormat"/>
    public abstract EpochFormat Format { get; }

    /// <inheritdoc cref="CalendarType"/>
    public abstract CalendarType Calendar { get; }

    /// <inheritdoc cref="Epoch.TimeSystem"/>
    public abstract TimeSystem TimeSystem { get; }

    /// <summary>The UTC offset of the timezone in which the <see cref="IEpoch"/> are expressed in a query.</summary>
    public abstract Time UTCOffset { get; }

    /// <summary>Constructs a new <see cref="IEpochSelection"/> with modified <see cref="Format"/>.</summary>
    /// <param name="format"><inheritdoc cref="Format" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract IEpochSelection WithFormat(EpochFormat format);

    /// <summary>Constructs a new <see cref="IEpochSelection"/> with modified <see cref="Calendar"/>.</summary>
    /// <param name="calendar"><inheritdoc cref="Calendar" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract IEpochSelection WithCalendar(CalendarType calendar);

    /// <summary>Constructs a new <see cref="IEpochSelection"/> with modified <see cref="TimeSystem"/>.</summary>
    /// <param name="timeSystem"><inheritdoc cref="TimeSystem" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract IEpochSelection WithTimeSystem(TimeSystem timeSystem);

    /// <summary>Constructs a new <see cref="IEpochSelection"/> with modified <see cref="UTCOffset"/>.</summary>
    /// <param name="utcOffset"><inheritdoc cref="UTCOffset" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    public abstract IEpochSelection WithUTCOffset(Time utcOffset);

    /// <summary>Constructs a new <see cref="IEpochSelection"/> with the new configuration. Properties that correspond to a <see langword="null"/> argument are not modified.</summary>
    /// <param name="format"><inheritdoc cref="Format" path="/summary"/></param>
    /// <param name="calendar"><inheritdoc cref="Calendar" path="/summary"/></param>
    /// <param name="timeSystem"><inheritdoc cref="TimeSystem" path="/summary"/></param>
    /// <param name="utcOffset"><inheritdoc cref="UTCOffset" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract IEpochSelection WithConfiguration(EpochFormat? format = null, CalendarType? calendar = null, TimeSystem? timeSystem = null, Time? utcOffset = null);

    /// <summary>Composes a <see cref="IEpochCollectionArgument"/> describing the selected <see cref="IEpoch"/>, if the <see cref="IEpoch"/> are selected according to <see cref="EpochSelectionMode.Collection"/>.</summary>
    /// <exception cref="UnsupportedEpochSelectionModeException"/>
    public abstract IEpochCollectionArgument ComposeCollectionArgument();

    /// <summary>Composes a <see cref="IEpochCollectionFormatArgument"/> describing the <see cref="EpochFormat"/>, if the <see cref="IEpoch"/> are selected according to <see cref="EpochSelectionMode.Collection"/>.</summary>
    /// <exception cref="UnsupportedEpochSelectionModeException"/>
    public abstract IEpochCollectionFormatArgument ComposeCollectionFormatArgument();

    /// <summary>Composes a <see cref="ICalendarTypeArgument"/> describing the <see cref="CalendarType"/>.</summary>
    public abstract ICalendarTypeArgument ComposeEpochCalendarArgument();

    /// <summary>Composes a <see cref="ITimeSystemArgument"/> describing the <see cref="Epoch.TimeSystem"/>.</summary>
    public abstract ITimeSystemArgument ComposeTimeSystemArgument();

    /// <summary>Composes a <see cref="ITimeZoneArgument"/> describing the <see cref="Time"/> offset to some <see cref="Epoch.TimeSystem"/>.</summary>
    public abstract ITimeZoneArgument ComposeTimeZoneArgument();

    /// <summary>Composes a <see cref="IStartEpochArgument"/> describing the start <see cref="IStartEpoch"/>, if the <see cref="IEpoch"/> are selected according to a <see cref="EpochSelectionMode.Range"/>.</summary>
    /// <exception cref="UnsupportedEpochSelectionModeException"/>
    public abstract IStartEpochArgument ComposeStartEpochArgument();

    /// <summary>Composes a <see cref="IStopEpochArgument"/> describing the stop <see cref="IStopEpoch"/>, if the <see cref="IEpoch"/> are selected according to a <see cref="EpochSelectionMode.Range"/>.</summary>
    /// <exception cref="UnsupportedEpochSelectionModeException"/>
    public abstract IStopEpochArgument ComposeStopEpochArgument();

    /// <summary>Composes a <see cref="IStepSizeArgument"/> describing the <see cref="IStepSize"/>, if the <see cref="IEpoch"/> are selected according to a <see cref="EpochSelectionMode.Range"/>.</summary>
    /// <exception cref="UnsupportedEpochSelectionModeException"/>
    public abstract IStepSizeArgument ComposeStepSizeArgument();
}
