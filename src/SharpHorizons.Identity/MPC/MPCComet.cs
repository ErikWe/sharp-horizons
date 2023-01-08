namespace SharpHorizons.MPC;

using System;
using System.Diagnostics.CodeAnalysis;

/// <summary>Represents a comet in the MPC catalogue.</summary>
public sealed record class MPCComet
{
    /// <summary>The <see cref="MPCCometDesignation"/> of the <see cref="MPCComet"/>.</summary>
    /// <exception cref="ArgumentException"/>
    public required MPCCometDesignation Designation
    {
        get => designation;
        init
        {
            MPCCometDesignation.Validate(value);

            designation = value;
        }
    }

    /// <summary>The <see cref="MPCCometName"/> of the <see cref="MPCComet"/>, or <see langword="null"/> if the <see cref="MPCComet"/> is unnamed.</summary>
    /// <exception cref="ArgumentException"/>
    public MPCCometName? Name
    {
        get => name;
        init
        {
            if (value is not null)
            {
                MPCCometName.Validate(value.Value);
            }

            name = value;
        }
    }

    /// <inheritdoc cref="MPCComet"/>
    public MPCComet() { }

    /// <inheritdoc cref="MPCComet"/>
    /// <param name="designation"><inheritdoc cref="Designation" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    [SetsRequiredMembers]
    public MPCComet(MPCCometDesignation designation)
    {
        MPCCometDesignation.Validate(designation);

        Designation = designation;
    }

    /// <inheritdoc cref="MPCComet"/>
    /// <param name="designation"><inheritdoc cref="Designation" path="/summary"/></param>
    /// <param name="name"><inheritdoc cref="Name" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    [SetsRequiredMembers]
    public MPCComet(MPCCometDesignation designation, MPCCometName? name)
    {
        MPCCometDesignation.Validate(designation);

        if (name is not null)
        {
            MPCCometName.Validate(name.Value);
        }

        Designation = designation;
        Name = name;
    }

    /// <summary>Backing field for <see cref="Designation"/>. Should not be used elsewhere.</summary>
    private readonly MPCCometDesignation designation;
    /// <summary>Backing field for <see cref="Name"/>. Should not be used elsewhere.</summary>
    private readonly MPCCometName? name;
}
