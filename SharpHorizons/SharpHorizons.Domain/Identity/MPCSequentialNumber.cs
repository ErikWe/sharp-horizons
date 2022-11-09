namespace SharpHorizons.Identity;

using System;
using System.Globalization;

/// <summary>Represents the sequential number of a non-provisional object in the MPC catalogue of minor planets.</summary>
public readonly record struct MPCSequentialNumber
{
    /// <summary>The sequential number of the object in the MPC catalogue.</summary>
    public int Value { get; }

    /// <summary>Represents the sequential number { <paramref name="value"/> } of a non-provisional object in the MPC catalogue of minor planets..</summary>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    public MPCSequentialNumber(int value)
    {
        Value = value;
    }

    /// <summary>Retrieves a <see cref="string"/>-representation of the sequential number represented by <see langword="this"/>.</summary>
    public override string ToString() => Value.ToString(CultureInfo.CurrentCulture);
    /// <summary>Retrieves a <see cref="string"/>-representation of the sequential number represented by <see langword="this"/>, formatted according to <paramref name="provider"/>.</summary>
    /// <param name="provider">Provides culture-specific formatting information.</param>
    public string ToString(IFormatProvider? provider) => Value.ToString(provider);
    /// <summary>Retrieves a <see cref="string"/>-representation of the sequential number represented by <see langword="this"/>, formatted according to <paramref name="format"/>.</summary>
    /// <param name="format">Provides formatting information.</param>
    public string ToString(string? format) => Value.ToString(format, CultureInfo.CurrentCulture);
    /// <summary>Retrieves a <see cref="string"/>-representation of the sequential number represented by <see langword="this"/>, formatted according to <paramref name="format"/> and <paramref name="provider"/>.</summary>
    /// <param name="format">Provides formatting information.</param>
    /// <param name="provider">Provides culture-specific formatting information.</param>
    public string ToString(string format, IFormatProvider? provider) => Value.ToString(format, provider);

    /// <inheritdoc cref="MPCSequentialNumber(int)"/>
    public static implicit operator MPCSequentialNumber(int value) => new(value);

    /// <summary>Retrieves the sequential number represented by <paramref name="sequentialNumber"/>.</summary>
    /// <param name="sequentialNumber"><inheritdoc cref="MPCName" path="/summary"/></param>
    public static implicit operator int(MPCSequentialNumber sequentialNumber) => sequentialNumber.Value;
}
