namespace SharpHorizons.MPC;

using System;
using System.Diagnostics.CodeAnalysis;

/// <summary>Represents a non-provisional object in the MPC catalogue of minor planets.</summary>
/// <remarks>For comets, <see cref="MPCComet"/> should be used instead.</remarks>
public sealed record class MPCObject
{
    /// <summary>The <see cref="MPCSequentialNumber"/> of the <see cref="MPCObject"/>.</summary>
    /// <exception cref="ArgumentException"/>
    public MPCSequentialNumber SequentialNumber
    {
        get => sequentialNumberField;
        init
        {
            MPCSequentialNumber.Validate(value);

            sequentialNumberField = value;
        }
    }

    /// <summary>The <see cref="MPCName"/> of the <see cref="MPCObject"/>, or <see langword="null"/> if the <see cref="MPCObject"/> was not assigned one.</summary>
    /// <remarks>If the <see cref="MPCObject"/> was not assigned a <see cref="MPCName"/>, <see cref="ProvisionalDesignation"/> is used.</remarks>
    /// <exception cref="ArgumentException"/>
    public MPCName? Name
    {
        get => nameField;
        init
        {
            if (value is not null)
            {
                MPCName.Validate(value.Value);
            }

            if (value is null && ProvisionalDesignation is null)
            {
                throw new ArgumentException($"The {nameof(Name)} of the {nameof(MPCObject)} cannot be set to null, as the {nameof(ProvisionalDesignation)} of the {nameof(MPCObject)} already is null.");
            }

            nameField = value;
        }
    }

    /// <summary>The <see cref="MPCProvisionalDesignation"/> that was assigned to the object. This may be <see langword="null"/> if the object was assigned a <see cref="MPCName"/>.</summary>
    /// <exception cref="ArgumentException"/>
    public MPCProvisionalDesignation? ProvisionalDesignation
    {
        get => provisionalDesignationField;
        init
        {
            if (value is not null)
            {
                MPCProvisionalDesignation.Validate(value.Value);
            }

            if (value is null && Name is null)
            {
                throw new ArgumentException($"The {nameof(ProvisionalDesignation)} of the {nameof(MPCObject)} cannot be set to null, as the {nameof(Name)} of the {nameof(MPCObject)} already is null.");
            }

            provisionalDesignationField = value;
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
    private MPCObject(MPCSequentialNumber sequentialNumber, MPCName name, MPCProvisionalDesignation provisionalDesignation)
    {
        SequentialNumber = sequentialNumber;
        Name = name;
        ProvisionalDesignation = provisionalDesignation;
    }

    /// <inheritdoc cref="MPCObject"/>
    /// <param name="sequentialNumber"><inheritdoc cref="SequentialNumber" path="/summary"/></param>
    /// <param name="name"><inheritdoc cref="Name" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    private MPCObject(MPCSequentialNumber sequentialNumber, MPCName name)
    {
        SequentialNumber = sequentialNumber;
        Name = name;
    }

    /// <inheritdoc cref="MPCObject"/>
    /// <param name="sequentialNumber"><inheritdoc cref="SequentialNumber" path="/summary"/></param>
    /// <param name="provisionalDesignation"><inheritdoc cref="ProvisionalDesignation" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    private MPCObject(MPCSequentialNumber sequentialNumber, MPCProvisionalDesignation provisionalDesignation)
    {
        SequentialNumber = sequentialNumber;
        ProvisionalDesignation = provisionalDesignation;
    }

    /// <summary>Constructs an <see cref="MPCObject"/>, representing a non-provisional object { <paramref name="sequentialNumber"/>, <paramref name="name"/> } in the MPC catalogue of minor planets.</summary>
    /// <param name="sequentialNumber">The <see cref="MPCSequentialNumber"/> of the object.</param>
    /// <param name="name">The <see cref="MPCName"/> of the object.</param>
    /// <exception cref="ArgumentException"/>
    public static MPCObject Named(MPCSequentialNumber sequentialNumber, MPCName name) => new(sequentialNumber, name);

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
    public static MPCObject Unnamed(MPCSequentialNumber sequentialNumber, MPCProvisionalDesignation provisionalDesignation) => new(sequentialNumber, provisionalDesignation);

    /// <summary>Backing field for <see cref="SequentialNumber"/>. Should not be used elsewhere.</summary>
    private readonly MPCSequentialNumber sequentialNumberField;
    /// <summary>Backing field for <see cref="Name"/>. Should not be used elsewhere.</summary>
    private readonly MPCName? nameField;
    /// <summary>Backing field for <see cref="ProvisionalDesignation"/>. Should not be used elsewhere.</summary>
    private readonly MPCProvisionalDesignation? provisionalDesignationField;
}
