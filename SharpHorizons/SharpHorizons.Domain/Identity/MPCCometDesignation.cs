namespace SharpHorizons.Identity;

using System;
using System.Diagnostics.CodeAnalysis;

/// <summary>Represents the designation of a comet in the MPC catalogue.</summary>
public readonly record struct MPCCometDesignation
{
    /// <summary>The designation of the comet in the MPC catalogue.</summary>
    public required string Designation { get; init; }

    /// <inheritdoc cref="MPCCometDesignation"/>
    public MPCCometDesignation() { }

    /// <inheritdoc cref="MPCCometDesignation"/>
    /// <param name="designation"><inheritdoc cref="Designation" path="/summary"/></param>
    [SetsRequiredMembers]
    public MPCCometDesignation(string designation)
    {
        Designation = designation;
    }

    /// <summary>Retrieves the designation represented by <see langword="this"/>.</summary>
    public override string ToString() => Designation;

    /// <summary>Retrieves the designation represented by <see langword="this"/>, formatted according to <paramref name="provider"/>.</summary>
    /// <param name="provider">Provides culture-specific formatting information.</param>
    public string ToString(IFormatProvider? provider) => Designation.ToString(provider);

    /// <inheritdoc cref="MPCCometDesignation"/>
    /// <param name="designation"><inheritdoc cref="Designation" path="/summary"/></param>
    public static implicit operator MPCCometDesignation(string designation) => new(designation);

    /// <summary>Retrieves the designation represented by <paramref name="designation"/>.</summary>
    /// <param name="designation"><inheritdoc cref="MPCCometDesignation" path="/summary"/></param>
    public static implicit operator string(MPCCometDesignation designation) => designation.Designation;
}
