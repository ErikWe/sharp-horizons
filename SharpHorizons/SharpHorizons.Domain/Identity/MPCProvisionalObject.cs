namespace SharpHorizons.Identity;

using System.Diagnostics.CodeAnalysis;

/// <summary>Represents a provisional object in the MPC catalogue of minor planets.</summary>
public readonly record struct MPCProvisionalObject
{
    /// <summary>The <see cref="MPCProvisionalDesignation"/> of the object.</summary>
    public required MPCProvisionalDesignation Designation { get; init; }

    /// <inheritdoc cref="MPCProvisionalObject"/>
    public MPCProvisionalObject() { }

    /// <inheritdoc cref="MPCProvisionalObject"/>
    /// <param name="designation"><inheritdoc cref="Designation" path="/summary"/></param>
    [SetsRequiredMembers]
    public MPCProvisionalObject(MPCProvisionalDesignation designation)
    {
        Designation = designation;
    }
}