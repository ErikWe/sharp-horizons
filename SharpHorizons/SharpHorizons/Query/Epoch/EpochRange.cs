namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Query.Arguments;

using System;
using System.Collections.Generic;

/// <inheritdoc cref="IEpochRange"/>
internal sealed record class EpochRange : IEpochRange
{
    public IStartEpoch StartEpoch { get; }
    public IStopEpoch StopEpoch { get; }
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