namespace SharpHorizons.Identity;

using System;
using System.Diagnostics.CodeAnalysis;

/// <summary>Represents the provisional designation of an object in the MPC catalogue of minor planets.</summary>
/// <remarks>The provisional designation may be used also for non-provisional objects - especially if they are not given a <see cref="MPCName"/>.</remarks>
public readonly partial record struct MPCProvisionalDesignation
{
    /// <summary>The provisional designation of the object in the MPC catalogue of minor planets.</summary>
    public required string Designation { get; init; }

    /// <inheritdoc cref="MPCProvisionalDesignation"/>
    public MPCProvisionalDesignation() { }

    /// <inheritdoc cref="MPCProvisionalDesignation"/>
    /// <param name="designation"><inheritdoc cref="Designation" path="/summary"/></param>
    [SetsRequiredMembers]
    public MPCProvisionalDesignation(string designation)
    {
        Designation = designation;
    }

    /// <summary>Retrieves the provisional designation represented by <see langword="this"/>.</summary>
    public override string ToString() => Designation;

    /// <summary>Retrieves the provisional designation represented by <see langword="this"/>, formatted according to <paramref name="provider"/>.</summary>
    /// <param name="provider">Provides culture-specific formatting information.</param>
    public string ToString(IFormatProvider? provider) => Designation.ToString(provider);

    /// <inheritdoc cref="MPCProvisionalDesignation"/>
    /// <param name="designation"><inheritdoc cref="Designation" path="/summary"/></param>
    public static implicit operator MPCProvisionalDesignation(string designation) => new(designation);

    /// <summary>Retrieves the provisional designation represented by <paramref name="provisionalDesignation"/>.</summary>
    /// <param name="provisionalDesignation"><inheritdoc cref="MPCName" path="/summary"/></param>
    public static implicit operator string(MPCProvisionalDesignation provisionalDesignation) => provisionalDesignation.Designation;
}