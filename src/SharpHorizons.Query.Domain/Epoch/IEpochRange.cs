namespace SharpHorizons.Query.Epoch;

using SharpMeasures;

using System;
using System.ComponentModel;

/// <summary>Uses the timespan between two <see cref="IEpoch"/> and an associated <see cref="IStepSize"/> to describe the <see cref="IEpochSelection"/> in a query.</summary>
public interface IEpochRange : IEpochSelection
{
    /// <summary>The start-point of the <see cref="IEpochRange"/>.</summary>
    public abstract IStartEpoch StartEpoch { get; }

    /// <summary>The stop-point of the <see cref="IEpochRange"/>.</summary>
    public abstract IStopEpoch StopEpoch { get; }

    /// <summary>The <see cref="IStepSize"/>, describing the difference between each <see cref="IEpoch"/> in the <see cref="IEpochSelection"/>.</summary>
    public abstract IStepSize StepSize { get; }

    /// <summary>Constructs a new <see cref="IEpochRange"/> with an updated <see cref="IEpochSelection.Format"/>.</summary>
    /// <param name="format"><inheritdoc cref="IEpochSelection.Format" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    new public abstract IEpochRange WithConfiguration(EpochFormat format);

    /// <summary>Constructs a new <see cref="IEpochRange"/> with an updated <see cref="IEpochSelection.Calendar"/>.</summary>
    /// <param name="calendar"><inheritdoc cref="IEpochSelection.Calendar" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    new public abstract IEpochRange WithConfiguration(CalendarType calendar);

    /// <summary>Constructs a new <see cref="IEpochRange"/> with an updated <see cref="IEpochSelection.TimeSystem"/>.</summary>
    /// <param name="timeSystem"><inheritdoc cref="IEpochSelection.TimeSystem" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    new public abstract IEpochRange WithConfiguration(TimeSystem timeSystem);

    /// <summary>Constructs a new <see cref="IEpochRange"/> with an updated <see cref="IEpochSelection.Offset"/>.</summary>
    /// <param name="offset"><inheritdoc cref="IEpochSelection.Offset" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    new public abstract IEpochRange WithConfiguration(Time offset);

    /// <summary>Constructs a new <see cref="IEpochRange"/> with the new configuration. Properties that correspond to a <see langword="null"/> parameter are not modified.</summary>
    /// <param name="format"><inheritdoc cref="IEpochSelection.Format" path="/summary"/></param>
    /// <param name="calendar"><inheritdoc cref="IEpochSelection.Calendar" path="/summary"/></param>
    /// <param name="timeSystem"><inheritdoc cref="IEpochSelection.TimeSystem" path="/summary"/></param>
    /// <param name="offset"><inheritdoc cref="IEpochSelection.Offset" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    new public abstract IEpochRange WithConfiguration(EpochFormat? format = null, CalendarType? calendar = null, TimeSystem? timeSystem = null, Time? offset = null);
}
