namespace SharpHorizons;

using NodaTime;

using SharpMeasures;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

/// <summary>Represents an <see cref="IEpoch"/>, an instant in time, expressed as a Julian day - the fractional number of days since { 12:00:00 UTC, January 1st, 4713 BCE, Julian Calendar }.</summary>
public sealed record class JulianDay : IEpoch<JulianDay>
{
    /// <summary>The <see cref="JulianDay"/> representing { 12:00:00 UTC, January 1st, 4713 BCE, Julian Calendar }.</summary>
    public static JulianDay Epoch { get; } = new(0);

    /// <summary>The bit mask for retrieving the time from <see cref="IntegralAndFractionalDay"/>.</summary>
    private static long FractionalDayBitMask { get; } = ((long)1 << 32) - 1;

    /// <summary>The bit mask for retrieving the integral day from <see cref="IntegralAndFractionalDay"/>.</summary>
    private static long IntegralDayBitMask { get; } = FractionalDayBitMask ^ -1;

    /// <summary>The fractional number of days since { 12:00:00 UTC, January 1st, 4713 BCE, Julian Calendar }. A negative <see cref="double"/> signifies a <see cref="JulianDay"/> before this date.</summary>
    public double Day => IntegralDay + (double)FractionalDay;

    /// <summary>The integral number of days since { 12:00:00 UTC, January 1st, 4713 BCE, Julian Calendar }. A negative <see cref="int"/> signifies a <see cref="JulianDay"/> before this date.</summary>
    public required int IntegralDay
    {
        get => (int)(IntegralAndFractionalDay >> 32);
        init => IntegralAndFractionalDay = SetIntegralDay(IntegralAndFractionalDay, value);
    }

    /// <summary>The fraction, in the range [0, 1), that has elapsed of the current <see cref="IntegralDay"/>.</summary>
    /// <remarks>Note that each <see cref="IntegralDay"/> starts at noon - therefore, for example, { 0.75 } indicates { 06:00:00 UTC } of the "next" calendar date.</remarks>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentOutOfRangeException"/>
    public float FractionalDay
    {
        get => BitConverter.UInt32BitsToSingle((uint)(IntegralAndFractionalDay & FractionalDayBitMask));
        init
        {
            ValidateFractionalDay(value);

            IntegralAndFractionalDay = SetFractionalDay(IntegralAndFractionalDay, value);
        }
    }

    /// <summary>The integral day and time - with the integral day being described by the 32 most significant bits.</summary>
    private long IntegralAndFractionalDay { get; init; }

    Instant IEpoch.Instant => Instant.FromJulianDate(Day);

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
        ValidateDay(day);

        var integralDay = (int)Math.Floor(day);
        var fractionalDay = (float)(day % 1);

        if (fractionalDay < 0)
        {
            fractionalDay += 1;
        }

