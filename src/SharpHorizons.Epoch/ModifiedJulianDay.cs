namespace SharpHorizons;

using SharpMeasures;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

/// <summary>Represents an <see cref="IEpoch"/>, an instant in time, expressed as a modified Julian day - the fractional number of days since { 00:00:00 UTC, November 17th, 1858 CE, Gregorian Calendar }.</summary>
public sealed record class ModifiedJulianDay : IEpoch<ModifiedJulianDay>
{
    /// <summary>The <see cref="ModifiedJulianDay"/> representing { 00:00:00 UTC, November 17th, 1858 CE, Gregorian Calendar }, or the <see cref="Day"/> { 0 }.</summary>
    public static ModifiedJulianDay Epoch { get; } = new(0);

    /// <summary>The <see cref="JulianDay"/> equivalent to <see cref="Epoch"/>. This also represents the difference { <see cref="JulianDay"/> - <see cref="ModifiedJulianDay"/> }.</summary>
    private static JulianDay JulianDayNumberEpoch { get; } = new(2400000, 0.5f);

    /// <summary>Describes the <see cref="IntegralDay"/> and <see cref="FractionalDay"/> of the <see cref="ModifiedJulianDay"/>.</summary>
    private JulianDayRepresentation<ModifiedJulianDay> Representation { get; init; } = JulianDayRepresentation<ModifiedJulianDay>.Zero;

    /// <summary>The fractional number of days since { 00:00:00 UTC, November 17th, 1858 CE, Gregorian Calendar }. A negative <see cref="double"/> signifies a <see cref="ModifiedJulianDay"/> before this date.</summary>
    public double Day => Representation.Day;

    /// <summary>The integral number of days since { 00:00:00 UTC, November 17th, 1858 CE, Gregorian Calendar }. A negative <see cref="int"/> signifies a <see cref="ModifiedJulianDay"/> before this date.</summary>
    public required int IntegralDay
    {
        get => Representation.IntegralDay;
        init => Representation = Representation.WithIntegralDay(value);
    }

    /// <summary>The fraction, in the range [ 0, 1 ), that has elapsed of the current <see cref="IntegralDay"/>.</summary>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentOutOfRangeException"/>
    public float FractionalDay
    {
        get => Representation.FractionalDay;
        init => Representation = Representation.WithFractionalDay(value);
    }

    /// <inheritdoc cref="ModifiedJulianDay"/>
    public ModifiedJulianDay() { }

    /// <inheritdoc cref="ModifiedJulianDay"/>
    /// <param name="integralDay"><inheritdoc cref="IntegralDay" path="/summary"/></param>'
    [SetsRequiredMembers]
    public ModifiedJulianDay(int integralDay)
    {
        IntegralDay = integralDay;
    }

    /// <inheritdoc cref="ModifiedJulianDay"/>
    /// <param name="integralDay"><inheritdoc cref="IntegralDay" path="/summary"/></param>
    /// <param name="fractionalDay"><inheritdoc cref="FractionalDay" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentOutOfRangeException"/>
    [SetsRequiredMembers]
    public ModifiedJulianDay(int integralDay, float fractionalDay) : this(integralDay)
    {
        FractionalDay = fractionalDay;
    }

    /// <inheritdoc cref="ModifiedJulianDay"/>
    /// <param name="day"><inheritdoc cref="Day" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentOutOfRangeException"/>
    [SetsRequiredMembers]
    public ModifiedJulianDay(double day)
    {
        Representation = JulianDayRepresentation<ModifiedJulianDay>.Construct(day);
    }

    /// <summary>Converts the <see cref="ModifiedJulianDay"/> to an instance of <see cref="JulianDay"/> representing the same epoch.</summary>
    /// <exception cref="EpochOutOfBoundsException"/>
    public JulianDay ToJulianDay()
    {
        int integralDay;

        checked
        {
            try
            {
                integralDay = IntegralDay + JulianDayNumberEpoch.IntegralDay;
            }
            catch (OverflowException e)
            {
                throw EpochOutOfBoundsException.ToJulianDay<ModifiedJulianDay>(e);
            }
        }

        var fractionalDay = FractionalDay + JulianDayNumberEpoch.FractionalDay;

        if (fractionalDay >= 1)
        {
            integralDay += 1;
            fractionalDay -= 1;
        }

        return new(integralDay, fractionalDay);
    }

