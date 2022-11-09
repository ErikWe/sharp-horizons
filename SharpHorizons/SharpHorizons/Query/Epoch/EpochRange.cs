namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Calendars;

using System;

/// <inheritdoc cref="IEpochRange"/>
internal sealed record class EpochRange : IEpochRange
{
    /// <inheritdoc cref="IEpochRange.StartEpoch"/>
    public IStartEpoch StartEpoch { get; }

    /// <inheritdoc cref="IEpochRange.StopEpoch"/>
    public IStopEpoch StopEpoch { get; }

    /// <inheritdoc/>
    public IStepSize StepSize { get; }

    /// <summary>Uses the timespan between <paramref name="startEpoch"/> and <paramref name="stopEpoch"/> with the associated <paramref name="stepSize"/> to describe the selection of <see cref="IEpoch"/> in a query.</summary>
    /// <param name="startEpoch"><inheritdoc cref="StartEpoch" path="/summary"/></param>
    /// <param name="stopEpoch"><inheritdoc cref="StopEpoch" path="/summary"/></param>
    /// <param name="stepSize"><inheritdoc cref="StepSize" path="/summary"/></param>
    /// <exception cref="ArgumentNullException"/>
    public EpochRange(IStartEpoch startEpoch, IStopEpoch stopEpoch, IStepSize stepSize)
    {
        StartEpoch = startEpoch;
        StopEpoch = stopEpoch;

        StepSize = stepSize;
    }

    EpochSelectionMode IEpochSelection.Selection => EpochSelectionMode.Range;
    IEpochCollectionArgument IEpochSelection.ComposeCollectionArgument() => throw UnsupportedEpochSelectionException.EpochSelectionNotCollection;
    IEpochCollectionFormatArgument IEpochSelection.ComposeCollectionFormatArgument() => throw UnsupportedEpochSelectionException.EpochSelectionNotCollection;
    IStartEpochArgument IEpochSelection.ComposeStartTimeArgument() => StartEpoch.ComposeArgument();
    IStopEpochArgument IEpochSelection.ComposeStopTimeArgument() => StopEpoch.ComposeArgument();
    IStepSizeArgument IEpochSelection.ComposeStepSizeArgument() => StepSize.ComposeArgument();
}