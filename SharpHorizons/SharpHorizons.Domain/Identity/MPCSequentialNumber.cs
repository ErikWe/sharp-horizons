namespace SharpHorizons.Identity;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

/// <summary>Represents the sequential number of a non-provisional object in the MPC catalogue of minor planets.</summary>
public readonly record struct MPCSequentialNumber
{
    /// <summary>The sequential number of the object in the MPC catalogue.</summary>
    public required int Number { get; init; }

    /// <inheritdoc cref="MPCSequentialNumber"/>
    public MPCSequentialNumber() { }

    /// <inheritdoc cref="MPCSequentialNumber"/>
    /// <param name="number"><inheritdoc cref="Number" path="/summary"/></param>
    [SetsRequiredMembers]
    public MPCSequentialNumber(int number)
    {
        Number = number;
    }

    /// <summary>Retrieves a <see cref="string"/>-representation of the sequential number represented by <see langword="this"/>.</summary>
    public override string ToString() => Number.ToString(CultureInfo.CurrentCulture);

    /// <summary>Retrieves a <see cref="string"/>-representation of the sequential number represented by <see langword="this"/>, formatted according to <paramref name="provider"/>.</summary>
    /// <param name="provider">Provides culture-specific formatting information.</param>
    public string ToString(IFormatProvider? provider) => Number.ToString(provider);

    /// <summary>Retrieves a <see cref="string"/>-representation of the sequential number represented by <see langword="this"/>, formatted according to <paramref name="format"/>.</summary>
    /// <param name="format">Provides formatting information.</param>
    public string ToString(string? format) => Number.ToString(format, CultureInfo.CurrentCulture);

    /// <summary>Retrieves a <see cref="string"/>-representation of the sequential number represented by <see langword="this"/>, formatted according to <paramref name="format"/> and <paramref name="provider"/>.</summary>
    /// <param name="format">Provides formatting information.</param>
    /// <param name="provider">Provides culture-specific formatting information.</param>
    public string ToString(string format, IFormatProvider? provider) => Number.ToString(format, provider);

    /// <inheritdoc cref="MPCSequentialNumber"/>
    /// <param name="number"><inheritdoc cref="Number" path="/summary"/></param>
    public static implicit operator MPCSequentialNumber(int number) => new(number);

    /// <summary>Retrieves the sequential number represented by <paramref name="sequentialNumber"/>.</summary>
    /// <param name="sequentialNumber"><inheritdoc cref="MPCName" path="/summary"/></param>
    public static implicit operator int(MPCSequentialNumber sequentialNumber) => sequentialNumber.Number;
}