    /// <summary>Constructs an instance of <see cref="ModifiedJulianDay"/>, representing the same epoch as <paramref name="julianDay"/>.</summary>
    /// <param name="julianDay">The constructed <see cref="ModifiedJulianDay"/> represents the same epoch as this <see cref="JulianDay"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="ArgumentOutOfRangeException"/>
    public static ModifiedJulianDay FromJulianDay(JulianDay julianDay)
    {
        ArgumentNullException.ThrowIfNull(julianDay);

        int integralDay;

        checked
        {
            try
            {
                integralDay = julianDay.IntegralDay - JulianDayNumberEpoch.IntegralDay;
            }
            catch (OverflowException e)
            {
                throw new ArgumentOutOfRangeException($"The {nameof(JulianDay)} {julianDay.Day} could not be represented as a {nameof(ModifiedJulianDay)}.", e);
            }
        }

        var fractionalDay = julianDay.FractionalDay - JulianDayNumberEpoch.FractionalDay;

        if (fractionalDay < 0)
        {
            integralDay -= 1;
            fractionalDay += 1;
        }

        return new(integralDay, fractionalDay);
    }

    /// <summary>Compares the <see cref="ModifiedJulianDay"/> <see langword="this"/> and <paramref name="other"/>, resulting in:
    /// <list type="bullet">
    /// <item><term>+1</term><description> <see langword="this"/> <see cref="ModifiedJulianDay"/> represents a later epoch than the <paramref name="other"/> <see cref="ModifiedJulianDay"/>, or the <paramref name="other"/> <see cref="ModifiedJulianDay"/> is <see langword="null"/>.</description></item>
    /// <item><term>0</term><description> the two <see cref="ModifiedJulianDay"/> <see langword="this"/> and <paramref name="other"/> represent the same epoch.</description></item>
    /// <item><term>-1</term><description> <see langword="this"/> <see cref="ModifiedJulianDay"/> represents an earlier epoch than the <paramref name="other"/> <see cref="ModifiedJulianDay"/>.</description></item>
    /// </list></summary>
    /// <param name="other">The <see cref="ModifiedJulianDay"/> to which <see langword="this"/> <see cref="ModifiedJulianDay"/> is compared.</param>
    /// <remarks>The behaviour is consistent with <see cref="double.CompareTo(double)"/>, with the <see cref="Day"/> representing the <see cref="double"/>.</remarks>
    public int CompareTo(ModifiedJulianDay? other)
    {
        if (other is null)
        {
            return 1;
        }

        return Day.CompareTo(other.Day);
    }

    /// <summary>Compares the <see cref="IEpoch"/> <see langword="this"/> and <paramref name="other"/>, resulting in:
    /// <list type="bullet">
    /// <item><term>+1</term><description> <see langword="this"/> <see cref="ModifiedJulianDay"/> represents a later epoch than the <paramref name="other"/> <see cref="IEpoch"/>, or the <paramref name="other"/> <see cref="IEpoch"/> is <see langword="null"/>.</description></item>
    /// <item><term>0</term><description> the two <see cref="IEpoch"/> <see langword="this"/> and <paramref name="other"/> represent the same epoch.</description></item>
    /// <item><term>-1</term><description> <see langword="this"/> <see cref="ModifiedJulianDay"/> represents an earlier epoch than the <paramref name="other"/> <see cref="IEpoch"/>.</description></item>
    /// </list></summary>
    /// <param name="other">The <see cref="IEpoch"/> to which <see langword="this"/> <see cref="ModifiedJulianDay"/> is compared.</param>
    /// <exception cref="ArgumentException"/>
    public int CompareTo(IEpoch? other)
    {
        if (other is null)
        {
            return 1;
        }

        if (other is ModifiedJulianDay otherModifiedJulianDay)
        {
            return CompareTo(otherModifiedJulianDay);
        }

        try
        {
            return Day.CompareTo(other.ToJulianDay().Day - JulianDayNumberEpoch.Day);
        }
        catch (EpochOutOfBoundsException e)
        {
            throw ArgumentExceptionFactory.InternalException<IEpoch>(nameof(other), e);
        }
    }

