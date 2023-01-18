namespace SharpHorizons.Query.Epoch;

using SharpMeasures;

using System;
using System.Collections.Generic;
using System.ComponentModel;

/// <summary>Handles construction of <see cref="IEpochCollection"/>.</summary>
public interface IEpochCollectionFactory
{
    /// <summary>Constructs an <see cref="IEpochCollection"/> containing <paramref name="epochs"/>.</summary>
    /// <param name="epochs"><inheritdoc cref="IEpochCollection.Epochs" path="/summary"/></param>
    /// <exception cref="ArgumentNullException"/>
    public abstract IEpochCollection Create(IEnumerable<IEpoch> epochs);

    /// <summary>Constructs an <see cref="IEpochCollection"/> containing <paramref name="epochs"/>.</summary>
    /// <param name="epochs"><inheritdoc cref="IEpochCollection.Epochs" path="/summary"/></param>
    /// <exception cref="ArgumentNullException"/>
    public abstract IEpochCollection Create(params IEpoch[] epochs);

    /// <summary>Specifies the <see cref="IEpochSelection.Format"/> of the constructed <see cref="IEpochCollection"/>.</summary>
    /// <param name="format"><inheritdoc cref="IEpochSelection.Format" path="/summary"/></param>
    /// <returns>The same instance of <see cref="IEpochCollectionFactory"/>, so that calls can be chained.</returns>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract IEpochCollectionFactory WithFormat(EpochFormat format);

    /// <summary>Specifies the <see cref="IEpochSelection.Calendar"/> of the constructed <see cref="IEpochCollection"/>.</summary>
    /// <param name="calendar"><inheritdoc cref="IEpochSelection.Calendar" path="/summary"/></param>
    /// <returns>The same instance of <see cref="IEpochCollectionFactory"/>, so that calls can be chained.</returns>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract IEpochCollectionFactory WithCalendar(CalendarType calendar);

    /// <summary>Specifies the <see cref="IEpochSelection.TimeSystem"/> of the constructed <see cref="IEpochCollection"/>.</summary>
    /// <param name="timeSystem"><inheritdoc cref="IEpochSelection.TimeSystem" path="/summary"/></param>
    /// <returns>The same instance of <see cref="IEpochCollectionFactory"/>, so that calls can be chained.</returns>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract IEpochCollectionFactory WithTimeSystem(TimeSystem timeSystem);

    /// <summary>Specifies the <see cref="IEpochSelection.UTCOffset"/> of the constructed <see cref="IEpochCollection"/>.</summary>
    /// <param name="utcOffset"><inheritdoc cref="IEpochSelection.UTCOffset" path="/summary"/></param>
    /// <returns>The same instance of <see cref="IEpochCollectionFactory"/>, so that calls can be chained.</returns>
    /// <exception cref="ArgumentException"/>
    public abstract IEpochCollectionFactory WithUTCOffset(Time utcOffset);
}
