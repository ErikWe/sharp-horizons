namespace SharpHorizons.Query.Arguments.Composers;

using SharpHorizons.Query.Epoch;

/// <summary>Composes <see cref="ICalendarTypeArgument"/> that describe <see cref="CalendarType"/>.</summary>
public interface IEpochCalendarComposer : IArgumentComposer<ICalendarTypeArgument, CalendarType> { }
