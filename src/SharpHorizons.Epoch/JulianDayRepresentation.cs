namespace SharpHorizons;

using System;
using System.Runtime.CompilerServices;

/// <summary>Describes the integral and fractional part of some <see cref="JulianDay"/>-related type <typeparamref name="TEpoch"/>.</summary>
/// <typeparam name="TEpoch">The type that the <see cref="JulianDayRepresentation{TEpoch}"/> describes.</typeparam>
internal readonly record struct JulianDayRepresentation<TEpoch> where TEpoch : IEpoch<TEpoch>
{
    /// <summary>The <see cref="JulianDayRepresentation{TEpoch}"/> representing the <see cref="IntegralDay"/> and <see cref="FractionalDay"/> { 0 }.</summary>
    public static JulianDayRepresentation<TEpoch> Zero { get; } = new(0);

    /// <summary>Constructs the <see cref="JulianDayRepresentation{TEpoch}"/> describing <paramref name="integralDay"/> and <paramref name="fractionalDay"/>.</summary>
    /// <param name="integralDay">The <see cref="IntegralDay"/> of the constructed <see cref="JulianDayRepresentation{TEpoch}"/>.</param>
    /// <param name="fractionalDay">The <see cref="FractionalDay"/> of the constructed <see cref="JulianDayRepresentation{TEpoch}"/>.</param>
    public static JulianDayRepresentation<TEpoch> Construct(int integralDay, float fractionalDay)
    {
        ValidateFractionalDay(fractionalDay);

        var combinedRepresentation = ComputeCombinedRepresentation(integralDay, fractionalDay);

        return new(combinedRepresentation);
    }

    /// <summary>Constructs the <see cref="JulianDayRepresentation{TEpoch}"/> approximately describing <paramref name="day"/>.</summary>
    /// <param name="day">The approximate <see cref="Day"/> of the constructed <see cref="JulianDayRepresentation{TEpoch}"/>.</param>
    public static JulianDayRepresentation<TEpoch> Construct(double day)
    {
        ValidateDay(day);

        var integralDay = ComputeIntegralDay(day);
        var fractionalDay = ComputeFractionalDay(day);

        return Construct(integralDay, fractionalDay);
    }

    /// <summary>The bit mask for accessing the <see cref="FractionalDay"/> from <see cref="IntegralAndFractionalDay"/>.</summary>
    private static long FractionalDayBitMask { get; } = ((long)1 << 32) - 1;

    /// <summary>The bit mask for accessing the <see cref="IntegralDay"/> from <see cref="IntegralAndFractionalDay"/>.</summary>
    private static long IntegralDayBitMask { get; } = ~FractionalDayBitMask;

    /// <summary>The combined <see cref="IntegralDay"/> and <see cref="FractionalDay"/>.</summary>
    private long IntegralAndFractionalDay { get; init; }

    /// <summary>The integral day described by the <see cref="JulianDayRepresentation{TEpoch}"/>.</summary>
    public int IntegralDay => (int)(IntegralAndFractionalDay >> 32);

    /// <summary>The fractional day described by the <see cref="JulianDayRepresentation{TEpoch}"/>.</summary>
    public float FractionalDay => BitConverter.UInt32BitsToSingle((uint)(IntegralAndFractionalDay & FractionalDayBitMask));

    /// <summary>The arithmetically combined <see cref="IntegralDay"/> and <see cref="FractionalDay"/>.</summary>
    public double Day => IntegralDay + (double)FractionalDay;

    /// <inheritdoc cref="JulianDayRepresentation{TEpoch}"/>
    /// <param name="integralAndFractionalDay"><inheritdoc cref="IntegralAndFractionalDay" path="/summary"/></param>
    private JulianDayRepresentation(long integralAndFractionalDay)
    {
        IntegralAndFractionalDay = integralAndFractionalDay;
    }

    /// <summary>Constructs a <see cref="JulianDayRepresentation{TEpoch}"/> based on <see langword="this"/> <see cref="JulianDayRepresentation{TEpoch}"/>, modified to represent the <paramref name="integralDay"/>.</summary>
    /// <param name="integralDay">The <see cref="IntegralDay"/> of the constructed <see cref="JulianDayRepresentation{TEpoch}"/>.</param>
    public JulianDayRepresentation<TEpoch> WithIntegralDay(int integralDay) => new((IntegralAndFractionalDay & FractionalDayBitMask) | ((long)integralDay << 32));

    /// <summary>Constructs a <see cref="JulianDayRepresentation{TEpoch}"/> based on <see langword="this"/> <see cref="JulianDayRepresentation{TEpoch}"/>, modified to represent the <paramref name="fractionalDay"/>.</summary>
    /// <param name="fractionalDay">The <see cref="FractionalDay"/> of the constructed <see cref="JulianDayRepresentation{TEpoch}"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentOutOfRangeException"/>
    public JulianDayRepresentation<TEpoch> WithFractionalDay(float fractionalDay)
    {
        ValidateFractionalDay(fractionalDay);

        return new((IntegralAndFractionalDay & IntegralDayBitMask) | BitConverter.SingleToUInt32Bits(fractionalDay));
    }

    /// <summary>Computes the <see cref="long"/> <see cref="IntegralAndFractionalDay"/>.</summary>
    /// <param name="integralDay"><inheritdoc cref="IntegralDay" path="/summary"/></param>
    /// <param name="fractionalDay"><inheritdoc cref="FractionalDay" path="/summary"/></param>
    private static long ComputeCombinedRepresentation(int integralDay, float fractionalDay) => ((long)integralDay << 32) | BitConverter.SingleToUInt32Bits(fractionalDay);

    /// <summary>Computes the <see cref="int"/> <see cref="IntegralDay"/>.</summary>
    /// <param name="day"><inheritdoc cref="Day" path="/summary"/></param>
    private static int ComputeIntegralDay(double day) => (int)Math.Floor(day);

    /// <summary>Computes the <see cref="float"/> <see cref="FractionalDay"/>.</summary>
    /// <param name="day"><inheritdoc cref="Day" path="/summary"/></param>
    private static float ComputeFractionalDay(double day)
    {
        var fractionalDay = (float)(day % 1);

        if (fractionalDay < 0)
        {
            fractionalDay += 1;
        }

        return fractionalDay;
    }

    /// <summary>Validates that the <see cref="float"/> <paramref name="fractionalDay"/> can represent the <see cref="FractionalDay"/>, throwing an <see cref="ArgumentException"/> otherwise.</summary>
    /// <param name="fractionalDay">This <see cref="float"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="fractionalDay"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentOutOfRangeException"/>
    private static void ValidateFractionalDay(float fractionalDay, [CallerArgumentExpression(nameof(fractionalDay))] string? argumentExpression = null)
    {
        if (float.IsNaN(fractionalDay))
        {
            throw new ArgumentException($"{double.NaN} cannot be used to represent the fractional day of a {typeof(TEpoch).Name}", nameof(fractionalDay));
        }

        if (float.IsInfinity(fractionalDay) || fractionalDay is < 0 or >= 1)
        {
            throw new ArgumentOutOfRangeException(argumentExpression, fractionalDay, $"A value in the range [{0}, {1}) should be used to represent the fractional day of a {typeof(TEpoch).Name}.");
        }
    }

    /// <summary>Validates that the <see cref="double"/> <paramref name="day"/> can represent the <see cref="Day"/>, throwing an <see cref="ArgumentException"/> otherwise.</summary>
    /// <param name="day">This <see cref="double"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="day"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentOutOfRangeException"/>
    private static void ValidateDay(double day, [CallerArgumentExpression(nameof(day))] string? argumentExpression = null)
    {
        if (day is double.NaN)
        {
            throw new ArgumentException($"{day} cannot be used to represent the day of a {typeof(TEpoch).Name}.", argumentExpression);
        }

        if (day is < int.MinValue or >= (int.MaxValue + 1d))
        {
            throw new ArgumentOutOfRangeException(argumentExpression, day, $"The integral part of the value used to represent the day of a {typeof(TEpoch).Name} should be in the range [{int.MinValue}, {int.MaxValue}].");
        }
    }
}