    /// <summary>Retrieves a <see cref="string"/>-representation of the <see cref="Day"/> represented by the <see cref="ModifiedJulianDay"/>, formatted according to the <see cref="CultureInfo.CurrentCulture"/>.</summary>
    /// <remarks>The behaviour is consistent with <see cref="double.ToString()"/>, with the <see cref="Day"/> representing the <see cref="double"/>.</remarks>
    public override string ToString() => Day.ToString(CultureInfo.CurrentCulture);

    /// <summary>Retrieves a <see cref="string"/>-representation of the <see cref="Day"/> represented by the <see cref="ModifiedJulianDay"/>, formatted according to <paramref name="provider"/>.</summary>
    /// <param name="provider">Provides culture-specific formatting information.</param>
    /// <remarks>The behaviour is consistent with <see cref="double.ToString(IFormatProvider)"/>, with the <see cref="Day"/> representing the <see cref="double"/>.</remarks>
    public string ToString(IFormatProvider? provider) => Day.ToString(provider);

    /// <summary>Retrieves a <see cref="string"/>-representation of the <see cref="Day"/> represented by the <see cref="ModifiedJulianDay"/>, formatted according to <paramref name="format"/> and the <see cref="CultureInfo.CurrentCulture"/>.</summary>
    /// <param name="format">Provides formatting information.</param>
    /// <remarks>The behaviour is consistent with <see cref="double.ToString(string)"/>, with the <see cref="Day"/> representing the <see cref="double"/>.</remarks>
    public string ToString(string? format) => Day.ToString(format, CultureInfo.CurrentCulture);

    /// <summary>Retrieves a <see cref="string"/>-representation of the <see cref="Day"/> represented by the <see cref="ModifiedJulianDay"/>, formatted according to <paramref name="format"/> and <paramref name="provider"/>.</summary>
    /// <param name="format">Provides formatting information.</param>
    /// <param name="provider">Provides culture-specific formatting information.</param>
    /// <remarks>The behaviour is consistent with <see cref="double.ToString(string, IFormatProvider)"/>, with the <see cref="Day"/> representing the <see cref="double"/>.</remarks>
    public string ToString(string? format, IFormatProvider? provider) => Day.ToString(format, provider);

    /// <summary>Retrieves a <see cref="string"/>-representation of the <see cref="Day"/> represented by the <see cref="ModifiedJulianDay"/>, formatted according to the <see cref="CultureInfo.InvariantCulture"/>.</summary>
    /// <remarks>The behaviour is consistent with <see cref="double.ToString(IFormatProvider)"/>, with the <see cref="Day"/> representing the <see cref="double"/> and with the <see cref="CultureInfo.InvariantCulture"/> as the <see cref="IFormatProvider"/>.</remarks>
    public string ToStringInvariant() => Day.ToString(CultureInfo.InvariantCulture);

    /// <summary>Retrieves a <see cref="string"/>-representation of the <see cref="Day"/> represented by the <see cref="ModifiedJulianDay"/>, formatted according to <paramref name="format"/> and the <see cref="CultureInfo.InvariantCulture"/>.</summary>
    /// <param name="format">Provides formatting information.</param>
    /// <remarks>The behaviour is consistent with <see cref="double.ToString(string, IFormatProvider)"/>, with the <see cref="Day"/> representing the <see cref="double"/> and with the <see cref="CultureInfo.InvariantCulture"/> as the <see cref="IFormatProvider"/>.</remarks>
    public string ToStringInvariant(string? format) => Day.ToString(format, CultureInfo.InvariantCulture);

    /// <summary>Retrieves the <see cref="double"/> <see cref="Day"/> represented by the <see cref="ModifiedJulianDay"/>.</summary>
    public double ToDouble() => Day;

