namespace SharpHorizons.Query.Epoch;

using SharpHorizons;

using SharpMeasures;

/// <inheritdoc cref="ICalendarEpochRangeFactory"/>
internal sealed class CalendarEpochRangeFactory : ICalendarEpochRangeFactory
{
    /// <inheritdoc cref="ICalendarStepSizeFactory"/>
    private ICalendarStepSizeFactory StepSizeFactory { get; }

    /// <inheritdoc cref="IEpochRangeFactory"/>
    private IEpochRangeFactory EpochRangeFactory { get; }

    /// <inheritdoc cref="CalendarEpochRangeFactory"/>
    /// <param name="stepSizeFactory"><inheritdoc cref="StepSizeFactory" path="/summary"/></param>
    /// <param name="epochRangeFactory"><inheritdoc cref="EpochRangeFactory" path="/summary"/></param>
    public CalendarEpochRangeFactory(ICalendarStepSizeFactory? stepSizeFactory = null, IEpochRangeFactory? epochRangeFactory = null)
    {
        StepSizeFactory = stepSizeFactory ?? new CalendarStepSizeFactory();

        EpochRangeFactory = epochRangeFactory ?? new SimpleEpochRangeFactory();
    }

    /// <inheritdoc cref="IEpochRangeFactory.Create(IEpoch, IEpoch, IStepSize)"/>
    private IEpochRange Create(IEpoch startEpoch, IEpoch stopEpoch, IStepSize stepSize) => EpochRangeFactory.Create(startEpoch, stopEpoch, stepSize);

    IEpochRange IEpochRangeFactory.Create(IEpoch startEpoch, IEpoch stopEpoch, IStepSize stepSize) => Create(startEpoch, stopEpoch, stepSize);
    IEpochRange ICalendarEpochRangeFactory.Create(IEpoch startEpoch, IEpoch stopEpoch, int count, CalendarStepSizeUnit unit)
    {
        var stepSize = StepSizeFactory.Create(count, unit);

        return Create(startEpoch, stopEpoch, stepSize);
    }

    IEpochRangeFactory IEpochRangeFactory.WithFormat(EpochFormat format) => EpochRangeFactory.WithFormat(format);
    IEpochRangeFactory IEpochRangeFactory.WithCalendar(CalendarType calendar) => EpochRangeFactory.WithCalendar(calendar);
    IEpochRangeFactory IEpochRangeFactory.WithTimeSystem(TimeSystem timeSystem) => EpochRangeFactory.WithTimeSystem(timeSystem);
    IEpochRangeFactory IEpochRangeFactory.WithUTCOffset(Time utcOffset) => EpochRangeFactory.WithUTCOffset(utcOffset);
}
