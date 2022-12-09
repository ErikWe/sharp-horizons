namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Query.Arguments;

using SharpMeasures;

/// <summary>Represents the selection of <see cref="IEpoch"/> in a query.</summary>
public interface IEpochSelection
{
    /// <summary>Describes how the <see cref="IEpoch"/> are selected.</summary>
    public abstract EpochSelectionMode Selection { get; }

    /// <summary>The <see cref="EpochFormat"/> of the individual <see cref="IEpoch"/> in a query.</summary>
    public abstract EpochFormat Format { get; }

    /// <summary>The <see cref="CalendarType"/> in what calendar the <see cref="IEpoch"/> are expressed.</summary>
    public abstract CalendarType Calendar { get; }

    /// <summary>The <see cref="Epoch.TimeSystem"/> in which the <see cref="IEpoch"/> are expressed in a query, combined with a possible <see cref="Offset"/>.</summary>
    public abstract TimeSystem TimeSystem { get; }

    /// <summary>The offset from <see cref="TimeSystem"/> of the timezone in which the <see cref="IEpoch"/> are expressed in a query.</summary>
    public abstract Time Offset { get; }

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
    public abstract IStartEpochArgument ComposeStartTimeArgument();

    /// <summary>Composes a <see cref="IStopEpochArgument"/> describing the stop <see cref="IStopEpoch"/>, if the <see cref="IEpoch"/> are selected according to a <see cref="EpochSelectionMode.Range"/>.</summary>
    /// <exception cref="UnsupportedEpochSelectionModeException"/>
    public abstract IStopEpochArgument ComposeStopTimeArgument();

    /// <summary>Composes a <see cref="IStepSizeArgument"/> describing the <see cref="IStepSize"/>, if the <see cref="IEpoch"/> are selected according to a <see cref="EpochSelectionMode.Range"/>.</summary>
    /// <exception cref="UnsupportedEpochSelectionModeException"/>
    public abstract IStepSizeArgument ComposeStepSizeArgument();
}
