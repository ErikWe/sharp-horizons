namespace SharpHorizons;

using SharpMeasures;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

/// <summary>Represents an <see cref="IEpoch"/>, an instant in time, expressed as a Julian day - the fractional number of days since { 12:00:00 UTC, January 1st, 4713 BCE, Julian Calendar }.</summary>
public sealed record class JulianDay : IEpoch<JulianDay>, IComparable<JulianDay>
{
    /// <summary>The <see cref="JulianDay"/> representing { 12:00:00 UTC, January 1st, 4713 BCE, Julian Calendar }, or the <see cref="Day"/> { 0 }.</summary>
    public static JulianDay Epoch { get; } = new(0);

    /// <summary>Describes the <see cref="IntegralDay"/> and <see cref="FractionalDay"/> of the <see cref="JulianDay"/>.</summary>
    private JulianDayRepresentation<JulianDay> Representation { get; init; } = JulianDayRepresentation<JulianDay>.Zero;

    /// <summary>The fractional number of days since { 12:00:00 UTC, January 1st, 4713 BCE, Julian Calendar }. A negative <see cref="double"/> signifies a <see cref="JulianDay"/> before this date.</summary>
    public double Day => Representation.Day;

    /// <summary>The integral number of days since { 12:00:00 UTC, January 1st, 4713 BCE, Julian Calendar }. A negative <see cref="int"/> signifies a <see cref="JulianDay"/> before this date.</summary>
    public required int IntegralDay
    {
        get => Representation.IntegralDay;
        init => Representation = Representation.WithIntegralDay(value);
    }

    /// <summary>The fraction, in the range [ 0, 1 ), that has elapsed of the current <see cref="IntegralDay"/>.</summary>
    /// <remarks>Note that each <see cref="IntegralDay"/> starts at noon - therefore, for example, { 0.75 } indicates { 06:00:00 UTC } of the "next" calendar date.</remarks>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentOutOfRangeException"/>
    public float FractionalDay
    {
        get => Representation.FractionalDay;
        init => Representation = Representation.WithFractionalDay(value);
    }

    /// <inheritdoc cref="JulianDay"/>
    public JulianDay() { }

    /// <inheritdoc cref="JulianDay"/>
    /// <param name="integralDay"><inheritdoc cref="IntegralDay" path="/summary"/></param>
    [SetsRequiredMembers]
    public JulianDay(int integralDay)
    {
        IntegralDay = integralDay;
    }

    /// <inheritdoc cref="JulianDay"/>
    /// <param name="integralDay"><inheritdoc cref="IntegralDay" path="/summary"/></param>
    /// <param name="fractionalDay"><inheritdoc cref="FractionalDay" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentOutOfRangeException"/>
    [SetsRequiredMembers]
    public JulianDay(int integralDay, float fractionalDay) : this(integralDay)
    {
        FractionalDay = fractionalDay;
    }

    /// <inheritdoc cref="JulianDay"/>
    /// <param name="day"><inheritdoc cref="Day" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentOutOfRangeException"/>
    [SetsRequiredMembers]
    public JulianDay(double day)
    {
        Representation = JulianDayRepresentation<JulianDay>.Construct(day);
    }

    JulianDay IEpoch.ToJulianDay() => this;
    static JulianDay IEpoch<JulianDay>.FromJulianDay(JulianDay julianDay)
    {
        ArgumentNullException.ThrowIfNull(julianDay);

        return julianDay;
    }

    /// <summary>Compares the <see cref="JulianDay"/> <see langword="this"/> and <paramref name="other"/>, resulting in:
    /// <list type="bullet">
    /// <item><term>+1</term><description> <see langword="this"/> <see cref="JulianDay"/> represents a later epoch than the <paramref name="other"/> <see cref="JulianDay"/>, or the <paramref name="other"/> <see cref="JulianDay"/> is <see langword="null"/>.</description></item>
    /// <item><term>0</term><description> the two <see cref="JulianDay"/> <see langword="this"/> and <paramref name="other"/> represent the same epoch.</description></item>
    /// <item><term>-1</term><description> <see langword="this"/> <see cref="JulianDay"/> represents an earlier epoch than the <paramref name="other"/> <see cref="JulianDay"/>.</description></item>
    /// </list></summary>
    /// <param name="other">The <see cref="JulianDay"/> to which <see langword="this"/> <see cref="JulianDay"/> is compared.</param>
    /// <remarks>The behaviour is consistent with <see cref="double.CompareTo(double)"/>, with the <see cref="Day"/> representing the <see cref="double"/>.</remarks>
    public int CompareTo(JulianDay? other)
    {
        if (other is null)
        {
            return 1;
        }

        return Day.CompareTo(other.Day);
    }

