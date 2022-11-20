namespace SharpHorizons.Identity;

using System.Diagnostics.CodeAnalysis;

/// <summary>Represents a comet in the MPC catalogue.</summary>
public sealed record class MPCComet
{
    /// <summary>The <see cref="MPCCometDesignation"/> that was assigned to the comet.</summary>
    public required MPCCometDesignation Designation { get; init; }

    /// <summary>The <see cref="MPCCometName"/> of the comet, or <see langword="null"/> if the comet is unnamed.</summary>
    public MPCCometName? Name { get; init; }

    /// <inheritdoc cref="MPCComet"/>
    public MPCComet() { }

    /// <inheritdoc cref="MPCComet"/>
    /// <param name="designation"><inheritdoc cref="Designation" path="/summary"/></param>
    [SetsRequiredMembers]
    public MPCComet(MPCCometDesignation designation)
    {
        Designation = designation;
    }

    /// <inheritdoc cref="MPCComet"/>
    /// <param name="designation"><inheritdoc cref="Designation" path="/summary"/></param>
    /// <param name="name"><inheritdoc cref="Name" path="/summary"/></param>
    [SetsRequiredMembers]
    public MPCComet(MPCCometDesignation designation, MPCCometName? name)
    {
        Designation = designation;
        Name = name;
    }
}
