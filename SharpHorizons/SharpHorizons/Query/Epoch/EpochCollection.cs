namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Epoch;
using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;

/// <inheritdoc cref="IEpochCollection"/>
internal sealed record class EpochCollection : IEpochCollection
{
    public required IEnumerable<IEpoch> Epochs { get; init; }
    public required EpochCollectionFormat Format
    {
        get => _Format;
        init
        {
            ValidateEpochCollectionFormat(value);

            _Format = value;
        }
    }

    /// <summary>Used to compose <see cref="IEpochCollectionArgument"/> that describe <see langword="this"/>.</summary>
    public required IEpochCollectionComposer<IEpochCollection> Composer { private get; init; }

    /// <summary>Used to compose <see cref="IEpochCollectionFormatArgument"/> that describe <see cref="Format"/>.</summary>
    public required IEpochCollectionFormatComposer FormatComposer { private get; init; }

    /// <inheritdoc cref="Format"/>
    private EpochCollectionFormat _Format { get; init; }

    /// <inheritdoc cref="EpochCollection"/>
    public EpochCollection() { }

    /// <inheritdoc cref="EpochCollection"/>
    /// <param name="epochs"><inheritdoc cref="Epochs" path="/summary"/></param>
    /// <param name="format"><inheritdoc cref="Format" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    /// <param name="formatComposer"><inheritdoc cref="FormatComposer" path="/summary"/></param>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    [SetsRequiredMembers]
    public EpochCollection(IEnumerable<IEpoch> epochs, EpochCollectionFormat format, IEpochCollectionComposer<IEpochCollection> composer, IEpochCollectionFormatComposer formatComposer)
    {
        ValidateEpochCollectionFormat(format);

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

    public IEpochCollection Concat(IEnumerable<IEpoch> epochs)
    {
        ArgumentNullException.ThrowIfNull(epochs);

        return new EpochCollection(Epochs.Concat(epochs), Format, Composer, FormatComposer);
    }

    public IEnumerator<IEpoch> GetEnumerator() => Epochs.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    /// <summary>Throws an <see cref="InvalidEnumArgumentException"/> if <paramref name="format"/> does not represent a valid <see cref="EpochCollectionFormat"/>.</summary>
    /// <param name="format">A <see cref="InvalidEnumArgumentException"/> is thrown if this <see cref="EpochCollectionFormat"/> is invalid.</param>
    /// <param name="parameterName">The name of the parameter with which <paramref name="format"/> corresponds.</param>
    /// <exception cref="InvalidEnumArgumentException"/>
    private static void ValidateEpochCollectionFormat(EpochCollectionFormat format, [CallerArgumentExpression("format")] string? parameterName = null)
    {
        if (Enum.IsDefined(typeof(EpochCollectionFormat), format) is false)
        {
            throw new InvalidEnumArgumentException(parameterName, (int)format, typeof(EpochCollectionFormat));
        }
    }
}