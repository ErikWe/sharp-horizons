namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Query.Arguments;

using SharpMeasures;

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

    /// <summary>Composes a <see cref="IEpochCollectionArgument"/> describing the selected <see cref="IEpoch"/>, if the <see cref="IEpoch"/> are selected according to <see cref="EpochSelectionMode.Collection"/>.</summary>
    /// <exception cref="UnsupportedEpochSelectionModeException"/>
    public abstract IEpochCollectionArgument ComposeCollectionArgument();

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
