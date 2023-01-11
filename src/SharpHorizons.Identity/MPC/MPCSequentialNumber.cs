namespace SharpHorizons.MPC;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;

/// <summary>Represents the <see cref="int"/> sequential number of a non-provisional object in the MPC catalogue of minor planets.</summary>
public readonly record struct MPCSequentialNumber
{
    /// <summary>The <see cref="int"/> sequential number of the object in the MPC catalogue.</summary>
    /// <exception cref="ArgumentOutOfRangeException"/>
    /// <exception cref="InvalidOperationException"/>
    public required int Value
    {
        get
        {
            try
            {
                Validate(valueField);
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw InvalidOperationExceptionFactory.InvalidState<MPCSequentialNumber>(e);
            }

            return valueField;
        }
        init
        {
            Validate(value);

            valueField = value;
        }
    }

    /// <inheritdoc cref="MPCSequentialNumber"/>
    public MPCSequentialNumber() { }

    /// <inheritdoc cref="MPCSequentialNumber"/>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    /// <exception cref="ArgumentOutOfRangeException"/>
    [SetsRequiredMembers]
    public MPCSequentialNumber(int value)
    {
        Value = value;
    }

    /// <summary>Retrieves a <see cref="string"/>-representation of the <see cref="int"/> <see cref="Value"/> represented by the <see cref="MPCSequentialNumber"/>, formatted according to the <see cref="CultureInfo.CurrentCulture"/>.</summary>
    /// <exception cref="InvalidOperationException"/>
    public override string ToString() => Value.ToString(CultureInfo.CurrentCulture);

    /// <summary>Retrieves a <see cref="string"/>-representation of the <see cref="int"/> <see cref="Value"/> represented by the <see cref="MPCSequentialNumber"/>, formatted according to <paramref name="provider"/>.</summary>
    /// <param name="provider">Provides culture-specific formatting information.</param>
    /// <exception cref="InvalidOperationException"/>
    public string ToString(IFormatProvider? provider) => Value.ToString(provider);

    /// <summary>Retrieves a <see cref="string"/>-representation of the <see cref="int"/> <see cref="Value"/> represented by the <see cref="MPCSequentialNumber"/>, formatted according to <paramref name="format"/> and the <see cref="CultureInfo.CurrentCulture"/>.</summary>
    /// <param name="format">Provides formatting information.</param>
    /// <exception cref="InvalidOperationException"/>
    public string ToString(string? format) => Value.ToString(format, CultureInfo.CurrentCulture);

    /// <summary>Retrieves a <see cref="string"/>-representation of the <see cref="int"/> <see cref="Value"/> represented by the <see cref="MPCSequentialNumber"/>, formatted according to <paramref name="format"/> and <paramref name="provider"/>.</summary>
    /// <param name="format">Provides formatting information.</param>
    /// <param name="provider">Provides culture-specific formatting information.</param>
    /// <exception cref="InvalidOperationException"/>
    public string ToString(string? format, IFormatProvider? provider) => Value.ToString(format, provider);

    /// <summary>Retrieves a <see cref="string"/>-representation of the <see cref="int"/> <see cref="Value"/> represented by the <see cref="MPCSequentialNumber"/>, formatted according to the <see cref="CultureInfo.InvariantCulture"/>.</summary>
    /// <exception cref="InvalidOperationException"/>
    public string ToStringInvariant() => Value.ToString(CultureInfo.InvariantCulture);

    /// <summary>Retrieves a <see cref="string"/>-representation of the <see cref="int"/> <see cref="Value"/> represented by the <see cref="MPCSequentialNumber"/>, formatted according to <paramref name="format"/> and the <see cref="CultureInfo.InvariantCulture"/>.</summary>
    /// <param name="format">Provides formatting information.</param>
    /// <exception cref="InvalidOperationException"/>
    public string ToStringInvariant(string? format) => Value.ToString(format, CultureInfo.InvariantCulture);

    /// <summary>Retrieves the <see cref="int"/> <see cref="Value"/> represented by the <see cref="MPCSequentialNumber"/>.</summary>
    /// <exception cref="InvalidOperationException"/>
    public int ToInt32() => Value;

    /// <summary>Backing field for <see cref="Value"/>. Should not be used elsewhere.</summary>
    private readonly int valueField;

    /// <summary>Constructs an <see cref="MPCSequentialNumber"/>, representing the <see cref="int"/> <paramref name="value"/>.</summary>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    /// <exception cref="ArgumentOutOfRangeException"/>
    public static MPCSequentialNumber FromInt32(int value) => new(value);

    /// <inheritdoc cref="MPCSequentialNumber"/>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    /// <exception cref="ArgumentOutOfRangeException"/>
    public static explicit operator MPCSequentialNumber(int value) => FromInt32(value);

    /// <summary>Retrieves the <see cref="int"/> <see cref="Value"/> represented by <paramref name="sequentialNumber"/>.</summary>
    /// <param name="sequentialNumber"><inheritdoc cref="MPCName" path="/summary"/></param>
    /// <exception cref="InvalidOperationException"/>
    public static implicit operator int(MPCSequentialNumber sequentialNumber) => sequentialNumber.ToInt32();

    /// <summary>Validates that the <see cref="string"/>-representation of <paramref name="value"/> can represent the <see cref="Value"/>, throwing an <see cref="ArgumentOutOfRangeException"/> otherwise.</summary>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="value"/>.</param>
    /// <exception cref="ArgumentOutOfRangeException"/>
    private static void Validate(int value, [CallerArgumentExpression(nameof(value))] string? argumentExpression = null)
    {
        if (value <= 0)
        {
            throw new ArgumentOutOfRangeException(argumentExpression, value, $"A value greater than 0 should be used to describe the {nameof(Value)} of an {nameof(MPCSequentialNumber)}.");
        }
    }

    /// <summary>Validates the <see cref="MPCSequentialNumber"/> <paramref name="sequentialNumber"/>, throwing an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="sequentialNumber">This <see cref="MPCSequentialNumber"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="sequentialNumber"/>.</param>
    /// <exception cref="ArgumentException"/>
    public static void Validate(MPCSequentialNumber sequentialNumber, [CallerArgumentExpression(nameof(sequentialNumber))] string? argumentExpression = null)
    {
        try
        {
            _ = sequentialNumber.Value;
        }
        catch (InvalidOperationException e)
        {
            throw ArgumentExceptionFactory.InvalidState<MPCSequentialNumber>(argumentExpression, e);
        }
    }
}
