namespace SharpHorizons.Query.Target;

using System;

/// <summary>An identifier describing an <see cref="ITargetSiteObject"/> associated with some <see cref="ITargetSite"/>.</summary>
internal readonly record struct TargetSiteObjectIdentifier
{
    /// <summary>The identifier, describing an <see cref="ITargetSiteObject"/> associated with some <see cref="ITargetSite"/>.</summary>
    public string Value { get; }

    /// <summary>Uses { <paramref name="value"/> } to describe an <see cref="ITargetSiteObject"/> associated with some <see cref="ITargetSite"/>.</summary>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    public TargetSiteObjectIdentifier(string value)
    {
        Value = value;
    }

    /// <summary>Retrieves the identifier represented by <see langword="this"/>.</summary>
    public override string ToString() => Value;
    /// <summary>Retrieves the identifier represented by <see langword="this"/>, formatted according to <paramref name="provider"/>.</summary>
    /// <param name="provider">Provides culture-specific formatting information.</param>
    public string ToString(IFormatProvider? provider) => Value.ToString(provider);

    /// <inheritdoc cref="TargetSiteObjectIdentifier(string)"/>
    public static implicit operator TargetSiteObjectIdentifier(string value) => new(value);

    /// <summary>Retrieves the identifier represented by <paramref name="targetSite"/>.</summary>
    /// <param name="targetSite"><inheritdoc cref="TargetSiteObjectIdentifier" path="/summary"/></param>
    public static implicit operator string(TargetSiteObjectIdentifier targetSite) => targetSite.Value;
}