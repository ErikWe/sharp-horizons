namespace SharpHorizons;

using NodaTime;

using SharpMeasures;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

/// <summary>Represents an <see cref="IEpoch"/>, expressed as a <see cref="System.DateTimeOffset"/>.</summary>
public sealed record class DateTimeEpoch : IEpoch<DateTimeEpoch>
{
    /// <summary>The <see cref="System.DateTimeOffset"/> represented by the <see cref="DateTimeEpoch"/>.</summary>
    public required DateTimeOffset DateTimeOffset { get; init; }

    /// <summary>The <see cref="System.DateTime"/> represented by the <see cref="DateTimeEpoch"/> - ignoring the <see cref="Offset"/>.</summary>
    public DateTime DateTime => DateTimeOffset.DateTime;

    /// <summary>The <see cref="TimeSpan"/> offset to UTC of the <see cref="System.DateTimeOffset"/>.</summary>
    public TimeSpan Offset => DateTimeOffset.Offset;

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

    /// <summary>Compares the <see cref="DateTimeEpoch"/> <see langword="this"/> and <paramref name="other"/>, resulting in:
    /// <list type="bullet">
    /// <item><term>+1</term><description> <see langword="this"/> <see cref="DateTimeEpoch"/> represents a later epoch than the <paramref name="other"/> <see cref="DateTimeEpoch"/>, or the <paramref name="other"/> <see cref="DateTimeEpoch"/> is <see langword="null"/>.</description></item>
    /// <item><term>0</term><description> the two <see cref="DateTimeEpoch"/> <see langword="this"/> and <paramref name="other"/> represent the same epoch.</description></item>
    /// <item><term>-1</term><description> <see langword="this"/> <see cref="DateTimeEpoch"/> represents an earlier epoch than the <paramref name="other"/> <see cref="DateTimeEpoch"/>.</description></item>
    /// </list></summary>
    /// <param name="other">The <see cref="DateTimeEpoch"/> to which <see langword="this"/> <see cref="DateTimeEpoch"/> is compared.</param>
    /// <remarks>The behaviour is consistent with <see cref="DateTimeOffset.CompareTo(DateTimeOffset)"/>.</remarks>
    public int CompareTo(DateTimeEpoch? other)
    {
        if (other is null)
        {
            return 1;
        }

        return DateTimeOffset.CompareTo(other.DateTimeOffset);
    }

    /// <summary>Compares the <see cref="IEpoch"/> <see langword="this"/> and <paramref name="other"/>, resulting in:
    /// <list type="bullet">
    /// <item><term>+1</term><description> <see langword="this"/> <see cref="DateTimeEpoch"/> represents a later epoch than the <paramref name="other"/> <see cref="IEpoch"/>, or the <paramref name="other"/> <see cref="IEpoch"/> is <see langword="null"/>.</description></item>
    /// <item><term>0</term><description> the two <see cref="IEpoch"/> <see langword="this"/> and <paramref name="other"/> represent the same epoch.</description></item>
    /// <item><term>-1</term><description> <see langword="this"/> <see cref="DateTimeEpoch"/> represents an earlier epoch than the <paramref name="other"/> <see cref="IEpoch"/>.</description></item>
    /// </list></summary>
    /// <param name="other">The <see cref="IEpoch"/> to which <see langword="this"/> <see cref="DateTimeEpoch"/> is compared.</param>
    /// <exception cref="ArgumentException"/>
    public int CompareTo(IEpoch? other)
    {
        if (other is null)
        {
            return 1;
        }

        return ToJulianDay().CompareTo(other);
    }

    /// <summary>Retrieves a <see cref="string"/>-representation of the <see cref="DateTimeOffset"/> represented by the <see cref="DateTimeEpoch"/>, formatted according to the <see cref="CultureInfo.CurrentCulture"/>.</summary>
    /// <remarks>The behaviour is consistent with <see cref="DateTimeOffset.ToString()"/>.</remarks>
    public override string ToString() => DateTimeOffset.ToString(CultureInfo.CurrentCulture);

    /// <summary>Retrieves a <see cref="string"/>-representation of the <see cref="DateTimeOffset"/> represented by the <see cref="DateTimeEpoch"/>, formatted according to <paramref name="provider"/>.</summary>
    /// <param name="provider">Provides culture-specific formatting information.</param>
    /// <remarks>The behaviour is consistent with <see cref="DateTimeOffset.ToString(IFormatProvider)"/>.</remarks>
    public string ToString(IFormatProvider? provider) => DateTimeOffset.ToString(provider);

