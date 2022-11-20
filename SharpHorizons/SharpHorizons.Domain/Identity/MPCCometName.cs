namespace SharpHorizons.Identity;

using System;
using System.Diagnostics.CodeAnalysis;

/// <summary>Represents the name of a comet in the MPC catalogue.</summary>
public readonly record struct MPCCometName
{
    /// <summary>The name of the comet in the MPC catalogue.</summary>
    public required string Name { get; init; }

    /// <inheritdoc cref="MPCCometName"/>
    public MPCCometName() { }

    /// <inheritdoc cref="MPCCometName"/>
    /// <param name="name"><inheritdoc cref="Name" path="/summary"/></param>
    [SetsRequiredMembers]
    public MPCCometName(string name)
    {
        Name = name;
    }

    /// <summary>Retrieves the name represented by <see langword="this"/>.</summary>
    public override string ToString() => Name;

    /// <summary>Retrieves the name represented by <see langword="this"/>, formatted according to <paramref name="provider"/>.</summary>
    /// <param name="provider">Provides culture-specific formatting information.</param>
    public string ToString(IFormatProvider? provider) => Name.ToString(provider);

    /// <inheritdoc cref="MPCCometName"/>
    /// <param name="name"><inheritdoc cref="Name" path="/summary"/></param>
    public static implicit operator MPCCometName(string name) => new(name);

    /// <summary>Retrieves the name represented by <paramref name="name"/>.</summary>
    /// <param name="name"><inheritdoc cref="MPCCometName" path="/summary"/></param>
    public static implicit operator string(MPCCometName name) => name.Name;
}
