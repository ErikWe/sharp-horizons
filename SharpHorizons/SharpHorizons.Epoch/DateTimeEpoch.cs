namespace SharpHorizons;

using NodaTime;

using SharpMeasures;

using System;
using System.Diagnostics.CodeAnalysis;

/// <summary>Represents an <see cref="IEpoch"/>, expressed as a <see cref="System.DateTimeOffset"/>.</summary>
public sealed record class DateTimeEpoch : IEpoch<DateTimeEpoch>
{
    /// <summary>The <see cref="System.DateTimeOffset"/> represented by the <see cref="DateTimeEpoch"/>.</summary>
    public required DateTimeOffset DateTimeOffset { get; init; }

    /// <summary>The <see cref="System.DateTime"/> represented by the <see cref="DateTimeEpoch"/> - ignoring the <see cref="Offset"/>.</summary>
    public DateTime DateTime => DateTimeOffset.DateTime;

    /// <summary>The <see cref="TimeSpan"/> offset to UTC of the <see cref="System.DateTimeOffset"/>.</summary>
    public TimeSpan Offset => DateTimeOffset.Offset;

    Instant IEpoch.Instant => Instant.FromDateTimeOffset(DateTimeOffset);

    /// <inheritdoc cref="DateTimeEpoch"/>
    public DateTimeEpoch() { }

    /// <inheritdoc cref="DateTimeEpoch"/>
    /// <param name="instant"><inheritdoc cref="DateTimeOffset" path="/summary"/></param>
    [SetsRequiredMembers]
    public DateTimeEpoch(DateTimeOffset instant)
    {
        DateTimeOffset = instant;
    }

    /// <inheritdoc cref="DateTimeEpoch"/>
    /// <param name="dateTime"><inheritdoc cref="DateTime" path="/summary"/></param>
    /// <param name="offset"><inheritdoc cref="Offset" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentOutOfRangeException"/>
    [SetsRequiredMembers]
    public DateTimeEpoch(DateTime dateTime, TimeSpan offset) : this(new DateTimeOffset(dateTime, offset)) { }

    /// <summary>Converts the <see cref="DateTimeEpoch"/> to an instance of <see cref="JulianDay"/> representing the same epoch.</summary>
    public JulianDay ToJulianDay() => new Epoch(Instant.FromDateTimeOffset(DateTimeOffset)).ToJulianDay();

    /// <summary>Constructs an instance of <see cref="DateTimeEpoch"/>, representing the same epoch as <paramref name="julianDay"/>.</summary>
    /// <param name="julianDay">The constructed <see cref="DateTimeEpoch"/> represents the same epoch as this <see cref="JulianDay"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="ArgumentOutOfRangeException"/>
    public static DateTimeEpoch FromJulianDay(JulianDay julianDay)
    {
        ArgumentNullException.ThrowIfNull(julianDay);

        try
        {
            return new(Instant.FromJulianDate(julianDay.Day).ToDateTimeOffset());
        }
        catch (InvalidOperationException e)
        {
            throw new ArgumentOutOfRangeException($"The {nameof(JulianDay)} {julianDay} could not be represented as a {nameof(DateTimeEpoch)}.", e);
        }
    }

    IEpoch IEpoch.Add(Time difference) => Add(difference);

    /// <inheritdoc/>
    public int CompareTo(IEpoch? other)
    {
        if (other is null)
        {
            return 1;
        }

        return ToJulianDay().CompareTo(other);
    }

    /// <summary>Computes the <see cref="Time"/> difference { <see langword="this"/> - <paramref name="initial"/> }.</summary>
    /// <param name="initial">The initial <see cref="IEpoch"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    public Time Difference(IEpoch initial)
    {
        ArgumentNullException.ThrowIfNull(initial);

        return ToJulianDay().Difference(initial);
    }

