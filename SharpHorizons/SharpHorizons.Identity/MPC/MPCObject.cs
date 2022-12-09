namespace SharpHorizons.MPC;

using System;
using System.Diagnostics.CodeAnalysis;

/// <summary>Represents a non-provisional object in the MPC catalogue of minor planets.</summary>
/// <remarks>For comets, <see cref="MPCComet"/> should be used instead.</remarks>
public sealed record class MPCObject
{
    /// <summary>The <see cref="MPCSequentialNumber"/> of the <see cref="MPCObject"/>.</summary>
    public MPCSequentialNumber SequentialNumber { get; init; }

    /// <summary>The <see cref="MPCName"/> of the <see cref="MPCObject"/>, or <see langword="null"/> if the <see cref="MPCObject"/> was not assigned one.</summary>
    /// <remarks>If the <see cref="MPCObject"/> was not assigned a <see cref="MPCName"/>, <see cref="ProvisionalDesignation"/> is used.</remarks>
    /// <exception cref="ArgumentException"/>
    public MPCName? Name
    {
        get => name;
        init
        {
            if (value is not null)
            {
                MPCName.Validate(value.Value);
            }

            name = value;
        }
    }

    /// <summary>The <see cref="MPCProvisionalDesignation"/> that was assigned to the object. This may be <see langword="null"/> if the object was assigned a <see cref="MPCName"/>.</summary>
    /// <exception cref="ArgumentException"/>
    public MPCProvisionalDesignation? ProvisionalDesignation
    {
        get => provisionalDesignation;
        init
        {
            if (value is not null)
            {
                MPCProvisionalDesignation.Validate(value.Value);
            }

            provisionalDesignation = value;
        }
    }

    /// <summary>Indicates whether the object is assigned a <see cref="MPCName"/>. If <see langword="false"/>, the <see cref="MPCProvisionalDesignation"/> is used instead.</summary>
    [MemberNotNullWhen(true, nameof(Name))]
    [MemberNotNullWhen(false, nameof(ProvisionalDesignation))]
    public bool IsNamed => Name is not null;

    /// <inheritdoc cref="MPCObject"/>
    /// <param name="sequentialNumber"><inheritdoc cref="SequentialNumber" path="/summary"/></param>
    /// <param name="name"><inheritdoc cref="Name" path="/summary"/></param>
    /// <param name="provisionalDesignation"><inheritdoc cref="ProvisionalDesignation" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    private MPCObject(MPCSequentialNumber sequentialNumber, MPCName? name, MPCProvisionalDesignation? provisionalDesignation)
    {
        if (name is not null)
        {
            MPCName.Validate(name.Value);
        }

        if (provisionalDesignation is not null)
        {
            MPCProvisionalDesignation.Validate(provisionalDesignation.Value);
        }

        SequentialNumber = sequentialNumber;
        Name = name;
        ProvisionalDesignation = provisionalDesignation;
    }

    /// <summary>Constructs an <see cref="MPCObject"/>, representing a non-provisional object { <paramref name="sequentialNumber"/>, <paramref name="name"/> } in the MPC catalogue of minor planets.</summary>
    /// <param name="sequentialNumber">The <see cref="MPCSequentialNumber"/> of the object.</param>
    /// <param name="name">The <see cref="MPCName"/> of the object.</param>
    /// <exception cref="ArgumentException"/>
    public static MPCObject Named(MPCSequentialNumber sequentialNumber, MPCName name) => new(sequentialNumber, name, null);

    /// <summary>Constructs an <see cref="MPCObject"/>, representing a non-provisional object { <paramref name="sequentialNumber"/>, <paramref name="name"/>, <paramref name="provisionalDesignation"/> } in the MPC catalogue of minor planets.</summary>
    /// <param name="sequentialNumber">The <see cref="MPCSequentialNumber"/> of the object.</param>
    /// <param name="name">The <see cref="MPCName"/> of the object.</param>
    /// <param name="provisionalDesignation">The <see cref="MPCProvisionalDesignation"/> of the object.</param>
    /// <exception cref="ArgumentException"/>
    public static MPCObject Named(MPCSequentialNumber sequentialNumber, MPCName name, MPCProvisionalDesignation provisionalDesignation) => new(sequentialNumber, name, provisionalDesignation);

    /// <summary>Constructs an <see cref="MPCObject"/>, representing a non-provisional object { <paramref name="sequentialNumber"/>, <paramref name="provisionalDesignation"/> } in the MPC catalogue of minor planets.</summary>
    /// <param name="sequentialNumber">The <see cref="MPCSequentialNumber"/> of the object.</param>
    /// <param name="provisionalDesignation">The <see cref="MPCProvisionalDesignation"/> of the object.</param>
    /// <exception cref="ArgumentException"/>
    public static MPCObject Unnamed(MPCSequentialNumber sequentialNumber, MPCProvisionalDesignation provisionalDesignation) => new(sequentialNumber, null, provisionalDesignation);

    /// <summary>Backing field for <see cref="Name"/>. Should not be used elsewhere.</summary>
    private readonly MPCName? name;
    /// <summary>Backing field for <see cref="ProvisionalDesignation"/>. Should not be used elsewhere.</summary>
    private readonly MPCProvisionalDesignation? provisionalDesignation;
}
