namespace SharpHorizons;

using NodaTime;

using SharpMeasures;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

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

        try
        {
            return new(Instant.FromJulianDate(julianDay.Day));
        }
        catch (ArgumentOutOfRangeException e)
        {
            throw new ArgumentOutOfRangeException($"The {nameof(JulianDay)} {julianDay} could not be represented as an {nameof(Epoch)}.", e);
        }
    }

    /// <summary>Compares the <see cref="Epoch"/> <see langword="this"/> and <paramref name="other"/>, resulting in:
    /// <list type="bullet">
    /// <item><term>+1</term><description> <see langword="this"/> <see cref="Epoch"/> represents a later epoch than the <paramref name="other"/> <see cref="Epoch"/>, or the <paramref name="other"/> <see cref="Epoch"/> is <see langword="null"/>.</description></item>
    /// <item><term>0</term><description> the two <see cref="Epoch"/> <see langword="this"/> and <paramref name="other"/> represent the same epoch.</description></item>
    /// <item><term>-1</term><description> <see langword="this"/> <see cref="Epoch"/> represents an earlier epoch than the <paramref name="other"/> <see cref="Epoch"/>.</description></item>
    /// </list></summary>
    /// <param name="other">The <see cref="Epoch"/> to which <see langword="this"/> <see cref="Epoch"/> is compared.</param>
    /// <remarks>The behaviour is consistent with <see cref="Instant.CompareTo(Instant)"/>.</remarks>
    public int CompareTo(Epoch? other)
    {
        if (other is null)
        {
            return 1;
        }

        return Instant.CompareTo(other.Instant);
    }

    /// <summary>Compares the <see cref="IEpoch"/> <see langword="this"/> and <paramref name="other"/>, resulting in:
    /// <list type="bullet">
    /// <item><term>+1</term><description> <see langword="this"/> <see cref="Epoch"/> represents a later epoch than the <paramref name="other"/> <see cref="IEpoch"/>, or the <paramref name="other"/> <see cref="IEpoch"/> is <see langword="null"/>.</description></item>
    /// <item><term>0</term><description> the two <see cref="IEpoch"/> <see langword="this"/> and <paramref name="other"/> represent the same epoch.</description></item>
    /// <item><term>-1</term><description> <see langword="this"/> <see cref="Epoch"/> represents an earlier epoch than the <paramref name="other"/> <see cref="IEpoch"/>.</description></item>
    /// </list></summary>
    /// <param name="other">The <see cref="IEpoch"/> to which <see langword="this"/> <see cref="Epoch"/> is compared.</param>
    /// <exception cref="ArgumentException"/>
    public int CompareTo(IEpoch? other)
    {
        if (other is null)
        {
            return 1;
        }

        if (other is Epoch otherEpoch)
        {
            return CompareTo(otherEpoch);
        }

        return ToJulianDay().CompareTo(other);
    }

    /// <summary>Retrieves a <see cref="string"/>-representation of the <see cref="Instant"/> represented by the <see cref="Epoch"/>, formatted according to the <see cref="CultureInfo.CurrentCulture"/>.</summary>
    /// <remarks>The behaviour is consistent with <see cref="Instant.ToString()"/>.</remarks>
    public override string ToString() => Instant.ToString(null, CultureInfo.CurrentCulture);

    /// <summary>Retrieves a <see cref="string"/>-representation of the <see cref="Instant"/> represented by the <see cref="Epoch"/>, formatted according to <paramref name="provider"/>.</summary>
    /// <param name="provider">Provides culture-specific formatting information.</param>
    /// <remarks>The behaviour is consistent with <see cref="Instant.ToString(string, IFormatProvider)"/>, with <see langword="null"/> as the <see cref="string"/> format.</remarks>
    public string ToString(IFormatProvider? provider) => Instant.ToString(null, provider);

    /// <summary>Retrieves a <see cref="string"/>-representation of the <see cref="Instant"/> represented by the <see cref="Epoch"/>, formatted according to <paramref name="format"/> and the <see cref="CultureInfo.CurrentCulture"/>.</summary>
    /// <param name="format">Provides formatting information.</param>
    /// <remarks>The behaviour is consistent with <see cref="Instant.ToString(string, IFormatProvider)"/>, with the <see cref="CultureInfo.CurrentCulture"/> as the <see cref="IFormatProvider"/>.</remarks>
    public string ToString(string? format) => Instant.ToString(format, CultureInfo.CurrentCulture);

    /// <summary>Retrieves a <see cref="string"/>-representation of the <see cref="Instant"/> represented by the <see cref="Epoch"/>, formatted according to <paramref name="format"/> and <paramref name="provider"/>.</summary>
    /// <param name="format">Provides formatting information.</param>
    /// <param name="provider">Provides culture-specific formatting information.</param>
    /// <remarks>The behaviour is consistent with <see cref="Instant.ToString(string, IFormatProvider)"/>.</remarks>
    public string ToString(string? format, IFormatProvider? provider) => Instant.ToString(format, provider);

    /// <summary>Retrieves a <see cref="string"/>-representation of the <see cref="Instant"/> represented by the <see cref="Epoch"/>, formatted according to the <see cref="CultureInfo.InvariantCulture"/>.</summary>
    /// <remarks>The behaviour is consistent with <see cref="Instant.ToString(string, IFormatProvider)"/>, with <see langword="null"/> as the <see cref="string"/> format and with the <see cref="CultureInfo.InvariantCulture"/> as the <see cref="IFormatProvider"/>.</remarks>
    public string ToStringInvariant() => Instant.ToString(null, CultureInfo.InvariantCulture);

    /// <summary>Retrieves a <see cref="string"/>-representation of the <see cref="Instant"/> represented by the <see cref="Epoch"/>, formatted according to <paramref name="format"/> and the <see cref="CultureInfo.InvariantCulture"/>.</summary>
    /// <param name="format">Provides formatting information.</param>
    /// <remarks>The behaviour is consistent with <see cref="Instant.ToString(string, IFormatProvider)"/>, with the <see cref="CultureInfo.InvariantCulture"/> as the <see cref="IFormatProvider"/>.</remarks>
    public string ToStringInvariant(string? format) => Instant.ToString(format, CultureInfo.InvariantCulture);

    /// <summary>Computes the <see cref="Time"/> difference { <see langword="this"/> - <paramref name="initial"/> }. The resulting <see cref="Time"/> is positive if <see langword="this"/> <see cref="Epoch"/> represents a later epoch than the <paramref name="initial"/> <see cref="Epoch"/>.</summary>
    /// <param name="initial">The <see cref="Epoch"/> representing the initial epoch.</param>
    /// <exception cref="ArgumentNullException"/>
    public Time Difference(Epoch initial)
    {
        ArgumentNullException.ThrowIfNull(initial);

        return Instant.Subtract(Instant, initial.Instant).TotalSeconds * Time.OneSecond;
    }

    /// <summary>Computes the <see cref="Time"/> difference { <see langword="this"/> - <paramref name="initial"/> }. The resulting <see cref="Time"/> is positive if <see langword="this"/> <see cref="Epoch"/> represents a later epoch than the <paramref name="initial"/> <see cref="IEpoch"/>.</summary>
    /// <param name="initial">The <see cref="IEpoch"/> representing the initial epoch.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public Time Difference(IEpoch initial)
    {
        ArgumentNullException.ThrowIfNull(initial);

        if (initial is Epoch initialEpoch)
        {
            return Difference(initialEpoch);
        }

        return ToJulianDay().Difference(initial);
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

    /// <summary>Computes the <see cref="Epoch"/> representing { <see langword="this"/> - <paramref name="difference"/> }.</summary>
    /// <param name="difference">The <see cref="Time"/> between <see langword="this"/> <see cref="Epoch"/> and the resulting <see cref="Epoch"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="EpochOutOfBoundsException"/>
    public Epoch Subtract(Time difference)
    {
        SharpMeasuresValidation.Validate(difference);

        try
        {
            return new(Instant - Duration.FromDays(difference.Days));
        }
        catch (ArgumentOutOfRangeException e)
        {
            throw EpochOutOfBoundsException.FromAddition<Epoch>(difference, e);
        }
    }

    /// <summary>Computes the <see cref="Time"/> difference { <paramref name="final"/> - <paramref name="initial"/> }. The resulting <see cref="Time"/> is positive if the <paramref name="final"/> <see cref="Epoch"/> represents a later epoch than the <paramref name="initial"/> <see cref="Epoch"/>.</summary>
    /// <param name="final">The <see cref="Epoch"/> representing the final epoch.</param>
    /// <param name="initial">The <see cref="Epoch"/> representing the initial epoch.</param>
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

        return initial.Subtract(difference);
    }

    /// <summary>Determines the truthfulness of { <paramref name="lhs"/> &lt; <paramref name="rhs"/> }, resulting in:
    /// <list type="bullet">
    /// <item><term><see langword="true"/></term><description> the <see cref="Epoch"/> <paramref name="lhs"/> represents an earlier epoch than the <see cref="Epoch"/> <paramref name="rhs"/>.</description></item>
    /// <item><term><see langword="false"/></term><description> the <see cref="Epoch"/> <paramref name="lhs"/> represents the same or a later epoch than the <see cref="Epoch"/> <paramref name="rhs"/>, or either <see cref="Epoch"/> is <see langword="null"/>.</description></item>
    /// </list>
    /// </summary>
    /// <param name="lhs">This <see cref="Epoch"/> is assumed to represent an earlier epoch than the <see cref="Epoch"/> <paramref name="rhs"/>.</param>
    /// <param name="rhs">This <see cref="Epoch"/> is assumed to represent the same or a later epoch than the <see cref="Epoch"/> <paramref name="lhs"/>.</param>
    /// <remarks>The behaviour is consistent with <see cref="Instant.operator &lt;(Instant, Instant)"/>.</remarks>
    public static bool operator <(Epoch? lhs, Epoch? rhs) => lhs?.Instant < rhs?.Instant;

    /// <summary>Determines the truthfulness of { <paramref name="lhs"/> &gt; <paramref name="rhs"/> }, resulting in:
    /// <list type="bullet">
    /// <item><term><see langword="true"/></term><description> the <see cref="Epoch"/> <paramref name="lhs"/> represents a later epoch than the <see cref="Epoch"/> <paramref name="rhs"/>.</description></item>
    /// <item><term><see langword="false"/></term><description> the <see cref="Epoch"/> <paramref name="lhs"/> represents the same or an earlier epoch than the <see cref="Epoch"/> <paramref name="rhs"/>, or either <see cref="Epoch"/> is <see langword="null"/>.</description></item>
    /// </list>
    /// </summary>
    /// <param name="lhs">This <see cref="Epoch"/> is assumed to represent a later epoch than the <see cref="Epoch"/> <paramref name="rhs"/>.</param>
    /// <param name="rhs">This <see cref="Epoch"/> is assumed to represent the same or an earlier epoch than the <see cref="Epoch"/> <paramref name="lhs"/>.</param>
    /// <remarks>The behaviour is consistent with <see cref="Instant.operator >(Instant, Instant)"/>.</remarks>
    public static bool operator >(Epoch? lhs, Epoch? rhs) => lhs?.Instant > rhs?.Instant;

    /// <summary>Determines the truthfulness of { <paramref name="lhs"/> ≤ <paramref name="rhs"/> }, resulting in:
    /// <list type="bullet">
    /// <item><term><see langword="true"/></term><description> the <see cref="Epoch"/> <paramref name="lhs"/> represents the same or an earlier epoch than the <see cref="Epoch"/> <paramref name="rhs"/>.</description></item>
    /// <item><term><see langword="false"/></term><description> the <see cref="Epoch"/> <paramref name="lhs"/> represents a later epoch than the <see cref="Epoch"/> <paramref name="rhs"/>, or either <see cref="Epoch"/> is <see langword="null"/>.</description></item>
    /// </list>
    /// </summary>
    /// <param name="lhs">This <see cref="Epoch"/> is assumed to represent the same or an earlier epoch than the <see cref="Epoch"/> <paramref name="rhs"/>.</param>
    /// <param name="rhs">This <see cref="Epoch"/> is assumed to represent a later epoch than the <see cref="Epoch"/> <paramref name="lhs"/>.</param>
    /// <remarks>The behaviour is consistent with <see cref="Instant.operator &lt;=(Instant, Instant)"/>.</remarks>
    public static bool operator <=(Epoch? lhs, Epoch? rhs) => lhs?.Instant <= rhs?.Instant;

    /// <summary>Determines the truthfulness of { <paramref name="lhs"/> ≥ <paramref name="rhs"/> }, resulting in:
    /// <list type="bullet">
    /// <item><term><see langword="true"/></term><description> the <see cref="Epoch"/> <paramref name="lhs"/> represents the same or a later epoch than the <see cref="Epoch"/> <paramref name="rhs"/>.</description></item>
    /// <item><term><see langword="false"/></term><description> the <see cref="Epoch"/> <paramref name="lhs"/> represents an earlier epoch than the <see cref="Epoch"/> <paramref name="rhs"/>, or either <see cref="Epoch"/> is <see langword="null"/>.</description></item>
    /// </list>
    /// </summary>
    /// <param name="lhs">This <see cref="Epoch"/> is assumed to represent the same or a later epoch than the <see cref="Epoch"/> <paramref name="rhs"/>.</param>
    /// <param name="rhs">This <see cref="Epoch"/> is assumed to represent an earlier epoch than the <see cref="Epoch"/> <paramref name="lhs"/>.</param>
    /// <remarks>The behaviour is consistent with <see cref="Instant.operator >=(Instant, Instant)"/>.</remarks>
    public static bool operator >=(Epoch? lhs, Epoch? rhs) => lhs?.Instant >= rhs?.Instant;

    /// <summary>Constructs an <see cref="Epoch"/>, representing the <see cref="NodaTime.Instant"/> <paramref name="instant"/>.</summary>
    /// <param name="instant"><inheritdoc cref="Instant" path="/summary"/></param>
    public static Epoch FromInstant(Instant instant) => new(instant);

    /// <inheritdoc cref="Epoch"/>
    /// <param name="instant"><inheritdoc cref="Instant" path="/summary"/></param>
    public static explicit operator Epoch(Instant instant) => FromInstant(instant);

    /// <summary>Retrieves the <see cref="NodaTime.Instant"/> represented by <paramref name="epoch"/>.</summary>
    /// <param name="epoch">The <see cref="NodaTime.Instant"/> represented by this <see cref="Epoch"/> is retrieved.</param>
    /// <exception cref="ArgumentNullException"/>
    public static explicit operator Instant(Epoch epoch)
    {
        ArgumentNullException.ThrowIfNull(epoch);

        return epoch.ToInstant();
    }
}