    /// <summary>Retrieves a <see cref="string"/>-representation of the <see cref="DateTimeOffset"/> represented by the <see cref="DateTimeEpoch"/>, formatted according to <paramref name="format"/> and the <see cref="CultureInfo.CurrentCulture"/>.</summary>
    /// <param name="format">Provides formatting information.</param>
    /// <remarks>The behaviour is consistent with <see cref="DateTimeOffset.ToString(string)"/>.</remarks>
    public string ToString(string? format) => DateTimeOffset.ToString(format, CultureInfo.CurrentCulture);

    /// <summary>Retrieves a <see cref="string"/>-representation of the <see cref="DateTimeOffset"/> represented by the <see cref="DateTimeEpoch"/>, formatted according to <paramref name="format"/> and <paramref name="provider"/>.</summary>
    /// <param name="format">Provides formatting information.</param>
    /// <param name="provider">Provides culture-specific formatting information.</param>
    /// <remarks>The behaviour is consistent with <see cref="DateTimeOffset.ToString(string, IFormatProvider)"/>.</remarks>
    public string ToString(string? format, IFormatProvider? provider) => DateTimeOffset.ToString(format, provider);

    /// <summary>Retrieves a <see cref="string"/>-representation of the <see cref="DateTimeOffset"/> represented by the <see cref="DateTimeEpoch"/>, formatted according to the <see cref="CultureInfo.InvariantCulture"/>.</summary>
    /// <remarks>The behaviour is consistent with <see cref="DateTimeOffset.ToString(IFormatProvider)"/>, with the <see cref="CultureInfo.InvariantCulture"/> as the <see cref="IFormatProvider"/>.</remarks>
    public string ToStringInvariant() => DateTimeOffset.ToString(CultureInfo.InvariantCulture);

    /// <summary>Retrieves a <see cref="string"/>-representation of the <see cref="DateTimeOffset"/> represented by the <see cref="DateTimeEpoch"/>, formatted according to <paramref name="format"/> and the <see cref="CultureInfo.InvariantCulture"/>.</summary>
    /// <param name="format">Provides formatting information.</param>
    /// <remarks>The behaviour is consistent with <see cref="DateTimeOffset.ToString(string, IFormatProvider)"/>, with the <see cref="CultureInfo.InvariantCulture"/> as the <see cref="IFormatProvider"/>.</remarks>
    public string ToStringInvariant(string? format) => DateTimeOffset.ToString(format, CultureInfo.InvariantCulture);

    /// <summary>Computes the <see cref="Time"/> difference { <see langword="this"/> - <paramref name="initial"/> }. The resulting <see cref="Time"/> is positive if <see langword="this"/> <see cref="DateTimeEpoch"/> represents a later epoch than the <paramref name="initial"/> <see cref="IEpoch"/>.</summary>
    /// <param name="initial">The <see cref="IEpoch"/> representing the initial epoch.</param>
    /// <exception cref="ArgumentException"/>
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

    /// <summary>Computes the <see cref="DateTimeEpoch"/> representing { <see langword="this"/> - <paramref name="difference"/> }.</summary>
    /// <param name="difference">The <see cref="Time"/> between <see langword="this"/> <see cref="DateTimeEpoch"/> and the resulting <see cref="DateTimeEpoch"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="EpochOutOfBoundsException"/>
    public DateTimeEpoch Subtract(Time difference)
    {
        SharpMeasuresValidation.Validate(difference);

        try
        {
            return new(DateTimeOffset.AddDays(-difference.Days));
        }
        catch (ArgumentOutOfRangeException e)
        {
            throw EpochOutOfBoundsException.FromAddition<DateTimeEpoch>(difference, e);
        }
    }

    /// <summary>Computes the <see cref="Time"/> difference { <paramref name="final"/> - <paramref name="initial"/> }. The resulting <see cref="Time"/> is positive if the <paramref name="final"/> <see cref="DateTimeEpoch"/> represents a later epoch than the <paramref name="initial"/> <see cref="DateTimeEpoch"/>.</summary>
    /// <param name="final">The <see cref="DateTimeEpoch"/> representing the final epoch.</param>
    /// <param name="initial">The <see cref="DateTimeEpoch"/> representing the initial epoch.</param>
    /// <exception cref="ArgumentNullException"/>
    public static Time operator -(DateTimeEpoch final, DateTimeEpoch initial)
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