    /// <summary>Computes the <see cref="Time"/> difference { <see langword="this"/> - <paramref name="initial"/> }. The resulting <see cref="Time"/> is positive if <see langword="this"/> <see cref="ModifiedJulianDay"/> represents a later epoch than the <paramref name="initial"/> <see cref="ModifiedJulianDay"/>.</summary>
    /// <param name="initial">The <see cref="ModifiedJulianDay"/> representing the initial epoch.</param>
    /// <exception cref="ArgumentNullException"/>
    public Time Difference(ModifiedJulianDay initial)
    {
        ArgumentNullException.ThrowIfNull(initial);

        return (Day - initial.Day) * Time.OneDay;
    }

    /// <summary>Computes the <see cref="Time"/> difference { <see langword="this"/> - <paramref name="initial"/> }. The resulting <see cref="Time"/> is positive if <see langword="this"/> <see cref="ModifiedJulianDay"/> represents a later epoch than the <paramref name="initial"/> <see cref="IEpoch"/>.</summary>
    /// <param name="initial">The <see cref="IEpoch"/> representing the initial epoch.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public Time Difference(IEpoch initial)
    {
        ArgumentNullException.ThrowIfNull(initial);

        if (initial is ModifiedJulianDay initialModifiedJulianDay)
        {
            return Difference(initialModifiedJulianDay);
        }

        try
        {
            return (Day - (initial.ToJulianDay().Day - JulianDayNumberEpoch.Day)) * Time.OneDay;
        }
        catch (EpochOutOfBoundsException e)
        {
            throw ArgumentExceptionFactory.InternalException<ModifiedJulianDay>(nameof(initial), e);
        }
    }

    /// <summary>Computes the <see cref="ModifiedJulianDay"/> representing { <see langword="this"/> + <paramref name="difference"/> }.</summary>
    /// <param name="difference">The <see cref="Time"/> between <see langword="this"/> <see cref="ModifiedJulianDay"/> and the resulting <see cref="ModifiedJulianDay"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="EpochOutOfBoundsException"/>
    public ModifiedJulianDay Add(Time difference)
    {
        SharpMeasuresValidation.Validate(difference);

        try
        {
            return new(Day + difference.Days);
        }
        catch (ArgumentOutOfRangeException e)
        {
            throw EpochOutOfBoundsException.FromAddition<ModifiedJulianDay>(difference, e);
        }
    }

    /// <summary>Computes the <see cref="ModifiedJulianDay"/> representing { <see langword="this"/> - <paramref name="difference"/> }.</summary>
    /// <param name="difference">The <see cref="Time"/> between <see langword="this"/> <see cref="ModifiedJulianDay"/> and the resulting <see cref="ModifiedJulianDay"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="EpochOutOfBoundsException"/>
    public ModifiedJulianDay Subtract(Time difference)
    {
        SharpMeasuresValidation.Validate(difference);

        try
        {
            return new(Day - difference.Days);
        }
        catch (ArgumentOutOfRangeException e)
        {
            throw EpochOutOfBoundsException.FromSubtraction<ModifiedJulianDay>(difference, e);
        }
    }

    /// <summary>Computes the <see cref="Time"/> difference { <paramref name="final"/> - <paramref name="initial"/> }. The resulting <see cref="Time"/> is positive if the <paramref name="final"/> <see cref="ModifiedJulianDay"/> represents a later epoch than the <paramref name="initial"/> <see cref="ModifiedJulianDay"/>.</summary>
    /// <param name="final">The <see cref="ModifiedJulianDay"/> representing the final epoch.</param>
    /// <param name="initial">The <see cref="ModifiedJulianDay"/> representing the initial epoch.</param>
    /// <exception cref="ArgumentNullException"/>
    public static Time operator -(ModifiedJulianDay final, ModifiedJulianDay initial)
    {
        ArgumentNullException.ThrowIfNull(final);

        return final.Difference(initial);
    }

    /// <summary>Computes the <see cref="ModifiedJulianDay"/> representing { <paramref name="initial"/> + <paramref name="difference"/> }.</summary>
    /// <param name="initial">The <see cref="ModifiedJulianDay"/> representing the initial epoch.</param>
    /// <param name="difference">The <see cref="Time"/> between the <paramref name="initial"/> <see cref="ModifiedJulianDay"/> and the resulting <see cref="ModifiedJulianDay"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="EpochOutOfBoundsException"/>
    public static ModifiedJulianDay operator +(ModifiedJulianDay initial, Time difference)
    {
        ArgumentNullException.ThrowIfNull(initial);

        return initial.Add(difference);
    }

