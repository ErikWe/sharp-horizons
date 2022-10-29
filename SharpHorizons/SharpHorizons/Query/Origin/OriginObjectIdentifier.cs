namespace SharpHorizons.Query.Origin;

using System;

/// <summary>An identifier describing the <see cref="IOriginObject"/> in a query.</summary>
internal readonly record struct OriginObjectIdentifier
{
    /// <summary>The identifier.</summary>
    public string Value { get; }

    /// <summary>Uses { <paramref name="value"/> } to describe the <see cref="IOriginObject"/> in a query.</summary>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    public OriginObjectIdentifier(string value)
    {
        Value = value;
    }

    /// <summary>Retrieves the identifier represented by <see langword="this"/>.</summary>
    public override string ToString() => Value;
    /// <summary>Retrieves the identifier represented by <see langword="this"/>, formatted according to <paramref name="provider"/>.</summary>
    /// <param name="provider">Provides culture-specific formatting information.</param>
    public string ToString(IFormatProvider? provider) => Value.ToString(provider);

    /// <inheritdoc cref="OriginObjectIdentifier(string)"/>
    public static implicit operator OriginObjectIdentifier(string value) => new(value);

    /// <summary>Retrieves the identifier represented by <paramref name="originObject"/>.</summary>
    /// <param name="originObject"><inheritdoc cref="OriginObjectIdentifier" path="/summary"/></param>
    public static implicit operator string(OriginObjectIdentifier originObject) => originObject.Value;
}