    /// <summary>Compares the <see cref="IEpoch"/> <see langword="this"/> and <paramref name="other"/>, resulting in:
    /// <list type="bullet">
    /// <item><term>+1</term><description> <see langword="this"/> <see cref="JulianDay"/> represents a later epoch than the <paramref name="other"/> <see cref="IEpoch"/>, or the <paramref name="other"/> <see cref="IEpoch"/> is <see langword="null"/>.</description></item>
    /// <item><term>0</term><description> the two <see cref="IEpoch"/> <see langword="this"/> and <paramref name="other"/> represent the same epoch.</description></item>
    /// <item><term>-1</term><description> <see langword="this"/> <see cref="JulianDay"/> represents an earlier epoch than the <paramref name="other"/> <see cref="IEpoch"/>.</description></item>
    /// </list></summary>
    /// <param name="other">The <see cref="IEpoch"/> to which <see langword="this"/> <see cref="JulianDay"/> is compared.</param>
    /// <exception cref="ArgumentException"/>
    public int CompareTo(IEpoch? other)
    {
        if (other is null)
        {
            return 1;
        }

        try
        {
            return Day.CompareTo(other.ToJulianDay().Day);
        }
        catch (EpochOutOfBoundsException e)
        {
            throw new ArgumentException($"As the provided {nameof(IEpoch)} could not be converted to a {nameof(JulianDay)}, the comparison could not be performed.", nameof(other), e);
        }
    }

    /// <inheritdoc/>
    public bool Equals(JulianDay? other) => Day.Equals(other?.Day);

    /// <inheritdoc/>
    public override int GetHashCode() => Day.GetHashCode();

    /// <summary>Retrieves a <see cref="string"/>-representation of the <see cref="Day"/> represented by the <see cref="JulianDay"/>, formatted according to the <see cref="CultureInfo.CurrentCulture"/>.</summary>
    /// <remarks>The behaviour is consistent with <see cref="double.ToString()"/>, with the <see cref="Day"/> representing the <see cref="double"/>.</remarks>
    public override string ToString() => Day.ToString(CultureInfo.CurrentCulture);

    /// <summary>Retrieves a <see cref="string"/>-representation of the <see cref="Day"/> represented by the <see cref="JulianDay"/>, formatted according to <paramref name="provider"/>.</summary>
    /// <param name="provider">Provides culture-specific formatting information.</param>
    /// <remarks>The behaviour is consistent with <see cref="double.ToString(IFormatProvider)"/>, with the <see cref="Day"/> representing the <see cref="double"/>.</remarks>
    public string ToString(IFormatProvider? provider) => Day.ToString(provider);

    /// <summary>Retrieves a <see cref="string"/>-representation of the <see cref="Day"/> represented by the <see cref="JulianDay"/>, formatted according to <paramref name="format"/> and the <see cref="CultureInfo.CurrentCulture"/>.</summary>
    /// <param name="format">Provides formatting information.</param>
    /// <remarks>The behaviour is consistent with <see cref="double.ToString(string)"/>, with the <see cref="Day"/> representing the <see cref="double"/>.</remarks>
    public string ToString(string? format) => Day.ToString(format, CultureInfo.CurrentCulture);

    /// <summary>Retrieves a <see cref="string"/>-representation of the <see cref="Day"/> represented by the <see cref="JulianDay"/>, formatted according to <paramref name="format"/> and <paramref name="provider"/>.</summary>
    /// <param name="format">Provides formatting information.</param>
    /// <param name="provider">Provides culture-specific formatting information.</param>
    /// <remarks>The behaviour is consistent with <see cref="double.ToString(string, IFormatProvider)"/>, with the <see cref="Day"/> representing the <see cref="double"/>.</remarks>
    public string ToString(string? format, IFormatProvider? provider) => Day.ToString(format, provider);