        IntegralAndFractionalDay = SetIntegralAndFractionalDay(integralDay, fractionalDay);
    }

    JulianDay IEpoch.ToJulianDay() => this;
    static JulianDay IEpoch<JulianDay>.FromJulianDay(JulianDay julianDay) => julianDay;
    IEpoch IEpoch.Add(Time difference) => Add(difference);

    /// <inheritdoc/>
    public int CompareTo(IEpoch? other)
    {
        if (other is null)
        {
            return 1;
        }

        return Day.CompareTo(other.ToJulianDay().Day);
    }

    /// <summary>Computes the <see cref="Time"/> difference { <see langword="this"/> - <paramref name="initial"/> }.</summary>
    /// <param name="initial">The <see cref="JulianDay"/> representing the initial epoch.</param>
    /// <exception cref="ArgumentNullException"/>
    public Time Difference(JulianDay initial)
    {
        ArgumentNullException.ThrowIfNull(initial);

        return (Day - initial.Day) * Time.OneDay;
    }

    /// <summary>Computes the <see cref="Time"/> difference { <see langword="this"/> - <paramref name="initial"/> }.</summary>
    /// <param name="initial">The initial <see cref="IEpoch"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    public Time Difference(IEpoch initial)
    {
        ArgumentNullException.ThrowIfNull(initial);

        return Difference(initial.ToJulianDay());
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

    /// <summary>Computes the <see cref="Time"/> difference { <paramref name="final"/> - <paramref name="initial"/>.</summary>
    /// <param name="initial">The <see cref="JulianDay"/> representing the initial epoch.</param>
    /// <param name="final">The <see cref="JulianDay"/> representing the final epoch.</param>
    /// <exception cref="ArgumentNullException"/>
    public static Time operator -(JulianDay final, JulianDay initial)
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

        return initial.Add(-difference);
    }

    /// <inheritdoc cref="JulianDay"/>
    /// <param name="day"><inheritdoc cref="Day" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="EpochOutOfBoundsException"/>
    public static explicit operator JulianDay(double day) => new(day);

    /// <summary>Retrieves the <see cref="Day"/> represented by <paramref name="julianDay"/>.</summary>
    /// <param name="julianDay">The <see cref="Day"/> represented by this <see cref="JulianDay"/> is retrieved.</param>
    /// <exception cref="ArgumentNullException"/>
    public static explicit operator double(JulianDay julianDay)
    {
        ArgumentNullException.ThrowIfNull(julianDay);

        return julianDay.Day;
    }

    /// <summary>Constructs the <see cref="long"/> describing the fractional day of the <paramref name="original"/> and the <paramref name="integralDay"/>.</summary>
    /// <param name="original">The original <see cref="long"/>.</param>
    /// <param name="integralDay">The integral day of the new <see cref="long"/>.</param>
    private static long SetIntegralDay(long original, int integralDay) => original & FractionalDayBitMask | (long)integralDay << 32;

    /// <summary>Constructs the <see cref="long"/> describing the integral day of the <paramref name="original"/> and the <paramref name="fractionalDay"/>.</summary>
    /// <param name="original">The original <see cref="long"/>.</param>
    /// <param name="fractionalDay">The fractional day of the new <see cref="long"/>.</param>
    private static long SetFractionalDay(long original, float fractionalDay) => original & IntegralDayBitMask | BitConverter.SingleToUInt32Bits(fractionalDay);

    /// <summary>Constructs the <see cref="long"/> describing <paramref name="integralDay"/> and <paramref name="fractionalDay"/>.</summary>
    /// <param name="integralDay">The integral day of the new <see cref="long"/>.</param>
    /// <param name="fractionalDay">The fractional day of the new <see cref="long"/>.</param>
    private static long SetIntegralAndFractionalDay(int integralDay, float fractionalDay) => (long)integralDay << 32 | BitConverter.SingleToUInt32Bits(fractionalDay);

    /// <summary>Validates that <paramref name="fractionalDay"/> can represent the <see cref="FractionalDay"/>, and throws an exception otherwise.</summary>
    /// <param name="fractionalDay">The possibility for this <see cref="float"/> to represent the <see cref="FractionalDay"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="fractionalDay"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentOutOfRangeException"/>
    private static void ValidateFractionalDay(float fractionalDay, [CallerArgumentExpression(nameof(fractionalDay))] string? argumentExpression = null)
    {
        if (float.IsNaN(fractionalDay))
        {
            throw new ArgumentException($"{double.NaN} cannot be used to represent the fractional day of a {nameof(JulianDay)}");
        }

        if (float.IsInfinity(fractionalDay) || fractionalDay is < 0 or >= 1)
        {
            throw new ArgumentOutOfRangeException(argumentExpression, fractionalDay, $"A value in the range [{0}, {1}) should be used to represent the fractional day of a {nameof(JulianDay)}.");
        }
    }

    /// <summary>Validates that <paramref name="day"/> can be used to represent the <see cref="Day"/>, and throws an exception otherwise.</summary>
    /// <param name="day">The possibility for this <see cref="double"/> to represent the <see cref="Day"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="day"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentOutOfRangeException"/>
    private static void ValidateDay(double day, [CallerArgumentExpression(nameof(day))] string? argumentExpression = null)
    {
        if (day is double.NaN)
        {
            throw new ArgumentException($"{day} cannot be used to represent the day of a {nameof(JulianDay)}.", argumentExpression);
        }

        if (day is < int.MinValue or >= (int.MaxValue + (long)1))
        {
            throw new ArgumentOutOfRangeException(argumentExpression, day, $"The integral part of the value used to represent the day of a {nameof(JulianDay)} should be in the range [{int.MinValue}, {int.MaxValue}].");
        }
    }
}
