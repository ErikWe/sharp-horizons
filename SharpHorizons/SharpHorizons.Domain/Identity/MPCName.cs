namespace SharpHorizons.Identity;

using System;
using System.Diagnostics.CodeAnalysis;

/// <summary>Represents the name of a non-provisional object in the MPC catalogue of minor planets.</summary>
public readonly record struct MPCName
{
    /// <summary>The name of the object in the MPC catalogue of minor planets..</summary>
    public string Value { get; }

    /// <summary>Represents the name { <paramref name="value"/> } of a non-provisional object in the MPC catalogue of minor planets.</summary>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    public MPCName(string value)
    {
        Value = value;
    }

    /// <summary>Retrieves the name represented by <see langword="this"/>.</summary>
    public override string ToString() => Value;
    /// <summary>Retrieves the name represented by <see langword="this"/>, formatted according to <paramref name="provider"/>.</summary>
    /// <param name="provider">Provides culture-specific formatting information.</param>
    public string ToString(IFormatProvider? provider) => Value.ToString(provider);

    /// <inheritdoc cref="MPCName(string)"/>
    [SuppressMessage("Usage", "CA2225", Justification = "Available through a constructor")]
    public static implicit operator MPCName(string value) => new(value);

    /// <summary>Retrieves the name represented by <paramref name="name"/>.</summary>
    /// <param name="name"><inheritdoc cref="MPCName" path="/summary"/></param>
    public static implicit operator string(MPCName name) => name.Value;
}
