namespace SharpHorizons.MPC;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

/// <summary>Represents the sequential number of a non-provisional object in the MPC catalogue of minor planets.</summary>
public readonly record struct MPCSequentialNumber
{
    /// <summary>The sequential number of the object in the MPC catalogue.</summary>
    public required int Value { get; init; }

    /// <inheritdoc cref="MPCSequentialNumber"/>
    public MPCSequentialNumber() { }

    /// <inheritdoc cref="MPCSequentialNumber"/>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    [SetsRequiredMembers]
    public MPCSequentialNumber(int value)
    {
        Value = value;
    }

    /// <summary>Retrieves a <see cref="string"/>-representation of the <see cref="Value"/> represented by the <see cref="MPCSequentialNumber"/>, formatted according to the <see cref="CultureInfo.CurrentCulture"/>.</summary>
    public override string ToString() => Value.ToString(CultureInfo.CurrentCulture);

    /// <summary>Retrieves a <see cref="string"/>-representation of the <see cref="Value"/> represented by the <see cref="MPCSequentialNumber"/>, formatted according to <paramref name="provider"/>.</summary>
    /// <param name="provider">Provides culture-specific formatting information.</param>
    public string ToString(IFormatProvider? provider) => Value.ToString(provider);

    /// <summary>Retrieves a <see cref="string"/>-representation of the <see cref="Value"/> represented by the <see cref="MPCSequentialNumber"/>, formatted according to <paramref name="format"/> and the <see cref="CultureInfo.CurrentCulture"/>.</summary>
    /// <param name="format">Provides formatting information.</param>
    public string ToString(string? format) => Value.ToString(format, CultureInfo.CurrentCulture);

    /// <summary>Retrieves a <see cref="string"/>-representation of the <see cref="Value"/> represented by the <see cref="MPCSequentialNumber"/>, formatted according to <paramref name="format"/> and <paramref name="provider"/>.</summary>
    /// <param name="format">Provides formatting information.</param>
    /// <param name="provider">Provides culture-specific formatting information.</param>
    public string ToString(string? format, IFormatProvider? provider) => Value.ToString(format, provider);

    /// <summary>Retrieves a <see cref="string"/>-representation of the <see cref="Value"/> represented by the <see cref="MPCSequentialNumber"/>, formatted according to the <see cref="CultureInfo.InvariantCulture"/>.</summary>
    public string ToStringInvariant() => Value.ToString(CultureInfo.InvariantCulture);

    /// <summary>Retrieves a <see cref="string"/>-representation of the <see cref="Value"/> represented by the <see cref="MPCSequentialNumber"/>, formatted according to <paramref name="format"/> and the <see cref="CultureInfo.InvariantCulture"/>.</summary>
    /// <param name="format">Provides formatting information.</param>
    public string ToStringInvariant(string? format) => Value.ToString(format, CultureInfo.InvariantCulture);

    /// <inheritdoc cref="MPCSequentialNumber"/>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    public static explicit operator MPCSequentialNumber(int value) => new(value);

    /// <summary>Retrieves the <see cref="Value"/> represented by <paramref name="sequentialNumber"/>.</summary>
    /// <param name="sequentialNumber"><inheritdoc cref="MPCName" path="/summary"/></param>
    public static implicit operator int(MPCSequentialNumber sequentialNumber) => sequentialNumber.Value;
}
