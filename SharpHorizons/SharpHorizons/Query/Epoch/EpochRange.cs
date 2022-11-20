namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Query.Arguments;

using System;
using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IEpochRange"/>
internal sealed record class EpochRange : IEpochRange
{
    public required IStartEpoch StartEpoch { get; init; }
    public required IStopEpoch StopEpoch { get; init; }
    public required IStepSize StepSize { get; init; }

    /// <inheritdoc cref="EpochRange"/>
    public EpochRange() { }

    /// <inheritdoc cref="EpochRange"/>
    /// <param name="startEpoch"><inheritdoc cref="StartEpoch" path="/summary"/></param>
    /// <param name="stopEpoch"><inheritdoc cref="StopEpoch" path="/summary"/></param>
    /// <param name="stepSize"><inheritdoc cref="StepSize" path="/summary"/></param>
    /// <exception cref="ArgumentNullException"/>
    [SetsRequiredMembers]
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