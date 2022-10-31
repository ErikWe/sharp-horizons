﻿namespace SharpHorizons.Query.Target;

using System;

/// <summary>An identifier describing a <see cref="ITargetSite"/> associated with some <see cref="ITargetSiteObject"/>.</summary>
internal readonly record struct TargetSiteIdentifier
{
    /// <summary>The identifier, describing a <see cref="ITargetSite"/> associated with some <see cref="ITargetSiteObject"/>.</summary>
    public string Value { get; }

    /// <summary>Uses { <paramref name="value"/> } to describe a <see cref="ITargetSite"/> associated with some <see cref="ITargetSiteObject"/>.</summary>
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
    public static implicit operator TargetSiteIdentifier(string value) => new(value);

    /// <summary>Retrieves the identifier represented by <paramref name="targetSite"/>.</summary>
    /// <param name="targetSite"><inheritdoc cref="TargetSiteIdentifier" path="/summary"/></param>
    public static implicit operator string(TargetSiteIdentifier targetSite) => targetSite.Value;
}