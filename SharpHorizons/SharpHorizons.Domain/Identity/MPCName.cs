namespace SharpHorizons.Identity;

using System;
using System.Diagnostics.CodeAnalysis;

/// <summary>Represents the name of a non-provisional object in the MPC catalogue of minor planets.</summary>
/// <remarks>For the <see cref="MPCName"/> of comets, use <see cref="MPCCometName"/>.</remarks>
public readonly record struct MPCName
{
    /// <summary>The name of the object in the MPC catalogue of minor planets.</summary>
    public required string Name { get; init; }

    /// <inheritdoc cref="MPCName"/>
    public MPCName() { }

    /// <inheritdoc cref="MPCName"/>
    /// <param name="name"><inheritdoc cref="Name" path="/summary"/></param>
    [SetsRequiredMembers]
    public MPCName(string name)
    {
        Name = name;
    }

    /// <summary>Retrieves the name represented by <see langword="this"/>.</summary>
    public override string ToString() => Name;

    /// <summary>Retrieves the name represented by <see langword="this"/>, formatted according to <paramref name="provider"/>.</summary>
    /// <param name="provider">Provides culture-specific formatting information.</param>
    public string ToString(IFormatProvider? provider) => Name.ToString(provider);

    /// <inheritdoc cref="MPCName"/>
    /// <param name="name"><inheritdoc cref="Name" path="/summary"/></param>
    public static implicit operator MPCName(string name) => new(name);

    /// <summary>Retrieves the name represented by <paramref name="name"/>.</summary>
    /// <param name="name"><inheritdoc cref="MPCName" path="/summary"/></param>
    public static implicit operator string(MPCName name) => name.Name;
}