    /// <summary>Retrieves a <see cref="string"/>-representation of the <see cref="Day"/> represented by the <see cref="JulianDay"/>, formatted according to the <see cref="CultureInfo.InvariantCulture"/>.</summary>
    /// <remarks>The behaviour is consistent with <see cref="double.ToString(IFormatProvider)"/>, with the <see cref="Day"/> representing the <see cref="double"/> and with the <see cref="CultureInfo.InvariantCulture"/> as the <see cref="IFormatProvider"/>.</remarks>
    public string ToStringInvariant() => Day.ToString(CultureInfo.InvariantCulture);

    /// <summary>Retrieves a <see cref="string"/>-representation of the <see cref="Day"/> represented by the <see cref="JulianDay"/>, formatted according to <paramref name="format"/> and the <see cref="CultureInfo.InvariantCulture"/>.</summary>
    /// <param name="format">Provides formatting information.</param>
    /// <remarks>The behaviour is consistent with <see cref="double.ToString(string, IFormatProvider)"/>, with the <see cref="Day"/> representing the <see cref="double"/> and with the <see cref="CultureInfo.InvariantCulture"/> as the <see cref="IFormatProvider"/>.</remarks>
    public string ToStringInvariant(string? format) => Day.ToString(format, CultureInfo.InvariantCulture);

    /// <summary>Computes the <see cref="Time"/> difference { <see langword="this"/> - <paramref name="initial"/> }. The resulting <see cref="Time"/> is positive if <see langword="this"/> <see cref="JulianDay"/> represents a later epoch than the <paramref name="initial"/> <see cref="JulianDay"/>.</summary>
    /// <param name="initial">The <see cref="JulianDay"/> representing the initial epoch.</param>
    /// <exception cref="ArgumentNullException"/>
    public Time Difference(JulianDay initial)
    {
        ArgumentNullException.ThrowIfNull(initial);

        return (Day - initial.Day) * Time.OneDay;
    }

    /// <summary>Computes the <see cref="Time"/> difference { <see langword="this"/> - <paramref name="initial"/> }. The resulting <see cref="Time"/> is positive if <see langword="this"/> <see cref="JulianDay"/> represents a later epoch than the <paramref name="initial"/> <see cref="IEpoch"/>.</summary>
    /// <param name="initial">The <see cref="IEpoch"/> representing the initial epoch.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public Time Difference(IEpoch initial)
    {
        ArgumentNullException.ThrowIfNull(initial);

        try
        {
            return Difference(initial.ToJulianDay());
        }
        catch (EpochOutOfBoundsException e)
        {
            throw new ArgumentException($"As the provided {nameof(IEpoch)} could not be converted to a {nameof(JulianDay)}, the {nameof(Time)} difference could not be computed.", nameof(initial), e);
        }
    }

    /// <summary>Computes the <see cref="JulianDay"/> representing { <see langword="this"/> + <paramref name="difference"/> }.</summary>
    /// <param name="difference">The <see cref="Time"/> between <see langword="this"/> <see cref="JulianDay"/> and the resulting <see cref="JulianDay"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="EpochOutOfBoundsException"/>
    public JulianDay Add(Time difference)
    {
        SharpMeasuresValidation.Validate(difference);

        try
        {
            return new(Day + difference.Days);
        }
        catch (ArgumentOutOfRangeException e)
        {
            throw EpochOutOfBoundsException.FromAddition<JulianDay>(difference, e);
        }
    }

    /// <summary>Computes the <see cref="JulianDay"/> representing { <see langword="this"/> - <paramref name="difference"/> }.</summary>
    /// <param name="difference">The <see cref="Time"/> between <see langword="this"/> <see cref="JulianDay"/> and the resulting <see cref="JulianDay"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="EpochOutOfBoundsException"/>
    public JulianDay Subtract(Time difference)
    {
        SharpMeasuresValidation.Validate(difference);

        try
        {
            return new(Day - difference.Days);
        }
        catch (ArgumentOutOfRangeException e)
        {
            throw EpochOutOfBoundsException.FromSubtraction<JulianDay>(difference, e);
        }
    }

    /// <summary>Computes the <see cref="Time"/> difference { <paramref name="final"/> - <paramref name="initial"/> }. The resulting <see cref="Time"/> is positive if the <paramref name="final"/> <see cref="JulianDay"/> represents a later epoch than the <paramref name="initial"/> <see cref="JulianDay"/>.</summary>
    /// <param name="final">The <see cref="JulianDay"/> representing the final epoch.</param>
    /// <param name="initial">The <see cref="JulianDay"/> representing the initial epoch.</param>
    /// <exception cref="ArgumentNullException"/>
    public static Time operator -(JulianDay final, JulianDay initial)
    {
        ArgumentNullException.ThrowIfNull(final);

        return final.Difference(initial);
    }

