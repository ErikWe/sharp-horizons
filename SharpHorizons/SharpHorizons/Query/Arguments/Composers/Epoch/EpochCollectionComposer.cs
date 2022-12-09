namespace SharpHorizons.Query.Arguments.Composers.Epoch;

using SharpHorizons.Query.Epoch;

using SharpMeasures;

using System;
using System.Collections.Generic;
using System.ComponentModel;

/// <summary>Composes <see cref="IEpochCollectionArgument"/> that describe <see cref="IEpochCollection"/>.</summary>
internal sealed class EpochCollectionComposer : IEpochCollectionComposer<IEpochCollection>
{
    /// <inheritdoc cref="IQueryEpochComposer"/>
    private IQueryEpochComposer QueryEpochComposer { get; }

    /// <inheritdoc cref="EpochCalendarComposer"/>
    /// <param name="queryEpochComposer"><inheritdoc cref="QueryEpochComposer" path="/summary"/></param>
    public EpochCollectionComposer(IQueryEpochComposer? queryEpochComposer = null)
    {
        QueryEpochComposer = queryEpochComposer ?? new QueryEpochComposer();
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
        catch (ArgumentNullException e)
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
            return Compose(epoch, epochCollection.Format, epochCollection.Calendar, epochCollection.TimeSystem, epochCollection.Offset);
        }
        catch (ArgumentException e)
        {
            throw ArgumentExceptionFactory.InvalidState<IEpochCollection>(nameof(epochCollection), e);
        }
    }

    /// <summary>Composes a <see cref="string"/> describing <paramref name="epoch"/>.</summary>
    /// <param name="epoch">The composed <see cref="string"/> describes this <see cref="IEpoch"/>.</param>
    /// <param name="format"><inheritdoc cref="QueryEpoch.Format" path="/summary"/></param>
    /// <param name="calendar"><inheritdoc cref="QueryEpoch.Calendar" path="/summary"/></param>
    /// <param name="timeSystem"><inheritdoc cref="QueryEpoch.TimeSystem" path="/summary"/></param>
    /// <param name="offset"><inheritdoc cref="QueryEpoch.Offset" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    /// <exception cref="InvalidOperationException"/>
    private string Compose(IEpoch epoch, EpochFormat format, CalendarType calendar, TimeSystem timeSystem, Time offset)
    {
        QueryEpoch queryEpoch = new(epoch) { Format = format, Calendar = calendar, TimeSystem = timeSystem, Offset = offset };

        return Compose(queryEpoch);
    }

    /// <summary>Composes a <see cref="string"/> describing <paramref name="queryEpoch"/>.</summary>
    /// <param name="queryEpoch">The composed <see cref="string"/> describes this <see cref="QueryEpoch"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidOperationException"/>
    private string Compose(QueryEpoch queryEpoch)
    {
        var composed = QueryEpochComposer.Compose(queryEpoch);

        if (string.IsNullOrEmpty(composed))
        {
            throw new InvalidOperationException($"The {nameof(IQueryEpochComposer)} provided an invalid {nameof(String)}.");
        }

        return composed;
    }
}
