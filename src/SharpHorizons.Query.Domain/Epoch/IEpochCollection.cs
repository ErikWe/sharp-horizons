namespace SharpHorizons.Query.Epoch;

using SharpMeasures;

using System;
using System.Collections.Generic;
using System.ComponentModel;

/// <summary>Uses a collection of individual <see cref="IEpoch"/> to describe the <see cref="IEpochSelection"/> in a query.</summary>
public interface IEpochCollection : IEnumerable<IEpoch>, IEpochSelection
{
    /// <summary>The selected <see cref="IEpoch"/>.</summary>
    public abstract IEnumerable<IEpoch> Epochs { get; }

    /// <summary>Constructs a new <see cref="IEpochCollection"/>, with <paramref name="epochs"/> added to the collection.</summary>
    /// <param name="epochs">These <see cref="IEpoch"/> are added to the <see cref="IEpochCollection"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    public abstract IEpochCollection Concat(IEnumerable<IEpoch> epochs);

    /// <summary>Constructs a new <see cref="IEpochCollection"/> with an updated <see cref="IEpochSelection.Format"/>.</summary>
    /// <param name="format"><inheritdoc cref="IEpochSelection.Format" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    new public abstract IEpochCollection WithConfiguration(EpochFormat format);

    /// <summary>Constructs a new <see cref="IEpochCollection"/> with an updated <see cref="IEpochSelection.Calendar"/>.</summary>
    /// <param name="calendar"><inheritdoc cref="IEpochSelection.Calendar" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    new public abstract IEpochCollection WithConfiguration(CalendarType calendar);

    /// <summary>Constructs a new <see cref="IEpochCollection"/> with an updated <see cref="IEpochSelection.TimeSystem"/>.</summary>
    /// <param name="timeSystem"><inheritdoc cref="IEpochSelection.TimeSystem" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    new public abstract IEpochCollection WithConfiguration(TimeSystem timeSystem);

    /// <summary>Constructs a new <see cref="IEpochCollection"/> with an updated <see cref="IEpochSelection.Offset"/>.</summary>
    /// <param name="offset"><inheritdoc cref="IEpochSelection.Offset" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    new public abstract IEpochCollection WithConfiguration(Time offset);

    /// <summary>Constructs a new <see cref="IEpochCollection"/> with the new configuration. Properties that correspond to a <see langword="null"/> parameter are not modified.</summary>
    /// <param name="format"><inheritdoc cref="IEpochSelection.Format" path="/summary"/></param>
    /// <param name="calendar"><inheritdoc cref="IEpochSelection.Calendar" path="/summary"/></param>
    /// <param name="timeSystem"><inheritdoc cref="IEpochSelection.TimeSystem" path="/summary"/></param>
    /// <param name="offset"><inheritdoc cref="IEpochSelection.Offset" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    new public abstract IEpochCollection WithConfiguration(EpochFormat? format = null, CalendarType? calendar = null, TimeSystem? timeSystem = null, Time? offset = null);
}
