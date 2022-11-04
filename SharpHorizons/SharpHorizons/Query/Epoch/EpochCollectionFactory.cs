namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Calendars;
using SharpHorizons.Query.Arguments;

using System;
using System.Collections.Generic;

/// <summary>Handles construction of <see cref="IEpochCollection"/>.</summary>
public sealed class EpochCollectionFactory : IEpochCollectionFactory
{
    /// <summary>Determines the default <see cref="EpochCollectionFormat"/>.</summary>
    private static EpochCollectionFormat DefaultFormat { get; } = EpochCollectionFormat.JulianDays;

    /// <summary>Composes <see cref="IEpochCollectionArgument"/> that describe <see cref="IEpochCollection"/>.</summary>
    private IEpochCollectionComposer<IEpochCollection> Composer { get; }

    /// <summary>Used to compose <see cref="IEpochCollectionFormatArgument"/> that describe the <see cref="EpochCollectionFormat"/> of <see cref="IEpochCollection"/>.</summary>
    private IEpochCollectionFormatComposer FormatComposer { get; }

    /// <summary><inheritdoc cref="EpochCollectionFactory" path="/summary"/></summary>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    /// <param name="formatComposer"><inheritdoc cref="FormatComposer" path="/summary"/></param>
    public EpochCollectionFactory(IEpochCollectionComposer<IEpochCollection>? composer = null, IEpochCollectionFormatComposer? formatComposer = null)
    {
        Composer = composer ?? new EpochCollectionComposer();
        FormatComposer = formatComposer ?? new EpochCollectionFormatComposer();
    }

    /// <inheritdoc/>
    public IEpochCollection Create(IEnumerable<IEpoch> epochs, EpochCollectionFormat format)
    {
        ArgumentNullException.ThrowIfNull(epochs);

        return new EpochCollection(epochs, format, Composer, FormatComposer);
    }

    /// <inheritdoc/>
    public IEpochCollection Create(IEnumerable<IEpoch> epochs) => Create(epochs, DefaultFormat);

    /// <inheritdoc/>
    public IEpochCollection Create(EpochCollectionFormat format, params IEpoch[] epochs) => Create(epochs as IEnumerable<IEpoch>, format);

    /// <inheritdoc/>
    public IEpochCollection Create(params IEpoch[] epochs) => Create(DefaultFormat, epochs);

    /// <inheritdoc/>
    public IEpochCollection Create(EpochCollectionFormat format) => Create(Array.Empty<IEpoch>(), format);

    /// <inheritdoc/>
    public IEpochCollection Create() => Create(DefaultFormat);
}
