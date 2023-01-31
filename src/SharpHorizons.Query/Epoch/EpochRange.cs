namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;

using SharpMeasures;

using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IEpochRange"/>
internal sealed record class EpochRange : IEpochRange
{
    public required IStartEpoch StartEpoch { get; init; }
    public required IStopEpoch StopEpoch { get; init; }
    public required IStepSize StepSize { get; init; }

    public EpochFormat Format { get; init; } = EpochFormat.JulianDays;
    public CalendarType Calendar { get; init; } = CalendarType.Gregorian;
    public TimeSystem TimeSystem { get; init; } = TimeSystem.UniversalTime;
    public Time UTCOffset { get; init; } = Time.Zero;

    /// <summary>Used to compose <see cref="IStartEpochArgument"/> that describe <see cref="StartEpoch"/>.</summary>
    public required IStartEpochComposer<IEpochRange> StartEpochComposer { private get; init; }

    /// <summary>Used to compose <see cref="IStopEpochArgument"/> that describe <see cref="StopEpoch"/>.</summary>
    public required IStopEpochComposer<IEpochRange> StopEpochComposer { private get; init; }

    /// <inheritdoc cref="EpochRange"/>
    public EpochRange() { }

    /// <inheritdoc cref="EpochRange"/>
    /// <param name="startEpoch"><inheritdoc cref="StartEpoch" path="/summary"/></param>
    /// <param name="stopEpoch"><inheritdoc cref="StopEpoch" path="/summary"/></param>
    /// <param name="stepSize"><inheritdoc cref="StepSize" path="/summary"/></param>
    /// <param name="startEpochComposer"><inheritdoc cref="StartEpochComposer" path="/summary"/></param>
    /// <param name="stopEpochComposer"><inheritdoc cref="StopEpochComposer" path="/summary"/></param>
    [SetsRequiredMembers]
    public EpochRange(IStartEpoch startEpoch, IStopEpoch stopEpoch, IStepSize stepSize, IStartEpochComposer<IEpochRange> startEpochComposer, IStopEpochComposer<IEpochRange> stopEpochComposer)
    {
        StartEpoch = startEpoch;
        StopEpoch = stopEpoch;

        StepSize = stepSize;

        StartEpochComposer = startEpochComposer;
        StopEpochComposer = stopEpochComposer;
    }

    EpochSelectionMode IEpochSelection.SelectionMode => EpochSelectionMode.Range;
    IEpochCollectionArgument IEpochSelection.ComposeCollectionArgument() => throw UnsupportedEpochSelectionModeException.EpochSelectionNotCollection();
    IStartEpochArgument IEpochSelection.ComposeStartEpochArgument() => StartEpochComposer.Compose(this);
    IStopEpochArgument IEpochSelection.ComposeStopEpochArgument() => StopEpochComposer.Compose(this);
    IStepSizeArgument IEpochSelection.ComposeStepSizeArgument() => StepSize.ComposeArgument();
}
