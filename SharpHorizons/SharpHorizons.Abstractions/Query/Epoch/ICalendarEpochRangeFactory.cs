namespace SharpHorizons.Query.Epoch;

using System;
using System.ComponentModel;

/// <summary>Handles construction of <see cref="IEpochRange"/> using the timespan between two <see cref="IEpoch"/>, with some calendar-based <see cref="IStepSize"/>.</summary>
/// <remarks>To construct <see cref="IEpochRange"/> using a non-variable calendar-related unit, such as days or weeks, use <see cref="IFixedEpochRangeFactory"/>.</remarks>
public interface ICalendarEpochRangeFactory
{
    /// <summary>Constructs a <see cref="IEpochRange"/> using the timespan between <paramref name="startEpoch"/> and <paramref name="stopEpoch"/>, with a <see cref="IStepSize"/> such that each step represents <paramref name="count"/> of some calendar-based <paramref name="unit"/>.</summary>
    /// <param name="startEpoch"><inheritdoc cref="IEpochRange.StartEpoch" path="/summary"/></param>
    /// <param name="stopEpoch"><inheritdoc cref="IEpochRange.StopEpoch" path="/summary"/></param>
    /// <param name="count"><inheritdoc cref="ICalendarStepSize.Count" path="/summary"/></param>
    /// <param name="unit"><inheritdoc cref="ICalendarStepSize.Unit" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="ArgumentOutOfRangeException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract IEpochRange Create(IEpoch startEpoch, IEpoch stopEpoch, int count, CalendarStepSizeUnit unit);

    /// <summary>Constructs a <see cref="IEpochRange"/> using the timespan between <paramref name="startEpoch"/> and <paramref name="stopEpoch"/>, with a <see cref="IStepSize"/> such that each step represents <paramref name="count"/> <see cref="CalendarStepSizeUnit.Month"/>.</summary>
    /// <param name="startEpoch"><inheritdoc cref="IEpochRange.StartEpoch" path="/summary"/></param>
    /// <param name="stopEpoch"><inheritdoc cref="IEpochRange.StopEpoch" path="/summary"/></param>
    /// <param name="count"><inheritdoc cref="ICalendarStepSizeFactory.Months(int)" path="/param[@name='count']"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="ArgumentOutOfRangeException"/>
    public abstract IEpochRange Months(IEpoch startEpoch, IEpoch stopEpoch, int count);

    /// <summary>Constructs a <see cref="IEpochRange"/> using the timespan between <paramref name="startEpoch"/> and <paramref name="stopEpoch"/>, with a <see cref="IStepSize"/> such that each step represents <paramref name="count"/> <see cref="CalendarStepSizeUnit.Year"/>.</summary>
    /// <param name="startEpoch"><inheritdoc cref="IEpochRange.StartEpoch" path="/summary"/></param>
    /// <param name="stopEpoch"><inheritdoc cref="IEpochRange.StopEpoch" path="/summary"/></param>
    /// <param name="count"><inheritdoc cref="ICalendarStepSizeFactory.Years(int)" path="/param[@name='count']"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="ArgumentOutOfRangeException"/>
    public abstract IEpochRange Years(IEpoch startEpoch, IEpoch stopEpoch, int count);
}
