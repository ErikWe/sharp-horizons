namespace SharpHorizons.Query;

using SharpHorizons.Query.Arguments;

using System;

/// <summary>Describes the <see cref="string"/>-representation of a <see cref="IQueryArgumentSet"/>, used to perform a Horizons query.</summary>
public readonly record struct HorizonsQueryString
{
    /// <summary>The <see cref="string"/> composed from the query.</summary>
    public string Value { get; }

    /// <summary><inheritdoc cref="HorizonsQueryString" path="/summary"/></summary>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    /// <exception cref="ArgumentNullException"/>
    public HorizonsQueryString(string value)
    {
        ArgumentNullException.ThrowIfNull(value);

        Value = value;
    }

    /// <summary>Retrieves the identifier represented by <see langword="this"/>.</summary>
    public override string ToString() => Value;
    /// <summary>Retrieves the identifier represented by <see langword="this"/>, formatted according to <paramref name="provider"/>.</summary>
    /// <param name="provider">Provides culture-specific formatting information.</param>
    public string ToString(IFormatProvider? provider) => Value.ToString(provider);

    /// <inheritdoc cref="HorizonsQueryString(string)"/>
    /// <exception cref="ArgumentNullException"/>
    public static implicit operator HorizonsQueryString(string value) => new(value);

    /// <summary>Retrieves the <see cref="string"/> represented by <paramref name="queryString"/>.</summary>
    /// <param name="queryString"><inheritdoc cref="HorizonsQueryString" path="/summary"/></param>
    public static implicit operator string(HorizonsQueryString queryString) => queryString.Value;
}
