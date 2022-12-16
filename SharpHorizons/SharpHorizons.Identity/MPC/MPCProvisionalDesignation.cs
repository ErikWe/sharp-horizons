namespace SharpHorizons.MPC;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

/// <summary>Represents the provisional designation of an object in the MPC catalogue of minor planets.</summary>
/// <remarks>The provisional designation may be used also for non-provisional objects - especially if they are not given a <see cref="MPCName"/>.</remarks>
public readonly partial record struct MPCProvisionalDesignation
{
    /// <summary>The provisional designation of the object in the MPC catalogue of minor planets.</summary>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidOperationException"/>
    public required string Value
    {
        get
        {
            try
            {
                ArgumentException.ThrowIfNullOrEmpty(valueField);
            }
            catch (ArgumentException e)
            {
                throw InvalidOperationExceptionFactory.InvalidState<MPCProvisionalDesignation>(e);
            }

            return valueField;
        }
        init
        {
            ArgumentException.ThrowIfNullOrEmpty(value);

            valueField = value;
        }
    }

    /// <inheritdoc cref="MPCProvisionalDesignation"/>
    public MPCProvisionalDesignation() { }

    /// <inheritdoc cref="MPCProvisionalDesignation"/>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    [SetsRequiredMembers]
    public MPCProvisionalDesignation(string value)
    {
        Value = value;
    }

    /// <summary>Retrieves the <see cref="Value"/> represented by the <see cref="MPCProvisionalDesignation"/>.</summary>
    /// <exception cref="InvalidOperationException"/>
    public override string ToString() => Value;

    /// <summary>Backing field for <see cref="Value"/>. Should not be used elsewhere.</summary>
    private readonly string? valueField;

    /// <inheritdoc cref="MPCProvisionalDesignation"/>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public static explicit operator MPCProvisionalDesignation(string value) => new(value);

    /// <summary>Retrieves the <see cref="Value"/> represented by <paramref name="provisionalDesignation"/>.</summary>
    /// <param name="provisionalDesignation"><inheritdoc cref="MPCName" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    public static explicit operator string(MPCProvisionalDesignation provisionalDesignation)
    {
        try
        {
            return provisionalDesignation.Value;
        }
        catch (InvalidOperationException e)
        {
            throw ArgumentExceptionFactory.InvalidState<MPCProvisionalDesignation>(nameof(provisionalDesignation), e);
        }
    }

    /// <summary>Validates the <see cref="MPCProvisionalDesignation"/> <paramref name="designation"/>, and throws an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="designation">This <see cref="MPCProvisionalDesignation"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="designation"/>.</param>
    /// <exception cref="ArgumentException"/>
    public static void Validate(MPCProvisionalDesignation designation, [CallerArgumentExpression(nameof(designation))] string? argumentExpression = null)
    {
        try
        {
            _ = designation.Value;
        }
        catch (InvalidOperationException e)
        {
            throw ArgumentExceptionFactory.InvalidState<MPCProvisionalDesignation>(argumentExpression, e);
        }
    }
}