    /// <summary>Computes the <see cref="ModifiedJulianDay"/> representing { <paramref name="initial"/> - <paramref name="difference"/> }.</summary>
    /// <param name="initial">The <see cref="ModifiedJulianDay"/> representing the initial epoch.</param>
    /// <param name="difference">The <see cref="Time"/> between the <paramref name="initial"/> <see cref="ModifiedJulianDay"/> and the resulting <see cref="ModifiedJulianDay"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="EpochOutOfBoundsException"/>
    public static ModifiedJulianDay operator -(ModifiedJulianDay initial, Time difference)
    {
        ArgumentNullException.ThrowIfNull(initial);

        return initial.Subtract(difference);
    }

    /// <summary>Determines the truthfulness of { <paramref name="lhs"/> &lt; <paramref name="rhs"/> }, resulting in:
    /// <list type="bullet">
    /// <item><term><see langword="true"/></term><description> if the <see cref="ModifiedJulianDay"/> <paramref name="lhs"/> represents an earlier epoch than the <see cref="ModifiedJulianDay"/> <paramref name="rhs"/>.</description></item>
    /// <item><term><see langword="false"/></term><description> if the <see cref="ModifiedJulianDay"/> <paramref name="lhs"/> represents the same or a later epoch than the <see cref="ModifiedJulianDay"/> <paramref name="rhs"/>, or either <see cref="ModifiedJulianDay"/> is <see langword="null"/>.</description></item>
    /// </list>
    /// </summary>
    /// <param name="lhs">This <see cref="ModifiedJulianDay"/> is assumed to represent an earlier epoch than the <see cref="ModifiedJulianDay"/> <paramref name="rhs"/>.</param>
    /// <param name="rhs">This <see cref="ModifiedJulianDay"/> is assumed to represent the same or a later epoch than the <see cref="ModifiedJulianDay"/> <paramref name="lhs"/>.</param>
    /// <remarks>The behaviour is consistent with <see cref="double.operator &lt;(double, double)"/>, with with the <see cref="Day"/> representing the <see cref="double"/>.</remarks>
    public static bool operator <(ModifiedJulianDay? lhs, ModifiedJulianDay? rhs) => lhs?.Day < rhs?.Day;

    /// <summary>Determines the truthfulness of { <paramref name="lhs"/> &gt; <paramref name="rhs"/> }, resulting in:
    /// <list type="bullet">
    /// <item><term><see langword="true"/></term><description> if the <see cref="ModifiedJulianDay"/> <paramref name="lhs"/> represents a later epoch than the <see cref="ModifiedJulianDay"/> <paramref name="rhs"/>.</description></item>
    /// <item><term><see langword="false"/></term><description> if the <see cref="ModifiedJulianDay"/> <paramref name="lhs"/> represents the same or an earlier epoch than the <see cref="ModifiedJulianDay"/> <paramref name="rhs"/>, or either <see cref="ModifiedJulianDay"/> is <see langword="null"/>.</description></item>
    /// </list>
    /// </summary>
    /// <param name="lhs">This <see cref="ModifiedJulianDay"/> is assumed to represent a later epoch than the <see cref="ModifiedJulianDay"/> <paramref name="rhs"/>.</param>
    /// <param name="rhs">This <see cref="ModifiedJulianDay"/> is assumed to represent the same or an earlier epoch than the <see cref="ModifiedJulianDay"/> <paramref name="lhs"/>.</param>
    /// <remarks>The behaviour is consistent with <see cref="double.operator >(double, double)"/>, with with the <see cref="Day"/> representing the <see cref="double"/>.</remarks>
    public static bool operator >(ModifiedJulianDay? lhs, ModifiedJulianDay? rhs) => lhs?.Day > rhs?.Day;

