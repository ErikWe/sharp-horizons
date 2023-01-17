namespace SharpHorizons.Query.Arguments.Composers.Epoch;

using SharpHorizons.Query.Epoch;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

/// <summary>Composes <see cref="IEpochCollectionArgument"/> that describe <see cref="IEpochCollection"/>.</summary>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class EpochCollectionComposer : IEpochCollectionComposer<IEpochCollection>
{
    /// <inheritdoc cref="Epoch.QueryEpochComposer"/>
    private QueryEpochComposer QueryEpochComposer { get; }

    /// <inheritdoc cref="EpochCalendarComposer"/>
    /// <param name="timesystemOffsetProvider"><inheritdoc cref="ITimeSystemOffsetProvider" path="/summary"/></param>
    public EpochCollectionComposer(ITimeSystemOffsetProvider? timesystemOffsetProvider = null)
    {
        QueryEpochComposer = new(timesystemOffsetProvider ?? new ZeroTimeSystemOffsetProvider());
    }

    IEpochCollectionArgument IArgumentComposer<IEpochCollectionArgument, IEpochCollection>.Compose(IEpochCollection obj)
    {
        ArgumentNullException.ThrowIfNull(obj);

        return new QueryArgument(Compose(obj));
    }

    /// <summary>Composes a <see cref="string"/> describing <paramref name="epochCollection"/>.</summary>
    /// <param name="epochCollection">The composed <see cref="string"/> describes this <see cref="IEpochCollection"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidOperationException"/>
    private string Compose(IEpochCollection epochCollection) => string.Join(',', ComposeComponents(epochCollection));

    /// <summary>Composes <see cref="string"/> that describes the <see cref="IEpoch"/> of <paramref name="epochCollection"/>.</summary>
    /// <param name="epochCollection">The composed <see cref="string"/> describe the <see cref="IEpoch"/> of this <see cref="IEpochCollection"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidOperationException"/>
    private IEnumerable<string> ComposeComponents(IEpochCollection epochCollection)
    {
        try
        {
            return ComposeComponents(epochCollection, epochCollection.GetEnumerator());
        }
        catch (ArgumentException e)
        {
            throw ArgumentExceptionFactory.InvalidState<IEpochCollection>(nameof(epochCollection), e);
        }
    }

    /// <summary>Composes <see cref="string"/> that describes the <see cref="IEpoch"/> of <paramref name="epochCollection"/>.</summary>
    /// <param name="epochCollection">The composed <see cref="string"/> describe the <see cref="IEpoch"/> of this <see cref="IEpochCollection"/>.</param>
    /// <param name="epochEnumerator">The <see cref="IEnumerator{T}"/> used to enumerate the <see cref="IEpoch"/> of <paramref name="epochCollection"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidOperationException"/>
    private IEnumerable<string> ComposeComponents(IEpochCollection epochCollection, IEnumerator<IEpoch> epochEnumerator)
    {
        ArgumentNullException.ThrowIfNull(epochEnumerator);

        while (epochEnumerator.MoveNext())
        {
            yield return Compose(epochCollection, epochEnumerator.Current);
        }
    }

    /// <summary>Composes a <see cref="string"/> describing <paramref name="epoch"/>.</summary>
    /// <param name="epochCollection">Provides the <see cref="EpochFormat"/> and related information about how to compose the <see cref="string"/>.</param>
    /// <param name="epoch">The composed <see cref="string"/> describes this <see cref="IEpoch"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidOperationException"/>
    private string Compose(IEpochCollection epochCollection, IEpoch epoch)
    {
        ArgumentNullException.ThrowIfNull(epoch);

        try
        {
            return QueryEpochComposer.Compose(epoch, epochCollection.Format, epochCollection.Calendar, epochCollection.TimeSystem, epochCollection.UTCOffset);
        }
        catch (ArgumentException e)
        {
            throw ArgumentExceptionFactory.InvalidState<IEpochCollection>(nameof(epochCollection), e);
        }
    }
}
