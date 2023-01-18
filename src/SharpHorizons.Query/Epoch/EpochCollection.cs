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
    public TimeSystem TimeSystem { get; init; } = TimeSystem.UniversalTime;
    public Time UTCOffset { get; init; } = Time.Zero;

    /// <summary>Used to compose <see cref="IEpochCollectionArgument"/> that describe <see langword="this"/>.</summary>
    public required IEpochCollectionComposer<IEpochCollection> Composer { private get; init; }

    /// <inheritdoc cref="EpochCollection"/>
    public EpochCollection() { }

    /// <inheritdoc cref="EpochCollection"/>
    /// <param name="epochs"><inheritdoc cref="Epochs" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    [SetsRequiredMembers]
    public EpochCollection(IEnumerable<IEpoch> epochs, IEpochCollectionComposer<IEpochCollection> composer)
    {
        Epochs = epochs;

        Composer = composer;
    }

    EpochSelectionMode IEpochSelection.SelectionMode => EpochSelectionMode.Collection;
    IEpochCollectionArgument IEpochSelection.ComposeCollectionArgument() => Composer.Compose(this);
    IStartEpochArgument IEpochSelection.ComposeStartEpochArgument() => throw UnsupportedEpochSelectionModeException.EpochSelectionNotRange();
    IStopEpochArgument IEpochSelection.ComposeStopEpochArgument() => throw UnsupportedEpochSelectionModeException.EpochSelectionNotRange();
    IStepSizeArgument IEpochSelection.ComposeStepSizeArgument() => throw UnsupportedEpochSelectionModeException.EpochSelectionNotRange();

    public IEpochCollection Concat(IEnumerable<IEpoch> epochs)
    {
        ArgumentNullException.ThrowIfNull(epochs);

        return this with { Epochs = Epochs.Concat(epochs) };
    }

    public IEnumerator<IEpoch> GetEnumerator() => Epochs.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