    /// <summary>Computes the <see cref="DateTimeEpoch"/> representing { <see langword="this"/> + <paramref name="difference"/> }.</summary>
    /// <param name="difference">The <see cref="Time"/> between <see langword="this"/> <see cref="DateTimeEpoch"/> and the resulting <see cref="DateTimeEpoch"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="EpochOutOfBoundsException"/>
    public DateTimeEpoch Add(Time difference)
    {
        SharpMeasuresValidation.Validate(difference);

        try
        {
            return new(DateTimeOffset.AddDays(difference.Days));
        }
        catch (ArgumentOutOfRangeException e)
        {
            throw EpochOutOfBoundsException.FromAddition<DateTimeEpoch>(difference, e);
        }
    }

    /// <summary>Computes the <see cref="Time"/> difference { <paramref name="final"/> - <paramref name="initial"/> }.</summary>
    /// <param name="final">The <see cref="DateTimeEpoch"/> representing the final epoch.</param>
    /// <param name="initial">The <see cref="DateTimeEpoch"/> representing the initial epoch.</param>
    /// <exception cref="ArgumentNullException"/>
    public static Time operator -(DateTimeEpoch final, DateTimeEpoch initial)
    {
        ArgumentNullException.ThrowIfNull(final);

        return final.Difference(initial);
    }

    /// <summary>Computes the <see cref="Time"/> difference { <paramref name="final"/> - <paramref name="initial"/> }.</summary>
    /// <param name="final">The <see cref="DateTimeEpoch"/> representing the final epoch.</param>
    /// <param name="initial">The <see cref="IEpoch"/> representing the initial epoch.</param>
    /// <exception cref="ArgumentNullException"/>
    public static Time operator -(DateTimeEpoch final, IEpoch initial)
    {
        ArgumentNullException.ThrowIfNull(final);

        return final.Difference(initial);
    }

    /// <summary>Computes the <see cref="DateTimeEpoch"/> representing { <paramref name="initial"/> + <paramref name="difference"/> }.</summary>
    /// <param name="initial">The <see cref="DateTimeEpoch"/> representing the initial epoch.</param>
    /// <param name="difference">The <see cref="Time"/> between the <paramref name="initial"/> <see cref="DateTimeEpoch"/> and the resulting <see cref="DateTimeEpoch"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="EpochOutOfBoundsException"/>
    public static DateTimeEpoch operator +(DateTimeEpoch initial, Time difference)
    {
        ArgumentNullException.ThrowIfNull(initial);

        return initial.Add(difference);
    }

    /// <summary>Computes the <see cref="DateTimeEpoch"/> representing { <paramref name="initial"/> - <paramref name="difference"/> }.</summary>
    /// <param name="initial">The <see cref="DateTimeEpoch"/> representing the initial epoch.</param>
    /// <param name="difference">The <see cref="Time"/> between the <paramref name="initial"/> <see cref="DateTimeEpoch"/> and the resulting <see cref="DateTimeEpoch"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="EpochOutOfBoundsException"/>
    public static DateTimeEpoch operator -(DateTimeEpoch initial, Time difference)
    {
        ArgumentNullException.ThrowIfNull(initial);

        return initial.Add(-difference);
    }

    /// <inheritdoc cref="DateTimeEpoch"/>
    /// <param name="instant"><inheritdoc cref="DateTimeOffset" path="/summary"/></param>
    public static implicit operator DateTimeEpoch(DateTimeOffset instant) => new(instant);

    /// <summary>Retrieves the <see cref="DateTimeOffset"/> represented by <paramref name="epoch"/>.</summary>
    /// <param name="epoch">The <see cref="DateTimeOffset"/> represented by this <see cref="Epoch"/> is retrieved.</param>
    /// <exception cref="ArgumentNullException"/>
    public static explicit operator DateTimeOffset(DateTimeEpoch epoch)
    {
        ArgumentNullException.ThrowIfNull(epoch);

        return epoch.DateTimeOffset;
    }
}
