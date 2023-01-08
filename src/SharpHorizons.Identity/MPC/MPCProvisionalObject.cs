namespace SharpHorizons.MPC;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

/// <summary>Represents a provisional object in the MPC catalogue of minor planets.</summary>
public readonly record struct MPCProvisionalObject
{
    /// <summary>The <see cref="MPCProvisionalDesignation"/> of the object.</summary>
    public required MPCProvisionalDesignation Designation
    {
        get => designation;
        init
        {
            MPCProvisionalDesignation.Validate(value);

            designation = value;
        }
    }

    /// <inheritdoc cref="MPCProvisionalObject"/>
    public MPCProvisionalObject() { }

    /// <inheritdoc cref="MPCProvisionalObject"/>
    /// <param name="designation"><inheritdoc cref="Designation" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    [SetsRequiredMembers]
    public MPCProvisionalObject(MPCProvisionalDesignation designation)
    {
        MPCProvisionalDesignation.Validate(designation);

        Designation = designation;
    }

    /// <summary>Backing field for <see cref="Designation"/>. Should not be used elsewhere.</summary>
    private readonly MPCProvisionalDesignation designation;

    /// <summary>Validates the <see cref="MPCProvisionalObject"/> <paramref name="mpcObject"/>, throwing an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="mpcObject">This <see cref="MPCProvisionalObject"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="mpcObject"/>.</param>
    /// <exception cref="ArgumentException"/>
    public static void Validate(MPCProvisionalObject mpcObject, [CallerArgumentExpression(nameof(mpcObject))] string? argumentExpression = null)
    {
        try
        {
            MPCProvisionalDesignation.Validate(mpcObject.Designation);
        }
        catch (ArgumentException e)
        {
            throw new ArgumentException($"The {nameof(MPCProvisionalObject)} represents an invalid {nameof(MPCProvisionalDesignation)}.", argumentExpression, e);
        }
    }
}
