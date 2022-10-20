namespace SharpHorizons.Calendars;

using System;
using System.Diagnostics.CodeAnalysis;

/// <summary>Represents a point in time, expressed in some calendar.</summary>
public interface ICalendarDate
{
    /// <summary>Converts <see langword="this"/> to the equivalent <typeparamref name="TCalendarDate"/>.</summary>
    /// <typeparam name="TCalendarDate"><see langword="this"/> is converted to the equivalent <see cref="ICalendarDate"/> of this type.</typeparam>
    public abstract TCalendarDate ToCalendarDate<TCalendarDate>() where TCalendarDate : ICalendarDate<TCalendarDate>;

    /// <summary>Converts <see langword="this"/> to the equivalent <see cref="JulianDay"/>.</summary>
    public abstract JulianDay ToJulianDay();

    /// <summary>Converts <see langword="this"/> to the equivalent <see cref="DateTime"/>.</summary>
    public abstract DateTime ToDateTime();
}

/// <summary>Represents a point in time, expressed in some calendar.</summary>
public interface ICalendarDate<TSelf> : ICalendarDate where TSelf : ICalendarDate<TSelf>
{
    /// <summary>Constructs the <typeparamref name="TSelf"/> equivalent to <paramref name="calendarDate"/>.</summary>
    /// <typeparam name="TCalendarDate">The constructed <typeparamref name="TSelf"/> is equivalent to an <see cref="ICalendarDate"/> of this type.</typeparam>
    /// <param name="calendarDate">The constructed <typeparamref name="TSelf"/> is equivalent to this <typeparamref name="TCalendarDate"/>.</param>
    [SuppressMessage("Design", "CA1000", Justification = "Implementing type is not necessarily generic.")]
    public abstract static TSelf FromCalendarDate<TCalendarDate>(TCalendarDate calendarDate) where TCalendarDate : ICalendarDate<TCalendarDate>;

    /// <summary>Constructs the <typeparamref name="TSelf"/> equivalent to <paramref name="julianDay"/>.</summary>
    /// <param name="julianDay">The constructed <typeparamref name="TSelf"/> is equivalent to this <see cref="JulianDay"/>.</param>
    [SuppressMessage("Design", "CA1000", Justification = "Implementing type is not necessarily generic.")]
    public abstract static TSelf FromJulianDay(JulianDay julianDay);

    /// <summary>Constructs the <typeparamref name="TSelf"/> equivalent to <paramref name="dateTime"/>.</summary>
    /// <param name="dateTime">The constructed <typeparamref name="TSelf"/> is equivalent to this <see cref="DateTime"/>.</param>
    [SuppressMessage("Design", "CA1000", Justification = "Implementing type is not necessarily generic.")]
    public abstract static TSelf FromDateTime(DateTime dateTime);
}