        return initial.Subtract(difference);
    }

    /// <summary>Determines the truthfulness of { <paramref name="lhs"/> &lt; <paramref name="rhs"/> }, resulting in:
    /// <list type="bullet">
    /// <item><term><see langword="true"/></term><description> the <see cref="DateTimeEpoch"/> <paramref name="lhs"/> represents an earlier epoch than the <see cref="DateTimeEpoch"/> <paramref name="rhs"/>.</description></item>
    /// <item><term><see langword="false"/></term><description> the <see cref="DateTimeEpoch"/> <paramref name="lhs"/> represents the same or a later epoch than the <see cref="DateTimeEpoch"/> <paramref name="rhs"/>, or either <see cref="DateTimeEpoch"/> is <see langword="null"/>.</description></item>
    /// </list>
    /// </summary>
    /// <param name="lhs">This <see cref="DateTimeEpoch"/> is assumed to represent an earlier epoch than the <see cref="DateTimeEpoch"/> <paramref name="rhs"/>.</param>
    /// <param name="rhs">This <see cref="DateTimeEpoch"/> is assumed to represent the same or a later epoch than the <see cref="DateTimeEpoch"/> <paramref name="lhs"/>.</param>
    public static bool operator <(DateTimeEpoch? lhs, DateTimeEpoch? rhs) => lhs?.DateTimeOffset < rhs?.DateTimeOffset;

    /// <summary>Determines the truthfulness of { <paramref name="lhs"/> &gt; <paramref name="rhs"/> }, resulting in:
    /// <list type="bullet">
    /// <item><term><see langword="true"/></term><description> the <see cref="DateTimeEpoch"/> <paramref name="lhs"/> represents a later epoch than the <see cref="DateTimeEpoch"/> <paramref name="rhs"/>.</description></item>
    /// <item><term><see langword="false"/></term><description> the <see cref="DateTimeEpoch"/> <paramref name="lhs"/> represents the same or an earlier epoch than the <see cref="DateTimeEpoch"/> <paramref name="rhs"/>, or either <see cref="DateTimeEpoch"/> is <see langword="null"/>.</description></item>
    /// </list>
    /// </summary>
    /// <param name="lhs">This <see cref="DateTimeEpoch"/> is assumed to represent a later epoch than the <see cref="DateTimeEpoch"/> <paramref name="rhs"/>.</param>
    /// <param name="rhs">This <see cref="DateTimeEpoch"/> is assumed to represent the same or an earlier epoch than the <see cref="DateTimeEpoch"/> <paramref name="lhs"/>.</param>
    public static bool operator >(DateTimeEpoch? lhs, DateTimeEpoch? rhs) => lhs?.DateTimeOffset > rhs?.DateTimeOffset;

    /// <summary>Determines the truthfulness of { <paramref name="lhs"/> ≤ <paramref name="rhs"/> }, resulting in:
    /// <list type="bullet">
    /// <item><term><see langword="true"/></term><description> the <see cref="DateTimeEpoch"/> <paramref name="lhs"/> represents the same or an earlier epoch than the <see cref="DateTimeEpoch"/> <paramref name="rhs"/>.</description></item>
    /// <item><term><see langword="false"/></term><description> the <see cref="DateTimeEpoch"/> <paramref name="lhs"/> represents a later epoch than the <see cref="DateTimeEpoch"/> <paramref name="rhs"/>, or either <see cref="DateTimeEpoch"/> is <see langword="null"/>.</description></item>
    /// </list>
    /// </summary>
    /// <param name="lhs">This <see cref="DateTimeEpoch"/> is assumed to represent the same or an earlier epoch than the <see cref="DateTimeEpoch"/> <paramref name="rhs"/>.</param>
    /// <param name="rhs">This <see cref="DateTimeEpoch"/> is assumed to represent a later epoch than the <see cref="DateTimeEpoch"/> <paramref name="lhs"/>.</param>
    public static bool operator <=(DateTimeEpoch? lhs, DateTimeEpoch? rhs) => lhs?.DateTimeOffset <= rhs?.DateTimeOffset;

    /// <summary>Determines the truthfulness of { <paramref name="lhs"/> ≥ <paramref name="rhs"/> }, resulting in:
    /// <list type="bullet">
    /// <item><term><see langword="true"/></term><description> the <see cref="DateTimeEpoch"/> <paramref name="lhs"/> represents the same or a later epoch than the <see cref="DateTimeEpoch"/> <paramref name="rhs"/>.</description></item>
    /// <item><term><see langword="false"/></term><description> the <see cref="DateTimeEpoch"/> <paramref name="lhs"/> represents an earlier epoch than the <see cref="DateTimeEpoch"/> <paramref name="rhs"/>, or either <see cref="DateTimeEpoch"/> is <see langword="null"/>.</description></item>
    /// </list>
    /// </summary>
    /// <param name="lhs">This <see cref="DateTimeEpoch"/> is assumed to represent the same or a later epoch than the <see cref="DateTimeEpoch"/> <paramref name="rhs"/>.</param>
    /// <param name="rhs">This <see cref="DateTimeEpoch"/> is assumed to represent an earlier epoch than the <see cref="DateTimeEpoch"/> <paramref name="lhs"/>.</param>
    public static bool operator >=(DateTimeEpoch? lhs, DateTimeEpoch? rhs) => lhs?.DateTimeOffset >= rhs?.DateTimeOffset;

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