    /// <summary>Computes the <see cref="Time"/> difference { <paramref name="final"/> - <paramref name="initial"/> }. The resulting <see cref="Time"/> is positive if the <paramref name="final"/> <see cref="JulianDay"/> represents a later epoch than the <paramref name="initial"/> <see cref="IEpoch"/>.</summary>
    /// <param name="final">The <see cref="JulianDay"/> representing the final epoch.</param>
    /// <param name="initial">The <see cref="IEpoch"/> representing the initial epoch.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public static Time operator -(JulianDay final, IEpoch initial)
    {
        ArgumentNullException.ThrowIfNull(final);

        return final.Difference(initial);
    }

    /// <summary>Computes the <see cref="JulianDay"/> representing { <paramref name="initial"/> + <paramref name="difference"/> }.</summary>
    /// <param name="initial">The <see cref="JulianDay"/> representing the initial epoch.</param>
    /// <param name="difference">The <see cref="Time"/> between the <paramref name="initial"/> <see cref="JulianDay"/> and the resulting <see cref="JulianDay"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="EpochOutOfBoundsException"/>
    public static JulianDay operator +(JulianDay initial, Time difference)
    {
        ArgumentNullException.ThrowIfNull(initial);

        return initial.Add(difference);
    }

    /// <summary>Computes the <see cref="JulianDay"/> representing { <paramref name="initial"/> - <paramref name="difference"/> }.</summary>
    /// <param name="initial">The <see cref="JulianDay"/> representing the initial epoch.</param>
    /// <param name="difference">The <see cref="Time"/> between the <paramref name="initial"/> <see cref="JulianDay"/> and the resulting <see cref="JulianDay"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="EpochOutOfBoundsException"/>
    public static JulianDay operator -(JulianDay initial, Time difference)
    {
        ArgumentNullException.ThrowIfNull(initial);

        return initial.Subtract(difference);
    }

    /// <summary>Determines the truthfulness of { <paramref name="lhs"/> &lt; <paramref name="rhs"/> }, resulting in:
    /// <list type="bullet">
    /// <item><term><see langword="true"/></term><description> the <see cref="JulianDay"/> <paramref name="lhs"/> represents an earlier epoch than the <see cref="JulianDay"/> <paramref name="rhs"/>.</description></item>
    /// <item><term><see langword="false"/></term><description> the <see cref="JulianDay"/> <paramref name="lhs"/> represents the same or a later epoch than the <see cref="JulianDay"/> <paramref name="rhs"/>, or either <see cref="JulianDay"/> is <see langword="null"/>.</description></item>
    /// </list>
    /// </summary>
    /// <param name="lhs">This <see cref="JulianDay"/> is assumed to represent an earlier epoch than the <see cref="JulianDay"/> <paramref name="rhs"/>.</param>
    /// <param name="rhs">This <see cref="JulianDay"/> is assumed to represent the same or a later epoch than the <see cref="JulianDay"/> <paramref name="lhs"/>.</param>
    /// <remarks>The behaviour is consistent with <see cref="double.operator &lt;(double, double)"/>, with with the <see cref="Day"/> representing the <see cref="double"/>.</remarks>
    public static bool operator <(JulianDay? lhs, JulianDay? rhs) => lhs?.Day < rhs?.Day;

    /// <summary>Determines the truthfulness of { <paramref name="lhs"/> &gt; <paramref name="rhs"/> }, resulting in:
    /// <list type="bullet">
    /// <item><term><see langword="true"/></term><description> the <see cref="JulianDay"/> <paramref name="lhs"/> represents a later epoch than the <see cref="JulianDay"/> <paramref name="rhs"/>.</description></item>
    /// <item><term><see langword="false"/></term><description> the <see cref="JulianDay"/> <paramref name="lhs"/> represents the same or an earlier epoch than the <see cref="JulianDay"/> <paramref name="rhs"/>, or either <see cref="JulianDay"/> is <see langword="null"/>.</description></item>
    /// </list>
    /// </summary>
    /// <param name="lhs">This <see cref="JulianDay"/> is assumed to represent a later epoch than the <see cref="JulianDay"/> <paramref name="rhs"/>.</param>
    /// <param name="rhs">This <see cref="JulianDay"/> is assumed to represent the same or an earlier epoch than the <see cref="JulianDay"/> <paramref name="lhs"/>.</param>
    /// <remarks>The behaviour is consistent with <see cref="double.operator >(double, double)"/>, with with the <see cref="Day"/> representing the <see cref="double"/>.</remarks>
    public static bool operator >(JulianDay? lhs, JulianDay? rhs) => lhs?.Day > rhs?.Day;

