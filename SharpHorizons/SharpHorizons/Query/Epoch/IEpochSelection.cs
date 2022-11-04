namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Calendars;
using SharpHorizons.Composers.Arguments;

/// <summary>Represents the selection of <see cref="IEpoch"/> in a query.</summary>
public interface IEpochSelection
{
    /// <summary>Describes how the <see cref="IEpoch"/> are selected.</summary>
    public abstract EpochSelectionMode Selection { get; }

    /// <summary>Composes a <see cref="IEpochCollectionArgument"/> describing the selected <see cref="IEpoch"/>, if the <see cref="IEpoch"/> are selected according to a <see cref="EpochSelectionMode.Collection"/>.</summary>
    /// <exception cref="UnsupportedEpochSelectionException"/>
    public abstract IEpochCollectionArgument ComposeCollectionArgument();

    /// <summary>Composes a <see cref="IEpochCollectionFormatArgument"/> describing the <see cref="EpochCollectionFormat"/>, if the <see cref="IEpoch"/> are selected according to a <see cref="EpochSelectionMode.Collection"/>.</summary>
    /// <exception cref="UnsupportedEpochSelectionException"/>
    public abstract IEpochCollectionFormatArgument ComposeCollectionFormatArgument();

    /// <summary>Composes a <see cref="IStartEpochArgument"/> describing the start <see cref="IEpoch"/>, if the <see cref="IEpoch"/> are selected according to a <see cref="EpochSelectionMode.Range"/>.</summary>
    /// <exception cref="UnsupportedEpochSelectionException"/>
    public abstract IStartEpochArgument ComposeStartTimeArgument();

    /// <summary>Composes a <see cref="IStopEpochArgument"/> describing the stop <see cref="IEpoch"/>, if the <see cref="IEpoch"/> are selected according to a <see cref="EpochSelectionMode.Range"/>.</summary>
    /// <exception cref="UnsupportedEpochSelectionException"/>
    public abstract IStopEpochArgument ComposeStopTimeArgument();

    /// <summary>Composes a <see cref="IStepSizeArgument"/> describing the <see cref="IStepSize"/>, if the <see cref="IEpoch"/> are selected according to a <see cref="EpochSelectionMode.Range"/>.</summary>
    /// <exception cref="UnsupportedEpochSelectionException"/>
    public abstract IStepSizeArgument ComposeStepSizeArgument();
}
