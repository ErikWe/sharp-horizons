namespace SharpHorizons;

using NodaTime;

using SharpMeasures;

using System;
using System.Diagnostics.CodeAnalysis;

/// <summary>Represents an <see cref="IEpoch"/>, expressed as an <see cref="NodaTime.Instant"/>.</summary>
public sealed record class Epoch : IEpoch<Epoch>
{
    /// <summary>The <see cref="NodaTime.Instant"/> represented by the <see cref="Epoch"/>.</summary>
    public required Instant Instant { get; init; }

    /// <inheritdoc cref="Epoch"/>
    public Epoch() { }

    /// <inheritdoc cref="Epoch"/>
    /// <param name="instant"><inheritdoc cref="Instant" path="/summary"/></param>
    [SetsRequiredMembers]
    public Epoch(Instant instant)
    {
        Instant = instant;
    }

    /// <inheritdoc cref="Epoch"/>
    /// <param name="zonedDateTime">Describes the <see cref="NodaTime.Instant"/> represented by the <see cref="Epoch"/>, in some <see cref="DateTimeZone"/>.</param>
    [SetsRequiredMembers]
    public Epoch(ZonedDateTime zonedDateTime) : this(zonedDateTime.ToInstant()) { }

    /// <summary>Converts the <see cref="Epoch"/> to an instance of <see cref="JulianDay"/> representing the same epoch.</summary>
    public JulianDay ToJulianDay() => new(Instant.ToJulianDate());

    /// <summary>Constructs an instance of <see cref="Epoch"/>, representing the same epoch as <paramref name="julianDay"/>.</summary>
    /// <param name="julianDay">The constructed <see cref="Epoch"/> represents the same epoch as this <see cref="JulianDay"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="ArgumentOutOfRangeException"/>
    public static Epoch FromJulianDay(JulianDay julianDay)
    {
        ArgumentNullException.ThrowIfNull(julianDay);

        return new(Instant.FromJulianDate(julianDay.Day));
    }

    IEpoch IEpoch.Add(Time difference) => Add(difference);

    /// <inheritdoc/>
    public int CompareTo(IEpoch? other)
    {
        if (other is null)
        {
            return 1;
        }

        return Instant.CompareTo(other.Instant);
    }

    /// <summary>Computes the <see cref="Time"/> difference { <see langword="this"/> - <paramref name="initial"/> }.</summary>
    /// <param name="initial">The initial <see cref="IEpoch"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    public Time Difference(IEpoch initial)
    {
        ArgumentNullException.ThrowIfNull(initial);

        return (Instant - initial.Instant).TotalDays * Time.OneDay;
    }

    /// <summary>Computes the <see cref="Epoch"/> representing { <see langword="this"/> + <paramref name="difference"/> }.</summary>
    /// <param name="difference">The <see cref="Time"/> between <see langword="this"/> <see cref="Epoch"/> and the resulting <see cref="Epoch"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="EpochOutOfBoundsException"/>
    public Epoch Add(Time difference)
    {
        SharpMeasuresValidation.Validate(difference);

        try
        {
            return new(Instant + Duration.FromDays(difference.Days));
        }
        catch (ArgumentOutOfRangeException e)
        {
            throw EpochOutOfBoundsException.FromAddition<Epoch>(difference, e);
        }
    }

    /// <summary>Computes the <see cref="Time"/> difference { <paramref name="final"/> - <paramref name="initial"/>.</summary>
    /// <param name="initial">The <see cref="Epoch"/> representing the initial epoch.</param>
    /// <param name="final">The <see cref="Epoch"/> representing the final epoch.</param>
    /// <exception cref="ArgumentNullException"/>
    public static Time operator -(Epoch final, Epoch initial)
    {
        ArgumentNullException.ThrowIfNull(final);

        return final.Difference(initial);
    }

    /// <summary>Computes the <see cref="Epoch"/> representing { <paramref name="initial"/> + <paramref name="difference"/> }.</summary>
    /// <param name="initial">The <see cref="Epoch"/> representing the initial epoch.</param>
    /// <param name="difference">The <see cref="Time"/> between the <paramref name="initial"/> <see cref="Epoch"/> and the resulting <see cref="Epoch"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="EpochOutOfBoundsException"/>
    public static Epoch operator +(Epoch initial, Time difference)
    {
        ArgumentNullException.ThrowIfNull(initial);

        return initial.Add(difference);
    }

    /// <summary>Computes the <see cref="Epoch"/> representing { <paramref name="initial"/> - <paramref name="difference"/> }.</summary>
    /// <param name="initial">The <see cref="Epoch"/> representing the initial epoch.</param>
    /// <param name="difference">The <see cref="Time"/> between the <paramref name="initial"/> <see cref="Epoch"/> and the resulting <see cref="Epoch"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="EpochOutOfBoundsException"/>
    public static Epoch operator -(Epoch initial, Time difference)
    {
        ArgumentNullException.ThrowIfNull(initial);

        return initial.Add(-difference);
    }

    /// <inheritdoc cref="Epoch"/>
    /// <param name="instant"><inheritdoc cref="Instant" path="/summary"/></param>
    public static explicit operator Epoch(Instant instant) => new(instant);

    /// <summary>Retrieves the <see cref="Instant"/> represented by <paramref name="epoch"/>.</summary>
    /// <param name="epoch">The <see cref="Instant"/> represented by this <see cref="Epoch"/> is retrieved.</param>
    /// <exception cref="ArgumentNullException"/>
    public static explicit operator Instant(Epoch epoch)
    {
        ArgumentNullException.ThrowIfNull(epoch);

        return epoch.Instant;
    }
}