    /// <summary>Determines the truthfulness of { <paramref name="lhs"/> ≤ <paramref name="rhs"/> }, resulting in:
    /// <list type="bullet">
    /// <item><term><see langword="true"/></term><description> the <see cref="JulianDay"/> <paramref name="lhs"/> represents the same or an earlier epoch than the <see cref="JulianDay"/> <paramref name="rhs"/>.</description></item>
    /// <item><term><see langword="false"/></term><description> the <see cref="JulianDay"/> <paramref name="lhs"/> represents a later epoch than the <see cref="JulianDay"/> <paramref name="rhs"/>, or either <see cref="JulianDay"/> is <see langword="null"/>.</description></item>
    /// </list>
    /// </summary>
    /// <param name="lhs">This <see cref="JulianDay"/> is assumed to represent the same or an earlier epoch than the <see cref="JulianDay"/> <paramref name="rhs"/>.</param>
    /// <param name="rhs">This <see cref="JulianDay"/> is assumed to represent a later epoch than the <see cref="JulianDay"/> <paramref name="lhs"/>.</param>
    /// <remarks>The behaviour is consistent with <see cref="double.operator &lt;=(double, double)"/>, with with the <see cref="Day"/> representing the <see cref="double"/>.</remarks>
    public static bool operator <=(JulianDay? lhs, JulianDay? rhs) => lhs?.Day <= rhs?.Day;

    /// <summary>Determines the truthfulness of { <paramref name="lhs"/> ≥ <paramref name="rhs"/> }, resulting in:
    /// <list type="bullet">
    /// <item><term><see langword="true"/></term><description> the <see cref="JulianDay"/> <paramref name="lhs"/> represents the same or a later epoch than the <see cref="JulianDay"/> <paramref name="rhs"/>.</description></item>
    /// <item><term><see langword="false"/></term><description> the <see cref="JulianDay"/> <paramref name="lhs"/> represents an earlier epoch than the <see cref="JulianDay"/> <paramref name="rhs"/>, or either <see cref="JulianDay"/> is <see langword="null"/>.</description></item>
    /// </list>
    /// </summary>
    /// <param name="lhs">This <see cref="JulianDay"/> is assumed to represent the same or a later epoch than the <see cref="JulianDay"/> <paramref name="rhs"/>.</param>
    /// <param name="rhs">This <see cref="JulianDay"/> is assumed to represent an earlier epoch than the <see cref="JulianDay"/> <paramref name="lhs"/>.</param>
    /// <remarks>The behaviour is consistent with <see cref="double.operator >=(double, double)"/>, with with the <see cref="Day"/> representing the <see cref="double"/>.</remarks>
    public static bool operator >=(JulianDay? lhs, JulianDay? rhs) => lhs?.Day >= rhs?.Day;

    /// <summary>Constructs a <see cref="JulianDay"/>, representing the <see cref="double"/> <paramref name="day"/>.</summary>
    /// <param name="day"><inheritdoc cref="Day" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentOutOfRangeException"/>
    public static JulianDay FromDouble(double day) => new(day);

    /// <summary>Retrieves the <see cref="double"/> <see cref="Day"/> represented by the <see cref="JulianDay"/>.</summary>
    public double ToDouble() => Day;

    /// <inheritdoc cref="JulianDay"/>
    /// <param name="day"><inheritdoc cref="Day" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentOutOfRangeException"/>
    public static explicit operator JulianDay(double day) => FromDouble(day);

    /// <summary>Retrieves the <see cref="double"/> <see cref="Day"/> represented by the <see cref="JulianDay"/> <paramref name="julianDay"/>.</summary>
    /// <param name="julianDay">The <see cref="double"/> <see cref="Day"/> represented by this <see cref="JulianDay"/> is retrieved.</param>
    /// <exception cref="ArgumentNullException"/>
    public static explicit operator double(JulianDay julianDay)
    {
        ArgumentNullException.ThrowIfNull(julianDay);

        return julianDay.ToDouble();
    }
}
