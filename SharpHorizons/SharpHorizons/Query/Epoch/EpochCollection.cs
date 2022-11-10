namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Calendars;
using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

/// <inheritdoc cref="IEpochCollection"/>
internal sealed record class EpochCollection : IEpochCollection
{
    /// <inheritdoc/>
    public IEnumerable<IEpoch> Epochs { get; }

    /// <inheritdoc/>
    public EpochCollectionFormat Format { get; }

    /// <summary>Used to compose <see cref="IEpochCollectionArgument"/> that describe <see langword="this"/>.</summary>
    private IEpochCollectionComposer<IEpochCollection> Composer { get; }

    /// <summary>Used to compose <see cref="IEpochCollectionFormatArgument"/> that describe <see cref="Format"/>.</summary>
    private IEpochCollectionFormatComposer FormatComposer { get; }

    /// <summary>Uses a collection of individual <see cref="IEpoch"/>, <paramref name="epochs"/>, to describe the selection of <see cref="IEpoch"/> in a query - each formatted according to <paramref name="format"/>.</summary>
    /// <param name="epochs"><inheritdoc cref="Epochs" path="/summary"/></param>
    /// <param name="format"><inheritdoc cref="Format" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    /// <param name="formatComposer"><inheritdoc cref="FormatComposer" path="/summary"/></param>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public EpochCollection(IEnumerable<IEpoch> epochs, EpochCollectionFormat format, IEpochCollectionComposer<IEpochCollection> composer, IEpochCollectionFormatComposer formatComposer)
    {
        Epochs = epochs;

        Format = format;

        Composer = composer;
        FormatComposer = formatComposer;
    }

    EpochSelectionMode IEpochSelection.Selection => EpochSelectionMode.Collection;
    IEpochCollectionArgument IEpochSelection.ComposeCollectionArgument() => Composer.Compose(this);
    IEpochCollectionFormatArgument IEpochSelection.ComposeCollectionFormatArgument() => FormatComposer.Compose(Format);
    IStartEpochArgument IEpochSelection.ComposeStartTimeArgument() => throw UnsupportedEpochSelectionException.EpochSelectionNotRange;
    IStopEpochArgument IEpochSelection.ComposeStopTimeArgument() => throw UnsupportedEpochSelectionException.EpochSelectionNotRange;
    IStepSizeArgument IEpochSelection.ComposeStepSizeArgument() => throw UnsupportedEpochSelectionException.EpochSelectionNotRange;

    /// <inheritdoc/>
    public IEpochCollection Concat(IEnumerable<IEpoch> epochs)
    {
        ArgumentNullException.ThrowIfNull(epochs);

        return new EpochCollection(Epochs.Concat(epochs), Format, Composer, FormatComposer);
    }

    /// <inheritdoc/>
    public IEnumerator<IEpoch> GetEnumerator() => Epochs.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}