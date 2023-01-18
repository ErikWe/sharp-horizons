namespace SharpHorizons.Query.Epoch;

using SharpMeasures;

using System;
using System.ComponentModel;

/// <summary>Handles construction of <see cref="IEpochRange"/> using the timespan between two <see cref="IEpoch"/>, and some <see cref="IStepSize"/>.</summary>
public interface IEpochRangeFactory
{
    /// <summary>Constructs an <see cref="IEpochRange"/> using the timespan between <paramref name="startEpoch"/> and <paramref name="stopEpoch"/>, and some <paramref name="stepSize"/>.</summary>
    /// <param name="startEpoch"><inheritdoc cref="IEpochRange.StartEpoch" path="/summary"/></param>
    /// <param name="stopEpoch"><inheritdoc cref="IEpochRange.StopEpoch" path="/summary"/></param>
    /// <param name="stepSize"><inheritdoc cref="IEpochRange.StepSize" path="/summary"/></param>
    /// <returns>The constructed <see cref="IEpochRange"/>.</returns>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract IEpochRange Create(IEpoch startEpoch, IEpoch stopEpoch, IStepSize stepSize);

    /// <summary>Specifies the <see cref="IEpochSelection.Format"/> of the constructed <see cref="IEpochRange"/>.</summary>
    /// <param name="format"><inheritdoc cref="IEpochSelection.Format" path="/summary"/></param>
    /// <returns>The same instance of <see cref="IEpochRangeFactory"/>, so that calls can be chained.</returns>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract IEpochRangeFactory WithFormat(EpochFormat format);

    /// <summary>Specifies the <see cref="IEpochSelection.Calendar"/> of the constructed <see cref="IEpochRange"/>.</summary>
    /// <param name="calendar"><inheritdoc cref="IEpochSelection.Calendar" path="/summary"/></param>
    /// <returns>The same instance of <see cref="IEpochRangeFactory"/>, so that calls can be chained.</returns>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract IEpochRangeFactory WithCalendar(CalendarType calendar);

    /// <summary>Specifies the <see cref="IEpochSelection.TimeSystem"/> of the constructed <see cref="IEpochRange"/>.</summary>
    /// <param name="timeSystem"><inheritdoc cref="IEpochSelection.TimeSystem" path="/summary"/></param>
    /// <returns>The same instance of <see cref="IEpochRangeFactory"/>, so that calls can be chained.</returns>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract IEpochRangeFactory WithTimeSystem(TimeSystem timeSystem);

    /// <summary>Specifies the <see cref="IEpochSelection.UTCOffset"/> of the constructed <see cref="IEpochRange"/>.</summary>
    /// <param name="utcOffset"><inheritdoc cref="IEpochSelection.UTCOffset" path="/summary"/></param>
    /// <returns>The same instance of <see cref="IEpochRangeFactory"/>, so that calls can be chained.</returns>
    /// <exception cref="ArgumentException"/>
    public abstract IEpochRangeFactory WithUTCOffset(Time utcOffset);
}
