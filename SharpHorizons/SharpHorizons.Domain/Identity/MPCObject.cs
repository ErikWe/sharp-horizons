namespace SharpHorizons.Identity;

using System.Diagnostics.CodeAnalysis;

/// <summary>Represents a non-provisional object in the MPC catalogue of minor planets.</summary>
public sealed record class MPCObject
{
    /// <summary>The <see cref="MPCSequentialNumber"/> of the object.</summary>
    public MPCSequentialNumber SequentialNumber { get; }
    /// <summary>The <see cref="MPCName"/> of the object, or <see langword="null"/> if the object was not assigned one.</summary>
    /// <remarks>If the object was not assigned a <see cref="MPCName"/>, <see cref="ProvisionalDesignation"/> is used also for non-provisional objects.</remarks>
    public MPCName? Name { get; }
    /// <summary>The <see cref="MPCProvisionalDesignation"/> that was assigned to the object. This may be <see langword="null"/> if the object was assigned a <see cref="MPCName"/>.</summary>
    public MPCProvisionalDesignation? ProvisionalDesignation { get; }

    /// <summary>Indicates whether the object is assigned a <see cref="MPCName"/>. If <see langword="false"/>, the <see cref="MPCProvisionalDesignation"/> is used instead.</summary>
    [MemberNotNullWhen(true, nameof(Name))]
    [MemberNotNullWhen(false, nameof(ProvisionalDesignation))]
    public bool IsNamed => Name is not null;

    /// <summary>Represents a non-provisional object { <paramref name="sequentialNumber"/>, <paramref name="name"/>, <paramref name="provisionalDesignation"/> } in the MPC catalogue of minor planets.</summary>
    /// <param name="sequentialNumber"><inheritdoc cref="SequentialNumber" path="/summary"/></param>
    /// <param name="name"><inheritdoc cref="Name" path="/summary"/></param>
    /// <param name="provisionalDesignation"><inheritdoc cref="ProvisionalDesignation" path="/summary"/></param>
    private MPCObject(MPCSequentialNumber sequentialNumber, MPCName? name, MPCProvisionalDesignation? provisionalDesignation)
    {
        SequentialNumber = sequentialNumber;
        Name = name;
        ProvisionalDesignation = provisionalDesignation;
    }

    /// <summary>Constructs an <see cref="MPCObject"/>, representing a non-provisional object { <paramref name="sequentialNumber"/>, <paramref name="name"/> } in the MPC catalogue of minor planets.</summary>
    /// <param name="sequentialNumber">The sequential number of the object.</param>
    /// <param name="name">The name of the object.</param>
    public static MPCObject Named(MPCSequentialNumber sequentialNumber, MPCName name) => new(sequentialNumber, name, null);

    /// <summary>Constructs an <see cref="MPCObject"/>, representing a non-provisional object { <paramref name="sequentialNumber"/>, <paramref name="name"/>, <paramref name="provisionalDesignation"/> } in the MPC catalogue of minor planets.</summary>
    /// <param name="sequentialNumber">The sequential number of the object.</param>
    /// <param name="name">The name of the object.</param>
    /// <param name="provisionalDesignation">The provisional designation of the object.</param>
    public static MPCObject Named(MPCSequentialNumber sequentialNumber, MPCName name, MPCProvisionalDesignation provisionalDesignation) => new(sequentialNumber, name, provisionalDesignation);

    /// <summary>Constructs an <see cref="MPCObject"/>, representing a non-provisional object { <paramref name="sequentialNumber"/>, <paramref name="provisionalDesignation"/> } in the MPC catalogue of minor planets.</summary>
    /// <param name="sequentialNumber">The sequential number of the object.</param>
    /// <param name="provisionalDesignation">The provisional designation of the object.</param>
    public static MPCObject Unnamed(MPCSequentialNumber sequentialNumber, MPCProvisionalDesignation provisionalDesignation) => new(sequentialNumber, null, provisionalDesignation);
}