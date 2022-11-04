namespace SharpHorizons.Query.Target;

using System;
using System.Diagnostics.CodeAnalysis;

/// <summary>An identifier describing a <see cref="ITargetSite"/> associated with some <see cref="ITargetSiteObject"/>.</summary>
public readonly record struct TargetSiteIdentifier
{
    /// <summary>The identifier.</summary>
    public string Value { get; }

    /// <summary><inheritdoc cref="TargetSiteIdentifier" path="/summary"/></summary>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    public TargetSiteIdentifier(string value)
    {
        Value = value;
    }

    /// <summary>Retrieves the identifier represented by <see langword="this"/>.</summary>
    public override string ToString() => Value;
    /// <summary>Retrieves the identifier represented by <see langword="this"/>, formatted according to <paramref name="provider"/>.</summary>
    /// <param name="provider">Provides culture-specific formatting information.</param>
    public string ToString(IFormatProvider? provider) => Value.ToString(provider);

    /// <inheritdoc cref="TargetSiteIdentifier(string)"/>
    [SuppressMessage("Usage", "CA2225", Justification = "Available through a constructor")]
    public static implicit operator TargetSiteIdentifier(string value) => new(value);

    /// <summary>Retrieves the identifier represented by <paramref name="targetSite"/>.</summary>
    /// <param name="targetSite"><inheritdoc cref="TargetSiteIdentifier" path="/summary"/></param>
    public static implicit operator string(TargetSiteIdentifier targetSite) => targetSite.Value;
}