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
            Validate();

            return valueField!;
        }
        init
        {
            Validate(value);

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
        Validate(provisionalDesignation);

        return provisionalDesignation.valueField!;
    }

    /// <summary>Validates that <paramref name="value"/> can be used to represent the designation of an <see cref="MPCObject"/>, and throws an <see cref="ArgumentException"/> otherwise.</summary>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="value"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    private static void Validate(string? value, [CallerArgumentExpression(nameof(value))] string? argumentExpression = null) => ArgumentException.ThrowIfNullOrEmpty(value, argumentExpression);

    /// <summary>Validates the <see cref="MPCProvisionalDesignation"/> <paramref name="designation"/>, and throws an <see cref="Exception"/> of type <typeparamref name="TException"/> if invalid.</summary>
    /// <typeparam name="TException">The type of the <see cref="Exception"/> that is thrown if <paramref name="designation"/> is invalid.</typeparam>
    /// <param name="designation">This <see cref="MPCProvisionalDesignation"/> is validated.</param>
    /// <param name="exceptionInstantiation">Handles construction of <typeparamref name="TException"/>.</param>
    private static void Validate<TException>(MPCProvisionalDesignation designation, ExceptionInstantiation<TException> exceptionInstantiation) where TException : Exception
    {
        try
        {
            Validate(designation.valueField);
        }
        catch (ArgumentException e)
        {
            throw exceptionInstantiation(e);
        }
    }

    /// <summary>Validates the <see cref="MPCProvisionalDesignation"/>, and throws an <see cref="InvalidOperationException"/> if invalid.</summary>
    /// <exception cref="InvalidOperationException"/>
    private void Validate() => Validate(this, InvalidOperationExceptionFactory.InvalidState<MPCProvisionalDesignation>);

    /// <summary>Validates the <see cref="MPCProvisionalDesignation"/> <paramref name="designation"/>, and throws an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="designation">This <see cref="MPCProvisionalDesignation"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="designation"/>.</param>
    /// <exception cref="ArgumentException"/>
    public static void Validate(MPCProvisionalDesignation designation, [CallerArgumentExpression(nameof(designation))] string? argumentExpression = null) => Validate(designation, ArgumentExceptionFactory.InvalidStateDelegate<MPCProvisionalDesignation>(argumentExpression));
}