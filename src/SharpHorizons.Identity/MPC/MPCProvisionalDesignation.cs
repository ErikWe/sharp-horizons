﻿namespace SharpHorizons.MPC;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

/// <summary>Represents the <see cref="string"/> provisional designation of an object in the MPC catalogue of minor planets.</summary>
/// <remarks>The provisional designation may be used also for non-provisional objects - especially if they are not given a <see cref="MPCName"/>.</remarks>
public readonly partial record struct MPCProvisionalDesignation
{
    /// <summary>The <see cref="string"/> provisional designation of the object in the MPC catalogue of minor planets.</summary>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidOperationException"/>
    public required string Value
    {
        get
        {
            try
            {
                ArgumentExceptionUtility.ThrowIfNullOrWhiteSpace(valueField);
            }
            catch (ArgumentException e)
            {
                throw InvalidOperationExceptionFactory.InvalidState<MPCProvisionalDesignation>(e);
            }

            return valueField;
        }
        init
        {
            ArgumentExceptionUtility.ThrowIfNullOrWhiteSpace(value);

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

    /// <summary>Retrieves the <see cref="string"/> <see cref="Value"/> represented by the <see cref="MPCProvisionalDesignation"/>.</summary>
    /// <exception cref="InvalidOperationException"/>
    public override string ToString() => Value;

    /// <summary>Backing field for <see cref="Value"/>. Should not be used elsewhere.</summary>
    private readonly string? valueField;

    /// <summary>Constructs an <see cref="MPCProvisionalDesignation"/>, representing the <see cref="string"/> <paramref name="value"/>.</summary>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public static MPCProvisionalDesignation FromString(string value) => new(value);

    /// <inheritdoc cref="MPCProvisionalDesignation"/>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public static explicit operator MPCProvisionalDesignation(string value) => FromString(value);

    /// <summary>Retrieves the <see cref="string"/> <see cref="Value"/> represented by <paramref name="provisionalDesignation"/>.</summary>
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

    /// <summary>Validates the <see cref="MPCProvisionalDesignation"/> <paramref name="designation"/>, throwing an <see cref="ArgumentException"/> if invalid.</summary>
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