    /// <summary>Determines the truthfulness of { <paramref name="lhs"/> ≤ <paramref name="rhs"/> }, resulting in:
    /// <list type="bullet">
    /// <item><term><see langword="true"/></term><description> if the <see cref="ModifiedJulianDay"/> <paramref name="lhs"/> represents the same or an earlier epoch than the <see cref="ModifiedJulianDay"/> <paramref name="rhs"/>.</description></item>
    /// <item><term><see langword="false"/></term><description> if the <see cref="ModifiedJulianDay"/> <paramref name="lhs"/> represents a later epoch than the <see cref="ModifiedJulianDay"/> <paramref name="rhs"/>, or either <see cref="ModifiedJulianDay"/> is <see langword="null"/>.</description></item>
    /// </list>
    /// </summary>
    /// <param name="lhs">This <see cref="ModifiedJulianDay"/> is assumed to represent the same or an earlier epoch than the <see cref="ModifiedJulianDay"/> <paramref name="rhs"/>.</param>
    /// <param name="rhs">This <see cref="ModifiedJulianDay"/> is assumed to represent a later epoch than the <see cref="ModifiedJulianDay"/> <paramref name="lhs"/>.</param>
    /// <remarks>The behaviour is consistent with <see cref="double.operator &lt;=(double, double)"/>, with with the <see cref="Day"/> representing the <see cref="double"/>.</remarks>
    public static bool operator <=(ModifiedJulianDay? lhs, ModifiedJulianDay? rhs) => lhs?.Day <= rhs?.Day;

    /// <summary>Determines the truthfulness of { <paramref name="lhs"/> ≥ <paramref name="rhs"/> }, resulting in:
    /// <list type="bullet">
    /// <item><term><see langword="true"/></term><description> if the <see cref="ModifiedJulianDay"/> <paramref name="lhs"/> represents the same or a later epoch than the <see cref="ModifiedJulianDay"/> <paramref name="rhs"/>.</description></item>
    /// <item><term><see langword="false"/></term><description> if the <see cref="ModifiedJulianDay"/> <paramref name="lhs"/> represents an earlier epoch than the <see cref="ModifiedJulianDay"/> <paramref name="rhs"/>, or either <see cref="ModifiedJulianDay"/> is <see langword="null"/>.</description></item>
    /// </list>
    /// </summary>
    /// <param name="lhs">This <see cref="ModifiedJulianDay"/> is assumed to represent the same or a later epoch than the <see cref="ModifiedJulianDay"/> <paramref name="rhs"/>.</param>
    /// <param name="rhs">This <see cref="ModifiedJulianDay"/> is assumed to represent an earlier epoch than the <see cref="ModifiedJulianDay"/> <paramref name="lhs"/>.</param>
    /// <remarks>The behaviour is consistent with <see cref="double.operator >=(double, double)"/>, with with the <see cref="Day"/> representing the <see cref="double"/>.</remarks>
    public static bool operator >=(ModifiedJulianDay? lhs, ModifiedJulianDay? rhs) => lhs?.Day >= rhs?.Day;

    /// <summary>Constructs a <see cref="ModifiedJulianDay"/>, representing the <see cref="double"/> <paramref name="day"/>.</summary>
    /// <param name="day"><inheritdoc cref="Day" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="EpochOutOfBoundsException"/>
    public static ModifiedJulianDay FromDouble(double day) => new(day);

    /// <inheritdoc cref="ModifiedJulianDay"/>
    /// <param name="day"><inheritdoc cref="Day" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="EpochOutOfBoundsException"/>
    public static explicit operator ModifiedJulianDay(double day) => FromDouble(day);

    /// <summary>Retrieves the <see cref="double"/> <see cref="Day"/> represented by <paramref name="modifiedJulianDay"/>.</summary>
    /// <param name="modifiedJulianDay">The <see cref="Day"/> represented by this <see cref="ModifiedJulianDay"/> is retrieved.</param>
    /// <exception cref="ArgumentNullException"/>
    public static explicit operator double(ModifiedJulianDay modifiedJulianDay)
    {
        ArgumentNullException.ThrowIfNull(modifiedJulianDay);

        return modifiedJulianDay.ToDouble();
    }
}
