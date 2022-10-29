namespace SharpHorizons.Query;

using SharpHorizons.Calendars;
using SharpHorizons.Query.Arguments;

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

/// <summary>Uses a collection of individual <see cref="IEpoch"/> to describe the selection of <see cref="IEpoch"/> in a query.</summary>
public sealed record class EpochCollection : IEnumerable<IEpoch>, IEpochSelection
{
    /// <summary>The selected <see cref="IEpoch"/> in a query.</summary>
    private IEnumerable<IEpoch> Epochs { get; }

    /// <summary>Determines the <see cref="EpochCollectionFormat"/> of the individual <see cref="IEpoch"/> in a query.</summary>
    public EpochCollectionFormat Format { get; init; }

    EpochSelectionMode IEpochSelection.Selection => EpochSelectionMode.Collection;

    /// <summary>Uses a collection of individual <see cref="IEpoch"/>, <paramref name="epochs"/>, to describe the selection of <see cref="IEpoch"/> in a query - each formatted according to <paramref name="format"/>.</summary>
    /// <param name="epochs"><inheritdoc cref="Epochs" path="/summary"/></param>
    /// <param name="format">Determines the <see cref="EpochCollectionFormat"/> of the individual <see cref="IEpoch"/> in a query.</param>
    /// <exception cref="InvalidEnumArgumentException"/>
    public EpochCollection(IEnumerable<IEpoch> epochs, EpochCollectionFormat format)
    {
        if (Enum.IsDefined(typeof(EpochCollectionFormat), format) is false)
        {
            throw new InvalidEnumArgumentException(nameof(format), (int)format, typeof(EpochCollectionFormat));
        }

        Epochs = epochs;

        Format = format;
    }

    /// <summary>Uses a collection of individual <see cref="IEpoch"/>, <paramref name="epochs"/>, to describe the selection of <see cref="IEpoch"/> in a query - each formatted according to <see cref="EpochCollectionFormat.JulianDays"/>.</summary>
    /// <param name="epochs"><inheritdoc cref="Epochs" path="/summary"/></param>
    public EpochCollection(IEnumerable<IEpoch> epochs) : this(epochs, EpochCollectionFormat.JulianDays) { }

    /// <summary>Uses a collection of individual <see cref="IEpoch"/>, with a single entry <paramref name="epoch"/>, to describe the selection of <see cref="IEpoch"/> in a query - formatted according to <paramref name="format"/>.</summary>
    /// <param name="epoch">The single epoch.</param>
    /// <param name="format">Determines the <see cref="EpochCollectionFormat"/> of <paramref name="epoch"/> in a query.</param>
    /// <exception cref="InvalidEnumArgumentException"/>
    public EpochCollection(IEpoch epoch, EpochCollectionFormat format) : this(new[] { epoch }, format) { }

    /// <summary>Uses a collection of individual <see cref="IEpoch"/>, with a single entry <paramref name="epoch"/>, to describe the selection of <see cref="IEpoch"/> in a query - formatted according to <see cref="EpochCollectionFormat.JulianDays"/>.</summary>
    /// <param name="epoch">The single epoch.</param>
    public EpochCollection(IEpoch epoch) : this(epoch, EpochCollectionFormat.JulianDays) { }

    /// <summary>Uses an empty collection to describe the selection of <see cref="IEpoch"/> in a query</summary>
    public EpochCollection() : this(Array.Empty<IEpoch>()) { }

    IEpochCollectionArgument IEpochSelection.ComposeCollectionArgument() => EpochCollectionArgument.Compose(this, Format);
    IEpochCollectionFormatArgument IEpochSelection.ComposeCollectionFormatArgument() => EpochCollectionFormatArgument.Compose(EpochCollectionFormat.JulianDays);
    IStartTimeArgument IEpochSelection.ComposeStartTimeArgument() => throw new UnsupportedEpochSelectionException(EpochSelectionMode.Range);
    IStopTimeArgument IEpochSelection.ComposeStopTimeArgument() => throw new UnsupportedEpochSelectionException(EpochSelectionMode.Range);
    IStepSizeArgument IEpochSelection.ComposeStepSizeArgument() => throw new UnsupportedEpochSelectionException(EpochSelectionMode.Range);

    /// <summary>Constructs a new <see cref="EpochCollection"/>, with <paramref name="epochs"/> added to the <see cref="EpochCollection"/>.</summary>
    /// <param name="epochs">These <see cref="IEpoch"/> are added to the <see cref="EpochCollection"/>.</param>
    public EpochCollection Concat(IEnumerable<IEpoch> epochs) => new(Epochs.Concat(epochs), Format);

    /// <inheritdoc/>
    public IEnumerator<IEpoch> GetEnumerator() => Epochs.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}